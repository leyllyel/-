using System;
using System.Collections.Generic;

namespace техносервис.Models;

public partial class Application
{
    public int Id { get; set; }

    public DateTime? AddDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public int? ExecutorId { get; set; }

    public int? UserId { get; set; }

    public int? PriorityId { get; set; }

    public int? StatusId { get; set; }

    public string? Result { get; set; }

    public int? EquipmentId { get; set; }

    public int? TypeId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Equipment? Equipment { get; set; }

    public virtual User? Executor { get; set; }

    public virtual Priority IdNavigation { get; set; } = null!;

    public virtual Status? Status { get; set; }

    public virtual Type? Type { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
}
