using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutCircuitChild
{
    public int WorkoutCircuitChild1 { get; set; }

    public int? Month { get; set; }

    public int? Day { get; set; }

    public int? Year { get; set; }

    public DateTime? WorkoutDate { get; set; }

    public string? Excercise { get; set; }

    public int? Reps { get; set; }

    public string? Time { get; set; }

    public int? RestPeriod { get; set; }

    public int? Notes { get; set; }

    public int WorkoutCircuitParentId { get; set; }

    public virtual WorkoutCircuitParent WorkoutCircuitParent { get; set; } = null!;
}
