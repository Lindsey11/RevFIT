using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Context;
using RevFIT.Context.Models;

namespace RevFIT.DataAccess.WorkoutCircuit
{
 
    public class WorkoutCircuitChildRepository : IWorkoutCircuitChildRepository
    {
        private readonly DataContext _dbContext;

        public WorkoutCircuitChildRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkoutCircuitChild>> GetAllWorkoutCircuitChildrenAsync()
        {
            return await _dbContext.WorkoutCircuitChildren
                .Include(wcc => wcc.WorkoutCircuitParent)
                .ToListAsync();
        }

        public async Task<WorkoutCircuitChild> GetWorkoutCircuitChildByIdAsync(int id)
        {
            return await _dbContext.WorkoutCircuitChildren
                .Include(wcc => wcc.WorkoutCircuitParent)
                .FirstOrDefaultAsync(wcc => wcc.WorkoutCircuitChild1 == id);
        }

        public async Task<bool> AddWorkoutCircuitChildAsync(WorkoutCircuitChild workoutCircuitChild)
        {
            _dbContext.WorkoutCircuitChildren.Add(workoutCircuitChild);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateWorkoutCircuitChildAsync(WorkoutCircuitChild workoutCircuitChild)
        {
            _dbContext.Update(workoutCircuitChild);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteWorkoutCircuitChildAsync(int id)
        {
            var workoutCircuitChild = await _dbContext.WorkoutCircuitChildren.FindAsync(id);
            if (workoutCircuitChild != null)
            {
                _dbContext.WorkoutCircuitChildren.Remove(workoutCircuitChild);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }

}
