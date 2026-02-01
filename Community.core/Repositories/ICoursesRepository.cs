using Community.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.core.Repositories
{
    public interface ICoursesRepository
    {

        public Task<List<Courses>> GetCoursesAsync();
        public Task<Courses> AddCourseAsync(Courses courses);
        public Task<Courses> GetCourseByIdAsync(int id);
        public Task<Courses> UpdateCourseAsync(int id, Courses course);
         Task DeleteCourseAsync(int id);
         Task SaveAsync();

    }
}
