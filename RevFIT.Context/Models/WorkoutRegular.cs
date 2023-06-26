using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutRegular
{
    public int WorkoutRegularId { get; set; }

    public string WorkoutName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? WarmUp { get; set; }

    public string? CoolDown { get; set; }

    public string MuscleGroupFocus { get; set; } = null!;

    public string? Notes { get; set; }

    public int? ExcerciseProgramId { get; set; }

    public DateTime WorkoutDate { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ExcerciseProgram? ExcerciseProgram { get; set; }

    public virtual ICollection<WorkoutRegularChild> WorkoutRegularChildren { get; set; } = new List<WorkoutRegularChild>();
}
