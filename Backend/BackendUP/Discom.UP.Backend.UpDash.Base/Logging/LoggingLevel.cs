using System.Runtime.Serialization;
using Discom.UP.Backend.UpDash.Base.Entities.Common;

namespace Discom.UP.Backend.UpDash.Base.Logging
{
    /// <summary>
    /// Log level
    /// </summary>
    [DataContract]
    public class LoggingLevel : Enumeration
    {
        [DataMember(Order = 1)]
        public override string Name { get; set; }

        [DataMember(Order = 2)]
        public override int Id { get; set; }

        /// <summary>
        /// None
        /// </summary>
        public static LoggingLevel None = new LoggingLevel(0, nameof(None));

        /// <summary>
        /// Information
        /// </summary>
        public static LoggingLevel Information = new LoggingLevel(1, nameof(Information));

        /// <summary>
        /// Warning
        /// </summary>
        public static LoggingLevel Warning = new LoggingLevel(2, nameof(Warning));

        /// <summary>
        /// Error
        /// </summary>
        public static LoggingLevel Error = new LoggingLevel(3, nameof(Error));

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private LoggingLevel(int id, string name) : base(id, name)
        {
        }
        /// <summary>
        /// Default Constructor for Serialization
        /// </summary>
        public LoggingLevel() : base(0, nameof(None)) { }
    }
}
