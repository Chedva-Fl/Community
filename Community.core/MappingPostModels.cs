using AutoMapper;
using Community.core.DTO;
using Community.core.Models;
/*using Community.Models*/

namespace Community
{
    public class MappingPostModels:Profile
    {
        public MappingPostModels()
        {
            CreateMap<Courses, CoursesDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

        }

    }
}
