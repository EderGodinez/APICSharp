using Microsoft.AspNetCore.Mvc;

namespace MoviesHubAPI.Services.Files
{
    public interface IFilesService
    {
        Task<string> SaveFileAsync(IFormFile file);
        Task<FileContentResult> GetImageByPath(String id);

        Task<IActionResult> DeleteFile(String id);
    }
}
