using Application.Features.Human.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.Validators;

public class UserFieldsValidator<T> : AbstractValidator<T> where T : IUserDto
{
    public UserFieldsValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^(0|\+84)[0-9]{9}$")
            .WithMessage("Invalid Vietnamese phone number");
        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Today.AddYears(-5))
            .WithMessage("User must be at least 5 years old");
    }
}
