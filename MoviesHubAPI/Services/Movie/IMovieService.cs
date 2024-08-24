using MoviesHubAPI.Models.MediaF.MovieF;
using MoviesHubAPI.Models.UserF;

namespace MoviesHubAPI.Services.MovieS
{
    public interface IMovieService
    {
        public Task<List<Movie>> GetMovies();
    }
}
