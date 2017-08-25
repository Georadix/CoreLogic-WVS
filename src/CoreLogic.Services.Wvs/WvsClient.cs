namespace CoreLogic.Services.Wvs
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;

    /// <summary>
    /// Represents a client used to communicate with CoreLogic Weather Verification Services (WVS).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WvsClient : IWvsClient, IDisposable
    {
        private readonly IWvsConfig config;
        private readonly XmlMediaTypeFormatter formatter;
        private readonly HttpClient httpClient;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsClient"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config" /> is <see langword="null" />.</exception>
        public WvsClient(IWvsConfig config)
        {
            config.AssertNotNull("config");

            this.config = config;

            this.formatter = new XmlMediaTypeFormatter() { UseXmlSerializer = true };
            this.formatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            this.httpClient = this.CreateHttpClient();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WvsClient"/> class.
        /// </summary>
        ~WvsClient()
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

        /// <summary>
        /// Gets a map from the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="Stream"/> instance.</returns>
        /// <exception cref="WvsException">The request returned an error.</exception>
        /// <exception cref="TimeoutException">The request timed out.</exception>
        public Stream GetMap(LHMServiceRequest request)
        {
            request.SetRequestToken(this.config.ClientId, this.config.ApiKey);

            var response = this.httpClient.PostAsync(string.Empty, request, this.formatter);
            response.Wait();

            var contentType = response.Result.Content.Headers.ContentType;

            if (this.formatter.SupportedMediaTypes.Any(mt =>
                    mt.MediaType.Equals(contentType.MediaType, StringComparison.InvariantCultureIgnoreCase)))
            {
                var content = response.Result.Content.ReadAsAsync<LHMResponse>(
                    new MediaTypeFormatter[] { this.formatter });
                content.Wait();

                var result = content.Result;

                throw new WvsException(
                    string.Format("{0} ({1})", result.StatusCode.message, result.StatusCode.Value),
                    response.Result,
                    request,
                    result);
            }
            else
            {
                var content = response.Result.Content.ReadAsStreamAsync();
                content.Wait();

                return content.Result;
            }
        }

        /// <summary>
        /// Gets the response to the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="LHMResponse"/> instance.</returns>
        /// <exception cref="WvsException">The request returned an error.</exception>
        /// <exception cref="TimeoutException">The request timed out.</exception>
        public LHMResponse GetResponse(LHMServiceRequest request)
        {
            request.SetRequestToken(this.config.ClientId, this.config.ApiKey);

            var response = this.httpClient.PostAsync(string.Empty, request, this.formatter);
            response.Wait();

            var content = response.Result.Content.ReadAsAsync<LHMResponse>(
                new MediaTypeFormatter[] { this.formatter });
            content.Wait();

            var result = content.Result;

            if ((result == null) || (result.StatusCode.Value != "1"))
            {
                throw new WvsException(
                    string.Format("{0} ({1})", result.StatusCode.message, result.StatusCode.Value),
                    response.Result,
                    request,
                    result);
            }

            return result;
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
                    this.httpClient.Dispose();
                }

                this.disposed = true;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var client = HttpClientFactory.Create(handler, new WvsErrorHandler());
            client.BaseAddress = new Uri(this.config.EndpointUrl);
            client.Timeout = TimeSpan.FromSeconds(this.config.Timeout);

            client.DefaultRequestHeaders.AcceptEncoding.Clear();
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            return client;
        }
    }
}