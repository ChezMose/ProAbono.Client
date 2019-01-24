//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Net;
using System.Web;
using ProAbonoApi.Tools;

namespace ProAbonoApi
{
    /// <summary>
    /// ProAbono client for API
    /// 
    /// Base class
    /// </summary>
    public partial class ClientApiBase
    {
        #region Error management

        /// <summary>
        /// Parse a response and return occured errors
        /// </summary>
        public RequestReport HandleResponse(ResponseEx response)
        {
            RequestReport result = null;

            // get the HTTP status code
            var status = response.StatusHttp;

            // if success or 'no content'
            if((status == HttpStatusCode.OK)
                || (status == HttpStatusCode.Created)
                || (status == HttpStatusCode.NoContent))
            {
                // then do nothing, it's not an error
            }
            // if any other case
            else
            {
                // create a simple error report
                result = new RequestReport(status)
                    {
                        Code = "Api.Client.Response.Failure",
                        Message = status.ToString()
                    };
            }
            return result;
        }
        /// <summary>
        /// Parse a response and return occured errors
        /// </summary>
        public RequestReport HandleResponse<TContent>(out TContent content, ResponseEx response)
            where TContent: class
        {
            RequestReport result = null;
            content = null;

            // if we have a response
            if(response != null)
            {
                // get the HTTP status code
                var status = response.StatusHttp;

                // if we have a body
                if (response.HasBody)
                {
                    // if succeeded
                    if ((status == HttpStatusCode.OK)
                        || (status == HttpStatusCode.Created))
                    {
                        // deserialize
                        content = response.GetBodyAsJson<TContent>();
                        // if parsing failed
                        if (content == null)
                        {
                            // wrap in an error report
                            result = new RequestReport(status)
                                {
                                    Code = "Api.Client.Response.ParsingFailed.Content",
                                    Message = string.Format("Could not parse response body after a success [{0}]", response.GetBodyAsString())
                                };
                        }
                    }
                        // if failed
                    else
                    {
                        // deserialize an error
                        result = response.GetBodyAsJson<RequestReport>();
                        // if parsing succeeded
                        if (result != null)
                            // update the status
                            result.StatusCode = (int) status;
                            // if failed
                        else
                        {
                            // wrap in an error report
                            result = new RequestReport(status)
                                {
                                    Code = "Api.Client.Response.ParsingFailed.Error",
                                    Message = string.Format("Could not parse response body after a failure [{0}]", response.GetBodyAsString())
                                };
                        }
                    }

                }
                    // if no body in the response
                else
                {
                    // if it's an error
                    if (status >= HttpStatusCode.BadRequest)
                    {
                        // create a simple error report
                        result = new RequestReport(status)
                            {
                                Code = "Api.Client.Response.Failure",
                                Message = status.ToString()
                            };
                    }
                }
            }
            return result;
        }

        #endregion

        #region Construction

        /// <summary>
        /// Empty
        /// </summary>
        public ClientApiBase()
        {
        }
        /// <summary>
        /// With a request provider
        /// </summary>
        public ClientApiBase(IProviderRequestFluent provider)
        {
            this._provider = provider;
        }

        #endregion

        #region Static tools

        /// <summary>
        /// Initialize
        /// </summary>
        static ClientApiBase()
        {
            UriRoot = null;

            // get the API endpoint
            var url = Client.Configuration.ApiEndpoint;
            // if any
            if(url != null)
                Uri.TryCreate(url, UriKind.Absolute, out UriRoot);
        }

        /// <summary>
        /// ProAbono API root URI
        /// </summary>
        public static readonly Uri UriRoot;

        #endregion

        #region Inner tool

        /// <summary>
        /// Create a request
        /// </summary>
        protected RequestReport CreateRequest(out RequestFluent request, string endpoint)
        {
            RequestReport result = null;
            request = null;

            // if we have a valid root uri
            if(UriRoot != null)
            {
                // if we have a given url
                if(!string.IsNullOrEmpty(endpoint))
                {
                    try
                    {
                        // combine the urls
                        endpoint = new Uri(UriRoot, new Uri(endpoint, UriKind.Relative)).ToString();

                        // if we got a provider
                        if (this._provider != null)
                            request = this._provider.CreateRequest(endpoint);
                        // if no provided
                        else
                            request = RequestFluent.Create(endpoint);
                    }
                    catch(Exception exc)
                    {
                        // error 
                        result = new RequestReport
                            {
                                Code = "Api.Client.CreateRequest.Exception",
                                Message = "ProAbono client library internal error - " + exc.Message,
                                Exception = exc.ToString()
                            };
                    }
                }
                // if no url
                else
                {
                    // error 
                    result = new RequestReport
                        {
                            Code = "Api.Client.CreateRequest.NoEndpoint",
                            Message = "ProAbono client library internal error suspected - Endpoint is missing"
                        };
                }
            }
            // if no root URI
            else
            {
                // error 
                result = new RequestReport
                    {
                        Code = "Api.Client.CreateRequest.NoRootUrl",
                        Message = "Configuration error suspected - ProAbono API root url not found"
                    };
            }
            return result;
        }
        /// <summary>
        /// Send a request, with retry
        /// </summary>
        protected ResponseEx Send(RequestFluent request)
        {
            // send
            var response = request.Send();
            // if failed
            if(response.StatusHttp == HttpStatusCode.InternalServerError)
                // retry
                response = request.Send();

            return response;
        }
        /// <summary>
        /// Send a request, with retry
        /// </summary>
        protected ResponseEx Send<TContent>(RequestFluent request, TContent content, HttpVerb verb = HttpVerb.Post)
            where TContent: class
        {
            // set the verb
            request.Verb(verb);

            // send
            var response = request.SendAsJson(content);
            // if failed
            if(response.StatusHttp == HttpStatusCode.InternalServerError)
                // retry
                response = request.SendAsJson(content);

            return response;
        }

        /// <summary>
        /// convert a reference into a string
        /// </summary>
        protected string ToString(object reference)
        {
            // if any given reference
            if(reference != null)
                // convert
                return HttpUtility.UrlEncode(reference.ToString());

            return null;
        }
        /// <summary>
        /// convert a date into a string
        /// </summary>
        protected string ToString(DateTime? date)
        {
            // if any given reference
            if(date != null)
                // convert
                return ToString(date.Value);

            return null;
        }
        /// <summary>
        /// convert a date into a string
        /// </summary>
        protected string ToString(DateTime date)
        {
            // convert
            return HttpUtility.UrlEncode(date.ToString("u"));
        }

        #endregion

        #region Inner data

        /// <summary>
        /// Working request provider, if any
        /// </summary>
        private IProviderRequestFluent _provider = null;

        #endregion

    }
}