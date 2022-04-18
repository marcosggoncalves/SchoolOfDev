using AutoMapper;
using SchoolOfDev.DTO.Course;
using SchoolOfDev.Entities;

namespace SchoolOfDev.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseRequest>();
            CreateMap<Course, CourseResponse>();

            CreateMap<CourseRequest, Course>();
            CreateMap<CourseResponse, Course>();
        }
    }
}
