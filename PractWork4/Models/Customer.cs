using System;
using System.Collections.Generic;

namespace PractWork4.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Login { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
