using SchoolOfDev.Enuns;
using System.ComponentModel.DataAnnotations;

namespace SchoolOfDev.DTO.User
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? UserName { get; set; }

        public string? LastName { get; set; }

        public TypeUser TypeUser { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(Entities.User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            UserName = user.UserName;
            LastName = user.LastName;  
            TypeUser = user.TypeUser;
            Token = token;
        }
    }
}
