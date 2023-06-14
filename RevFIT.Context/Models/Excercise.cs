using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class Excercise
{
    public int ExcerciseId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Muscle { get; set; }

    public string? Equipment { get; set; }

    public string? Difficulty { get; set; }

    public string? Instructions { get; set; }

    public int? ProgramId { get; set; }
}
