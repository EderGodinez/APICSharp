using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        // GET: api/<SeriesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SeriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("/episode")]
        public void AddEpisode([FromBody] string value)
        {
        }
        [HttpPut("/episode/{id}")]
        public void UpdateEpisode(int id, [FromBody] string value)
        {
        }
        [HttpDelete("/episode/{id}")]
        public void DeleteEpisode(int id)
        {
        }

    }
}
