namespace CoreLogic.Services.Wvs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Represents a WVS service request.
    /// </summary>
    public partial class LHMServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType)
        {
            return GetAvailableMaps(mapType, null, null, null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="date">The date.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateTime date)
        {
            return GetAvailableMaps(mapType, date, null, null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="dateRange">The date range.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateRange dateRange)
        {
            return GetAvailableMaps(mapType, null, dateRange, null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="regions">The regions.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, IEnumerable<string> regions)
        {
            return GetAvailableMaps(mapType, null, null, regions, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, GeoPoint point)
        {
            return GetAvailableMaps(mapType, null, null, null, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, GeoBounds bounds)
        {
            return GetAvailableMaps(mapType, null, null, null, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="date">The date.</param>
        /// <param name="regions">The regions.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateTime date, IEnumerable<string> regions)
        {
            return GetAvailableMaps(mapType, date, null, regions, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="dateRange">The date range.</param>
        /// <param name="regions">The regions.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateRange dateRange, IEnumerable<string> regions)
        {
            return GetAvailableMaps(mapType, null, dateRange, regions, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="date">The date.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateTime date, GeoPoint point)
        {
            return GetAvailableMaps(mapType, date, null, null, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="date">The date.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateTime date, GeoBounds bounds)
        {
            return GetAvailableMaps(mapType, date, null, null, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="dateRange">The date range.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateRange dateRange, GeoPoint point)
        {
            return GetAvailableMaps(mapType, null, dateRange, null, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="dateRange">The date range.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateRange dateRange, GeoBounds bounds)
        {
            return GetAvailableMaps(mapType, null, dateRange, null, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, IEnumerable<string> regions, GeoPoint point)
        {
            return GetAvailableMaps(mapType, null, null, regions, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, IEnumerable<string> regions, GeoBounds bounds)
        {
            return GetAvailableMaps(mapType, null, null, regions, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="date">The date.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateTime date, IEnumerable<string> regions, GeoPoint point)
        {
            return GetAvailableMaps(mapType, date, null, regions, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="date">The date.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(WeatherMapType mapType, DateTime date, IEnumerable<string> regions, GeoBounds bounds)
        {
            return GetAvailableMaps(mapType, date, null, regions, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="dateRange">The date range.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(
            WeatherMapType mapType, DateRange dateRange, IEnumerable<string> regions, GeoPoint point)
        {
            return GetAvailableMaps(mapType, null, dateRange, regions, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="dateRange">The date range.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(
            WeatherMapType mapType, DateRange dateRange, IEnumerable<string> regions, GeoBounds bounds)
        {
            return GetAvailableMaps(mapType, null, dateRange, regions, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve a map.
        /// </summary>
        /// <param name="mapType">The type of weather map.</param>
        /// <param name="regionId">The region ID.</param>
        /// <param name="convectiveDate">The convective date.</param>
        /// <param name="returnType">The return type (i.e. GEOJSON, KMZ, PNG).</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetMap(
            WeatherMapType mapType, string regionId, DateTime convectiveDate, string returnType = "GEOJSON")
        {
            var result = new LHMServiceRequest
            {
                convectiveDate = convectiveDate,
                convectiveDateSpecified = true,
                function = LHMServiceRequest.GetMapFunctionFromMapType(mapType),
                idRegion = regionId,
                returnType = returnType
            };

            return result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve regions.
        /// </summary>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetRegions()
        {
            return GetRegions(null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve regions.
        /// </summary>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetRegions(GeoPoint point)
        {
            return GetRegions(point, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve regions.
        /// </summary>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetRegions(GeoBounds bounds)
        {
            return GetRegions(null, bounds, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve regions.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetRegions(address address)
        {
            return GetRegions(null, null, address);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve regions.
        /// </summary>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetRegions(GeoPoint point, address address)
        {
            return GetRegions(point, null, address);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve regions.
        /// </summary>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetRegions(GeoBounds bounds, address address)
        {
            return GetRegions(null, bounds, address);
        }

        /// <summary>
        /// Sets the request token.
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="apiKey">The API key.</param>
        public void SetRequestToken(string clientId, string apiKey)
        {
            this.RequestToken = new RequestToken { idUser = clientId, key = apiKey };
        }

        private static LHMServiceRequest GetAvailableMaps(
            WeatherMapType mapType,
            DateTime? date,
            DateRange dateRange,
            IEnumerable<string> regions,
            GeoPoint point,
            GeoBounds bounds)
        {
            var result = new LHMServiceRequest
            {
                DateRange = dateRange,
                function = LHMServiceRequest.GetAvailableMapsFunctionFromMapType(mapType),
                GeoBounds = bounds,
                GeoPoint = point,
                Regions = GetRegionString(regions)
            };

            if (date.HasValue)
            {
                result.Date = date.Value;
                result.DateSpecified = true;
            }

            return result;
        }

        private static string GetAvailableMapsFunctionFromMapType(WeatherMapType mapType)
        {
            switch (mapType)
            {
                case WeatherMapType.Hail:
                    return "GetAvailableMaps";

                case WeatherMapType.Wind:
                    return "GetAvailableWindMaps";

                default:
                    throw new NotSupportedException(string.Format(
                        "The specified map type {0} is not supported.", mapType.ToString()));
            }
        }

        private static string GetMapFunctionFromMapType(WeatherMapType mapType)
        {
            switch (mapType)
            {
                case WeatherMapType.Hail:
                    return "GetMap";

                case WeatherMapType.Wind:
                    return "GetWindMap";

                default:
                    throw new NotSupportedException(string.Format(
                        "The specified map type {0} is not supported.", mapType.ToString()));
            }
        }

        private static LHMServiceRequest GetRegions(
            GeoPoint point,
            GeoBounds bounds,
            address address)
        {
            var result = new LHMServiceRequest
            {
                address = address,
                function = "GetRegions",
                GeoBounds = bounds,
                GeoPoint = point
            };

            return result;
        }

        private static string GetRegionString(IEnumerable<string> regions)
        {
            return ((regions == null) || (regions.Count() == 0)) ? null : string.Join(",", regions);
        }
    }
}