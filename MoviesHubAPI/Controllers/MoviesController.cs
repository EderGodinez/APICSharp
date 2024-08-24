using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models.MediaF.MovieF;
using MoviesHubAPI.Models.UserF;
using MoviesHubAPI.Services.MovieS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {   
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) { 
        _movieService = movieService;
        }
        // GET: api/<MoviesController>
        /// <summary>
        /// Obtiene todos las peliculas.
        /// </summary>
        /// <returns>Listado de las peliculas.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Movie>), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            return await this._movieService.GetMovies();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
