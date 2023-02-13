
using System.Net.Http.Headers;


namespace Discom.UP.Backend.UpDash.Rest.Interfaces
{
    /// <summary>
    /// Serialization Formatter
    /// </summary>
    public interface ISerializationFormatter
    {
        /// <summary>
        /// Mediatype
        /// </summary>
        /// <returns>MediaType Header</returns>
        MediaTypeWithQualityHeaderValue MediaType();
        /// <summary>
        /// Deserializer
        /// </summary>
        /// <typeparam name="TObject">Object</typeparam>
        /// <param name="stream">Stream</param>
        /// <returns>Object</returns>
        TObject Deserialize<TObject>(Stream stream);
    }
}
