namespace CoreLogic.Services.Wvs
{
    using System;
    using System.Linq;
    using Xunit;

    public class LHMServiceRequestFixture
    {
        [Fact]
        public void GetAvailableMapsSupportsAllWeatherMapTypes()
        {
            var mapTypes = Enum.GetValues(typeof(WeatherMapType)).Cast<WeatherMapType>();

            foreach (var mapType in mapTypes)
            {
                var request = LHMServiceRequest.GetAvailableMaps(mapType);

                Assert.NotEmpty(request.function);
            }
        }

        [Fact]
        public void GetMapSupportsAllWeatherMapTypes()
        {
            var mapTypes = Enum.GetValues(typeof(WeatherMapType)).Cast<WeatherMapType>();

            foreach (var mapType in mapTypes)
            {
                var request = LHMServiceRequest.GetMap(mapType, "FDR", DateTime.Now);

                Assert.NotEmpty(request.function);
            }
        }
    }
}