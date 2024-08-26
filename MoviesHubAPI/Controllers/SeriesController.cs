using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
using MoviesHubAPI.Services.Series;


namespace MoviesHubAPI.Controllers
{
    /// <summary>
    /// Controlador para la gestión de series y episodios.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly ISerieService _serieService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SeriesController"/>.
        /// </summary>
        /// <param name="serieService">El servicio utilizado para gestionar series y episodios.</param>
        public SeriesController(ISerieService serieService)
        {
            _serieService = serieService;
        }

        /// <summary>
        /// Obtiene todas las series con paginación.
        /// </summary>
        /// <param name="pageNumber">El número de página para la paginación. Debe ser mayor o igual a 1. El valor predeterminado es 1.</param>
        /// <param name="pageSize">El tamaño de la página para la paginación. Debe ser mayor o igual a 1. El valor predeterminado es 10.</param>
        /// <returns>Una respuesta que contiene una lista de todas las series paginadas. Si la página o el tamaño de página son inválidos, devuelve un código de estado 400 Bad Request con un mensaje de error.</returns>
        /// <response code="200">Devuelve una lista paginada de series.</response>
        /// <response code="400">Devuelve un error si el número de página o el tamaño de página son inválidos.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaDto>>> GetAllSeries([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1)
            {
                return BadRequest("El número de página debe ser mayor o igual a 1.");
            }
            if (pageSize < 1)
            {
                return BadRequest("El tamaño de página debe ser mayor o igual a 1.");
            }
            var series = await _serieService.GetAllSeriesAsync(pageNumber, pageSize);
            return Ok(series);
        }

        /// <summary>
        /// Obtiene una serie por su ID.
        /// </summary>
        /// <param name="id">El ID de la serie.</param>
        /// <returns>La serie con el ID especificado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Media>> GetSeriesById(int id)
        {
            var series = await _serieService.GetSeriesByIdAsync(id);
            if (series == null)
                return NotFound();
            return Ok(series);
        }

        /// <summary>
        /// Crea una nueva serie.
        /// </summary>
        /// <param name="media">La serie que se va a crear.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSeries([FromBody] Media media)
        {
            if (media == null)
                return BadRequest();

            await _serieService.CreateSeriesAsync(media);
            return CreatedAtAction(nameof(GetSeriesById), new { id = media.Id }, media);
        }

        /// <summary>
        /// Actualiza una serie existente por su ID.
        /// </summary>
        /// <param name="id">El ID de la serie que se va a actualizar.</param>
        /// <param name="media">Los datos actualizados de la serie.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeries(int id, [FromBody] Media media)
        {
            if (media == null || media.Id != id)
                return BadRequest();

            await _serieService.UpdateSeriesAsync(id, media);
            return NoContent();
        }

        /// <summary>
        /// Elimina una serie por su ID.
        /// </summary>
        /// <param name="id">El ID de la serie que se va a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _serieService.DeleteSeriesAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Crea un nuevo episodio.
        /// </summary>
        /// <param name="episode">El episodio que se va a crear.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPost("episode")]
        public async Task<IActionResult> CreateEpisode([FromBody] Episode episode)
        {
            if (episode == null)
                return BadRequest();

            await _serieService.CreateEpisodeAsync(episode);
            return CreatedAtAction(nameof(GetSeriesById), new { id = episode.Id }, episode);
        }

        /// <summary>
        /// Elimina un episodio por su ID.
        /// </summary>
        /// <param name="id">El ID del episodio que se va a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpDelete("episode/{id}")]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            await _serieService.DeleteEpisodeAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza un episodio por su ID.
        /// </summary>
        /// <param name="id">El ID del episodio que se va a actualizar.</param>
        /// <param name="episode">Los datos actualizados del episodio.</param>
        /// <returns>Una respuesta que indica el resultado de la operación.</returns>
        [HttpPatch("episode/{id}")]
        public async Task<IActionResult> UpdateEpisode(int id, [FromBody] Episode episode)
        {
            if (episode == null || episode.Id != id)
                return BadRequest();

            await _serieService.UpdateEpisodeAsync(id, episode);
            return NoContent();
        }
    }
}
