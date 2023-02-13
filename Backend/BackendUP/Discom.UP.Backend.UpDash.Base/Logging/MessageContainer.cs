
using Discom.UP.Backend.UpDash.Base.Interfaces.Application;
using Discom.UP.Backend.UpDash.Base.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Discom.UP.Backend.UpDash.Base.Logging
{
    /// <summary>
    /// Message Container for Message and Error Handling Transportation
    /// </summary>
    [DataContract]
    public class MessageContainer : DTOBase
    {
        /// <summary>
        /// Abstract Description Code
        /// </summary>
        [DataMember(Order = 1)]
        public Code Code { get; private set; }

        /// <summary>
        /// Detail Description Codes
        /// </summary>
        [DataMember(Order = 2)]
        public List<DetailCode> Details { get; private set; }

        /// <summary>
        /// Logging Level
        /// </summary>
        [DataMember(Order = 3)]
        public LoggingLevel Level { get; private set; }

        /// <summary>
        /// Debug Text
        /// </summary>
        [DataMember(Order = 4)]
        public string DebugText { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="details"></param>
        /// <param name="level"></param>
        /// <param name="debugText"></param>
        public MessageContainer(Code code, List<DetailCode> details, LoggingLevel level, string debugText)
        {
            Code = code;
            Details = details;
            Level = level;
            DebugText = debugText;
        }

        /// <summary>
        /// Constructor for Serialization
        /// </summary>
        private MessageContainer() { }

        /// <inheritdoc/>
        protected override DTOBase SerializableInstance()
        {
            return new MessageContainer(new Code(), new List<DetailCode>() { new DetailCode() }, new LoggingLevel(), "Englisch Debug Text");
        }

        /// <summary>
        /// Message Representation
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 12: 12001, 12002
        /// Validation
        /// FactoryMandatory, LineMandatory
        /// </remarks>
        public string Message(CultureInfo cultureInfo)
        {
            return $"{Code.Id}: {string.Join(", ", Details.Select(x => x.Id.ToString()).ToArray())}\r\n" +
                    $"{Language.LanguageUtility.GetLocalizedCodeString(Code, cultureInfo)}\r\n" +
                    $"{Language.LanguageUtility.GetLocalizedDetailCodeString(Details, cultureInfo)}";
        }

        public string GetTranslatedCode(CultureInfo cultureInfo)
        {
            return Language.LanguageUtility.GetLocalizedCodeString(Code, cultureInfo);
        }

        public string GetTranslatedDetails(CultureInfo cultureInfo)
        {
            return Language.LanguageUtility.GetLocalizedDetailCodeString(Details, cultureInfo);
        }

    }
}