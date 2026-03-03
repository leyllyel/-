using System;
using System.Collections.Generic;

namespace техносервис.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
