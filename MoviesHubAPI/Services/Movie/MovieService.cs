using EntityFrameworkExample.Context;
using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models.MediaF.MovieF;

namespace MoviesHubAPI.Services.MovieS
{
    public class MovieService:IMovieService
    {
        private readonly IContextDB _context;
        public MovieService(ContextDB context)
        {
            _context = context;
        }
        public async Task<List<Movie>> GetMovies()
        {
            return await this._context.Movies.ToListAsync();
        }
    }
}
