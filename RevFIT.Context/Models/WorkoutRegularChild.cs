using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutRegularChild
{
    public int WorkoutRegularChildrenId { get; set; }

    public int? Reps { get; set; }

    public int? Sets { get; set; }

    public int? Time { get; set; }

    public int? Weight { get; set; }

    public int? RestPeriod { get; set; }

    public string? Notes { get; set; }

    public DateTime DateCreated { get; set; }

    public int WorkoutRegularParentId { get; set; }

    public virtual WorkoutRegular WorkoutRegularParent { get; set; } = null!;
}
