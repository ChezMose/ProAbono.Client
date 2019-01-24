//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.Web;
using System.Text.RegularExpressions;

namespace ProAbonoApi.Tools
{
    /// <summary>
    /// Helps to deal with urls
    /// </summary>
    public static class HelperUrl
    {
        #region Regex & constants

        /// <summary>
        /// Url size min
        /// http://a.fr
        /// </summary>
        private const int SizeUrlMin = 11;
        /// <summary>
        /// Url size max
        /// </summary>
        private const int SizeUrlMax = 511;

        /// <summary>
        ///  Matches Urls
        /// </summary>
        private static readonly Regex RegexUrl = new Regex(
                    "(?<Protocol>\\w+):\\/\\/(?<Domain>[\\w@][\\w.:@]+)\\/?[\\w\\.?=%&=\\-@/$,]*",
                    RegexOptions.IgnoreCase
                    | RegexOptions.CultureInvariant
                    | RegexOptions.IgnorePatternWhitespace
                    | RegexOptions.Compiled
                    );

        #endregion

        #region Validation

        /// <summary>
        /// True if the given url is valid
        /// </summary>
        public static bool IsUrlValid(string url)
        {
            // url is valid if
            return
                // we have one
                !string.IsNullOrEmpty(url)
                // length is ok
                    && (url.Length > SizeUrlMin)
                    && (url.Length < SizeUrlMax)
                    // it passes the regex test
                    && RegexUrl.IsMatch(url);
        }

        #endregion

        #region Parameters

        /// <summary>
        /// Set a parameter in given url
        /// </summary>
        public static string GetParameter(string url, string parameter)
        {
            string result = null;

            // if url and parameter are valid
            if (!string.IsNullOrEmpty(url)
                && !string.IsNullOrEmpty(parameter))
            {
                // look for the n-th parameter in the url
                int indexStart = url.LastIndexOf('&' + parameter + '=');
                // if not found
                if (indexStart < 0)
                    // then maybe it's the first one
                    indexStart = url.LastIndexOf('?' + parameter + '=');
                // if found
                // ex1 : http://exemple?alpha=a
                // ex2 : http://exemple?alpha=a&beta=b
                if(indexStart > 0)
                {
                    // just get that part
                    result = url.Substring((indexStart + 1), parameter.Length);
                }
            }
            return result;
        }

        /// <summary>
        /// Set a parameter in given url
        /// </summary>
        public static string SetParameter(string url, string parameter, object value)
        {
            string result = url;

            // if url and parameter are valid
            if (!string.IsNullOrEmpty(result)
                && !string.IsNullOrEmpty(parameter))
            {
                // if we got a value
                string valueAsString = null;
                if(value != null)
                {
                    // get it as a string
                    valueAsString = value.ToString();
                    // encode the value
                    valueAsString = HttpUtility.UrlEncode(valueAsString);
                }

                // look for the n-th parameter in the url
                int indexStart = result.LastIndexOf('&' + parameter + '=');
                // if not found
                if (indexStart < 0)
                    // then maybe it's the first one
                    indexStart = result.LastIndexOf('?' + parameter + '=');
                // if found
                // ex1 : http://exemple?alpha=a
                // ex2 : http://exemple?alpha=a&beta=b
                if (indexStart > 0)
                {
                    // if deleting parameters
                    if (string.IsNullOrEmpty(valueAsString))
                        // then cut the url
                        result = url.Substring(0, indexStart + 1);

                        // if updating
                    else
                    {
                        // update the index to check for parameter value
                        indexStart += (parameter.Length + 2);

                        // simply cut and use the new value
                        result = url.Substring(0, indexStart) + valueAsString + '&';
                    }

                    int indexEnd = -1;
                    // if there is something after the "="
                    if (url.Length > indexStart)
                        // then look for the next parameter
                        indexEnd = url.IndexOf('&', (indexStart + 1));

                    // if any next parameter
                    if (indexEnd > 0)
                        // put it at the end
                        result += url.Substring(indexEnd + 1);
                        // if no next parameter
                    else
                        // then remove the last character (that was left here)
                        result = result.Substring(0, (result.Length - 1));
                }
                    // if the parameter is not here but we want to add it
                else if (!string.IsNullOrEmpty(valueAsString))
                {
                    // if we have at least 1 parameters
                    if (url.IndexOf('?') > 0)
                        // add a n-th parameter
                        result += '&' + parameter + '=' + valueAsString;
                        // if no parameter for now
                    else
                        // then add a first parameter
                        result += '?' + parameter + '=' + valueAsString;
                }
            }
            return result;
        }

        /// <summary>
        /// Add a parameter in given url
        /// </summary>
        public static string AddParameter(string url, string parameter, object value)
        {
            string result = url;

            // if url, parameter and value are valid
            if (!string.IsNullOrEmpty(result)
                && !string.IsNullOrEmpty(parameter)
                && (value != null))
            {
                // get the value as a string
                var valueAsString = value.ToString();
                // if any
                if(!string.IsNullOrEmpty(valueAsString))
                {
                    // encode the value
                    valueAsString = HttpUtility.UrlEncode(valueAsString);

                    // if we have no parameter for now
                    var indexFirstParam = result.IndexOf('?');
                    if(indexFirstParam < 0)
                        // just append as the first parameter
                        result = string.Concat(url, '?', parameter, '=', valueAsString);
                    // if we have parameters
                    else
                        // append as the follow-up parameter
                        result = string.Concat(url, '&', parameter, '=', valueAsString);
                }
            }
            return result;
        }

        #endregion
    }
}
