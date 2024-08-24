
using MoviesHubAPI.Models.Genders.GenderListF;

namespace MoviesHubAPI.Models.Genders
{
    public class Gender 
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GenderList> GenderLists { get; set; }
    }
}
