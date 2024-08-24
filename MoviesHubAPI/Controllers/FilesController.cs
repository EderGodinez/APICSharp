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
        public FilesController(IFilesService fileService)
        {
            _fileService = fileService;
        }

        // GET api/<FilesController>/5
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

        // POST api/<FilesController>
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
        // DELETE api/<FilesController>/5

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

        
    

       

