namespace CoreLogic.Services.Wvs
{
    using Georadix.Core;
    using Georadix.WebApi.Testing;
    using Moq;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Xml.Serialization;
    using Xunit;

    public class WvsClientFixture : IDisposable
    {
        private readonly Mock<IWvsConfig> config = new Mock<IWvsConfig>(MockBehavior.Strict);
        private readonly FakeResponseHandler fakeResponseHandler;
        private readonly WvsClient sut;
        private bool disposed = false;

        public WvsClientFixture()
        {
            this.config.Setup(c => c.ApiKey).Returns("apiKey");
            this.config.Setup(c => c.ClientId).Returns("clientId");
            this.config.Setup(c => c.EndpointUrl).Returns("https://services.wvs.corelogic.com/");
            this.config.Setup(c => c.Timeout).Returns(10);

            this.fakeResponseHandler = new FakeResponseHandler();

            this.sut = new WvsClient(this.config.Object, this.fakeResponseHandler);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WvsClientFixture"/> class.
        /// </summary>
        ~WvsClientFixture()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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

            var request = LHMServiceRequest.GetAvailableMaps(
                WeatherMapType.Hail, dateRange, new string[] { "FDR", "TLX", "VNX", "ICT" });

            var result = sut.GetResponse(request).HailMaps;

            Assert.Equal(1, result.Count());

            var map = result.First();

            Assert.Equal("1", map.category);
            Assert.Equal(34.362, (double)map.centerLat);
            Assert.Equal(-98.976, (double)map.centerLon);
            Assert.Equal("March 19th, 2015 - Wichita Falls - TX", map.displayName);
            Assert.Equal("2015-03-19T12:00:00", map.convectiveDate.ToString("s"));
            Assert.Equal("2017-03-26T21:27:00", map.lastUpdated.ToString("s"));
            Assert.Equal("FDR", map.region);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetAvailableWindMapsReturnsWindMaps()
        {
            var sut = new WvsClient(this.config.Object);

            var dateRange = new DateRange()
            {
                EndDate = new DateTime(2015, 03, 20),
                StartDate = new DateTime(2015, 02, 18)
            };

            var request = LHMServiceRequest.GetAvailableMaps(
                WeatherMapType.Wind, dateRange);

            var result = sut.GetResponse(request).WindMaps;

            Assert.True(result.Count() > 0);

            var map = result.First();

            Assert.Equal(45, map.maxSpeed.Value);
            Assert.Equal("mph", map.maxSpeed.units);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetHailMapReturnsHailMap()
        {
            var sut = new WvsClient(this.config.Object);

            var request = LHMServiceRequest.GetMap(
                WeatherMapType.Hail, "FDR", DateTime.Parse("2015-03-25T12:00:00"), "GEOJSON");

            var result = sut.GetMap(request);

            // To save the contents to a file, uncomment the following lines:
            // var bytes = new byte[result.Length];
            // result.Read(bytes, 0, bytes.Length);
            // File.WriteAllBytes(@"d:\data\storm.kmz", bytes);
            Assert.Equal(236298, result.Length);
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

        [Fact]
        public void GetResponseReturnsExpectedResult()
        {
            var dateRange = new DateRange()
            {
                EndDate = new DateTime(2015, 03, 20),
                StartDate = new DateTime(2015, 03, 18)
            };

            var request = LHMServiceRequest.GetAvailableMaps(
                WeatherMapType.Hail, dateRange, new string[] { "FDR", "TLX", "VNX", "ICT" });

            var expectedResponse = new LHMResponse()
            {
                HailMaps = new HailMap[]
                {
                    new HailMap()
                    {
                        category = "2",
                        centerLat = 45.5M,
                        centerLon = -75.7M,
                        convectiveDate = DateTime.Parse("2015-03-19T12:00:00"),
                        displayName = "A storm",
                        lastUpdated = DateTime.Parse("2017-03-26T21:27:00"),
                        region = "REG"
                    }
                },
                StatusCode = new StatusCode() { Value = "1" }
            };

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(string.Format(
                    "{0}",
                    this.config.Object.EndpointUrl)),
                (requestContent) =>
                {
                    var expectedRequest = request;
                    var actualRequest = DeserializeObject<LHMServiceRequest>(requestContent);

                    Assert.True(
                        new GenericEqualityComparer<LHMServiceRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SerializeObject(expectedResponse), Encoding.Unicode, "application/xml")
                    };
                });

            var actualResponse = this.sut.GetResponse(request);

            Assert.True(
                new GenericEqualityComparer<LHMResponse>().Equals(expectedResponse, actualResponse));
        }

        [Fact]
        public void GetResponseWithInvalidStatusCodeThrowsWvsException()
        {
            var request = LHMServiceRequest.GetRegions();

            var response = new LHMResponse()
            {
                StatusCode = new StatusCode() { Value = "0" }
            };

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(string.Format(
                    "{0}",
                    this.config.Object.EndpointUrl)),
                (requestContent) =>
                {
                    var expectedRequest = request;
                    var actualRequest = DeserializeObject<LHMServiceRequest>(requestContent);

                    Assert.True(
                        new GenericEqualityComparer<LHMServiceRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SerializeObject(response), Encoding.Unicode, "application/xml")
                    };
                });

            Assert.Throws<WvsException>(() => this.sut.GetResponse(request));
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetWindMapReturnsWindMap()
        {
            var sut = new WvsClient(this.config.Object);

            var request = LHMServiceRequest.GetMap(
                WeatherMapType.Wind, "FDR", DateTime.Parse("2015-03-25T12:00:00"), "GEOJSON");

            var result = sut.GetMap(request);

            // To save the contents to a file, uncomment the following lines:
            // var bytes = new byte[result.Length];
            // result.Read(bytes, 0, bytes.Length);
            // File.WriteAllBytes(@"d:\data\wind-storm.json", bytes);
            Assert.Equal(1602620, result.Length);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.sut.Dispose();
                    this.fakeResponseHandler.Dispose();
                }

                this.disposed = true;
            }
        }

        private T DeserializeObject<T>(string value)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var textReader = new StringReader(value))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        private string SerializeObject<T>(T value)
        {
            var xmlSerializer = new XmlSerializer(value.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, value);
                return textWriter.ToString();
            }
        }
    }
}
