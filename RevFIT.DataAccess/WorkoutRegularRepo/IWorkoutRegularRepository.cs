using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutRegularRepo
{
    public interface IWorkoutRegularRepository
    {
        Task<IEnumerable<WorkoutRegular>> GetAllWorkoutRegularsAsync();
        Task<WorkoutRegular> GetWorkoutRegularByIdAsync(int id);
        Task<bool> AddWorkoutRegularAsync(WorkoutRegular workoutRegular);
        Task<bool> UpdateWorkoutRegularAsync(WorkoutRegular workoutRegular);
        Task<bool> DeleteWorkoutRegularAsync(int id);
    }
}
