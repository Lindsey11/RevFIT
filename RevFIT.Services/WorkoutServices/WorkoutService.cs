using RevFIT.Context.Models;
using RevFIT.DataAccess.WorkoutRepo;
using RevFIT.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.WorkoutServices
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<ServiceResponseModel<Workout>> GetTodaysWorkout(int programID, DateTime workoutDate)
        {
            try
            {
                var workout = await _workoutRepository.GetWorkoutByProgramAndDateAsync(programID, workoutDate);
                if (workout == null)
                {
                    return new() { Data = null, IsSuccess = false, Message = "No workout found for today." };
                }

                return new() { Data = workout, IsSuccess = true, Message = "Workout found." };
            }
            catch (Exception error)
            {
                return new() { Data = null, IsSuccess = false, Message = $"Error getting today's workout. {error.Message}" };
            }
        }
    }
}
