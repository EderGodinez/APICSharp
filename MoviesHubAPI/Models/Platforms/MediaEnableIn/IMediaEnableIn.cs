using MoviesHubAPI.Models.MediaF;

namespace MoviesHubAPI.Models.Platforms.MediaEnableIn
{
    public interface IMediaEnableIn
    {
        public int MediaId { get; set; }
        public Media Media { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
