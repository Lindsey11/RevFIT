using Microsoft.AspNetCore.Components;
using RevFit.Client.UI.UIServices.Workout;
using RevFit.Client.UI.ViewModels.Workout;

namespace RevFit.Client.UI.Pages.WodUI
{
    public partial class WorkoutOfTheDay: ComponentBase
    {
        [Inject]
        private IUIWodService uIWodService { get; set; }
        public DateTime workoutDate { get; set; } = DateTime.Now;
        public int ProgramID = 1;
        public List<WorkoutViewModel> workouts { get; set; } = new List<WorkoutViewModel>();

        protected override async Task OnInitializedAsync()
        {
           await GetTodaysWorkout();
        }

        private async Task GetTodaysWorkout()
        {
            var wods = await uIWodService.GetTodaysWorkout(ProgramID,workoutDate);
            workouts = wods;
        }
    }
}
