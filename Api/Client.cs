//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using ProAbonoApi.Implementation;
using ProAbonoApi.Tools;

namespace ProAbonoApi
{
    /// <summary>
    /// Static version of the API client
    /// </summary>
    public static partial class Client
    {
        #region Static accessor

        /// <summary>
        /// Static constructor, used for global configuration
        /// </summary>
        static Client()
        {
            // initialize the request builder
            var requestBuilder = new ProviderRequestFluent();
            // set defaults
            requestBuilder
                .Accept("application/json")
                .BasicAuthentication(Configuration.ApiKeyAgent, Configuration.ApiKey);

            // create the client singleton
            _Current = new ClientApiV1(requestBuilder);
        }
        /// <summary>
        /// API client
        /// </summary>
        private static IClientApiV1 _Current = null;

        /// <summary>
        /// Get the client
        /// </summary>
        public static IClientApiV1 Current
        {
            get { return _Current; }
        }

        #endregion


    }
}