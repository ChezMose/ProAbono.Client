//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using ProAbonoApi.Tools;
using System.Collections.Generic;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    partial class ClientApiV1
    {
        #region Single Offer

        /// <summary>
        /// Get an offers list
        /// </summary>
        /// <param name="offer">The related offer</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceOffer">(optional) reference of requested offer, required if idOffer is null</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="referenceCustomer">(optional) multiple purposes :
        /// adds a customer-specific 'subscribe' links in each offer to allow the customer to subscribe to the offer,
        /// determining the language of the localized texts (if language not provided),
        /// performing an upgrade (if upgrade requested and idSubscription not provided)</param>
        /// <param name="upgrade">(optional) ignored if referenceCustomer has not been provided. Adds a customer-specific 'upgrade' links, allowing given customer to subscribe to that offer</param>
        /// <param name="idSubscription">(optional) if provided, adds a customer-specific 'upgrade' links, allowing the customer to upgrade given subscription to the new offer</param>
        /// <param name="isVisible">(optional) filter - get only visible offers and their visible features. Default is null</param>
        /// <param name="ignoreFeatures">(optional) true to prevent returning contained. Faster call. Default is false</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport GetOffer(out Offer offer, object referenceSegment, object referenceOffer, string language, object referenceCustomer, bool? upgrade, long? idSubscription, bool? isVisible, bool? ignoreFeatures, bool? html)
        {
            offer = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Offer);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.ReferenceOffer, this.ToString(referenceOffer))
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IdSubscription, idSubscription)
                    .AddUrlParameter(EndpointParametersV1.Upgrade, upgrade)
                    .AddUrlParameter(EndpointParametersV1.IsVisible, isVisible)
                    .AddUrlParameter(EndpointParametersV1.IgnoreFeatures, ignoreFeatures)
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out offer, response);
            }
            return result;
        }

        #endregion

        #region Multiple Offers

        /// <summary>
        /// Get an offer
        /// </summary>
        /// <param name="offers">The related offers</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="prefixReferenceOffer">(optional) filter - get only offers whose reference start with given prefix</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="referenceCustomer">(optional) multiple purposes :
        /// adds a customer-specific 'subscribe' links in each offer to allow the customer to subscribe to the offer,
        /// determining the language of the localized texts (if language not provided),
        /// performing an upgrade (if upgrade requested and idSubscription not provided)</param>
        /// <param name="upgrade">(optional) ignored if referenceCustomer has not been provided. Adds a customer-specific 'upgrade' links, allowing given customer to subscribe to that offer</param>
        /// <param name="idSubscription">(optional) if provided, adds a customer-specific 'upgrade' links, allowing the customer to upgrade given subscription to the new offer</param>
        /// <param name="isVisible">(optional) filter - get only visible offers and their visible features. Default is null</param>
        /// <param name="ignoreFeatures">(optional) true to prevent returning contained. Faster call. Default is false</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="page">(optional) Pagination : page index (starts from 1) </param>
        /// <param name="sizePage">(optional) Pagination : page size (default is 10) </param>
        public virtual RequestReport ListOffers(out ListPaginated<Offer> offers, object referenceSegment, string prefixReferenceOffer, string language, object referenceCustomer, bool? upgrade, long? idSubscription, bool? isVisible, bool? ignoreFeatures, bool? html, int? page, int? sizePage)
        {
            offers = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Offers);
            // if succeeded
            if (result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.PrefixReferenceOffer, prefixReferenceOffer)
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IdSubscription, idSubscription)
                    .AddUrlParameter(EndpointParametersV1.Upgrade, upgrade)
                    .AddUrlParameter(EndpointParametersV1.IsVisible, isVisible)
                    .AddUrlParameter(EndpointParametersV1.IgnoreFeatures, ignoreFeatures)
                    .AddUrlParameter(EndpointParametersV1.Html, html)
                    .AddUrlParameter(EndpointParametersV1.Page, page)
                    .AddUrlParameter(EndpointParametersV1.SizePage, sizePage);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out offers, response);
            }
            return result;
        }
        /// <summary>
        /// Get a non-paginated list of offers
        /// </summary>
        /// <param name="offers">The related offers</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="prefixReferenceOffer">(optional) filter - get only offers whose reference start with given prefix</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="referenceCustomer">(optional) multiple purposes :
        /// adds a customer-specific 'subscribe' links in each offer to allow the customer to subscribe to the offer,
        /// determining the language of the localized texts (if language not provided),
        /// performing an upgrade (if upgrade requested and idSubscription not provided)</param>
        /// <param name="upgrade">(optional) ignored if referenceCustomer has not been provided. Adds a customer-specific 'upgrade' links, allowing given customer to subscribe to that offer</param>
        /// <param name="idSubscription">(optional) if provided, adds a customer-specific 'upgrade' links, allowing the customer to upgrade given subscription to the new offer</param>
        /// <param name="isVisible">(optional) filter - get only visible offers and their visible features. Default is null</param>
        /// <param name="ignoreFeatures">(optional) true to prevent returning contained. Faster call. Default is false</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport ListOffers(out List<Offer> offers, object referenceSegment, string prefixReferenceOffer, string language, object referenceCustomer, bool? upgrade, long? idSubscription, bool? isVisible, bool? ignoreFeatures, bool? html)
        {
            offers = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Offers);
            // if succeeded
            if (result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.PrefixReferenceOffer, prefixReferenceOffer)
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.IdSubscription, idSubscription)
                    .AddUrlParameter(EndpointParametersV1.Upgrade, upgrade)
                    .AddUrlParameter(EndpointParametersV1.IsVisible, isVisible)
                    .AddUrlParameter(EndpointParametersV1.IgnoreFeatures, ignoreFeatures)
                    .AddUrlParameter(EndpointParametersV1.Html, html)
                    // here we put an arbitrary huge number to have all usages returned
                    .AddUrlParameter(EndpointParametersV1.SizePage, 1000);

                // send the request
                var response = this.Send(request);

                // handle the response
                ListPaginated<Offer> allOffers;
                result = this.HandleResponse(out allOffers, response);
                // if any result
                if (allOffers != null)
                    // just get the contained list
                    offers = allOffers.Items;
            }
            return result;
        }

        #endregion
    }
}