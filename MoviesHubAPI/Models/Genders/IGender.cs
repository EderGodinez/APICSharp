using MoviesHubAPI.Models.Genders.GenderListF;

namespace MoviesHubAPI.Models.Genders
{
    public interface IGender 
    {
         int Id { get; set; }
         string Name { get; set; }

         ICollection<GenderList> GenderLists { get; set; }
    }
}
