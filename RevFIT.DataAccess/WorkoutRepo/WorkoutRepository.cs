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
    public class WODRepository : IWODRepository
    {
        private readonly DataContext _dbContext;

        public WODRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Wod>> GetAllWorkoutsAsync()
        {
            return await _dbContext.Wods
                .ToListAsync();
        }

        public async Task<Wod> GetWorkoutByIdAsync(int id)
        {
            return await _dbContext.Wods
                .FirstOrDefaultAsync(w => w.WodId == id);
        }

        public async Task<int> AddWorkoutAsync(Wod Wod)
        {
            _dbContext.Add(Wod);
            var res = await _dbContext.SaveChangesAsync();

            return Wod.WodId;
            //return affectedRows > 0;
        }

        public async Task<bool> UpdateWorkoutAsync(Wod Wod)
        {
            _dbContext.Update(Wod);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            var Wod = await _dbContext.Wods.FindAsync(id);
            if (Wod != null)
            {
                _dbContext.Set<Wod>().Remove(Wod);
                int affectedRows = await _dbContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }

        public async Task<Wod> GetWorkoutByProgramAndDateAsync(int programID, DateTime date)
        {
            var todays = await _dbContext.Wods
                                        .Where(x => x.ProgramId == programID && x.ScheduleDate == date.Date)
                                        .Include(x => x.WorkoutScores)
                                        .FirstOrDefaultAsync();

            return todays;
                                        
        }

        public async Task<int> AddWorkoutScroreingType(WorkoutScore score)
        {
            _dbContext.WorkoutScores.Add(score);
            var res = await _dbContext.SaveChangesAsync();
            return score.ScoreId;
        } 
    }
}
