using Microsoft.AspNetCore.Mvc;
namespace MoviesHubAPI.Services.Files
{
    public class FilesService :IFilesService
    {
        private readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png",".bmp" ,".webp"}; 
        private readonly long _fileSizeLimit = 10 * 1024 * 1024; // 10 MB
        private readonly string _uploadPath = "uploads/";

        public async Task<IActionResult> DeleteFile(string id)
        {
            try
            {
                var path = _uploadPath + id;
                if (string.IsNullOrEmpty(id) || !File.Exists(path))
                {
                    return new NotFoundObjectResult(new { Message = "Archivo no encontrado" });
                }

                File.Delete(path);
                return new OkObjectResult(new { Message = "Archivo eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { Message = $"Error al eliminar el archivo: {ex.Message}" });
            }
        }

        public async Task<FileContentResult> GetImageByPath(string id)
        {
            try {
                String path = _uploadPath + id;
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    throw new FileNotFoundException($"Archivo {id} no existe");
                }

                var fileBytes = await File.ReadAllBytesAsync(path);
                var contentType = GetContentType(path);

                return new FileContentResult(fileBytes, contentType)
                {
                    FileDownloadName = Path.GetFileName(path)
                };
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el archivo: {ex.Message}");
            }
            
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("Ningun archivo a sido subido");
                }
                if (file.Length > _fileSizeLimit)
                {
                    throw new ArgumentException($"El archivo no puede sobrepasar el limite de {_fileSizeLimit / (1024 * 1024)}MB");
                }

                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(ext) || !_permittedExtensions.Contains(ext))
                {
                    throw new ArgumentException($"Archivo con extencion invalida\nExtenciones validas {string.Join(", ", _permittedExtensions)}");


                }
                var path = _uploadPath+file.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return path;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }

        }
        private string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream",
            };
        }
    }

}
