

namespace MoviesHubAPI.Models
{
    public interface IMovie
    {
        int MediaId { get; set; }
        TimeSpan Duration { get; set; }
    }
}