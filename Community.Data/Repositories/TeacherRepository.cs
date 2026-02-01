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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task< List<Teacher>> GetTeachersAsync()
        {
            return await _context.Teacher.ToListAsync();
        }

        public  async Task< Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teacher.FirstOrDefaultAsync(t => t.teacherId == id);
        }

        public async Task< Teacher > AddTeacherAsync(Teacher teacher)
        {
           await _context.Teacher.AddAsync(teacher);
            return teacher;
        }

        public async Task< Teacher> UpdateTeacherAsync(int id, Teacher teacher)
        {
            var t =await GetTeacherByIdAsync(teacher.teacherId);
            t.name = teacher.name;
            t.description = teacher.description;
            t.coursName = teacher.coursName;

            return t;

        }

        public async Task DeleteTeacherAsync(int id)
        {
            var t = await GetTeacherByIdAsync(id);
            _context.Teacher.Remove(t);
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
