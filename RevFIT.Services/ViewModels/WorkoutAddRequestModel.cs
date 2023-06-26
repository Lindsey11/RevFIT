using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.ViewModels
{
    public class WorkoutAddRequestModel
    {
        public int WorkoutId { get; set; }

        public string? WarmUp { get; set; }

        public string WorkoutName { get; set; } = null!;

        public string? Description { get; set; }

        public int WorkoutTypeId { get; set; }

        public int ProgramId { get; set; }

        public string? CoolDown { get; set; }

        public DateTime WokoutDate { get; set; }
    }
}
