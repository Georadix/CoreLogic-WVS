namespace CoreLogic.Services.Wvs
{
    /// <summary>
    /// Defines the configuration for CoreLogic Weather Verification Services (WVS).
    /// </summary>
    public interface IWvsConfig
    {
        /// <summary>
        /// Gets the API key.
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// Gets the client ID.
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Gets the endpoint URL.
        /// </summary>
        string EndpointUrl { get; }

        /// <summary>
        /// Gets the number of seconds to wait before a request times out.
        /// </summary>
        int Timeout { get; }
    }
}