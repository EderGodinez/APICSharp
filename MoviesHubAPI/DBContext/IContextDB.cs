using Microsoft.EntityFrameworkCore;
using MoviesHubAPI.Models.MediaF.MovieF;
using MoviesHubAPI.Models.MediaF.SerieF;
using MoviesHubAPI.Models.UserF;

namespace EntityFrameworkExample.Context
{
    public interface IContextDB
    {
        DbSet<User> Users { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Serie> Series { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(bool CancellationToken,CancellationToken cancellationToken = default);
    }
}
