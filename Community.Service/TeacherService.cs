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
        public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await _teacherRepository.GetTeachersAsync();
        }

        public async Task< Teacher> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetTeacherByIdAsync(id);
        }

        public async  Task< Teacher> AddTeacherAsync(Teacher teacher)
        {
             return await _teacherRepository.AddTeacherAsync(teacher);

        }

        public async Task UpdateTeacherAsync(int id, Teacher teacher)
        {
           await _teacherRepository.UpdateTeacherAsync(id, teacher);
           await _teacherRepository.SaveAsync();

        }

        public async Task DeleteTeacherAsync(int id)
        {
           await _teacherRepository.DeleteTeacherAsync(id);
           await _teacherRepository.SaveAsync();
        }

        
    }

}