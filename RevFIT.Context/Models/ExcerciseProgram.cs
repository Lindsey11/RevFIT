using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class ExcerciseProgram
{
    public int ProgramId { get; set; }

    public string? ProgramName { get; set; }

    public int ProgramTypeId { get; set; }

    public int ProgramDurationWeeks { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ProgramType ProgramType { get; set; } = null!;

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
