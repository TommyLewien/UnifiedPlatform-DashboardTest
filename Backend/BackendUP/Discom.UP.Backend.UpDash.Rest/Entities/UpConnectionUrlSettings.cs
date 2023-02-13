
namespace Discom.UP.Backend.UpDash.Rest.Entities
{
    /// <summary>
    /// TargetUrl to connect to the UP WebApi
    /// </summary>
    public class UpConnectionUrlSettings
    {
        /// <summary>
        /// AuthenticationHandler
        /// </summary>
        public string? UpWebApiUrl { get; set; }
        public string? PersistenceServiceUrl { get; set; }

        public const string SectionName = "UpConnectionUrl";

    }
}
