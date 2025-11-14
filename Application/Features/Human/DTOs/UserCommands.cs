using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.DTOs;

internal class UserCommands
{
}

/// <summary>
/// Trong .net 8.0 [C#12] có record class vs record struct (xuất hiện từ C#10)
///     record class    →   reference type
///     record struct   →   value type
/// => giúp code tường minh hơn
///     mà "record = record class" → tương đương nhau
/// </summary>
public sealed record CreateUserDto /*: IUserDto*/
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
}
public sealed record class UpdateUserDto : IUserDto
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
}
