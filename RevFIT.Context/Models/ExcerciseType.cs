using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class ExcerciseType
{
    public int ExcerciseTypId { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }
}
