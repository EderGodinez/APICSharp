using MoviesHubAPI.Models.Platforms.EnablePlatform;

namespace MoviesHubAPI.Models.Platforms
{
    public class Platform :IPlatform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MediaAvailibleIn> MediaAvailibleIns { get; set; }
    }

}
