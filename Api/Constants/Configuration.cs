//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Configuration;

namespace ProAbonoApi
{
    /// <summary>
    /// Static version of the API client
    /// </summary>
    partial class Client
    {
        /// <summary>
        /// ProAbono configuration
        /// </summary>
        public static class Configuration
        {
            /// <summary>
            /// ProAbono rool endpoint
            /// </summary>
            public static readonly string ApiEndpoint = ConfigurationManager.AppSettings["ProAbono.Api.Endpoint.Api"];
            /// <summary>
            /// ProAbono API : agent key
            /// </summary>
            public static readonly string ApiKeyAgent = ConfigurationManager.AppSettings["ProAbono.Api.KeyAgent"];
            /// <summary>
            /// ProAbono API : api key
            /// </summary>
            public static readonly string ApiKey = ConfigurationManager.AppSettings["ProAbono.Api.KeyApi"];
        }
    }
}