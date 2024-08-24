using MoviesHubAPI.Models.MediaF;
using MoviesHubAPI.Models.Platforms.MediaEnableIn;

namespace MoviesHubAPI.Models.Platforms.EnablePlatform
{
    public class MediaAvailibleIn : IMediaEnableIn
    {
        public int MediaId { get; set; }
        public Media Media { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }

}
