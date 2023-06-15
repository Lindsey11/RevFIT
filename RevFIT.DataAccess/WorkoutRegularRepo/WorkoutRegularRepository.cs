using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Context;
using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.WorkoutRegularRepo
{
 
    public class WorkoutRegularRepository : IWorkoutRegularRepository
    {
        private readonly DataContext dataContext;

        public WorkoutRegularRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<WorkoutRegular>> GetAllWorkoutRegularsAsync()
        {
            return await dataContext.WorkoutRegulars.ToListAsync();
        }

        public async Task<WorkoutRegular> GetWorkoutRegularByIdAsync(int id)
        {
            return await dataContext.WorkoutRegulars.FindAsync(id);
        }

        public async Task<bool> AddWorkoutRegularAsync(WorkoutRegular workoutRegular)
        {
            dataContext.WorkoutRegulars.Add(workoutRegular);
            int affectedRows = await dataContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateWorkoutRegularAsync(WorkoutRegular workoutRegular)
        {
            dataContext.WorkoutRegulars.Update(workoutRegular);
            int affectedRows = await dataContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteWorkoutRegularAsync(int id)
        {
            var workoutRegular = await dataContext.WorkoutRegulars.FindAsync(id);
            if (workoutRegular != null)
            {
                dataContext.WorkoutRegulars.Remove(workoutRegular);
                int affectedRows = await dataContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }

}
