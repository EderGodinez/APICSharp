using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models;
using MoviesHubAPI.Services.DTOS;


namespace EntityFrameworkExample.Context
{
    public interface IContextDB
    {
        DbSet<TrendingDTO> TrendingDTOs { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Media> Series { get; set; }  
        DbSet<Platform> Platforms { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<GenderList> GenderLists { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Episode> Episodes { get; set; }
        DbSet<EpisodeList> EpisodeLists { get; set; }
        DbSet<UserAction> UserActions { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<MediaAvailibleIn> MediaAvailibleIn { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(bool CancellationToken,CancellationToken cancellationToken = default);
    }
}
