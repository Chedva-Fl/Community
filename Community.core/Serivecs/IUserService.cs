using Community.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.core.Serivecs
{
    public interface IUserService
    {


        public Task< List<User>> GetUserAsync();
        public Task< User> GetUserByIdAsync(int id);
        public Task< User > PostAsync(User User);
        Task UpdateUserAsync(int id, User user);
        Task DeleteUserAsync(int id);
       
    }
}
