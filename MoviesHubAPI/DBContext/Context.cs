using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models;
using MoviesHubAPI.Models.Configurations;
using MoviesHubAPI.Services.DTOS;


namespace EntityFrameworkExample.Context
{
    public class ContextDB : DbContext, IContextDB
    {
        public ContextDB(DbContextOptions<ContextDB> options)
        : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodesListConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new GendersListConfiguration());
            modelBuilder.ApplyConfiguration(new MediaAvailibleInConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new SeasonConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserActionConfiguration());
            modelBuilder.Entity<TrendingDTO>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null); // No mapeado a una vista o tabla en la base de datos
            });
        }
        public DbSet<TrendingDTO> TrendingDTOs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Media> Series { get; set; } 
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GenderList> GenderLists { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeList> EpisodeLists { get; set; }
        public DbSet<UserAction> UserActions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MediaAvailibleIn> MediaAvailibleIn { get; set; }
    }
}
