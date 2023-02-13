

namespace Discom.UP.Backend.UpDash.Rest.Interfaces
{
    /// <summary>
    /// Uri Builder
    /// </summary>
    public interface IUriBuilder
    {
        /// <summary>
        /// Build Uri
        /// </summary>
        /// <param name="request"></param>
        /// <param name="BaseUri"></param>
        /// <returns></returns>
        string BuildUri(object request, string BaseUri);
    }
}
