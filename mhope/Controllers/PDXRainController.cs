using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace martyhope.com.Controllers
{
    [Route("api/pdxrainfall")]
    public class PdxRainController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<RainGauge.PDXRainGauge.PrecipitationData> Get()
        {
            return RainGauge.PDXRainGauge.pdxRainfallRecords.Value;

        }
    }
}