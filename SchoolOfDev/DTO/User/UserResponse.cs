using SchoolOfDev.Entities;
using SchoolOfDev.Enuns;

namespace SchoolOfDev.DTO.User
{
    public class UserResponse : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? UserName { get; set; }

        public string? LastName { get; set; }

        public TypeUser TypeUser { get; set; }

        public List<Course> CoursesStuding { get; set; }

        public List<Course> CoursesTeaching { get; set; }
    }
}
