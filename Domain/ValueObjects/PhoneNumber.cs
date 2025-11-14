using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

public record PhoneNumber
{
    public string CountryCode { get; }
    public string NationalNumber { get; }

    public PhoneNumber(string raw)
    {
        if ( string.IsNullOrWhiteSpace(raw) )
            throw new ArgumentException("Phone number required");

        var normalized = raw.Trim().Replace(" " , "").Replace("-" , "");

        // Giả sử xử lý Việt Nam cho demo
        if ( normalized.StartsWith("+84") )
        {
            CountryCode = "+84";
            NationalNumber = normalized[3..];
        }
        else if ( normalized.StartsWith("0") )
        {
            CountryCode = "+84";
            NationalNumber = normalized[1..];
        }
        else
        {
            throw new ArgumentException("Unsupported phone number format");
        }

        if ( !Regex.IsMatch(NationalNumber , @"^\d{9}$") )
            throw new ArgumentException("Phone number must be 9 digits");
    }

    public override string ToString() => $"{CountryCode}{NationalNumber}";
}

/*public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if ( string.IsNullOrWhiteSpace(value) ||
            !Regex.IsMatch(value , @"^(0|\+84)[0-9]{9}$") )
            throw new ArgumentException("Invalid Vietnamese phone number");

        Value = value.Trim();
    }

    public override string ToString() => Value;
}*/