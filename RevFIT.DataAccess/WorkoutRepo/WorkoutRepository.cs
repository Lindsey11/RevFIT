using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Context;
using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutRepo
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly DataContext _dbContext;

        public WorkoutRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {
            return await _dbContext.Workouts.Include(w => w.Program)
                .Include(w => w.WorkoutCircuitParents)
                .Include(w => w.WorkoutRegulars)
                .ToListAsync();
        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _dbContext.Workouts
                .Include(w => w.Program)
                .Include(w => w.WorkoutCircuitParents)
                .Include(w => w.WorkoutRegulars)
                .FirstOrDefaultAsync(w => w.WorkoutId == id);
        }

        public async Task<bool> AddWorkoutAsync(Workout workout)
        {
            _dbContext.Add(workout);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateWorkoutAsync(Workout workout)
        {
            _dbContext.Update(workout);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            var workout = await _dbContext.Workouts.FindAsync(id);
            if (workout != null)
            {
                _dbContext.Set<Workout>().Remove(workout);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }

        public async Task<Workout> GetWorkoutByProgramAndDateAsync(int programID, DateTime date)
        {
            var todays = await _dbContext.Workouts
                                        .Where(x => x.ProgramId == programID && x.WokoutDate == date.Date)
                                        .Include(w => w.Program)
                                        .Include(w => w.WorkoutCircuitParents)
                                        .Include(w => w.WorkoutRegulars).FirstOrDefaultAsync();

            return todays;
                                        
        }
    }
}
