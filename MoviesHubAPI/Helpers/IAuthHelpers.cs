
using MoviesHubAPI.Services.Users.Responses;

namespace MoviesHubAPI.Helpers
{
    public interface IAuthHelpers
    {
        string GenerateJWTToken(userResponse user);
    }
}
