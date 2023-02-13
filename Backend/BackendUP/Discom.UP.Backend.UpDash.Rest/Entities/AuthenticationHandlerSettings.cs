
namespace Discom.UP.Backend.UpDash.Rest.Entities
{
    /// <summary>
    /// AuthenticationHandlerSettings for App Settings
    /// </summary>
    public class AuthenticationHandlerSettings
    {
        /// <summary>
        /// AuthenticationHandler
        /// </summary>
        public AuthenticationHandler AuthenticationHandler { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        public const string SectionName = "Authentication";
    }

    /// <summary>
    /// AuthenticationHandler
    /// </summary>
    public enum AuthenticationHandler { Default, NetworkCredentials }

}
