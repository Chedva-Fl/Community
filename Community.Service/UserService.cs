using Community.core.Models;
using Community.core.Repositories;
using Community.core.Serivecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task< List<User> > GetUserAsync()
        {
            return await _userRepository.GetUserAsync();
        }

        public async  Task< User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }


        public async Task UpdateUserAsync(int id, User user)
        {
           await _userRepository.UpdateUserAsync(id, user);
          await _userRepository.SaveAsync();

        }

        public async Task DeleteUserAsync(int id)
        {
           await _userRepository.DeleteUserAsync(id);
          await  _userRepository.SaveAsync();
        }


        public async Task< User> PostAsync(User User)
        {
            return await _userRepository.PostAsync(User);


        }
    }
}
    

