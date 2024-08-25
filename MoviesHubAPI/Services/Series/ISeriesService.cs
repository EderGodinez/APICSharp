

using MoviesHubAPI.Models;

namespace MoviesHubAPI.Services.Series
{
    public interface ISerieService
    {
        Task<IEnumerable<Media>> GetAllSeriesAsync();
        Task<Media> GetSeriesByIdAsync(int id);
        Task CreateSeriesAsync(Media media);
        Task UpdateSeriesAsync(int id, Media media);
        Task DeleteSeriesAsync(int id);
        Task CreateEpisodeAsync(Episode episode);
        Task DeleteEpisodeAsync(int id);
        Task UpdateEpisodeAsync(int id, Episode episode);
    }
}
