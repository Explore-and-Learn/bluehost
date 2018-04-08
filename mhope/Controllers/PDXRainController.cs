using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RainGauge;

namespace martyhope.com.Controllers
{
    [Route("api/pdxrainfall")]
    public class PdxRainController : Controller
    {
        [HttpGet]
        public IEnumerable<PDXRainGauge.PrecipitationData> Get()
        {
            return PDXRainGauge.pdxRainfallRecords.Value.OrderByDescending(x => x.WaterYearAccumulation);

        }
    }
}