using System.Threading.Tasks;
using AirQuality.Domain.Feed;
using AirQuality.Domain.Standard.Feed;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace martyhope.com.Controllers
{
    /// <summary>
    /// Retrieves air quality readings for US locations
    /// RSS feed location: http://feeds.enviroflash.info/rss/realtime/{locationId}.xml
    /// </summary>
    [Route("api/v1/[controller]")]
    public class AirQualityController : Controller
    {
        private const string EmptyResults = "Empty";
        private readonly FeedParser _parser = new FeedParser();

        // GET api/AirQuality/116 - return Portland, OR
        /// <summary>
        /// Get air quality reading for a location based on that location's id
        /// </summary>
        /// <param name="id">Id of location</param>
        /// <returns cref="AirQuality.Domain.Standard.Feed.AirQuality"></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var results = await _parser.Parse(id, FeedType.Rss);
            return results.ToString() != EmptyResults
                ? (IActionResult)Ok(results)
                : NotFound($"No results returned for {id}");
        }
    }
}
