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
    public class CourseService : ICoursesService
    {
        
        private readonly ICoursesRepository _courseRepository;

        public CourseService(ICoursesRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Courses>> GetCoursesAsync()
        {
            return await _courseRepository.GetCoursesAsync();
        }

        public async Task<Courses> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseByIdAsync(id);
        }

        public async Task<Courses> AddCourseAsync(Courses course)
        {
           return await _courseRepository.AddCourseAsync(course);

        }


        public async Task UpdateCourseAsync(int id, Courses course)
        {
           await _courseRepository.UpdateCourseAsync(id, course);
           await _courseRepository.SaveAsync();

        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
            await _courseRepository.SaveAsync();
        }


    }

}

