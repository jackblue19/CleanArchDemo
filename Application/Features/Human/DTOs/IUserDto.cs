using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.DTOs;

public interface IUserDto
{
    string FirstName { get; }
    string LastName { get; }
    string Email { get; }
    string PhoneNumber { get; }
    DateTime DateOfBirth { get; }   // string
}
