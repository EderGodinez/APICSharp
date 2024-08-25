
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.Movies.Responses;

namespace MoviesHubAPI.Services.MovieS
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieResponse>> GetAllMoviesAsync();
        Task<MovieResponse> GetMovieByIdAsync(int id);
        Task<string> RegisterMovieAsync(Movie model);
        Task<string> UpdateMovieAsync(int id, Movie model);
        Task<string> DeleteMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetTrendingMoviesAsync();
    }
}
