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
  
    public class WorkoutRegularChildRepository : IWorkoutRegularChildRepository
    {
        private readonly DataContext dataContext;

        public WorkoutRegularChildRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<WorkoutRegularChild>> GetAllWorkoutRegularChildrenAsync()
        {
            return await dataContext.WorkoutRegularChildren.ToListAsync();
        }

        public async Task<WorkoutRegularChild> GetWorkoutRegularChildByIdAsync(int id)
        {
            return await dataContext.WorkoutRegularChildren.FindAsync(id);
        }

        public async Task<bool> AddWorkoutRegularChildAsync(WorkoutRegularChild workoutRegularChild)
        {
            dataContext.WorkoutRegularChildren.Add(workoutRegularChild);
            int affectedRows = await dataContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateWorkoutRegularChildAsync(WorkoutRegularChild workoutRegularChild)
        {
            dataContext.WorkoutRegularChildren.Update(workoutRegularChild);
            int affectedRows = await dataContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteWorkoutRegularChildAsync(int id)
        {
            var workoutRegularChild = await dataContext.WorkoutRegularChildren.FindAsync(id);
            if (workoutRegularChild != null)
            {
                dataContext.WorkoutRegularChildren.Remove(workoutRegularChild);
                int affectedRows = await dataContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }

}
