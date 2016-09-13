namespace CoreLogic.Services.Wvs
{
    using System;
    using System.IO;

    /// <summary>
    /// Defines a client used to communicate with CoreLogic Weather Verification Services (WVS).
    /// </summary>
    public interface IWvsClient
    {
        /// <summary>
        /// Gets a map from the specified request.
        /// </summary>
        /// <param name="content">The request content.</param>
        /// <returns>A <see cref="Stream"/> instance.</returns>
        /// <exception cref="Exception">The request returned an error.</exception>
        /// <exception cref="TimeoutException">The request timed out.</exception>
        Stream GetMap(LHMServiceRequest content);

        /// <summary>
        /// Gets the response to the specified request.
        /// </summary>
        /// <param name="content">The request content.</param>
        /// <returns>A <see cref="LHMResponse"/> instance.</returns>
        /// <exception cref="Exception">The request returned an error.</exception>
        /// <exception cref="TimeoutException">The request timed out.</exception>
        LHMResponse GetResponse(LHMServiceRequest content);
    }
}