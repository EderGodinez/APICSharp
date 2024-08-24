
using MoviesHubAPI.Models.MediaF.SerieF.SeasonF;

namespace MoviesHubAPI.Models.MediaF.SerieF
{
    public interface ISerie : IMedia
    {
        ICollection<Season> Seasons { get; set; }
    }
}
