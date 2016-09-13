namespace CoreLogic.Services.Wvs
{
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the configuration for CoreLogic Weather Verification Services (WVS).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WvsConfigurationSection : ConfigurationSection, IWvsConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WvsConfigurationSection"/> class.
        /// </summary>
        protected WvsConfigurationSection()
        {
        }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
        }

        /// <summary>
        /// Gets the client ID.
        /// </summary>
        [ConfigurationProperty("clientId", IsRequired = true)]
        public string ClientId
        {
            get { return (string)this["clientId"]; }
        }

        /// <summary>
        /// Gets the endpoint URL.
        /// </summary>
        [ConfigurationProperty("endpointUrl", IsRequired = true)]
        public string EndpointUrl
        {
            get { return (string)this["endpointUrl"]; }
        }

        string IWvsConfig.ApiKey
        {
            get { return this.ApiKey; }
        }

        string IWvsConfig.ClientId
        {
            get { return this.ClientId; }
        }

        string IWvsConfig.EndpointUrl
        {
            get { return this.EndpointUrl; }
        }

        int IWvsConfig.Timeout
        {
            get { return this.Timeout; }
        }

        /// <summary>
        /// Gets the number of seconds to wait before a request times out.
        /// </summary>
        [ConfigurationProperty("timeout", IsRequired = false, DefaultValue = 10)]
        public int Timeout
        {
            get { return (int)this["timeout"]; }
        }
    }
}