using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutRepo
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();
        Task<Workout> GetWorkoutByIdAsync(int id);
        Task<bool> AddWorkoutAsync(Workout workout);
        Task<bool> UpdateWorkoutAsync(Workout workout);
        Task<bool> DeleteWorkoutAsync(int id);
        Task<Workout> GetWorkoutByProgramAndDateAsync(int programID, DateTime date);
    }
}
