using MoviesHubAPI.Models.MediaF;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Models.UserActionsF
{
    public interface IUAction
    {
         int? UserId { get; set; }
         int? MediaId { get; set; }
         char TypeAction { get; set; }
         DateTime ActionDate { get; set; }

         Media Media { get; set; }
    }
}
