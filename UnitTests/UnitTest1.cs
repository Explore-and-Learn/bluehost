using System;
using System.Linq;
using Xunit;


namespace UnitTests
{
    public class RainGaugeTests
    {
        [Fact]
        public void TestPDXRangeGaugeCollection()
        {
            var gauge = RainGauge.PDXRainGauge.pdxRainfallRecords.Value.ToList();
            Assert.True(gauge != null);
            //Assert.Collection(gauge, x =>
            //{
            //  Assert.True(x.StationNumber > 0,
            //        $"StationNumber property should be greater than 0 but {x.StationNumber} was returned.");

            //});

    }
    }
}
