using Discom.UP.Backend.UpDash.Base.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Discom.UP.Backend.UpDash.Rest.Communicator
{
    /// <summary>
    /// Request Exception
    /// </summary>
    public class RequestException : Exception
    {
        /// <summary>
        /// Http Status Code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }
            = HttpStatusCode.InternalServerError;

        /// <summary>
        /// MessageContainer
        /// </summary>
        public MessageContainer MessageContainer { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public RequestException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        public RequestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public RequestException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageContainer"></param>
        public RequestException(MessageContainer messageContainer)
                : base(messageContainer.Message(new System.Globalization.CultureInfo("en-US")))
        {
            MessageContainer = messageContainer;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageContainer"></param>
        /// <param name="inner"></param>
        public RequestException(MessageContainer messageContainer, Exception inner)
                : base(messageContainer.Message(new System.Globalization.CultureInfo("en-US")), inner)
        {
            MessageContainer = messageContainer;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageContainer"></param>
        /// <param name="status"></param>
        public RequestException(MessageContainer messageContainer, HttpStatusCode status)
            : base(messageContainer.Message(new System.Globalization.CultureInfo("en-US")))
        {
            MessageContainer = messageContainer;
            HttpStatusCode = status;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageContainer"></param>
        /// <param name="inner"></param>
        /// <param name="status"></param>
        public RequestException(MessageContainer messageContainer, Exception inner, HttpStatusCode status)
            : base(messageContainer.Message(new System.Globalization.CultureInfo("en-US")), inner)
        {
            MessageContainer = messageContainer;
            HttpStatusCode = status;
        }
    }
}
