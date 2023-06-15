using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutRegularRepo
{
    public interface IWorkoutRegularChildRepository
    {
        Task<IEnumerable<WorkoutRegularChild>> GetAllWorkoutRegularChildrenAsync();
        Task<WorkoutRegularChild> GetWorkoutRegularChildByIdAsync(int id);
        Task<bool> AddWorkoutRegularChildAsync(WorkoutRegularChild workoutRegularChild);
        Task<bool> UpdateWorkoutRegularChildAsync(WorkoutRegularChild workoutRegularChild);
        Task<bool> DeleteWorkoutRegularChildAsync(int id);
    }
}
