using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaoNgocLinh.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RePassword { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
