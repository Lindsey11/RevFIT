using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutRepo
{
    public interface IWODRepository
    {
        Task<IEnumerable<Wod>> GetAllWorkoutsAsync();
        Task<Wod> GetWorkoutByIdAsync(int id);
        Task<int> AddWorkoutAsync(Wod Wod);
        Task<int> AddWorkoutScroreingType(WorkoutScore scoretype);
        Task<bool> UpdateWorkoutAsync(Wod Wod);
        Task<bool> DeleteWorkoutAsync(int id);
        Task<Wod> GetWorkoutByProgramAndDateAsync(int programID, DateTime date);
    }
}
