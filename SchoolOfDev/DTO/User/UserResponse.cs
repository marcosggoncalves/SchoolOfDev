﻿using SchoolOfDev.Enuns;

namespace SchoolOfDev.DTO.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? UserName { get; set; }

        public string? LastName { get; set; }

        public TypeUser TypeUser { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Entities.Course> CoursesStuding { get; set; }

        public List<Entities.Course> CoursesTeaching { get; set; }
    }
}
