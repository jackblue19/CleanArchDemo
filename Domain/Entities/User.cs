using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public FullName FullName { get; set; } = default!;
    public Email Email { get; set; } = default!;
    public PhoneNumber PhoneNumber { get; set; } = default!;
    public DateOfBirth DateOfBirth { get; set; } = default!;
    public AuditInfo AuditInfo { get; set; } = new();
    //public Address Address { get; set; } = default!;  
    // có impl đều vì PatternDemo nên làm đơn giản hết sức có thể
    // có thể mở comment ra để tự debug impl lại cho quen để hiểu flow hơn (loc-18)
}

