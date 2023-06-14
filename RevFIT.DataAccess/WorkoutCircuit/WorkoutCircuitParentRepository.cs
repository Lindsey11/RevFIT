using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Context;
using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutCircuit
{
  
    public class WorkoutCircuitParentRepository : IWorkoutCircuitParentRepository
    {
        private readonly DataContext _dbContext;

        public WorkoutCircuitParentRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkoutCircuitParent>> GetAllWorkoutCircuitParentsAsync()
        {
            return await _dbContext.WorkoutCircuitParents
                .Include(wcp => wcp.Workout)
                .Include(wcp => wcp.WorkoutCircuitChildren)
                .ToListAsync();
        }

        public async Task<WorkoutCircuitParent> GetWorkoutCircuitParentByIdAsync(int id)
        {
            return await _dbContext.WorkoutCircuitParents
                .Include(wcp => wcp.Workout)
                .Include(wcp => wcp.WorkoutCircuitChildren)
                .FirstOrDefaultAsync(wcp => wcp.WorkoutCircutParent == id);
        }

        public async Task<bool> AddWorkoutCircuitParentAsync(WorkoutCircuitParent workoutCircuitParent)
        {
            _dbContext.Add(workoutCircuitParent);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateWorkoutCircuitParentAsync(WorkoutCircuitParent workoutCircuitParent)
        {
            _dbContext.Update(workoutCircuitParent);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteWorkoutCircuitParentAsync(int id)
        {
            var workoutCircuitParent = await _dbContext.WorkoutCircuitParents.FindAsync(id);
            if (workoutCircuitParent != null)
            {
                _dbContext.WorkoutCircuitParents.Remove(workoutCircuitParent);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }

}
