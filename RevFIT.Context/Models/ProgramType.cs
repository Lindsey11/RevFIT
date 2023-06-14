using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class ProgramType
{
    public int ProgramTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual ICollection<ExcerciseProgram> ExcercisePrograms { get; set; } = new List<ExcerciseProgram>();
}
