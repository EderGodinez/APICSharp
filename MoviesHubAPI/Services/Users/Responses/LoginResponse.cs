namespace MoviesHubAPI.Services.Users.Responses
{
    public class LoginResponse
    {   
        userResponse user { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
    public class userResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<int> FavoritesMediaId { get; set; }
    }
    }
