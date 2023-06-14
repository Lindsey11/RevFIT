using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class Workout
{
    public int WorkoutId { get; set; }

    public string? WarmUp { get; set; }

    public string WorkoutName { get; set; } = null!;

    public string? Description { get; set; }

    public int WorkoutTypeId { get; set; }

    public int ProgramId { get; set; }

    public string? CoolDown { get; set; }

    public DateTime WokoutDate { get; set; }

    public virtual ExcerciseProgram Program { get; set; } = null!;

    public virtual ICollection<WorkoutCircuitParent> WorkoutCircuitParents { get; set; } = new List<WorkoutCircuitParent>();

    public virtual ICollection<WorkoutRegular> WorkoutRegulars { get; set; } = new List<WorkoutRegular>();
}
