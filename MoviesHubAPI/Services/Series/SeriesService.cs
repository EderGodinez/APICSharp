using EntityFrameworkExample.Context;

namespace MoviesHubAPI.Services.Series
{
    public class SeriesService:ISeriesService
    {
        private readonly IContextDB _context;
        public SeriesService(ContextDB context)
        {
            _context = context;
        }
    }
}
