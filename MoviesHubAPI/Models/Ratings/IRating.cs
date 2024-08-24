using MoviesHubAPI.Models.MediaF;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Models.Ratings
{
    public interface IRating
    {
         int? UserId { get; set; }
         int? MediaId { get; set; }
         byte Rate { get; set; }
         DateTime RateDate { get; set; }

         Media Media { get; set; }
    }
}
