
using EntityFrameworkExample.Context;
using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;
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

        public async Task<IEnumerable<MediaDto>> GetAllSeriesAsync(int pageNumber, int pageSize)
        {
            //Obtengo los IDs de las series con paginación
            int[] ids = await _context.Series
            .Where(m => m.TypeMedia == "series")
            .Select(m => m.Id)
            .OrderBy(id => id) 
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize)
            .ToArrayAsync();
            var Series = new List<MediaDto>();
            foreach (var id in ids)
            {
                var series = await GetSeriesByIdAsync(id);
                if (series != null)
                {
                    Series.Add(series);
                }
            }
            return Series;
        }

        public async Task<MediaDto> GetSeriesByIdAsync(int id)
        {
            var series = await _context.Series
    .Include(m => m.GendersLists)
        .ThenInclude(gl => gl.Gender)
    .Include(m => m.MediaAvailibleIns)
        .ThenInclude(ma => ma.Platform)
    .Include(m => m.Seasons)
        .ThenInclude(s => s.EpisodesLists)
        .ThenInclude(el => el.Episode)
     .Include(m => m.Ratings)
    .FirstOrDefaultAsync(m => m.Id == id && m.TypeMedia == "series");

            if (series == null)
                return null;

            series.GendersLists = series.GendersLists
                .Select(gl => new GenderList { Gender = new Gender { Name = gl.Gender.Name } })
                .ToList();

            series.MediaAvailibleIns = series.MediaAvailibleIns
                .Select(ma => new MediaAvailibleIn { Platform = new Platform { Name = ma.Platform.Name } })
                .ToList();

            var groupedEpisodes = series.Seasons
                .Select(season => new
                {
                    SeasonId = season.Seasonld,
                    NumSeason = season.NumSeason,
                    Episodes = season.EpisodesLists.Select(el => el.Episode).ToList()
                })
                .ToList();

            // Mapeo del objeto DTO
            return new MediaDto
            {
                Id = series.Id,
                Title = series.Title,
                OriginalTitle = series.OriginalTitle,
                Overview = series.Overview,
                ImagePath = series.ImagePath,
                PosterImage = series.PosterImage,
                TrailerLink = series.TrailerLink,
                WatchLink = series.WatchLink,
                AddedDate = series.AddedDate,
                TypeMedia = series.TypeMedia,
                RelaseDate = series.RelaseDate,
                AgeRate = series.AgeRate,
                IsActive = series.IsActive,
                GendersLists = series.GendersLists.Select(gl => gl.Gender.Name).ToList(),
                MediaAvailibleIns = series.MediaAvailibleIns.Select(ma => ma.Platform.Name).ToList(),
                Seasons = groupedEpisodes.Select(season => new SeasonDto
                {
                    SeasonId = season.SeasonId,
                    NumSeason = season.NumSeason,
                    Episodes = season.Episodes.Select(e => new EpisodeDto
                    {
                        Id = e.Id,  
                        Title = e.Title,
                        Overview = e.Overview,
                        E_Num = e.E_Num,  
                        Duration = e.Duration,
                        ImagePath = e.ImagePath,
                        AddedDate = e.AddedDate,
                        WatchLink = e.WatchLink,
                        RelaseDate = e.RelaseDate
                    }).ToList()
                }).ToList(),
                Rating = series.Ratings != null && series.Ratings.Count > 0 ? (float)series.Ratings.Average(r => r.Rate) : null,
                Votes = series.Ratings?.Count ?? 0
            };
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

            _context.Entry(existingEpisode).CurrentValues.SetValues(episode);
            await _context.SaveChangesAsync();
        }
    }
}
