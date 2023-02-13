
using Discom.UP.Backend.UpDash.Rest.Interfaces;


namespace Discom.UP.Backend.UpDash.Rest.AuthenticationHandler
{
    /// <summary>
    /// JToken Authentication Client Handler
    /// </summary>
    public class DefaultAuthenticationClientHandler : IAuthenticationClientHandler
    {
        private readonly IUserService userService;
      
        /// <summary>
        /// Constructor for DI
        /// </summary>
        public DefaultAuthenticationClientHandler(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
      
        /// <summary>
        /// Client Handler
        /// </summary>
        /// <returns>Http Client Handler</returns>
        public HttpClientHandler CreateClientHandler()
        {
            return new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
        }
    }
}
