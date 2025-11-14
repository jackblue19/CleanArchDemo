using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

/// <summary>
/// ở đây có keyword "sealed" → vì dob có vẻ như ~ unique => thêm vào để tránh loạn ko cho thừa kế ... 
/// </summary>
public sealed record DateOfBirth
{
    public DateTime Value { get; }

    public DateOfBirth(DateTime value)
    {
        if ( value > DateTime.Today )
            throw new ArgumentException("Dob cannot be in the future");

        Value = value;
    }

    public int Age => (int) ((DateTime.Today - Value).TotalDays / 365.25);

    public bool IsAtLeast(int minAge) => Age >= minAge;
    public bool IsBetween(int minAge , int maxAge) => Age >= minAge && Age <= maxAge;

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}


/*public record DateOfBirth
{
    public DateTime Value { get; }

    public DateOfBirth(DateTime value)
    {
        if ( value > DateTime.Today )
            throw new ArgumentException("DOB cannot be in the future");
        if ( value < DateTime.Today.AddYears(-120) )
            throw new ArgumentException("DOB too far in the past");
        Value = value;
    }

    public int Age => (int) ((DateTime.Today - Value).TotalDays / 365.25);

    public override string ToString() => Value.ToShortDateString();
}
*/
