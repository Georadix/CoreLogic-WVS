namespace CoreLogic.Services.Wvs
{
    /// <summary>
    /// Represents region information.
    /// </summary>
    public class RegionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="stateCode">The state code.</param>
        public RegionInfo(string name, string stateCode)
        {
            this.Name = name;
            this.StateCode = stateCode;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the state code.
        /// </summary>
        public string StateCode { get; private set; }
    }
}