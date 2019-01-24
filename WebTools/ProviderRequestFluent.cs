//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace ProAbonoApi.Tools
{
    /// <summary>
    /// Provider of FluentRequest
    /// To use to have default settings pre-configured
    /// </summary>
    public class ProviderRequestFluent : IProviderRequestFluent
    {
        #region Constants

        /// <summary>
        /// Default Encoding (UTF8 without BOM)
        /// </summary>
        private static readonly Encoding EncodingDefault = new UTF8Encoding(false);

        #endregion

        #region Public - Create

        /// <summary>
        /// Create a new request
        /// </summary>
        public RequestFluent CreateRequest(string url)
        {
            RequestFluent result;

            // if we got a valid url
            if(HelperUrl.IsUrlValid(url))
            {
                // if we have a parameters
                if((this._urlParameters != null)
                    && (this._urlParameters.Count > 0))
                {
                    // loop
                    foreach(var urlParameter in this._urlParameters)
                    {
                        // update
                        url = HelperUrl.SetParameter(url, urlParameter.Key, urlParameter.Value);
                    }
                    
                }
                // create a request
                result = RequestFluent.Create(url);

                // if configured
                if(this._contentType != null)
                    // update the request
                    result.ContentType(this._contentType);

                // if configured
                if(this._encoding != null)
                    // update the request
                    result.Encoding(this._encoding);

                // if configured
                if(this._allowAutoRedirect.HasValue)
                    // update the request
                    result.AllowAutoRedirect(this._allowAutoRedirect.Value);

                // if configured
                if(this._accept != null)
                    // update the request
                    result.Accept(this._accept);

                // if configured
                if(this._userAgent != null)
                    // update the request
                    result.UserAgent(this._userAgent);

                // if any header
                if((this._headers != null)
                    && (this._headers.Count > 0))
                {
                    // loop
                    foreach(var header in this._headers)
                        result.Header(header.Key, header.Value);
                }
            }
                // if url is not valid
            else
                // then we have a problem
                throw new ArgumentException(string.Format("Invalid uri '{0}'", url));

            return result;
        }

        #endregion

        #region Public fluent - common

        /// <summary>
        /// Add the request content
        /// </summary>
        public IProviderRequestFluent ForcedUrlParameter(string parameter, object value)
        {
            // if we got a parameter
            if(!string.IsNullOrEmpty(parameter))
            {
                // if parameters yet
                if (this._urlParameters == null)
                    // instanciate
                    this._urlParameters = new Dictionary<string, object>();

                // store
                _urlParameters[parameter] = value;
            }
            return this;
        }

        /// <summary>
        /// Set the Content-Type
        /// </summary>
        public IProviderRequestFluent ContentType(string contentType)
        {
            // resolve the content type
            var parsed = ParseContentType(contentType);
            // if succeeded
            if(parsed != null)
                // store
                this._contentType = parsed;

            return this;
        }
        /// <summary>
        /// Set the Content-Type
        /// </summary>
        public IProviderRequestFluent ContentType(ContentType contentType)
        {
            // store
            this._contentType = contentType;

            return this;
        }
        /// <summary>
        /// Set the Encoding
        /// </summary>
        public IProviderRequestFluent Encoding(string encoding)
        {
            // resolve the content type
            var parsed = ParseEncoding(encoding);
            // if succeeded
            if(parsed != null)
                // store
                this._encoding = parsed;

            return this;
        }
        /// <summary>
        /// Set the Encoding
        /// </summary>
        public IProviderRequestFluent Encoding(Encoding encoding)
        {
            // store
            this._encoding = encoding;

            return this;
        }
        /// <summary>
        /// True to allow auto redirection
        /// </summary>
        public IProviderRequestFluent AllowAutoRedirect(bool allowAutoRedirect)
        {
            this._allowAutoRedirect = allowAutoRedirect;

            return this;
        }
        
        /// <summary>
        /// Add an accepted content type
        /// </summary>
        public IProviderRequestFluent Accept(string contentType)
        {
            // resolve the content type
            var parsed = ParseContentType(contentType);
            // if succeeded
            if(parsed != null)
                // store
                this._contentType = parsed;

            return this;
        }
        /// <summary>
        /// Add an accepted content type
        /// </summary>
        public IProviderRequestFluent Accept(ContentType contentType)
        {
            // if we have a given content type
            if(contentType != null)
            {
                // if no accept header yet, but we have a given content type
                if(string.IsNullOrEmpty(this._accept))
                    // use it as accept header
                    this._accept = contentType.ToString();
                else
                {
                    // concatenate
                    this._accept = string.Concat(this._accept, ";", contentType);
                }
            }
            // if no given content type
            else
                // clear accept
                this._accept = null;

            return this;
        }
        /// <summary>
        /// Set the user agent
        /// </summary>
        public IProviderRequestFluent UserAgent(string userAgent)
        {
            this._userAgent = userAgent;

            return this;
        }

        /// <summary>
        /// Set given header
        /// </summary>
        public IProviderRequestFluent Header(string name, string value)
        {
            // if we got a header name
            if(!string.IsNullOrEmpty(name))
            {
                // if no headers for now
                if (this._headers == null)
                    // instanciate
                    this._headers = new Dictionary<string, string>();

                // store
                this._headers[name] = value;
            }
            return this;
        }

        #endregion

        #region Public fluent - authentication

        /// <summary>
        /// Set the basic authentication
        /// </summary>
        public IProviderRequestFluent BasicAuthentication(string username, string password)
        {
            // if any
            if(!string.IsNullOrEmpty(username))
            {
                // concat login:password
                string authorization = username + ':' + (password ?? string.Empty);
                // we need an encoding
                var encoding = (this._encoding ?? EncodingDefault);
                // encode
                authorization = Convert.ToBase64String(encoding.GetBytes(authorization));

                // set the authorization header
                return this.Header("Authorization", "Basic " + authorization);
            }
            return this;
        }

        #endregion

        #region Inner data

        /// <summary>
        /// Url parameters
        /// </summary>
        private Dictionary<string, object> _urlParameters;

        /// <summary>
        /// Working content type
        /// </summary>
        private ContentType _contentType = null;
        /// <summary>
        /// Working encoding
        /// </summary>
        private Encoding _encoding = null;
        /// <summary>
        /// Allow auto redirection
        /// </summary>
        private bool? _allowAutoRedirect = null;

        /// <summary>
        /// Accept string
        /// </summary>
        private string _accept = null;
        /// <summary>
        /// HTTP user agent
        /// </summary>
        private string _userAgent = null;
        /// <summary>
        /// Headers
        /// </summary>
        private Dictionary<string, string> _headers = null;

        #endregion
        
        #region Private - Inner tools

        /// <summary>
        /// Resolve given string as a ContentType
        /// </summary>
        private static ContentType ParseContentType(string contentType)
        {
            ContentType result = null;

            // if input is valid
            if(!string.IsNullOrEmpty(contentType))
            {
                try
                {
                    // try to parse that content type
                    result = new ContentType(contentType);
                }
                catch
                {
                    // you may want want to plug your logger here to be aware of the problem
                }
            }
            return result;
        }
        /// <summary>
        /// Resolve given string as an Encoding
        /// </summary>
        private static Encoding ParseEncoding(string encoding)
        {
            Encoding result = null;

            // if input is valid
            if(!string.IsNullOrEmpty(encoding))
            {
                try
                {
                    // try to parse thaat encoding
                    System.Text.Encoding.GetEncoding(encoding);
                }
                catch
                {
                    // you may want want to plug your logger here to be aware of the problem
                }
            }
            return result;
        }

        #endregion
    }
}
