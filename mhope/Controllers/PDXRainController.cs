using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RainGauge;

namespace martyhope.com.Controllers
{
    [Route("api/pdxrainfall")]
    public class PdxRainController : Controller
    {
        /// <summary>
        /// Return all of the reporting stations data ordered by the water accumulation result
        /// </summary>
        /// <returns cref="IEnumerable&lt;PDXRainGauge.PrecipitationData&gt;"/>
        [HttpGet]
        public async Task<IEnumerable<PDXRainGauge.PrecipitationData>> GetAllOrderedByWaterYearAccumulationAmount()
        {
            return await Task<IEnumerable<PDXRainGauge.PrecipitationData>>.Factory.StartNew(
                () =>
                {
                    IEnumerable<PDXRainGauge.PrecipitationData> pdxRainData = RainGauge.PDXRainGauge.pdxRainfallRecords.Value;
                    return pdxRainData.OrderByDescending(x => x.WaterYearAccumulation);
                }, CancellationToken.None);

        }

        /// <summary>
        /// Return the requested number of reporting stations data ordered by the water accumulation result
        /// </summary>
        /// <returns cref="IEnumerable&lt;PDXRainGauge.PrecipitationData&gt;"/>
        [HttpGet("{i}")]
        public IEnumerable<PDXRainGauge.PrecipitationData> Get(int i)
        {
            IEnumerable<PDXRainGauge.PrecipitationData> pdxRainData = RainGauge.PDXRainGauge.pdxRainfallRecords.Value;
            return pdxRainData.OrderByDescending(x => x.WaterYearAccumulation).Take(i);

        }
    }
}