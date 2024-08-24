using MoviesHubAPI.Models.Ratings;
using MoviesHubAPI.Models.UserActionsF;

namespace MoviesHubAPI.Models.UserF
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
         string Password { get; set; }
        
         string Role { get; set; }
         ICollection<UserAction> UserActions { get; set; }
         ICollection<Rating> Ratings { get; set; }
    }
}
