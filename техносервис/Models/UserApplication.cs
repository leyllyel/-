using System;
using System.Collections.Generic;

namespace техносервис.Models;

public partial class UserApplication
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ApplicId { get; set; }

    public virtual Application? Applic { get; set; }

    public virtual User? User { get; set; }
}
