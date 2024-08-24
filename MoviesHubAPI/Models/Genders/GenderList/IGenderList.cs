using MoviesHubAPI.Models.MediaF;

namespace MoviesHubAPI.Models.Genders.GenderListF
{
    public interface IGenderList
    {
         int MediaId { get; set; }
         Media Media { get; set; }
         int GenderId { get; set; }
         Gender Gender { get; set; }

    }
}
