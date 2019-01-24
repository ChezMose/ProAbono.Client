//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using ProAbonoApi.Tools;
using System.Collections.Generic;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    partial class ClientApiV1
    {
        #region Single Feature

        /// <summary>
        /// Get a feature
        /// </summary>
        /// <param name="feature">The related feature</param>
        /// <param name="referenceSegment">(optional) the related segment, used only to localize the texts in the default language if 'language' has been provided</param>
        /// <param name="referenceFeature">(optional) reference of requested feature, required if idFeature is null</param>
        /// <param name="referenceCustomer">(optional) if provided, adds the current usage of that feature for given user (aggregated among its subscriptions)</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport GetFeature(out Feature feature, object referenceSegment, object referenceFeature, object referenceCustomer, string language, bool? html)
        {
            feature = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Feature);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.ReferenceFeature, this.ToString(referenceFeature))
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out feature, response);
            }
            return result;
        }

        #endregion

        #region Multiple Features

        /// <summary>
        /// Get a list of features
        /// </summary>
        /// <param name="features">The related features</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceCustomer">(optional) filter - return only features available to given customer. Adds the current usage of the features for given user (aggregated among its subscriptions)</param>
        /// <param name="isVisible">(optional) filter - get only visible features. Default is null</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="page">(optional) Pagination : page index (starts from 1) </param>
        /// <param name="sizePage">(optional) Pagination : page size (default is 10) </param>
        public virtual RequestReport ListFeatures(out ListPaginated<Feature> features, object referenceSegment, object referenceCustomer, bool? isVisible, string language, bool? html, int? page, int? sizePage)
        {
            features = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Features);
            // if succeeded
            if (result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IsVisible, isVisible)
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.Html, html)
                    .AddUrlParameter(EndpointParametersV1.Page, page)
                    .AddUrlParameter(EndpointParametersV1.SizePage, sizePage);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out features, response);
            }
            return result;
        }
        /// <summary>
        /// Get a non-paginated list of features
        /// </summary>
        /// <param name="features">The related features</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceCustomer">(optional) filter - return only features available to given customer. Adds the current usage of the features for given user (aggregated among its subscriptions)</param>
        /// <param name="isVisible">(optional) filter - get only visible features. Default is null</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport ListFeatures(out List<Feature> features, object referenceSegment, object referenceCustomer, bool? isVisible, string language, bool? html)
        {
            features = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Features);
            // if succeeded
            if (result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IsVisible, isVisible)
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.Html, html)
                    // here we put an arbitrary huge number to have all usages returned
                    .AddUrlParameter(EndpointParametersV1.SizePage, 1000);

                // send the request
                var response = this.Send(request);

                // handle the response
                ListPaginated<Feature> allFeatures;
                result = this.HandleResponse(out allFeatures, response);
                // if any result
                if (allFeatures != null)
                    // just get the contained list
                    features = allFeatures.Items;
            }
            return result;
        }

        #endregion
    }
}