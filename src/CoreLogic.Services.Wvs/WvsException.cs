namespace CoreLogic.Services.Wvs
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents errors that occur while processing HTTP requests to CoreLogic Weather Verification Services (WVS).
    /// </summary>
    [Serializable]
    public class WvsException : Exception
    {
        private readonly LHMServiceRequest requestContent;
        private readonly HttpResponseMessage response;
        private readonly LHMResponse responseContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsException"/> class.
        /// </summary>
        public WvsException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public WvsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsException"/> class with a specified error message and a
        /// reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or <see langword="null"/> if no inner exception
        /// is specified.
        /// </param>
        public WvsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsException"/> class with a specified error message, response
        /// message, request content, and response content.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="response">The response message.</param>
        /// <param name="requestContent">The request content.</param>
        /// <param name="responseContent">The response content.</param>
        public WvsException(
            string message,
            HttpResponseMessage response,
            LHMServiceRequest requestContent = null,
            LHMResponse responseContent = null)
            : this(message)
        {
            this.response = response;
            this.requestContent = requestContent;
            this.responseContent = responseContent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WvsException"/> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        protected WvsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.response = (HttpResponseMessage)info.GetValue("Response", typeof(HttpResponseMessage));
            this.requestContent = (LHMServiceRequest)info.GetValue("RequestContent", typeof(LHMServiceRequest));
            this.responseContent = (LHMResponse)info.GetValue("ResponseContent", typeof(LHMResponse));
        }

        /// <summary>
        /// Gets the request content.
        /// </summary>
        public LHMServiceRequest RequestContent
        {
            get { return this.requestContent; }
        }

        /// <summary>
        /// Gets the response content.
        /// </summary>
        public LHMResponse ResponseContent
        {
            get { return this.responseContent; }
        }

        /// <summary>
        /// Gets the status code of the HTTP response.
        /// </summary>
        public HttpStatusCode? StatusCode
        {
            get { return (this.response != null) ? this.response.StatusCode : (HttpStatusCode?)null; }
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"/> with information about the
        /// exception.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("Response", this.response);
            info.AddValue("RequestContent", this.requestContent);
            info.AddValue("ResponseContent", this.responseContent);
        }

        /// <summary>
        /// Returns a <see cref="String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder(base.ToString());

            this.AppendContent(
                builder,
                "Response:",
                this.response,
                this.responseContent,
                (this.response != null) ? this.response.Content : null);

            this.AppendContent(
                builder,
                "Request:",
                (this.response != null) ? this.response.RequestMessage : null,
                this.requestContent,
                (this.response != null) ? this.response.RequestMessage.Content : null);

            return builder.ToString();
        }

        private void AppendContent(
            StringBuilder builder, string title, object httpMessage, object objectContent, HttpContent httpContent)
        {
            builder.AppendLine().AppendLine(title).Append(httpMessage);

            if (objectContent != null)
            {
                using (var writer = new StringWriter())
                {
                    var serializer = new XmlSerializer(objectContent.GetType());
                    serializer.Serialize(writer, objectContent);

                    builder.AppendLine().AppendLine(writer.ToString());
                }
            }
            else if (httpContent != null)
            {
                try
                {
                    var stringContent = httpContent.ReadAsStringAsync();
                    stringContent.Wait();

                    builder.AppendLine().AppendLine(stringContent.Result);
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }
    }
}