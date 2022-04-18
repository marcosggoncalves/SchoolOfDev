using SchoolOfDev.Enuns;

namespace SchoolOfDev.DTO.User
{
    public class UserRequestUpdate : UserRequest
    {
        public string? CurrentPassword { get; set; }
    }
}
