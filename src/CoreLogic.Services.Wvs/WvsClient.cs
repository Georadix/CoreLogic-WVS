namespace CoreLogic.Services.Wvs
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;

    /// <summary>
    /// Represents a client used to communicate with CoreLogic Weather Verification Services (WVS).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WvsClient : IWvsClient
    {
        private readonly IWvsConfig config;
        private readonly XmlMediaTypeFormatter xmlFormatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsClient"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config" /> is <see langword="null" />.</exception>
        public WvsClient(IWvsConfig config)
        {
            config.AssertNotNull("config");

            this.config = config;

            this.xmlFormatter = new XmlMediaTypeFormatter() { UseXmlSerializer = true };
            this.xmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        /// <summary>
        /// Gets a map from the specified request.
        /// </summary>
        /// <param name="content">The request content.</param>
        /// <returns>A <see cref="Stream"/> instance.</returns>
        /// <exception cref="Exception">The request returned an error.</exception>
        /// <exception cref="TimeoutException">The request timed out.</exception>
        public Stream GetMap(LHMServiceRequest content)
        {
            content.SetRequestToken(this.config.ClientId, this.config.ApiKey);

            using (var client = this.CreateHttpClient())
            {
                var request = client.PostAsync(this.config.EndpointUrl, content, this.xmlFormatter);
                request.Wait();

                if (request.Result.IsSuccessStatusCode)
                {
                    var deserialize = request.Result.Content.ReadAsStreamAsync();
                    deserialize.Wait();

                    return deserialize.Result;
                }
                else
                {
                    var deserialize = request.Result.Content.ReadAsStringAsync();
                    deserialize.Wait();

                    var ex = new Exception("A request to WVS failed.");

                    ex.Data.Add("Url", this.config.EndpointUrl);
                    ex.Data.Add("Content", content);
                    ex.Data.Add("StatusCode", request.Result.StatusCode);
                    ex.Data.Add("Response", deserialize.Result);

                    throw ex;
                }
            }
        }

        /// <summary>
        /// Gets the response to the specified request.
        /// </summary>
        /// <param name="content">The request content.</param>
        /// <returns>A <see cref="LHMResponse"/> instance.</returns>
        /// <exception cref="Exception">The request returned an error.</exception>
        /// <exception cref="TimeoutException">The request timed out.</exception>
        public LHMResponse GetResponse(LHMServiceRequest content)
        {
            content.SetRequestToken(this.config.ClientId, this.config.ApiKey);

            using (var client = this.CreateHttpClient())
            {
                var request = client.PostAsync(this.config.EndpointUrl, content, this.xmlFormatter);
                request.Wait();

                if (request.Result.IsSuccessStatusCode)
                {
                    var deserialize = request.Result.Content.ReadAsAsync(
                        typeof(LHMResponse), new MediaTypeFormatter[] { this.xmlFormatter });
                    deserialize.Wait();

                    var result = (LHMResponse)deserialize.Result;

                    if (result.StatusCode.Value != "1")
                    {
                        var ex = new Exception(
                            string.Format("{0}: {1}", result.StatusCode.Value, result.StatusCode.message));

                        ex.Data.Add("Url", this.config.EndpointUrl);

                        throw ex;
                    }

                    return result;
                }
                else
                {
                    var deserialize = request.Result.Content.ReadAsStringAsync();
                    deserialize.Wait();

                    var ex = new Exception("A request to WVS failed.");

                    ex.Data.Add("Url", this.config.EndpointUrl);
                    ex.Data.Add("Content", content);
                    ex.Data.Add("StatusCode", request.Result.StatusCode);
                    ex.Data.Add("Response", deserialize.Result);

                    throw ex;
                }
            }
        }

        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(this.config.Timeout) };

            client.DefaultRequestHeaders.AcceptEncoding.Clear();
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            return client;
        }
    }
}