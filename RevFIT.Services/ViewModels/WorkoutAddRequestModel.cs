
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.ViewModels
{
    public class WorkoutAddRequestModel
    {
        public int WodId { get; set; }

        public string WorkoutName { get; set; } = null!;

        public string WorkoutDefinition { get; set; } = null!;

        public int ProgramId { get; set; }
        public int MeasureTypeID { get; set; }
        public int CalcTypeID { get; set; }
        public int OrderTypeID { get; set; }    
        public int set { get; set; }
        public string ScoreType { get; set; } = null!;

        public DateTime ScheduleDate { get; set; }

        public bool IsLive { get; set; }
    }
}
