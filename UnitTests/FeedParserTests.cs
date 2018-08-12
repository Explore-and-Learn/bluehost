using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AirQuality.Domain.Feed;
using AirQuality.Domain.Standard.Feed;
using Xunit;

namespace UnitTests
{
    public class FeedParserTests
    {
        [Fact]
        public async Task TestRssParser()
        {
            var validFeeds = new Dictionary<int, AirQuality.Domain.Standard.Feed.AirQuality>();
            //use 900 when populating data
            for (int j = 1; j < 10; j++)
            {
                var parser = new FeedParser();
                var airQuality = await parser.Parse(j, FeedType.Rss);
                if (!(airQuality is NullAirQuality))
                {
                    validFeeds.Add(j, airQuality);
                }
            }

            Assert.True(validFeeds.Count > 0);

        }

        [Fact]
        public void TestLocationRegex()
        {
            var airQuality = new TestAirQuality();
            var match = Regex.Match(airQuality.ParticlePollution, @"^.*- (\d+)");
            airQuality.ParticlePollution = match.Value.Substring(match.Value.IndexOf('-') + 1).Trim();


            Assert.True(match.Value == "Good  - 12");
            Assert.True(airQuality.ParticlePollution == "12");
        }
    }



    public class TestAirQuality : AirQuality.Domain.Standard.Feed.AirQuality
    {
        public TestAirQuality()
        {
            ParticlePollution = "Good  - 12 AQI - Particle Pollution (2.5 microns)";
        }
    }
}