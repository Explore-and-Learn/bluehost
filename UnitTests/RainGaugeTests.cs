using System;
using System.Linq;
using Xunit;


namespace UnitTests
{
    public class RainGaugeTests
    {
        [Fact]
        public void TestDataIsReturned()
        {
            var sut = RainGauge.PDXRainGauge.pdxRainfallRecords.Value;
            Assert.True(sut != null);
        }

        [Fact]
        public void TestOnlyNonReportingStationsAreReturned()
        {
            var sut = RainGauge.PDXRainGauge.pdxRainfallRecords.Value;
            Assert.True(sut.All(s => s.WaterYearAccumulation.CompareTo(0.0d) == 1));
        }
    }
}
