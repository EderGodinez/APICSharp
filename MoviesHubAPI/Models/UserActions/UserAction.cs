using MoviesHubAPI.Models.MediaF;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Models.UserActionsF
{
    public class UserAction : IUAction
    {
        public int? UserId { get; set; }
        public int? MediaId { get; set; }
        public char TypeAction { get; set; }
        public DateTime ActionDate { get; set; }

        public Media Media { get; set; }
        public User User { get; set; }
    }
}
