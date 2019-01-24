//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace ProAbonoApi.Tools
{
    /// <summary>
    /// Fluent class used to build a request
    /// </summary>
    public class RequestFluent
    {
        #region Constants

        /// <summary>
        /// Default Content-Type
        /// </summary>
        private static readonly ContentType ContentTypeDefault = new ContentType("application/json");
        /// <summary>
        /// Default Encoding (UTF8 without BOM)
        /// </summary>
        private static readonly Encoding EncodingDefault = new UTF8Encoding(false);
        /// <summary>
        /// Default value for AllowAutoRedirect
        /// </summary>
        private static readonly bool AllowAutoRedirectDefault = false;

        #endregion

        #region Public Static - Create

        /// <summary>
        /// Create a new request
        /// </summary>
        public static RequestFluent Create(string url)
        {
            RequestFluent result;

            // if we got a valid url
            if(HelperUrl.IsUrlValid(url))
                // create a request
                result = new RequestFluent(url);
                // if url is not valid
            else
                // then we have a problem
                throw new ArgumentException(string.Format("Invalid uri '{0}'", url));

            return result;
        }

        #endregion

        #region Public fluent - Common

        /// <summary>
        /// Set the HTTP verb (or method)
        /// </summary>
        public RequestFluent Verb(HttpVerb verb)
        {
            // set the verb
            this._verb = verb.ToString();

            return this;
        }
        /// <summary>
        /// Set the Content-Type
        /// </summary>
        public RequestFluent ContentType(string contentType)
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
        public RequestFluent ContentType(ContentType contentType)
        {
            // store
            this._contentType = contentType;

            return this;
        }
        /// <summary>
        /// Set the Encoding
        /// </summary>
        public RequestFluent Encoding(string encoding)
        {
            // resolve the encoding
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
        public RequestFluent Encoding(Encoding encoding)
        {
            // store
            this._encoding = encoding;

            return this;
        }
        /// <summary>
        /// Add an accepted content type
        /// </summary>
        public RequestFluent Accept(string contentType)
        {
            // parse
            var type = ParseContentType(contentType);
            // if succeeded
            if(type != null)
                // call the overload
                this.Accept(type);

            return this;
        }
        /// <summary>
        /// Add an accepted content type
        /// </summary>
        public RequestFluent Accept(ContentType contentType)
        {
            // if valid
            if(contentType != null)
            {
                // if no accept header
                if(string.IsNullOrEmpty(this._accept))
                    // just set it
                    this._accept = contentType.ToString();
                // we already have an accept header
                else
                    // concatenate
                    this._accept = string.Concat(this._accept, ";", contentType);
            }
            return this;
        }
        /// <summary>
        /// Set the user agent
        /// </summary>
        public RequestFluent UserAgent(string userAgent)
        {
            this._userAgent = userAgent;

            return this;
        }
        /// <summary>
        /// True to allow auto redirection
        /// </summary>
        public RequestFluent AllowAutoRedirect(bool allowAutoRedirect)
        {
            this._allowAutoRedirect = allowAutoRedirect;

            return this;
        }

        #endregion

        #region Public fluent - Headers

        /// <summary>
        /// Set given header
        /// </summary>
        public RequestFluent Header(string name, string value)
        {
            // if we got a given name
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

        #region Public fluent - url

        /// <summary>
        /// Set a querystring parameter in the request URL
        /// </summary>
        public RequestFluent SetUrlParameter(string parameter, object value)
        {
            this._url = HelperUrl.SetParameter(this._url, parameter, value);

            return this;
        }
        /// <summary>
        /// Add a querystring parameter in the request URL
        /// </summary>
        public RequestFluent AddUrlParameter(string parameter, object value)
        {
            this._url = HelperUrl.AddParameter(this._url, parameter, value);

            return this;
        }

        #endregion

        #region Public fluent - authentication

        /// <summary>
        /// Set the basic authentication
        /// </summary>
        public RequestFluent BasicAuthentication(string username, string password)
        {
            // if any
            if(!string.IsNullOrEmpty(username))
            {
                // concat login:password
                var authorization = username + ':' + (password ?? string.Empty);
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

        #region Public - Sending

        /// <summary>
        /// Send the request, get the result as a string
        /// </summary>
        public ResponseEx Send(string content = null, int? timeout = null)
        {
            ResponseEx result = null;

            // prepare the request
            string errorMessage;
            var request = InnerPrepareRequest(null, timeout, !string.IsNullOrEmpty(content), out errorMessage);

            // if we have a request
            if((request != null)
                // and no error message
                && string.IsNullOrEmpty(errorMessage))
            {
                // if we got a content
                if (!string.IsNullOrEmpty(content))
                {
                    // we really need an encoding here
                    var encoding = (this._encoding ?? EncodingDefault);
                    // convert content as a byte array
                    var buffer = encoding.GetBytes(content);
                    // set length
                    request.ContentLength = buffer.Length;
                    // open a stream
                    using (var stream = request.GetRequestStream())
                    {
                        // push the byte array
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            // if we have a request
            if((request != null)
                // and no error message
                && string.IsNullOrEmpty(errorMessage))
            {
                // then send the request and get the response
                result = ResponseEx.SendRequest(request);
            }
            // if we had an error at some point
            else
            {
                // then this is a failure
                result = ResponseEx.Failure(this._url, errorMessage);
            }
            return result;
        }
        /// <summary>
        /// Send the request, given content is serialized in JSON into the request body
        /// </summary>
        public ResponseEx SendAsJson<TContent>(TContent content = null, int? timeout = null)
            where TContent:class
        {
            ResponseEx result = null;

            // prepare the request and force JSON
            string errorMessage;
            var request = InnerPrepareRequest(new ContentType("application/json"), timeout, (content != null), out errorMessage);

            // if we have a request
            if((request != null)
                // and no error message
                && string.IsNullOrEmpty(errorMessage))
            {
                // if we got a content
                if (content != null)
                {
                    // get the encoding
                    var encoding = (this._encoding ?? EncodingDefault);
                    // open the stream
                    using (var stream = request.GetRequestStream())
                    {
                        // serialize
                        if (!SerializerForJson.Serialize(stream, content, encoding))
                        {
                            // if serialization failed
                            errorMessage = "JSON serialization failed";
                        }
                    }
                }
            }

            // if we have a request
            if((request != null)
                // and no error message
                && string.IsNullOrEmpty(errorMessage))
            {
                // then send the request and get the response
                result = ResponseEx.SendRequest(request);
            }
            // if we had an error at some point
            else
            {
                // then this is a failure
                result = ResponseEx.Failure(this._url, errorMessage);
            }
            return result;
        }

        #endregion
                
        #region Public - ToString override

        /// <summary>
        /// ToString override
        /// </summary>
        public override string ToString()
        {
            var result = new StringBuilder(200);

            // if we have a verb
            if(!string.IsNullOrEmpty(this._verb))
                // set it into the request
                result.Append(this._verb.ToUpper());
            // if no given verb
            else
                // Assume 'get'
                result.Append("GET");

            // append the url
            result.Append("  ");
            result.AppendLine(this._url);
            // get the content type, if none, use previously specified one, and clone it as it will be modified
            var contentType = new ContentType((this._contentType ?? ContentTypeDefault).ToString());
            // get the encoding, if none specified, use default
            var encoding = (this._encoding ?? EncodingDefault);
            // set the encoding
            contentType.CharSet = encoding.HeaderName;
            // now set the content-type in the request
            result.Append(" | Content-Type: ");
            result.AppendLine(contentType.ToString());
            
            // if we got an accept string
            if(!string.IsNullOrEmpty(this._accept))
            {
                // append it
                result.Append(" | Accept: ");
                result.AppendLine(this._accept);
            }

            // if we got a user-agent
            if(this._userAgent != null)
            {
                // append it
                result.Append(" | User-Agent: ");
                result.AppendLine(this._userAgent);
            }

            // if we have headers
            if((this._headers != null)
                && (this._headers.Count > 0))
            {
                // loop
                foreach(var header in this._headers.Keys)
                {
                    // append
                    result.Append(" | ");
                    result.Append(header);
                    result.Append(": ");
                    result.AppendLine(this._headers[header]);
                }
            }
            return result.ToString();
        }

        #endregion

        #region Private - HttpWebRequest preparation

        /// <summary>
        /// Prepare the request
        /// </summary>
        /// <param name="contentType">(optional) the content type, if forced</param>
        /// <param name="timeout">(optional) given request timeout</param>
        /// <param name="hasContent">(mandatory) true if request has a content</param>
        /// <param name="errorMessage">the error message, if request preparation failed</param>
        /// <returns>A valid HttpWebRequest, may be null</returns>
        private HttpWebRequest InnerPrepareRequest(ContentType contentType, int? timeout, bool hasContent, out string errorMessage)
        {
            HttpWebRequest request = null;
            errorMessage = null;

            try
            {
                // create the URI
                var uri = new Uri(this._url);
                // create the request
                request = (WebRequest.Create(uri) as HttpWebRequest);
            }
            catch(Exception exc)
            {
                // we have an error
                errorMessage = "HttpRequest creation failed - " + exc.Message;
            }

            // if we have a request
            if((request != null)
                // and no error message
                && string.IsNullOrEmpty(errorMessage))
            {
                // if we got a timeout
                if (timeout.HasValue)
                    // set the value
                    request.Timeout = timeout.Value;
                
                // if we have NO verb
                if(string.IsNullOrEmpty(this._verb))
                {
                    // if we have a content
                    if(hasContent)
                        // use a post
                        request.Method = HttpVerb.Post.ToString();
                    // if no content
                    else
                        // use a get
                        request.Method = HttpVerb.Get.ToString();
                }
                // if we have a verb
                else
                    // set it into the request
                    request.Method = this._verb;
                
                // do we allow autoredirection ? (fallback on default)
                request.AllowAutoRedirect = (this._allowAutoRedirect ?? AllowAutoRedirectDefault);

                // if we have headers
                if((this._headers != null)
                    && (this._headers.Count > 0))
                {
                    // loop
                    foreach(var header in this._headers.Keys)
                    {
                        // add the header
                        request.Headers[header] = this._headers[header];
                    }
                }

                // create the content type
                // use forced content-type, if none, use specified content-type, if none, clone default content-type
                contentType = (contentType ?? this._contentType ?? new ContentType(ContentTypeDefault.ToString()));
                // get the encoding, if none specified, use default
                this._encoding = (this._encoding ?? EncodingDefault);
                // set the encoding
                contentType.CharSet = this._encoding.HeaderName;
                // now set the content-type in the request
                request.ContentType = contentType.ToString();

                // if we got an accept string
                if(!string.IsNullOrEmpty(this._accept))
                    // set it
                    request.Accept = this._accept;

                // if we got a user-agent
                if(this._userAgent != null)
                    // set it in the request
                    request.UserAgent = this._userAgent;
            }
            // if request creation failed and we have no error message (dunno if it can happend, but who knows)
            else if(string.IsNullOrEmpty(errorMessage))
            {
                // if serialization failed
                errorMessage = "HttpRequest creation failed, check the URL";
            }
            return request;
        }
        
        #endregion

        #region Private - Construction

        /// <summary>
        /// Base constructor
        /// </summary>
        private RequestFluent(string url)
        {
            // create the request
            this._url = url;
        }

        #endregion

        #region Private - Inner data

        /// <summary>
        /// Request url
        /// </summary>
        private string _url = null;
        /// <summary>
        /// HTTP Verb (method)
        /// </summary>
        private string _verb = null;
        /// <summary>
        /// HTTP user agent
        /// </summary>
        private string _userAgent = null;
        /// <summary>
        /// Accept header string
        /// </summary>
        private string _accept = null;
        /// <summary>
        /// Allo auto redirect
        /// </summary>
        private bool? _allowAutoRedirect = null;
        /// <summary>
        /// Working content type
        /// </summary>
        private ContentType _contentType = null;
        /// <summary>
        /// Working encoding
        /// </summary>
        private Encoding _encoding = null;
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
