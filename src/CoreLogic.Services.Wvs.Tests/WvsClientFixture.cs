namespace CoreLogic.Services.Wvs
{
    using Moq;
    using System;
    using System.Linq;
    using Xunit;

    public class WvsClientFixture
    {
        private readonly Mock<IWvsConfig> config = new Mock<IWvsConfig>(MockBehavior.Strict);

        public WvsClientFixture()
        {
            this.config.Setup(c => c.ApiKey).Returns("Your WVS API key.");
            this.config.Setup(c => c.ClientId).Returns("Your WVS client ID.");
            this.config.Setup(c => c.EndpointUrl).Returns("https://services.wvs.corelogic.com/services/endpoint.php");
            this.config.Setup(c => c.Timeout).Returns(100);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetAvailableMapsReturnsHailMaps()
        {
            var sut = new WvsClient(this.config.Object);

            var dateRange = new DateRange()
            {
                EndDate = new DateTime(2015, 03, 20),
                StartDate = new DateTime(2015, 03, 18)
            };

            var request = LHMServiceRequest.GetAvailableMaps(dateRange, new string[] { "FDR", "TLX", "VNX", "ICT" });

            var result = sut.GetResponse(request).HailMaps;

            Assert.Equal(1, result.Count());

            var map = result.First();

            Assert.Equal("1", map.category);
            Assert.Equal("2015-03-19 12:00:00", map.convectiveDate.ToString());
            Assert.Equal("2016-03-25 21:08:23", map.lastUpdated.ToString());
            Assert.Equal("FDR", map.region);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetMapReturnsMap()
        {
            var sut = new WvsClient(this.config.Object);

            var request = LHMServiceRequest.GetMap("FDR", DateTime.Parse("2015-03-25T12:00:00"), "KMZ");

            var result = sut.GetMap(request);

            // To save the contents to a file, uncomment the following lines:
            // var bytes = new byte[result.Length];
            // result.Read(bytes, 0, bytes.Length);
            // File.WriteAllBytes(@"d:\data\storm.kmz", bytes);
            Assert.Equal(56066, result.Length);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetRegionsReturnsRegions()
        {
            var sut = new WvsClient(this.config.Object);

            var bounds = new GeoBounds()
            {
                EastLon = 180,
                NorthLat = 90,
                SouthLat = -90,
                WestLon = -180
            };

            var request = LHMServiceRequest.GetRegions(bounds);

            var result = sut.GetResponse(request).Regions;

            Assert.Equal(156, result.Count());

            var region = result.First();
            var info = region.GetRegionInfo();

            Assert.Equal("Bethel", info.Name);
            Assert.Equal("AK", info.StateCode);
            Assert.Equal(
                "POLYGON ((-164.73 62.19, -159.02 62.19, -159.02 59.4, -164.73 59.4, -164.73 62.19))",
                region.GetPolygonWkt());
        }
    }
}