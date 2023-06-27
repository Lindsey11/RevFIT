using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class Wod
{
    public int WodId { get; set; }

    public string WorkoutName { get; set; } = null!;

    public string WorkoutDefinition { get; set; } = null!;

    public int ProgramId { get; set; }

    public string ScoreType { get; set; } = null!;

    public DateTime ScheduleDate { get; set; }

    public bool IsLive { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ExcerciseProgram Program { get; set; } = null!;

    public virtual ICollection<WorkoutScore> WorkoutScores { get; set; } = new List<WorkoutScore>();
}
