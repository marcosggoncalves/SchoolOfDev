﻿using System.ComponentModel.DataAnnotations;

namespace SchoolOfDev.DTO.User
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
