using Community.core.Models;
using Community.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        
            private readonly DataContext _context;

            public UserRepository(DataContext context)
            {
                _context = context;
            }

            public async Task< List<User>> GetUserAsync()
            {
                return await _context.User.ToListAsync();
            }

            public async Task< User> GetUserByIdAsync(int id)
            {
                return await _context.User.FirstOrDefaultAsync(u => u.userId == id);
            }

        public async Task< User> PostAsync(User User)
        {
           await _context.User.AddAsync(User);
            return User;
        }

        public async Task< User> UpdateUserAsync(int id, User user)
        {
            var s = await GetUserByIdAsync(user.userId);
            s.name = user.name;
            s.phone = user.phone;
            s.email = user.email;

            return s;

        }

        public async Task DeleteUserAsync(int id)
        {
            var s = await GetUserByIdAsync(id);
            _context.User.Remove(s);

        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }


    }

}
