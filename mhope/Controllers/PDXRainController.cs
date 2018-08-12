using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RainGauge;

namespace martyhope.com.Controllers
{
    /// <summary>
    /// Retrieves data from City of Portland HYDRA Rainfall Network web site
    /// </summary>
    [Route("api/v1/raintotals")]
    public class PdxRainController : Controller
    {
        /// <summary>
        /// Return all of the reporting stations data ordered by the water accumulation result
        /// </summary>
        /// <returns cref="PDXRainGauge.PrecipitationData"/>
        [HttpGet]
        public async Task<IActionResult> GetAllOrderedByWaterYearAccumulationAmount()
        {
            var result = await Task<IEnumerable<PDXRainGauge.PrecipitationData>>.Factory.StartNew(
                () =>
                {
                    try
                    {
                        IEnumerable<PDXRainGauge.PrecipitationData> pdxRainData = RainGauge.PDXRainGauge.pdxRainfallRecords.Value;
                        return pdxRainData.OrderByDescending(x => x.WaterYearAccumulation);
                    }
                    catch
                    {
                        return null;
                    }

                }, CancellationToken.None);
            return result == null ? (IActionResult)NotFound() : Ok(result);

        }
        /// <summary>
        /// Take a stationid query string parameter and returns the data for just that station
        /// </summary>
        /// <param name="stationNumber">station number</param>
        ///  <returns cref="PDXRainGauge.PrecipitationData"/>

        [HttpGet("{stationNumber}")]
        public async Task<IActionResult> GetStationData(int stationNumber)
        {
            var result  = await Task<PDXRainGauge.PrecipitationData>.Factory.StartNew(
                () =>
                {
                    return RainGauge.PDXRainGauge.pdxRainfallRecords.Value.FirstOrDefault(x => x.StationNumber == stationNumber);
                }, CancellationToken.None);
            return result == null ? (IActionResult)NotFound($"Station number {stationNumber} does not exist.") : Ok(result);
        }
    }
}