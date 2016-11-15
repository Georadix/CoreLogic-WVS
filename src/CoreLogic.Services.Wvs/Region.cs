namespace CoreLogic.Services.Wvs
{
    using GeoAPI.Geometries;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a region.
    /// </summary>
    public partial class Region
    {
        private static Dictionary<string, RegionInfo> regionMetadata = new Dictionary<string, RegionInfo>();

        /// <summary>
        /// Initializes static members of the <see cref="Region"/> class.
        /// </summary>
        static Region()
        {
            regionMetadata.Add("ABC", new RegionInfo("Bethel", "AK"));
            regionMetadata.Add("ABR", new RegionInfo("Aberdeen", "SD"));
            regionMetadata.Add("ABX", new RegionInfo("Albuquerque", "NM"));
            regionMetadata.Add("ACG", new RegionInfo("Sitka", "AK"));
            regionMetadata.Add("AEC", new RegionInfo("Nome", "AK"));
            regionMetadata.Add("AHG", new RegionInfo("Anchorage", "AK"));
            regionMetadata.Add("AIH", new RegionInfo("Middleton Island", "AK"));
            regionMetadata.Add("AKC", new RegionInfo("King Salmon", "AK"));
            regionMetadata.Add("AKQ", new RegionInfo("Richmond", "VA"));
            regionMetadata.Add("AMA", new RegionInfo("Amarillo", "TX"));
            regionMetadata.Add("AMX", new RegionInfo("Miami", "FL"));
            regionMetadata.Add("APD", new RegionInfo("Fairbanks", "AK"));
            regionMetadata.Add("APX", new RegionInfo("Gaylord", "MI"));
            regionMetadata.Add("ARX", new RegionInfo("La Crosse", "WI"));
            regionMetadata.Add("ATX", new RegionInfo("Seattle", "WA"));
            regionMetadata.Add("BBX", new RegionInfo("Chico", "CA"));
            regionMetadata.Add("BGM", new RegionInfo("Binghamton", "NY"));
            regionMetadata.Add("BHX", new RegionInfo("Eureka", "CA"));
            regionMetadata.Add("BIS", new RegionInfo("Bismarck", "ND"));
            regionMetadata.Add("BLX", new RegionInfo("Billings", "MT"));
            regionMetadata.Add("BMX", new RegionInfo("Birmingham", "AL"));
            regionMetadata.Add("BOX", new RegionInfo("Boston", "MA"));
            regionMetadata.Add("BRO", new RegionInfo("Brownsville", "TX"));
            regionMetadata.Add("BUF", new RegionInfo("Buffalo", "NY"));
            regionMetadata.Add("BYX", new RegionInfo("Key West", "FL"));
            regionMetadata.Add("CAE", new RegionInfo("Columbia", "SC"));
            regionMetadata.Add("CBW", new RegionInfo("Houlton", "ME"));
            regionMetadata.Add("CBX", new RegionInfo("Boise", "ID"));
            regionMetadata.Add("CCX", new RegionInfo("State College", "PA"));
            regionMetadata.Add("CLE", new RegionInfo("Cleveland", "OH"));
            regionMetadata.Add("CLX", new RegionInfo("Charleston", "SC"));
            regionMetadata.Add("CRP", new RegionInfo("Corpus Christi", "TX"));
            regionMetadata.Add("CXX", new RegionInfo("Burlington", "VT"));
            regionMetadata.Add("CYS", new RegionInfo("Cheyenne", "WY"));
            regionMetadata.Add("DAX", new RegionInfo("Sacramento", "CA"));
            regionMetadata.Add("DDC", new RegionInfo("Dodge City", "KS"));
            regionMetadata.Add("DFX", new RegionInfo("Del Rio", "TX"));
            regionMetadata.Add("DGX", new RegionInfo("Jackson", "MS"));
            regionMetadata.Add("DIX", new RegionInfo("Philadelphia", "PA"));
            regionMetadata.Add("DLH", new RegionInfo("Duluth", "MN"));
            regionMetadata.Add("DMX", new RegionInfo("Des Moines", "IA"));
            regionMetadata.Add("DOX", new RegionInfo("Dover", "DE"));
            regionMetadata.Add("DTX", new RegionInfo("Detroit", "MI"));
            regionMetadata.Add("DVN", new RegionInfo("Davenport", "IA"));
            regionMetadata.Add("DYX", new RegionInfo("Abilene", "TX"));
            regionMetadata.Add("EAX", new RegionInfo("Kansas City", "MO"));
            regionMetadata.Add("EMX", new RegionInfo("Tucson", "AZ"));
            regionMetadata.Add("ENX", new RegionInfo("Albany", "NY"));
            regionMetadata.Add("EOX", new RegionInfo("Dothan", "AL"));
            regionMetadata.Add("EPZ", new RegionInfo("El Paso", "TX"));
            regionMetadata.Add("ESX", new RegionInfo("Las Vegas", "NV"));
            regionMetadata.Add("EVX", new RegionInfo("Crestview", "FL"));
            regionMetadata.Add("EWX", new RegionInfo("San Antonio", "TX"));
            regionMetadata.Add("EYX", new RegionInfo("San Bernardino", "CA"));
            regionMetadata.Add("FCX", new RegionInfo("Roanoke", "VA"));
            regionMetadata.Add("FDR", new RegionInfo("Wichita Falls", "TX"));
            regionMetadata.Add("FDX", new RegionInfo("Clovis", "NM"));
            regionMetadata.Add("FFC", new RegionInfo("Atlanta", "GA"));
            regionMetadata.Add("FSD", new RegionInfo("Sioux Falls", "SD"));
            regionMetadata.Add("FSX", new RegionInfo("Flagstaff", "AZ"));
            regionMetadata.Add("FTG", new RegionInfo("Denver", "CO"));
            regionMetadata.Add("FWS", new RegionInfo("Dallas", "TX"));
            regionMetadata.Add("GGW", new RegionInfo("Glasgow", "MT"));
            regionMetadata.Add("GJX", new RegionInfo("Grand Junction", "CO"));
            regionMetadata.Add("GLD", new RegionInfo("Goodland", "KS"));
            regionMetadata.Add("GRB", new RegionInfo("Green Bay", "WI"));
            regionMetadata.Add("GRK", new RegionInfo("Killeen", "TX"));
            regionMetadata.Add("GRR", new RegionInfo("Grand Rapids", "MI"));
            regionMetadata.Add("GSP", new RegionInfo("Greenville", "SC"));
            regionMetadata.Add("GUA", new RegionInfo("Haganta", "GU"));
            regionMetadata.Add("GWX", new RegionInfo("Tupelo", "MS"));
            regionMetadata.Add("GYX", new RegionInfo("Portland", "ME"));
            regionMetadata.Add("HDX", new RegionInfo("Alamogordo", "NM"));
            regionMetadata.Add("HGX", new RegionInfo("Houston", "TX"));
            regionMetadata.Add("HKI", new RegionInfo("Lihue", "HI"));
            regionMetadata.Add("HKM", new RegionInfo("Kalaoa", "HI"));
            regionMetadata.Add("HMO", new RegionInfo("Kalaupapa", "HI"));
            regionMetadata.Add("HNX", new RegionInfo("Fresno", "CA"));
            regionMetadata.Add("HPX", new RegionInfo("Clarksville", "TN"));
            regionMetadata.Add("HTX", new RegionInfo("Huntsville", "AL"));
            regionMetadata.Add("HWA", new RegionInfo("Hilo", "HI"));
            regionMetadata.Add("ICT", new RegionInfo("Wichita", "KS"));
            regionMetadata.Add("ICX", new RegionInfo("Cedar City", "UT"));
            regionMetadata.Add("ILN", new RegionInfo("Cincinnati", "OH"));
            regionMetadata.Add("ILX", new RegionInfo("Springfield", "IL"));
            regionMetadata.Add("IND", new RegionInfo("Indianapolis", "IN"));
            regionMetadata.Add("INX", new RegionInfo("Tulsa", "OK"));
            regionMetadata.Add("IWA", new RegionInfo("Phoenix", "AZ"));
            regionMetadata.Add("IWX", new RegionInfo("Fort Wayne", "IN"));
            regionMetadata.Add("JAX", new RegionInfo("Jacksonville", "FL"));
            regionMetadata.Add("JGX", new RegionInfo("Macon", "GA"));
            regionMetadata.Add("JKL", new RegionInfo("Jackson", "KY"));
            regionMetadata.Add("JUA", new RegionInfo("San Juan", "PR"));
            regionMetadata.Add("LBB", new RegionInfo("Lubbock", "TX"));
            regionMetadata.Add("LCH", new RegionInfo("Lake Charles", "LA"));
            regionMetadata.Add("LGX", new RegionInfo("Hoquiam", "WA"));
            regionMetadata.Add("LIX", new RegionInfo("New Orleans", "LA"));
            regionMetadata.Add("LNX", new RegionInfo("North Platte", "NE"));
            regionMetadata.Add("LOT", new RegionInfo("Chicago", "IL"));
            regionMetadata.Add("LRX", new RegionInfo("Elko", "NV"));
            regionMetadata.Add("LSX", new RegionInfo("St. Louis", "MO"));
            regionMetadata.Add("LTX", new RegionInfo("Wilmington", "NC"));
            regionMetadata.Add("LVX", new RegionInfo("Louisville", "KY"));
            regionMetadata.Add("LWX", new RegionInfo("Washington", "DC"));
            regionMetadata.Add("LZK", new RegionInfo("Little Rock", "AR"));
            regionMetadata.Add("MAF", new RegionInfo("Midland", "TX"));
            regionMetadata.Add("MAX", new RegionInfo("Medford", "OR"));
            regionMetadata.Add("MBX", new RegionInfo("Minot", "ND"));
            regionMetadata.Add("MHX", new RegionInfo("Morehead City", "NC"));
            regionMetadata.Add("MKX", new RegionInfo("Milwaukee", "WI"));
            regionMetadata.Add("MLB", new RegionInfo("Melbourne", "FL"));
            regionMetadata.Add("MOB", new RegionInfo("Mobile", "AL"));
            regionMetadata.Add("MPX", new RegionInfo("Minneapolis", "MN"));
            regionMetadata.Add("MQT", new RegionInfo("Marquette", "MI"));
            regionMetadata.Add("MRX", new RegionInfo("Knoxville", "TN"));
            regionMetadata.Add("MSX", new RegionInfo("Missoula", "MT"));
            regionMetadata.Add("MTX", new RegionInfo("Salt Lake City", "UT"));
            regionMetadata.Add("MUX", new RegionInfo("San Francisco", "CA"));
            regionMetadata.Add("MVX", new RegionInfo("Grand Forks", "ND"));
            regionMetadata.Add("MXX", new RegionInfo("Montgomery", "AL"));
            regionMetadata.Add("NKX", new RegionInfo("San Diego", "CA"));
            regionMetadata.Add("NQA", new RegionInfo("Memphis", "TN"));
            regionMetadata.Add("OAX", new RegionInfo("Omaha", "NE"));
            regionMetadata.Add("OHX", new RegionInfo("Nashville", "TN"));
            regionMetadata.Add("OKX", new RegionInfo("New York", "NY"));
            regionMetadata.Add("OTX", new RegionInfo("Spokane", "WA"));
            regionMetadata.Add("PAH", new RegionInfo("Paducah", "KY"));
            regionMetadata.Add("PBZ", new RegionInfo("Pittsburgh", "PA"));
            regionMetadata.Add("PDT", new RegionInfo("Pendleton", "OR"));
            regionMetadata.Add("POE", new RegionInfo("Alexandria", "LA"));
            regionMetadata.Add("PUX", new RegionInfo("Pueblo", "CO"));
            regionMetadata.Add("RAX", new RegionInfo("Raleigh", "NC"));
            regionMetadata.Add("RGX", new RegionInfo("Reno", "NV"));
            regionMetadata.Add("RIW", new RegionInfo("Riverton", "WY"));
            regionMetadata.Add("RLX", new RegionInfo("Charleston", "WV"));
            regionMetadata.Add("RTX", new RegionInfo("Portland", "OR"));
            regionMetadata.Add("SFX", new RegionInfo("Pocatello", "ID"));
            regionMetadata.Add("SGF", new RegionInfo("Springfield", "MO"));
            regionMetadata.Add("SHV", new RegionInfo("Shreveport", "LA"));
            regionMetadata.Add("SJT", new RegionInfo("San Angelo", "TX"));
            regionMetadata.Add("SOX", new RegionInfo("Santa Ana", "CA"));
            regionMetadata.Add("SRX", new RegionInfo("Fort Smith", "AR"));
            regionMetadata.Add("TBW", new RegionInfo("Tampa", "FL"));
            regionMetadata.Add("TFX", new RegionInfo("Great Falls", "MT"));
            regionMetadata.Add("TLH", new RegionInfo("Tallahassee", "FL"));
            regionMetadata.Add("TLX", new RegionInfo("Oklahoma City", "OK"));
            regionMetadata.Add("TWX", new RegionInfo("Topeka", "KS"));
            regionMetadata.Add("TYX", new RegionInfo("Watertown", "NY"));
            regionMetadata.Add("UDX", new RegionInfo("Rapid City", "SD"));
            regionMetadata.Add("UEX", new RegionInfo("Hastings", "NE"));
            regionMetadata.Add("VAX", new RegionInfo("Valdosta", "GA"));
            regionMetadata.Add("VBX", new RegionInfo("Santa Maria", "CA"));
            regionMetadata.Add("VNX", new RegionInfo("Enid", "OK"));
            regionMetadata.Add("VTX", new RegionInfo("Los Angeles", "CA"));
            regionMetadata.Add("VWX", new RegionInfo("Evansville", "IN"));
            regionMetadata.Add("YUX", new RegionInfo("Yuma", "AZ"));

            regionMetadata.Add("US", new RegionInfo("Continental U.S.", string.Empty));
        }

        /// <summary>
        /// Gets the region IDs for the specified state codes.
        /// </summary>
        /// <param name="stateCodes">The state codes.</param>
        /// <returns>The region IDs for the specified state codes.</returns>
        public static IEnumerable<string> GetRegionIds(IEnumerable<string> stateCodes)
        {
            return regionMetadata.Where(kvp => stateCodes.Contains(kvp.Value.StateCode)).Select(kvp => kvp.Key);
        }

        /// <summary>
        /// Gets the well-known text (WKT) representation of the region polygon.
        /// </summary>
        /// <returns>A well-known text string.</returns>
        public string GetPolygonWkt()
        {
            var coordinateStrings = this.Polygon.outerBoundaryIs.LinearRing.coordinates.Split('\n');

            var coordinates = coordinateStrings.Select(c =>
            {
                var parts = c.Split(',');
                return new Coordinate(double.Parse(parts[0]), double.Parse(parts[1]));
            });

            var polygon = new NetTopologySuite.Geometries.Polygon(
                new NetTopologySuite.Geometries.LinearRing(coordinates.ToArray()));

            return polygon.ToText();
        }

        /// <summary>
        /// Gets the region information.
        /// </summary>
        /// <returns>A <see cref="RegionInfo"/> instance.</returns>
        public RegionInfo GetRegionInfo()
        {
            return regionMetadata.ContainsKey(this.id) ?
                regionMetadata[this.id] : new RegionInfo(this.id, string.Empty);
        }
    }
}