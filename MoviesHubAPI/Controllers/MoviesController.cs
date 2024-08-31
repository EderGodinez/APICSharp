using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
using MoviesHubAPI.Services.Movies.Responses;
using MoviesHubAPI.Services.MovieS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesHubAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {   
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) { 
        _movieService = movieService;
        }
        /// <summary>
        /// Obtiene todas las películas.
        /// </summary>
        /// <returns>Lista de películas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        /// <summary>
        /// Registra una nueva película.
        /// </summary>
        /// <param name="model">Modelo de datos de la película.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost]
        public async Task<ActionResult> RegisterMovie(Movie model)
        {
            var message = await _movieService.RegisterMovieAsync(model);
            return Ok(new { message });
        }

        /// <summary>
        /// Obtiene una película por ID.
        /// </summary>
        /// <param name="id">ID de la película.</param>
        /// <returns>Película solicitada o error.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponse>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound(new { error = "Pelicula no encontrada" });
            }
            return Ok(movie);
        }

        /// <summary>
        /// Actualiza una película existente.
        /// </summary>
        /// <param name="id">ID de la película.</param>
        /// <param name="model">Modelo de datos actualizado de la película.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, Movie model)
        {
            var message = await _movieService.UpdateMovieAsync(id, model);
            if (message == "Pelicula no encontrada")
            {
                return NotFound(new { error = message });
            }
            return Ok(new { message });
        }

        /// <summary>
        /// Elimina una película por ID.
        /// </summary>
        /// <param name="id">ID de la película.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovieById(int id)
        {
            var message = await _movieService.DeleteMovieByIdAsync(id);
            if (message == "Pelicula no encontrada")
            {
                return NotFound(new { error = message });
            }
            return Ok(new { message });
        }

        /// <summary>
        /// Obtiene las películas populares.
        /// </summary>
        /// <returns>Lista de películas populares.</returns>
        [HttpGet("trending")]
        public async Task<ActionResult<IEnumerable<TrendingDTO>>> GetTrendingMovies()
        {
            var trendingMovies = await _movieService.GetTrendingMovies();
            return Ok(trendingMovies);
        }
    }
}
