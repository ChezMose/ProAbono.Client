//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using ProAbonoApi.Tools;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    public partial class ClientApiV1 : ClientApiBase, IClientApiV1
    {
        #region Construction

        /// <summary>
        /// Empty
        /// </summary>
        public ClientApiV1()
        {
        }
        /// <summary>
        /// With a request provider
        /// </summary>
        public ClientApiV1(IProviderRequestFluent provider)
            : base(provider)
        {
        }

        #endregion

        #region Constants

        /// <summary>
        /// Cache expiration : number of minutes
        /// </summary>
        private static int CountMinutesCacheExpiration = 6;
        /// <summary>
        /// True to automatically aggregated usages by customer,
        /// meaning it works perfectly fine if the customer has multiple subscriptions
        /// 
        /// If false, multiple usages could be returned for a single feature.
        /// </summary>
        private static readonly bool DoCacheAggregationByDefault = true;

        #endregion
    }
}