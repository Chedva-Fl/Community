using Community.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.core.Repositories
{
    public interface ITeacherRepository
    {

        public Task< Teacher> GetTeacherByIdAsync(int id);
        public Task< Teacher> AddTeacherAsync(Teacher teacher);
        public Task< Teacher> UpdateTeacherAsync(int id, Teacher teacher);
        Task DeleteTeacherAsync(int id);
        Task< List<Teacher>> GetTeachersAsync();
        public Task SaveAsync();

    }
}
