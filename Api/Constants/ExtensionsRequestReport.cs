//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

namespace ProAbonoApi
{
    /// <summary>
    /// Extends the request report class
    /// </summary>
    public static class ExtensionsRequestReport
    {
        /// <summary>
        /// Check if given request ended with a success
        /// </summary>
        public static bool IsSuccess(this RequestReport report)
        {
            return ((report == null)
                    || (report.StatusCode < 300));
        }
    }
}
