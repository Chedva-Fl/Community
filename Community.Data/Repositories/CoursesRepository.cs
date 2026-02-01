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
    public class CourseRepository : ICoursesRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Courses>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.coursId == id);
        }
        public async Task< Courses> AddCourseAsync(Courses courses)
        {
           await _context.Courses.AddAsync(courses);
            return courses;
        }

        public async Task<Courses> UpdateCourseAsync(int id, Courses course)
        {
            var c =  await GetCourseByIdAsync(course.coursId);
            c.name = course.name;
            c.description = course.description;
            return c;

        }

        public async Task DeleteCourseAsync(int id)
        {
            var c = await GetCourseByIdAsync(id);
            _context.Courses.Remove(c);
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
