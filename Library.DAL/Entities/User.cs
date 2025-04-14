using System;
using System.Collections.Generic;

namespace Library.DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public DateOnly? Birth { get; set; }

    public int? Role { get; set; }

    public string? UserEmail { get; set; }
}
