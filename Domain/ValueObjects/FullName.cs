using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

/// <summary>
/// nếu có keyword "sealed" → ko thể kế thừa FullName
/// FullName này có lẽ có thể tái sử dụng Value Objects này → ko thêm keyword "sealed"
/// </summary>
public /*sealed*/ record FullName       
{
    public string FirstName { get; }
    public string LastName { get; }

    public FullName(string firstName , string lastName)
    {
        if ( string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) )
            throw new ArgumentException("First and Last name are required");

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    public override string ToString() => $"{LastName} {FirstName}";
}

/*public record FullName
{
    public string Value { get; }

    public FullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("First and Last name are required");
        Value = value.Trim();
    }

    public override string ToString() => Value;
}
*/