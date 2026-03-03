using System;
using System.Collections.Generic;

namespace техносервис.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public int? ApplicId { get; set; }

    public virtual Application? Applic { get; set; }

    public virtual User? User { get; set; }
}
