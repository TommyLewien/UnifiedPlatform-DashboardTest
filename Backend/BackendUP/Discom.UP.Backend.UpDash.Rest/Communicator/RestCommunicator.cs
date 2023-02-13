using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;

using Discom.UP.Backend.UpDash.Rest.Interfaces;
using Discom.UP.Backend.UpDash.Base.Logging;
using Discom.UP.Backend.UpDash.Base.Interfaces.Application;
using Discom.UP.Backend.UpDash.Rest.Entities;



namespace Discom.UP.Backend.UpDash.Rest.Communicator
{
    /// <summary>
    /// Rest Communcator, Query/Command/Request Delegator
    /// </summary>
    public class RestCommunicator //: IRequestDelegator
    {
        private static HttpClient _client;
        private readonly IUriBuilder _uriBuilder;
        private readonly ISerializationFormatter _serializationFormatter;
        private JsonSerializerOptions _jsoOptions;
        private readonly string _webApiUrl;
        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="uriBuilder">Uri Builder</param>
        /// <param name="serializationFormatter">Serialization Formatter</param>
        /// <param name="authenticationClientHandler">Authentication Client Handler</param>
        public RestCommunicator(IOptions<UpConnectionUrlSettings> connectionUrl, IUriBuilder uriBuilder, ISerializationFormatter serializationFormatter, IAuthenticationClientHandler authenticationClientHandler)
        {

            this._uriBuilder = uriBuilder ?? throw new ArgumentNullException("_uriBuilder");
            this._serializationFormatter = serializationFormatter ?? throw new ArgumentNullException("_serializationFormatter");
            if (authenticationClientHandler == null)
                throw new ArgumentNullException("authenticationHandler");
            else
                _client = new HttpClient(authenticationClientHandler.CreateClientHandler());

            _jsoOptions = new JsonSerializerOptions { WriteIndented = true };
            _webApiUrl = connectionUrl.Value.UpWebApiUrl ?? throw new ArgumentNullException("UpWebApiUrl"); ;

        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <typeparam name="TResult">Result</typeparam>
        /// <param name="request">Request</param>
        /// <param name="targetUrl">URL</param>
        /// <param name="token">Token</param>
        /// <returns>Result</returns>
        public async Task<TResult> Handle<TResult>(ProcessingRequestBase<TResult> request, string targetUrl, CancellationToken token)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, _uriBuilder.BuildUri(request, targetUrl)))
            {
                try
                {
                    // set the media type
                    requestMessage.Headers.Accept.Add(_serializationFormatter.MediaType());
                    // serialize and add the request
                    requestMessage.Content = Content(request);
                    // send the request
                    var response = await _client.SendAsync(requestMessage, token);
                    // succesfully connected/requested to webapi, check for response
                    if (response.IsSuccessStatusCode)
                    {
                        return _serializationFormatter.Deserialize<TResult>(await response.Content.ReadAsStreamAsync());
                    }
                    else
                    {
                        return await HandleNonSuccess<TResult>(response);
                    }
                }
                catch (Exception e) // Something gone wrong connection to webapi
                {
                    return HandleException<TResult>(e);
                }
            }
        }

        /// <summary>
        /// Handle Stream
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="targetUrl">URL</param>
        /// <param name="token">Token</param>
        /// <returns>Result</returns>
        public async Task<Stream> Handle(ProcessingRequestBase<Stream> request, string targetUrl, CancellationToken token)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, _uriBuilder.BuildUri(request, targetUrl)))
            {
                try
                {
                    // serialize and add the request
                    requestMessage.Content = Content(request);
                    // send the request
                    var response = await _client.SendAsync(requestMessage, token);
                    // succesfully connected/requested to webapi, check for response
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStreamAsync();
                    }
                    else
                    {
                        return await HandleNonSuccess<Stream>(response);
                    }
                }
                catch (Exception e) // Something gone wrong connection to webapi
                {
                    return HandleException<Stream>(e);
                }
            }
        }

        /// <summary>
        /// Content Creator
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private StringContent Content(object request)
        {
            // return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            string payload = JsonSerializer.Serialize(request, _jsoOptions);
            return new StringContent(payload);
        }

        /// <summary>
        /// Handle Non Success Response
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="RequestException"></exception>
        private async Task<TResult> HandleNonSuccess<TResult>(HttpResponseMessage response)
        {
            // try to reconstruct the message
            MessageContainer? message = null;
            try
            {
                // message = JsonConvert.DeserializeObject<MessageContainer>(await response.Content.ReadAsStringAsync());
                string content = await response.Content.ReadAsStringAsync();
                if (content != null) message = JsonSerializer.Deserialize<MessageContainer>(content);
            }
            catch (Exception)
            {
            }
            if (message != null) // successfully return our own error - standard behaviour
                throw new RequestException(message, response.StatusCode);
            else // not our error - microsoft error
            {
                if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                    throw new RequestException(new MessageContainer(Code.Connection, new List<DetailCode>() { DetailCode.Connection_Unauthorized }, LoggingLevel.Warning, "Connection is unauthorized. " + response.ReasonPhrase), response.StatusCode);

                throw new RequestException(new MessageContainer(Code.Backend, new List<DetailCode>() { DetailCode.Backend_InternalServerError }, LoggingLevel.Error, "Server Error happened. " + response.ReasonPhrase), response.StatusCode);
            }
        }

        /// <summary>
        /// Handle Eeception
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <exception cref="RequestException"></exception>
        private TResult HandleException<TResult>(Exception e)
        {
            // rethrow our exception
            if (e is RequestException re)
                throw re;

            throw new RequestException(new MessageContainer(Code.Connection, new List<DetailCode>() { DetailCode.Connection_Failed }, LoggingLevel.Error, "No connection to the backend could be established." + e.Message + e.StackTrace), e);
        }
    }
}