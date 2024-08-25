using MoviesHubAPI.Models;

namespace MoviesHubAPI.Helpers
{
    public interface IAuthHelpers
    {
        string GenerateJWTToken(User user);
    }
}
