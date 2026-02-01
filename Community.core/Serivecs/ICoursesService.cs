using Community.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.core.Serivecs
{
    public interface ICoursesService
    {
        
        public Task<List<Courses>> GetCoursesAsync();
        public Task<Courses> AddCourseAsync(Courses courses);
        public Task<Courses> GetCourseByIdAsync(int id);
         Task UpdateCourseAsync(int id, Courses course);
         Task DeleteCourseAsync(int id);
    }
}
