namespace RevFit.Client.UI.ViewModels.Workout
{
    public class WorkoutViewModel
    {
        public int WodId { get; set; }

        public string WorkoutName { get; set; } = null!;

        public string WorkoutDefinition { get; set; } = null!;

        public int ProgramId { get; set; }

        public string ScoreType { get; set; } = null!;

        public DateTime ScheduleDate { get; set; }

        public bool IsLive { get; set; }

    }
}
