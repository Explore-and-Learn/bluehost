using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace martyhope.com.Controllers
{
    /// <summary>
    /// Simple controller that tests for primality
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/Prime")]
    public class PrimeController : Controller
    {
        private readonly IPrimeNumberService _service; 

        public PrimeController(IPrimeNumberService service)
        {
            _service = service;

        }
       
        /// <summary>
        /// Simple API that tests a candidate integer for primality
        /// </summary>
        /// <param name="candidate">integer </param>
        /// <returns>true if candidate is a prime number, otherwise false</returns>
        [HttpGet("{candidate}", Name = "Get")]
        public async Task<IActionResult> Get(int candidate)
        {
            var result = await _service.IsPrime(candidate);
            return new OkObjectResult(result);
        }
    }
}
