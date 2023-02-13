using Discom.UP.Backend.UpDash.Rest.Interfaces;

namespace Discom.UP.Backend.UpDash.Rest.Communicator
{
    /// <summary>
    /// Web Api Uri Builder
    /// </summary>
    public class WebApiUriBuilder : IUriBuilder
    {
        /// <summary>
        /// Constructor for DI
        /// </summary>
        public WebApiUriBuilder()
        {
        }
        /// <summary>
        /// Build Command URI
        /// </summary>
        /// <typeparam name="TCommand">Command</typeparam>
        /// <param name="BaseUrl">URL</param>
        /// <returns>Uri</returns>
        public string BuildCommandUri<TCommand>(string BaseUrl)
        {
            return BaseUrl + "/api/" + typeof(TCommand).Name;
        }
        /// <summary>
        /// Build Query URI
        /// </summary>
        /// <typeparam name="TQuery">Query</typeparam>
        /// <param name="BaseUrl">URL</param>
        /// <returns>Uri</returns>
        public string BuildQueryUri<TQuery>(string BaseUrl)
        {
            return BaseUrl + "/api/" + typeof(TQuery).Name;
        }
        /// <summary>
        /// Build Uri
        /// </summary>
        /// <param name="request"></param>
        /// <param name="BaseUri"></param>
        /// <returns></returns>
        public string BuildUri(object request, string BaseUri)
        {
            return BaseUri + "/api/" + request.GetType().Name;
        }
    }
}
