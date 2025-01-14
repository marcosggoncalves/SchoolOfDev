﻿using SchoolOfDev.Enuns;

namespace SchoolOfDev.DTO.User
{
    public class UserRequest
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? UserName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public TypeUser TypeUser { get; set; }

        public int[] CoursesStudentIds { get; set; }
    }
}
