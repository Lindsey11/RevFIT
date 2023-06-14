using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutCircuit
{
    public interface IWorkoutCircuitParentRepository
    {
        Task<IEnumerable<WorkoutCircuitParent>> GetAllWorkoutCircuitParentsAsync();
        Task<WorkoutCircuitParent> GetWorkoutCircuitParentByIdAsync(int id);
        Task<bool> AddWorkoutCircuitParentAsync(WorkoutCircuitParent workoutCircuitParent);
        Task<bool> UpdateWorkoutCircuitParentAsync(WorkoutCircuitParent workoutCircuitParent);
        Task<bool> DeleteWorkoutCircuitParentAsync(int id);
    }
}
