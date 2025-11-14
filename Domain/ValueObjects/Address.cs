using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

public sealed record class Address
{
    public string Street { get; init; }
    public string City { get; init; }
    public string? State { get; init; }  // District ~ Ward ...
    public string PostalCode { get; init; }
    public string Country { get; init; }

    public Address(string street , string city , string state , string postalCode , string country)
    {
        if ( string.IsNullOrWhiteSpace(street) ) throw new ArgumentException("Street is required");
        if ( string.IsNullOrWhiteSpace(city) ) throw new ArgumentException("City is required");
        if ( string.IsNullOrWhiteSpace(country) ) throw new ArgumentException("Country is required");
        if ( !IsValidPostalCode(postalCode , country) ) throw new ArgumentException("Invalid postal code");

        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public string FullAddress => $"{Street}, {City}, {State}, {PostalCode}, {Country}";

    public bool IsInCountry(string country) => string.Equals(Country , country , StringComparison.OrdinalIgnoreCase);

    private bool IsValidPostalCode(string postalCode , string country)
    {
        // Ví dụ cơ bản, có thể dùng regex theo từng quốc gia
        if ( string.IsNullOrWhiteSpace(postalCode) ) return false;
        return postalCode.Length >= 4 && postalCode.Length <= 10;
    }

    public Address Normalize()
    {
        return this with
        {
            Street = Street.Trim() ,
            City = City.Trim() ,
            State = State?.Trim() ,
            PostalCode = PostalCode.Trim().ToUpper() ,
            Country = Country.Trim().ToUpper()
        };
    }

    public override int GetHashCode() => HashCode.Combine(Street , City , Country);

    //public override bool Equals(object? obj)
    //{
    //    if ( obj is not Address other ) return false;
    //    return Street == other.Street && City == other.City && Country == other.Country;
    //}
}

