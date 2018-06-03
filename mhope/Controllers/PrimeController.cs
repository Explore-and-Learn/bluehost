using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace martyhope.com.Controllers
{
    [Produces("application/json")]
    [Route("api/Prime")]
    public class PrimeController : Controller
    {
        private readonly IPrimeNumberService _service; 

        public PrimeController(IPrimeNumberService service)
        {
            _service = service;

        }
       
        // GET: api/Prime/5
        [HttpGet("{candidate}", Name = "Get")]
        public async Task<IActionResult> Get(int candidate)
        {
            var result = await _service.IsPrime(candidate);
            return new OkObjectResult(result);
        }
    }
}
