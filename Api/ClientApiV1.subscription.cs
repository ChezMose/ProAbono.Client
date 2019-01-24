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
        #region Single Subscription

        /// <summary>
        /// Get a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(optional) ProAbono id of the requested subscription, mandatory if referenceCustomer not provided</param>
        /// <param name="referenceCustomer">(optional) Customer whose subscription is requested, mandatory if idSubscription not provided. Returns an error if the customer has multiple running subscriptions</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport GetSubscription(out Subscription subscription, long idSubscription, object referenceCustomer, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Subscription);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.IdSubscription, idSubscription)
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }
        /// <summary>
        /// Create a subscription
        /// Start it immediately if the customer is billable
        /// </summary>
        /// <param name="subscription">The created subscription, if succeeded</param>
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
        /// <param name="titleLocalized">(optional) the subscription localized title</param>
        /// <param name="descriptionLocalized">(optional) the subscription localized description</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport CreateSubscription(out Subscription subscription, object referenceOffer, object referenceCustomer, object referenceCustomerBuyer, bool? tryStart, DateTime? dateStart, int? amountUpFront, int? amountTrial, UnitDuration? unitTrial, int? durationTrial, int? amountRecurrence, UnitDuration? unitRecurrence, int? durationRecurrence, int? countRecurrences, int? countMinRecurrences, int? amountTermination, string titleLocalized, string descriptionLocalized, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Subscription);
            // if succeeded
            if(result.IsSuccess())
            {
                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.TryStart, tryStart)
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

                                       TitleLocalized = titleLocalized,
                                       DescriptionLocalized = descriptionLocalized
                                     };
                // send the request
                var response = this.Send(request, dataToSend);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }

        /// <summary>
        /// Suspend a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="stateSubscription">(optional) The subscription suspension status. Default is SuspendedAgent</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport SuspendSubscription(out Subscription subscription, long idSubscription, StateSubscription stateSubscription, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, string.Format(EndpointsV1.SubscriptionSuspension, idSubscription));
            // if succeeded
            if(result.IsSuccess())
            {
                // set the verb
                request.Verb(HttpVerb.Post);

                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.TryStart, stateSubscription)
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }
        /// <summary>
        /// Start or restart a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport StartSubscription(out Subscription subscription, long idSubscription, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, string.Format(EndpointsV1.SubscriptionStart, idSubscription));
            // if succeeded
            if(result.IsSuccess())
            {
                // set the verb
                request.Verb(HttpVerb.Post);

                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }
        /// <summary>
        /// Start or restart a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="immediate">(optional) true to terminate the subscription immediately, false to terminate at the end of the billign period. Default is false.</param>
        /// <param name="dateTermination">(optional) ignored if immediate is true. Date of termination, if you need to specify a date that is not the end of the billing period.</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport TerminateSubscription(out Subscription subscription, long idSubscription, bool? immediate, DateTime? dateTermination, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, string.Format(EndpointsV1.SubscriptionTermination, idSubscription));
            // if succeeded
            if(result.IsSuccess())
            {
                // set the verb
                request.Verb(HttpVerb.Post);

                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.Immediate, immediate)
                    .AddUrlParameter(EndpointParametersV1.DateTermination, this.ToString(dateTermination))
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }
        /// <summary>
        /// Upgrade a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="referenceOffer">(optional) reference of the related offer, required if idOffer is null</param>
        /// <param name="idOffer">(optional) ProAbono id of the related offer, required if referenceOffer is null</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport UpgradeSubscription(out Subscription subscription, long idSubscription, long? idOffer, object referenceOffer, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, string.Format(EndpointsV1.SubscriptionUpgrade, idSubscription));
            // if succeeded
            if(result.IsSuccess())
            {
                // set the verb
                request.Verb(HttpVerb.Post);

                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.IdOffer, idOffer)
                    .AddUrlParameter(EndpointParametersV1.ReferenceOffer, this.ToString(referenceOffer))
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }
        /// <summary>
        /// Change the term date of a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="dateTerm">(mandatory) the updated renewal date. must be in the future</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        public virtual RequestReport ChangeSubscriptionDateTerm(out Subscription subscription, long idSubscription, DateTime dateTerm, bool? html)
        {
            subscription = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, string.Format(EndpointsV1.SubscriptionDateTerm, idSubscription));
            // if succeeded
            if(result.IsSuccess())
            {
                // set the verb
                request.Verb(HttpVerb.Post);

                // append optional parameters
                request
                    .AddUrlParameter(EndpointParametersV1.DateTerm, this.ToString(dateTerm))
                    .AddUrlParameter(EndpointParametersV1.Html, html);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscription, response);
            }
            return result;
        }

        #endregion

        #region Multiple Subscriptions

        /// <summary>
        /// Get a list of subscriptions
        /// </summary>
        /// <param name="subscriptions">The related subscriptions</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceCustomer">(optional) Filter - returns only subscription where given customer is the recipient</param>
        /// <param name="referenceCustomerBuyer">(optional) Filter - returns only subscription where given customer is the buyer</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="page">(optional) Pagination : page index (starts from 1) </param>
        /// <param name="sizePage">(optional) Pagination : page size (default is 10) </param>
        public virtual RequestReport ListSubscriptions(out ListPaginated<Subscription> subscriptions, object referenceSegment, object referenceCustomer, object referenceCustomerBuyer, bool? html, int? page, int? sizePage)
        {
            subscriptions = null;

            // create the request
            RequestFluent request;
            var result = this.CreateRequest(out request, EndpointsV1.Subscriptions);
            // if succeeded
            if(result.IsSuccess())
            {
                // append all parameters
                request
                    .AddUrlParameter(EndpointParametersV1.ReferenceSegment, this.ToString(referenceSegment))
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomer, this.ToString(referenceCustomer))
                    .AddUrlParameter(EndpointParametersV1.ReferenceCustomerBuyer, this.ToString(referenceCustomerBuyer))
                    .AddUrlParameter(EndpointParametersV1.Html, html)
                    .AddUrlParameter(EndpointParametersV1.Page, page)
                    .AddUrlParameter(EndpointParametersV1.SizePage, sizePage);

                // send the request
                var response = this.Send(request);

                // handle the response
                result = this.HandleResponse(out subscriptions, response);
            }
            return result;
        }

        #endregion
    }
}