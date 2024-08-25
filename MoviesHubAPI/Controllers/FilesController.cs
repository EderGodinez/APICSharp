using Microsoft.AspNetCore.Mvc;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.Files;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _fileService;
        /// <summary>
        /// Inicializa una nueva instancia del controlador <see cref="FilesController"/>.
        /// </summary>
        /// <param name="fileService">Servicio para manejar operaciones de archivos.</param>
        public FilesController(IFilesService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Obtiene un archivo por su identificador.
        /// </summary>
        /// <param name="id">El identificador del archivo.</param>
        /// <returns>El archivo si se encuentra; de lo contrario, un mensaje de error.</returns>
        /// <response code="200">Devuelve el archivo solicitado.</response>
        /// <response code="404">Si el archivo no se encuentra.</response>
        /// <response code="500">Si ocurre un error interno en el servidor.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(string id)
        {
            try
            {
                var fileContentResult = await _fileService.GetImageByPath(id);
                if (fileContentResult == null)
                {
                    return NotFound(new { Message = "Archivo no encontrado" });
                }
                return fileContentResult;
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Error interno del servidor: {ex.Message}" });
            }
        }

        /// <summary>
        /// Sube un nuevo archivo.
        /// </summary>
        /// <param name="model">El modelo que contiene el archivo a subir.</param>
        /// <returns>La ruta del archivo subido si tiene éxito; de lo contrario, un mensaje de error.</returns>
        /// <response code="200">Devuelve la ruta del archivo subido.</response>
        /// <response code="400">Si el archivo no es válido o no se puede subir.</response>
        [HttpPost]
        public async Task<IActionResult> UploadFile(FileUploadModel model)
        {
            var file = model.File;
            try
            {
                var path = await _fileService.SaveFileAsync(file);
                return Ok(new { Message = "El archivo se subió exitosamente", FilePath = path });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        /// <summary>
        /// Elimina un archivo por su identificador.
        /// </summary>
        /// <param name="id">El identificador del archivo.</param>
        /// <returns>Un mensaje de éxito o un error.</returns>
        /// <response code="200">Si el archivo se elimina con éxito.</response>
        /// <response code="400">Si el identificador no es válido o el archivo no se puede eliminar.</response>
        /// <response code="500">Si ocurre un error interno en el servidor.</response>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            try
            {
                return await _fileService.DeleteFile(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Error interno del servidor: {ex.Message}" });
            }
        }
    }
}

        
    

       

