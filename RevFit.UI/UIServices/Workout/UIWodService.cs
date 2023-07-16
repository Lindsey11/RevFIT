using OpenAPIShared.RevFitAPI;
using RevFit.Client.UI.ViewModels.Workout;

namespace RevFit.Client.UI.UIServices.Workout
{
    public class UIWodService : IUIWodService
    {
        private readonly RevFITAPIClient _apiClient;
        public UIWodService(RevFITAPIClient revFITAPIClient) 
        {
             _apiClient = revFITAPIClient;
        }

        public async Task<List<WorkoutViewModel>> GetTodaysWorkout(int programId, DateTime WorkoutDate)
        {
            var data = await _apiClient.WorkoutTodaysWorkoutAsync(programId, WorkoutDate);
            var todaysWorkout = new List<WorkoutViewModel>();

            foreach (var workout in data.Data)
            {
                var newItwem = new WorkoutViewModel()
                {
                    IsLive = workout.IsLive,
                    WodId = workout.WodId,
                    WorkoutDefinition = workout.WorkoutDefinition,
                    WorkoutName = workout.WorkoutName,
                };
                todaysWorkout.Add(newItwem);
            }

            return todaysWorkout;
        }
    }
}
