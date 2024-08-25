using MoviesHubAPI.Models;

namespace MoviesHubAPI.Services.Movies.Responses
{
    public interface IMovieResponse
    {
        Media _Media { get; set; }
        TimeSpan? Duration { get; set; }
        List<string> GenderLists { get; set; }
    }
}
