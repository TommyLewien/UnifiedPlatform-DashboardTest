using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using Discom.UP.Backend.UpDash.Base.Logging;

namespace Discom.UP.Backend.UpDash.Base.Language
{
    /// <summary>
    /// Language Utility
    /// </summary>
    public class LanguageUtility
    {
        /// <summary>
        /// Retrieves the string resource based on a particular culture.
        /// </summary>
        /// <param name="key">The string resource key.</param>
        /// <param name="cultureInfo"></param>
        /// <returns>Localization</returns>
        public static string GetLocalizedString(string key, CultureInfo cultureInfo)
        {
            ResourceManager langResource = Language.LanguageResource.ResourceManager;
            string localizedValue = langResource.GetString(key, cultureInfo);

            return localizedValue;
        }

        /// <summary>
        /// Retrieves the string resource for a code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string GetLocalizedCodeString(Code code, CultureInfo cultureInfo)
        {
            return GetLocalizedString(code.Name, cultureInfo);
        }

        /// <summary>
        /// Retrieves the string resource for a detail code.
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string GetLocalizedDetailCodeString(DetailCode detail, CultureInfo cultureInfo)
        {
            return GetLocalizedString(detail.Name, cultureInfo);
        }

        /// <summary>
        /// Retrieves the string resource for a detail codes.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string GetLocalizedDetailCodeString(List<DetailCode> details, CultureInfo cultureInfo, string delimiter = "\r\n")
        {
            return string.Join(delimiter, details.Select(x => GetLocalizedDetailCodeString(x, cultureInfo)).ToArray());
        }
    }
}
