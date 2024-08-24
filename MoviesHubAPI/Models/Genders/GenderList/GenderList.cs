using MoviesHubAPI.Models.MediaF;

namespace MoviesHubAPI.Models.Genders.GenderListF
{
    public class GenderList : IGenderList
    {
        public int MediaId { get; set; }
        public Media Media { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
