using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutCircuit
{
    public interface IWorkoutCircuitChildRepository
    {
        Task<IEnumerable<WorkoutCircuitChild>> GetAllWorkoutCircuitChildrenAsync();
        Task<WorkoutCircuitChild> GetWorkoutCircuitChildByIdAsync(int id);
        Task<bool> AddWorkoutCircuitChildAsync(WorkoutCircuitChild workoutCircuitChild);
        Task<bool> UpdateWorkoutCircuitChildAsync(WorkoutCircuitChild workoutCircuitChild);
        Task<bool> DeleteWorkoutCircuitChildAsync(int id);
    }
}
