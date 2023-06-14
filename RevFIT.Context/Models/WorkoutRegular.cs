using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutRegular
{
    public int WorkoutRegularId { get; set; }

    public string? ExcerciseName { get; set; }

    public string? Description { get; set; }

    public string? MuscleGroupFocus { get; set; }

    public string? Notes { get; set; }

    public int WorkoutId { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual Workout Workout { get; set; } = null!;

    public virtual ICollection<WorkoutRegularChild> WorkoutRegularChildren { get; set; } = new List<WorkoutRegularChild>();
}
