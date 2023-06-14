using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class WorkoutType
{
    public int WorkoutTypeId { get; set; }

    public string WorkoutType1 { get; set; } = null!;

    public string? Description { get; set; }
}
