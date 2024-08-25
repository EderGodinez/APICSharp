
using EntityFrameworkExample.Context;
using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.Series;

namespace MoviesHubAPI.Services
{
    public class SerieService : ISerieService
    {
        private readonly ContextDB _context;

        public SerieService(ContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetAllSeriesAsync()
        {
            return await _context.Series
                .Include(m => m.GendersLists)
                .ThenInclude(gl => gl.Gender)
                .Where(m => m.TypeMedia == "series")
                .ToListAsync();
        }

        public async Task<Media> GetSeriesByIdAsync(int id)
        {
            var series = await _context.Series
                .Include(m => m.GendersLists)
                .ThenInclude(gl => gl.Gender)
                .FirstOrDefaultAsync(m => m.Id == id && m.TypeMedia == "series");

            if (series == null)
                return null;

            var episodes = await _context.Episodes
        .Join(_context.EpisodeLists,
            e => e.Id,
            el => el.Episode.Id,  // Use the correct property name for the join
            (e, el) => new { e, el })
        .Where(joined => joined.el.Seasonld == series.Id)  // Use the correct property name for the join condition
        .Select(joined => joined.e)
        .ToListAsync();

            series.Episodes = episodes;

            return series;
        }

        public async Task CreateSeriesAsync(Media media)
        {
            _context.Series.Add(media);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSeriesAsync(int id, Media media)
        {
            var existingSeries = await _context.Series.FindAsync(id);

            if (existingSeries == null)
                return;

            // Update the existing series with new data
            _context.Entry(existingSeries).CurrentValues.SetValues(media);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeriesAsync(int id)
        {
            var series = await _context.Series.FindAsync(id);

            if (series == null)
                return;

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
        }

        public async Task CreateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEpisodeAsync(int id)
        {
            var episode = await _context.Episodes.FindAsync(id);

            if (episode == null)
                return;

            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEpisodeAsync(int id, Episode episode)
        {
            var existingEpisode = await _context.Episodes.FindAsync(id);

            if (existingEpisode == null)
                return;

            // Update the existing episode with new data
            _context.Entry(existingEpisode).CurrentValues.SetValues(episode);
            await _context.SaveChangesAsync();
        }
    }
}
