using MoviesHubAPI.Models.Platforms.EnablePlatform;

namespace MoviesHubAPI.Models.Platforms
{
    public interface IPlatform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<MediaAvailibleIn> MediaAvailibleIns { get; set; }
    }
}
