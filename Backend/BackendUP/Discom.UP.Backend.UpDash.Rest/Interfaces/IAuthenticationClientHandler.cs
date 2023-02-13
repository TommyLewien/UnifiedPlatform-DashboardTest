

namespace Discom.UP.Backend.UpDash.Rest.Interfaces
{
    /// <summary>
    /// Auhtentication Client Handler
    /// </summary>
    public interface IAuthenticationClientHandler
    {
        /// <summary>
        /// Create Client Handler
        /// </summary>
        /// <returns>HttpClientHandler</returns>
        HttpClientHandler CreateClientHandler();
    }
}
