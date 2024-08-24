namespace MoviesHubAPI.Services.UserDtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
