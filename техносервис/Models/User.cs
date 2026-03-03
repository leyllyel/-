using System;
using System.Collections.Generic;

namespace техносервис.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Application> ApplicationExecutors { get; set; } = new List<Application>();

    public virtual ICollection<Application> ApplicationUsers { get; set; } = new List<Application>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
}
