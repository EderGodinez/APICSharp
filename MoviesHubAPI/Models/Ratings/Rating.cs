using MoviesHubAPI.Models.MediaF;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Models.Ratings
{
    public class Rating : IRating
    {
        public int? UserId { get; set; }
        public int? MediaId { get; set; }
        public byte Rate { get; set; }
        public DateTime RateDate { get; set; }

        public Media Media { get; set; }
        public User user { get; set; }
    }
}
