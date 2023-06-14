using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutCircuitParent
{
    public int WorkoutCircutParent { get; set; }

    public int? Rounds { get; set; }

    public string? Time { get; set; }

    public int TimeCap { get; set; }

    public int WorkoutId { get; set; }

    public DateTime WokoutDate { get; set; }

    public virtual Workout Workout { get; set; } = null!;

    public virtual ICollection<WorkoutCircuitChild> WorkoutCircuitChildren { get; set; } = new List<WorkoutCircuitChild>();
}
