

using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;

namespace MoviesHubAPI.Services.Series
{
    public interface ISerieService
    {
        Task<IEnumerable<MediaDto>> GetAllSeriesAsync(int pageNumber, int pageSize);
        Task<MediaDto> GetSeriesByIdAsync(int id);
        Task CreateSeriesAsync(Media media);
        Task UpdateSeriesAsync(int id, Media media);
        Task DeleteSeriesAsync(int id);
        Task CreateEpisodeAsync(Episode episode);
        Task DeleteEpisodeAsync(int id);
        Task UpdateEpisodeAsync(int id, Episode episode);
    }
}
