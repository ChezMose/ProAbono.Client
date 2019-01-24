//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Net.Mime;
using System.Text;

namespace ProAbonoApi.Tools
{
    /// <summary>
    /// Provider of FluentRequest
    /// To use to have default settings pre-configured
    /// </summary>
    public interface IProviderRequestFluent
    {
        /// <summary>
        /// Create a new request
        /// </summary>
        RequestFluent CreateRequest(string url);

        /// <summary>
        /// Configure a specific parameter to force into all created requests
        /// </summary>
        IProviderRequestFluent ForcedUrlParameter(string parameter, object value);

        /// <summary>
        /// Configure the Content-Type
        /// </summary>
        IProviderRequestFluent ContentType(string contentType);
        /// <summary>
        /// Configure the Content-Type
        /// </summary>
        IProviderRequestFluent ContentType(ContentType contentType);
        /// <summary>
        /// Configure the encoding
        /// </summary>
        IProviderRequestFluent Encoding(string encoding);
        /// <summary>
        /// Configure the encoding
        /// </summary>
        IProviderRequestFluent Encoding(Encoding encoding);
        /// <summary>
        /// Configure the auto-redirection behavior
        /// </summary>
        IProviderRequestFluent AllowAutoRedirect(bool allowAutoRedirect);

        /// <summary>
        /// Set prefered Content-Type to the accept header
        /// </summary>
        IProviderRequestFluent Accept(string contentType);
        /// <summary>
        /// Set prefered Content-Type to the accept header
        /// </summary>
        IProviderRequestFluent Accept(ContentType contentType);
        /// <summary>
        /// Configure the HTTP_USER_AGENT
        /// </summary>
        IProviderRequestFluent UserAgent(string userAgent);
        /// <summary>
        /// Configure a header
        /// </summary>
        IProviderRequestFluent Header(string name, string value);

        /// <summary>
        /// Configure Basic Auth to the authorization header
        /// </summary>
        IProviderRequestFluent BasicAuthentication(string username, string password);
    }
}
