using RevFit.Client.UI.ViewModels.Workout;

namespace RevFit.Client.UI.UIServices.Workout
{
    public interface IUIWodService
    {
        Task<List<WorkoutViewModel>> GetTodaysWorkout(int programId, DateTime WorkoutDate);
    }
}
