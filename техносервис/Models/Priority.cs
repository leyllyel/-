using System;
using System.Collections.Generic;

namespace техносервис.Models;

public partial class Priority
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual Application? Application { get; set; }
}
