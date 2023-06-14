using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutScoringType
{
    public int ScoringTypeId { get; set; }

    public string? ScoringType { get; set; }

    public string? Description { get; set; }
}
