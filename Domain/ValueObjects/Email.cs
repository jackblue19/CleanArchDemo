using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if ( string.IsNullOrWhiteSpace(value) ||
            !Regex.IsMatch(value , @"^[^@\s]+@[^@\s]+\.[^@\s]+$") )
            throw new ArgumentException("Invalid email format");

        Value = value.Trim();
    }

    public override string ToString() => Value;
}