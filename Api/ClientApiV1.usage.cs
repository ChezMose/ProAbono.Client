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
        #region Single Usage

        /// <summary>
        /// Get usage for a given customer (or subscription) and feature
        /// If given feature is present in multiple subscriptions for the customer, then the usages are aggregated
        /// </summary>
        /// <param name="usage">The related usage</param>
        /// <param name="referenceFeature">(optional) reference of related feature, required if idFeature is null</param>
        /// <param name="idFeature">(optional) ProAbono id of the related feature, required if referenceFeature is null</param>
        /// <param name="referenceCustomer">(optional) reference of related customer, required if idSubscription is null</param>
        /// <param name="idSubscription">(optional) reference of related subscription, required if referenceCustomer is null</param>
        public virtual RequestReport GetUsage(out Usage usage, object referenceFeature, long? idFeature, object referenceCustomer, long? idSubscription)
        {
            usage = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Usage);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceFeature, this.ToString(referenceFeature))
                    .AddUrlParameter(EndpointParametersV1.IdFeature, idFeature)
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IdSubscription, idSubscription);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out usage, response);
            }
            return result;
        }
        /// <summary>
        /// Update usage for a given customer (or subscription) and feature
        /// </summary>
        /// <param name="usage">The related usage</param>
        /// <param name="referenceFeature">(optional) reference of related feature, required if idFeature is null</param>
        /// <param name="idFeature">(optional) ProAbono id of the related feature, required if referenceFeature is null</param>
        /// <param name="referenceCustomer">(optional) reference of related customer, required if idSubscription is null</param>
        /// <param name="idSubscription">(optional) reference of related subscription, required if referenceCustomer is null</param>
        /// <param name="increment">(optional) the increment to apply to current usage</param>
        /// <param name="quantityCurrent">(optional) the new usage quantity</param>
        /// <param name="isEnabled">(optional) toggle usage on an on/off feature</param>
        /// <param name="dateStamp">(optional) the date the usage update occurs. Required for concurrency issues. Defaults to now (UTC)</param>
        public virtual RequestReport SaveUsage(out Usage usage, object referenceFeature, long? idFeature, object referenceCustomer, long? idSubscription, int? increment, int? quantityCurrent, bool? isEnabled, DateTime? dateStamp)
        {
            usage = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Usage);
            // if succeeded
            if(result.IsSuccess())
            {
                // we really need a date
                dateStamp = dateStamp ?? DateTime.UtcNow;

                // build the customer to send
                var usageToSend = new Usage
                                     {
                                       ReferenceFeature = this.ToString(referenceFeature),
                                       IdFeature = idFeature,
                                       ReferenceCustomer = this.ToString(referenceCustomer),
                                       IdSubscription = idSubscription,
                                       Increment = increment,
                                       QuantityCurrent = quantityCurrent,
                                       IsEnabled = isEnabled,
                                       DateStamp = dateStamp
                                     };

                // send the request
                var response = this.Send(request, usageToSend);

                // handle the response
                result = this.HandleResponse(out usage, response);
            }
            return result;
        }

        #endregion

        #region Multiple usages

        /// <summary>
        /// Get a usages list with specified criteria
        /// </summary>
        /// <param name="usages">The related usages</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceFeature">(optional) reference of related feature, required if idFeature is null</param>
        /// <param name="idFeature">(optional) ProAbono id of the related feature, required if referenceFeature is null</param>
        /// <param name="referenceCustomer">(optional) reference of related customer</param>
        /// <param name="idSubscription">(optional) reference of related subscription</param>
        /// <param name="aggregate">(optional) true to aggregate all usages of the same feature and the same customer. Default is false</param>
        /// <param name="page">(optional) Pagination : page index (starts from 1) </param>
        /// <param name="sizePage">(optional) Pagination : page size (default is 10) </param>
        public virtual RequestReport ListUsages(out ListPaginated<Usage> usages, object referenceSegment, object referenceFeature, long? idFeature, object referenceCustomer, long? idSubscription, bool? aggregate, int? page, int? sizePage)
        {
            usages = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Usages);
            // if succeeded
            if (result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.ReferenceFeature, this.ToString(referenceFeature))
                    .AddUrlParameter(EndpointParametersV1.IdFeature, idFeature)
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IdSubscription, idSubscription)
                    .AddUrlParameter(EndpointParametersV1.Aggregate, aggregate)
                    .AddUrlParameter(EndpointParametersV1.Page, page)
                    .AddUrlParameter(EndpointParametersV1.SizePage, sizePage);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out usages, response);
            }
            return result;
        }

        #endregion
    }
}