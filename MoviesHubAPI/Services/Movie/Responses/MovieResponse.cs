
using MoviesHubAPI.Models;


namespace MoviesHubAPI.Services.Movies.Responses
{
    public class MovieResponse : IMovieResponse
    {
       public Media _Media { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<string> GenderLists { get; set; }
    }
}
