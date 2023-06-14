using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Context;
using RevFIT.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.DataAccess.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _dataContext.Users.Add(user);
            int affectedRows = await _dataContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _dataContext.Entry(user).State = EntityState.Modified;
            int affectedRows = await _dataContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                int affectedRows = await _dataContext.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }



    }
}
