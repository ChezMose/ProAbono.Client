//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using ProAbonoApi.Tools;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    partial class ClientApiV1
    {
        #region Pricing - Subscription

        /// <summary>
        /// Compute the exact price for given customer to subscribe to given offer
        /// If there is a trial, the pricing will contain the pricing for the first billing period and the pricing for the next term
        /// You can override the offer's parameters in case you need a customized subscription
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="referenceOffer">(optional) reference of the related offer, required if idOffer is null</param>
        /// <param name="referenceCustomer">(mandatory) reference of related customer</param>
        /// <param name="referenceCustomerBuyer">(optional) reference of related buyer, if the buyer is not the recipient of the subscription</param>
        /// <param name="tryStart">(optional) if true, will check if the customer is billable. if he's not then an error is returned</param>
        /// <param name="dateStart">(optional) specify the subscription's start date</param>
        /// <param name="amountUpFront">(optional) Offer override - upfront amount </param>
        /// <param name="amountTrial">(optional) Offer override - trial period amount</param>
        /// <param name="unitTrial">(optional) Offer override - trial period duration unit</param>
        /// <param name="durationTrial">(optional) Offer override - trial period duration</param>
        /// <param name="amountRecurrence">(optional) Offer override - recurrence amount</param>
        /// <param name="unitRecurrence">(optional) Offer override - recurrence period unit</param>
        /// <param name="durationRecurrence">(optional) Offer override - recurrence period duration</param>
        /// <param name="countRecurrences">(optional) Offer override - number of billing periods (1 or more, null for infinite)</param>
        /// <param name="countMinRecurrences">(optional) Offer override - minimum number of billing periods (engagement)</param>
        /// <param name="amountTermination">(optional) Offer override - termination fee</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        public virtual RequestReport GetSubscriptionPricing(out Pricing pricing, object referenceOffer, object referenceCustomer, object referenceCustomerBuyer, bool? tryStart, DateTime? dateStart, int? amountUpFront, int? amountTrial, UnitDuration? unitTrial, int? durationTrial, int? amountRecurrence, UnitDuration? unitRecurrence, int? durationRecurrence, int? countRecurrences, int? countMinRecurrences, int? amountTermination, string language, bool? html, bool? ensureBillable)
        {
            pricing = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.PricingSubscription);
            // if succeeded
            if(result.IsSuccess())
            {
                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.TryStart, tryStart)
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // build the customer to send
                var dataToSend = new Subscription
                                     {
                                       ReferenceOffer = this.ToString(referenceOffer),
                                       ReferenceCustomer = this.ToString(referenceCustomer),
                                       ReferenceCustomerBuyer = this.ToString(referenceCustomerBuyer),
                                       DateStart = dateStart,
                                       AmountUpFront = amountUpFront,
                                       AmountTrial = amountTrial,
                                       UnitTrial = unitTrial,
                                       DurationTrial = durationTrial,
                                       AmountRecurrence = amountRecurrence,
                                       UnitRecurrence = unitRecurrence,
                                       DurationRecurrence = durationRecurrence,
                                       CountRecurrences = countRecurrences,
                                       CountMinRecurrences = countMinRecurrences,
                                       AmountTermination = amountTermination,
                                       EnsureBillable = ensureBillable
                                     };

                // send the request
                var response = this.Send(request, dataToSend);

                // handle the response
                result = this.HandleResponse(out pricing, response);
            }
            return result;
        }

        #endregion

        #region Pricing - Upgrade

        /// <summary>
        /// Compute the exact price to upgrade given subscription (or customer's subscription) to given offer
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="idSubscription">(optional) related subscription, required if referenceCustomer is null or if customer has multiple subscriptions</param>
        /// <param name="referenceCustomer">(optional) reference of related customer, required if idSubscription is null</param>
        /// <param name="referenceOffer">(optional) reference of the related offer, required if idOffer is null</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        public virtual RequestReport GetSubscriptionUpgradePricing(out Pricing pricing, long? idSubscription, object referenceCustomer, object referenceOffer, string language, bool? html, bool? ensureBillable)
        {
            pricing = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.PricingSubscription);
            // if succeeded
            if (result.IsSuccess())
            {
                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // build the customer to send
                var dataToSend = new Subscription
                {
                    IdSubscription = idSubscription,
                    ReferenceCustomer = this.ToString(referenceCustomer),
                    ReferenceOffer = this.ToString(referenceOffer),
                    EnsureBillable = ensureBillable
                };

                // send the request
                var response = this.Send(request, dataToSend);

                // handle the response
                result = this.HandleResponse(out pricing, response);
            }
            return result;
        }

        #endregion

        #region Pricing - Start

        /// <summary>
        /// Compute the exact price to start or restart given subscription
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="idSubscription">(mandatory) related subscription, required if referenceCustomer is null or if customer has multiple subscriptions</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        public virtual RequestReport GetSubscriptionStartPricing(out Pricing pricing, long? idSubscription, string language, bool? html, bool? ensureBillable)
        {
            pricing = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.PricingSubscription);
            // if succeeded
            if (result.IsSuccess())
            {
                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.Language, language)
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // build the customer to send
                var dataToSend = new Subscription
                {
                    IdSubscription = idSubscription,
                    EnsureBillable = ensureBillable
                };

                // send the request
                var response = this.Send(request, dataToSend);

                // handle the response
                result = this.HandleResponse(out pricing, response);
            }
            return result;
        }

        #endregion

        #region Pricing - Usage

        /// <summary>
        /// Compute the exact price for a usage update
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="referenceFeature">(optional) reference of the related feature, required if idFeature is null</param>
        /// <param name="referenceCustomer">(optional) reference of related customer</param>
        /// <param name="idSubscription">(optional) reference of related subscription, required if referenceCustomer is null</param>
        /// <param name="increment">(optional) the number of units to increment that usage, required if quantityCurrent and isEnabled are null</param>
        /// <param name="quantityCurrent">(optional) the new value of the usage (On-Off features only), required if increment and isEnabled are null</param>
        /// <param name="isEnabled">(optional) the new status of given on-off usage, required if increment and quantityCurrent are null</param>
        /// <param name="dateStamp">(optional) the date the usage update occurs. Required for concurrency issues. Defaults to now (UTC)</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        public virtual RequestReport GetUsagePricing(out Pricing pricing, object referenceFeature, object referenceCustomer, long? idSubscription, int? increment, int? quantityCurrent, bool isEnabled, DateTime? dateStamp, string language, bool? html, bool? ensureBillable)
        {
            pricing = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.PricingUsage);
            // if succeeded
            if(result.IsSuccess())
            {
                // we really need a date
                dateStamp = dateStamp ?? DateTime.UtcNow;

                // build the customer to send
                var usageToSend = new Usage
                {
                    ReferenceFeature = this.ToString(referenceFeature),
                    ReferenceCustomer = this.ToString(referenceCustomer),
                    IdSubscription = idSubscription,
                    Increment = increment,
                    QuantityCurrent = quantityCurrent,
                    IsEnabled = isEnabled,
                    DateStamp = dateStamp,
                    EnsureBillable = ensureBillable
                };

                // send the request
                var response = this.Send(request, usageToSend);

                // handle the response
                result = this.HandleResponse(out pricing, response);
            }
            return result;
        }

        #endregion
    }
}