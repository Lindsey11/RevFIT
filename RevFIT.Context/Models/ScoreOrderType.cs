using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class ScoreOrderType
{
    public int ScoreOrderTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual ICollection<WorkoutScore> WorkoutScores { get; set; } = new List<WorkoutScore>();
}
