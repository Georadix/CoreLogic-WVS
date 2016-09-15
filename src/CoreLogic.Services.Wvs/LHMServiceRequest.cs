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
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps()
        {
            return GetAvailableMaps(null, null, null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateTime date)
        {
            return GetAvailableMaps(date, null, null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateRange dateRange)
        {
            return GetAvailableMaps(null, dateRange, null, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="regions">The regions.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(IEnumerable<string> regions)
        {
            return GetAvailableMaps(null, null, regions, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(GeoPoint point)
        {
            return GetAvailableMaps(null, null, null, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(GeoBounds bounds)
        {
            return GetAvailableMaps(null, null, null, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="regions">The regions.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateTime date, IEnumerable<string> regions)
        {
            return GetAvailableMaps(date, null, regions, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <param name="regions">The regions.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateRange dateRange, IEnumerable<string> regions)
        {
            return GetAvailableMaps(null, dateRange, regions, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateTime date, GeoPoint point)
        {
            return GetAvailableMaps(date, null, null, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateTime date, GeoBounds bounds)
        {
            return GetAvailableMaps(date, null, null, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateRange dateRange, GeoPoint point)
        {
            return GetAvailableMaps(null, dateRange, null, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateRange dateRange, GeoBounds bounds)
        {
            return GetAvailableMaps(null, dateRange, null, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="regions">The regions.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(IEnumerable<string> regions, GeoPoint point)
        {
            return GetAvailableMaps(null, null, regions, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="regions">The regions.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(IEnumerable<string> regions, GeoBounds bounds)
        {
            return GetAvailableMaps(null, null, regions, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateTime date, IEnumerable<string> regions, GeoPoint point)
        {
            return GetAvailableMaps(date, null, regions, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(DateTime date, IEnumerable<string> regions, GeoBounds bounds)
        {
            return GetAvailableMaps(date, null, regions, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="point">The point in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(
            DateRange dateRange, IEnumerable<string> regions, GeoPoint point)
        {
            return GetAvailableMaps(null, dateRange, regions, point, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve available maps.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <param name="regions">The regions.</param>
        /// <param name="bounds">The bounds in latitude/longitude coordinates.</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetAvailableMaps(
            DateRange dateRange, IEnumerable<string> regions, GeoBounds bounds)
        {
            return GetAvailableMaps(null, dateRange, regions, null, bounds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LHMServiceRequest"/> class used to retrieve a map.
        /// </summary>
        /// <param name="regionId">The region ID.</param>
        /// <param name="convectiveDate">The convective date.</param>
        /// <param name="returnType">The return type (i.e. GEOJSON, KMZ, PNG).</param>
        /// <returns>A <see cref="LHMServiceRequest"/> instance.</returns>
        public static LHMServiceRequest GetMap(string regionId, DateTime convectiveDate, string returnType = "GEOJSON")
        {
            var result = new LHMServiceRequest
            {
                convectiveDate = convectiveDate,
                convectiveDateSpecified = true,
                function = "GetMap",
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
            DateTime? date,
            DateRange dateRange,
            IEnumerable<string> regions,
            GeoPoint point,
            GeoBounds bounds)
        {
            var result = new LHMServiceRequest
            {
                DateRange = dateRange,
                function = "GetAvailableMaps",
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