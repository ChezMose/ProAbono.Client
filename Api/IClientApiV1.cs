//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace ProAbonoApi
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    public interface IClientApiV1
    {
        #region Feature

        /// <summary>
        /// Get a feature
        /// </summary>
        /// <param name="feature">The related feature</param>
        /// <param name="referenceSegment">(optional) the related segment, used only to localize the texts in the default language if 'language' has been provided</param>
        /// <param name="referenceFeature">(optional) reference of requested feature, required if idFeature is null</param>
        /// <param name="referenceCustomer">(optional) if provided, adds the current usage of that feature for given user (aggregated among its subscriptions)</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport GetFeature(out Feature feature, object referenceSegment, object referenceFeature, object referenceCustomer, string language, bool? html);
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
        RequestReport ListFeatures(out ListPaginated<Feature> features, object referenceSegment, object referenceCustomer, bool? isVisible, string language, bool? html, int? page, int? sizePage);
        /// <summary>
        /// Get a non-paginated list of features
        /// </summary>
        /// <param name="features">The related features</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceCustomer">(optional) filter - return only features available to given customer. Adds the current usage of the features for given user (aggregated among its subscriptions)</param>
        /// <param name="isVisible">(optional) filter - get only visible features. Default is null</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport ListFeatures(out List<Feature> features, object referenceSegment, object referenceCustomer, bool? isVisible, string language, bool? html);

        #endregion

        #region Offer

        /// <summary>
        /// Get an offer
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
        /// <param name="isVisible">(optional) filter - ignored if ignoreFeatures has been specified. if true, returns only visible features, Default is null</param>
        /// <param name="ignoreFeatures">(optional) true to prevent returning contained. Faster call. Default is false</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport GetOffer(out Offer offer, object referenceSegment, object referenceOffer, string language, object referenceCustomer, bool? upgrade, long? idSubscription, bool? isVisible, bool? ignoreFeatures, bool? html);
        /// <summary>
        /// Get a list of offers
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
        RequestReport ListOffers(out ListPaginated<Offer> offers, object referenceSegment, string prefixReferenceOffer, string language, object referenceCustomer, bool? upgrade, long? idSubscription, bool? isVisible, bool? ignoreFeatures, bool? html, int? page, int? sizePage);
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
        RequestReport ListOffers(out List<Offer> offers, object referenceSegment, string prefixReferenceOffer, string language, object referenceCustomer, bool? upgrade, long? idSubscription, bool? isVisible, bool? ignoreFeatures, bool? html);

        #endregion

        #region Subscription

        /// <summary>
        /// Get a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(optional) ProAbono id of the requested subscription, mandatory if referenceCustomer not provided</param>
        /// <param name="referenceCustomer">(optional) Customer whose subscription is requested, mandatory if idSubscription not provided. Returns an error if the customer has multiple running subscriptions</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport GetSubscription(out Subscription subscription, long idSubscription, object referenceCustomer, bool? html);
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
        RequestReport ListSubscriptions(out ListPaginated<Subscription> subscriptions, object referenceSegment, object referenceCustomer, object referenceCustomerBuyer, bool? html, int? page, int? sizePage);

        /// <summary>
        /// Create a subscription
        /// Start it immediately if the customer is billable
        /// </summary>
        /// <param name="subscription">The created subscription, if succeeded</param>
        /// <param name="referenceOffer">(mandatory) reference of the related offer, required if idOffer is null</param>
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
        /// <param name="titleLocalized">(optional) Offer override - localized title</param>
        /// <param name="descriptionLocalized">(optional) Offer override - localized description</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport CreateSubscription(out Subscription subscription, object referenceOffer, object referenceCustomer, object referenceCustomerBuyer, bool? tryStart, DateTime? dateStart, int? amountUpFront, int? amountTrial, UnitDuration? unitTrial, int? durationTrial, int? amountRecurrence, UnitDuration? unitRecurrence, int? durationRecurrence, int? countRecurrences, int? countMinRecurrences, int? amountTermination, string titleLocalized, string descriptionLocalized, bool? html);

        /// <summary>
        /// Suspend a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="stateSubscription">(optional) The subscription suspension status. Default is SuspendedAgent</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport SuspendSubscription(out Subscription subscription, long idSubscription, StateSubscription stateSubscription, bool? html);
        /// <summary>
        /// Start or restart a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport StartSubscription(out Subscription subscription, long idSubscription, bool? html);
        /// <summary>
        /// Start or restart a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="immediate">(optional) true to terminate the subscription immediately, false to terminate at the end of the billign period. Default is false.</param>
        /// <param name="dateTermination">(optional) ignored if immediate is true. Date of termination, if you need to specify a date that is not the end of the billing period.</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport TerminateSubscription(out Subscription subscription, long idSubscription, bool? immediate, DateTime? dateTermination, bool? html);
        /// <summary>
        /// Upgrade a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="referenceOffer">(optional) reference of the related offer, required if idOffer is null</param>
        /// <param name="idOffer">(optional) ProAbono id of the related offer, required if referenceOffer is null</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport UpgradeSubscription(out Subscription subscription, long idSubscription, long? idOffer, object referenceOffer, bool? html);
        /// <summary>
        /// Change the renewal date of a subscription
        /// </summary>
        /// <param name="subscription">The related subscription</param>
        /// <param name="idSubscription">(mandatory) ProAbono id of the requested subscription</param>
        /// <param name="dateTerm">(mandatory) the updated renewal date. must be in the future</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        RequestReport ChangeSubscriptionDateTerm(out Subscription subscription, long idSubscription, DateTime dateTerm, bool? html);

        #endregion

        #region Customer

        /// <summary>
        /// Get a customer from its reference
        /// </summary>
        /// <param name="customer">Found customer, if succeeded</param>
        /// <param name="referenceCustomer">(optional) reference of requested customer, required if idCustomer is null</param>
        /// <param name="referenceOffer">(optional) if provided, adds a customer-specific 'subscribe' links, allowing the customer to subscribe to given offer</param>
        RequestReport GetCustomer(out Customer customer, object referenceCustomer, object referenceOffer);
        /// <summary>
        /// Insert or update a customer
        /// </summary>
        /// <param name="customer">Inserted/updated customer</param>
        /// <param name="referenceSegment">(optional) the segment you want the push the customer into, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceCustomer">(optional) new or existing customer reference</param>
        /// <param name="name">(optional) customer name</param>
        /// <param name="email">(optional) customer email</param>
        /// <param name="language">(optional) customer language, fallback on default</param>
        /// <param name="referenceAffiliation">(optional) affiliation key</param>
        /// <param name="referenceOffer">(optional) if provided, adds a customer-specific 'subscribe' links, allowing the customer to subscribe to given offer</param>
        /// <param name="idOffer">(optional) if provided, adds a customer-specific 'subscribe' links, allowing the customer to subscribe to given offer</param>
        RequestReport SaveCustomer(out Customer customer, object referenceSegment, object referenceCustomer, string name, string email, string language, object referenceAffiliation, object referenceOffer, long? idOffer);
        /// <summary>
        /// List all customers
        /// </summary>
        /// <param name="customers">the customers paginated list</param>
        /// <param name="referenceSegment">(optional) the related segment, if not provided and you have multiple segments, defaults on the first segment</param>
        /// <param name="referenceFeature">(optional) if provided, get only customers having access to given feature. Adds the current usage in the returned object</param>
        /// <param name="page">(optional) Pagination : page index (starts from 1) </param>
        /// <param name="sizePage">(optional) Pagination : page size (default is 10) </param>
        RequestReport ListCustomers(out ListPaginated<Customer> customers, object referenceSegment, object referenceFeature, int? page, int? sizePage);

        #endregion

        #region Customer settings & addresses

        /// <summary>
        /// Get a customer billing address
        /// </summary>
        /// <param name="address">Found address, if succeeded</param>
        /// <param name="referenceCustomer">(mandatory) required customer reference</param>
        RequestReport GetCustomerBillingAddress(out Address address, object referenceCustomer);
        /// <summary>
        /// Insert or update customer billing address
        /// </summary>
        /// <param name="address">Inserted/updated address</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="company">(optional) customer company</param>
        /// <param name="firstname">(optional) customer first name</param>
        /// <param name="lastname">(optional) customer last name</param>
        /// <param name="line1">(optional) address : line 1</param>
        /// <param name="line2">(optional) address : line 2</param>
        /// <param name="zipCode">(optional) address : zip code</param>
        /// <param name="city">(optional) address : city</param>
        /// <param name="country">(optional) address : country</param>
        /// <param name="region">(optional) address : region of the country</param>
        /// <param name="taxInformation">(optional) company : tax information</param>
        /// <param name="phone">(optional) customer : phone number</param>
        RequestReport SaveCustomerBillingAddress(out Address address, object referenceCustomer, string company, string firstname, string lastname, string line1, string line2, string zipCode, string city, string country, string region, string taxInformation, string phone);

        /// <summary>
        /// Get a customer shipping address
        /// </summary>
        /// <param name="address">Found address, if succeeded</param>
        /// <param name="referenceCustomer">(mandatory) required customer reference</param>
        RequestReport GetCustomerShippingAddress(out Address address, object referenceCustomer);
        /// <summary>
        /// Insert or update shipping billing address
        /// </summary>
        /// <param name="address">Inserted/updated address</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="company">(optional) customer company</param>
        /// <param name="firstname">(optional) customer first name</param>
        /// <param name="lastname">(optional) customer last name</param>
        /// <param name="line1">(optional) address : line 1</param>
        /// <param name="line2">(optional) address : line 2</param>
        /// <param name="zipCode">(optional) address : zip code</param>
        /// <param name="city">(optional) address : city</param>
        /// <param name="country">(optional) address : country</param>
        /// <param name="region">(optional) address : region of the country</param>
        /// <param name="taxInformation">(optional) company : tax information</param>
        /// <param name="phone">(optional) customer : phone number</param>
        RequestReport SaveCustomerShippingAddress(out Address address, object referenceCustomer, string company, string firstname, string lastname, string line1, string line2, string zipCode, string city, string country, string region, string taxInformation, string phone);

        /// <summary>
        /// Get a customer payment settings
        /// </summary>
        /// <param name="settings">Found settings, if succeeded</param>
        /// <param name="referenceCustomer">(mandatory) required customer reference</param>
        RequestReport GetCustomerPaymentSettings(out SettingsPayment settings, object referenceCustomer);
        /// <summary>
        /// Insert or update a customer payment settings
        /// </summary>
        /// <param name="settings">Inserted/updated settings</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="typePayment">(optional) the payment type</param>
        /// <param name="dateNextBilling">(optional) next billing date. If null, the customer won't be billed until the next time he subscribes.</param>
        RequestReport SaveCustomerPaymentSettings(out SettingsPayment settings, object referenceCustomer, TypePayment typePayment, DateTime? dateNextBilling);

        #endregion

        #region Usage - fast version (recommended)

        /// <summary>
        /// Get a usage from the cache for given customer and given feature
        /// 
        /// Note that this call is lightning-fast and built for massive requesting : it uses an internal cache to avoid calling the API too often
        /// The caching increase the resilience of your integration : in case of a temporary communication problem, an error is returned, but the last known usage will be returned too by this method
        /// </summary>
        /// <param name="usages">The customer usage</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="referenceFeature">(mandatory) the feature reference</param>
        /// <param name="forceReloading">(optional) true to force reloading of the cache</param>
        RequestReport FastGetUsage(out Usage usage, object referenceCustomer, object referenceFeature, bool forceReloading);
        /// <summary>
        /// List the usages from the cache for given customer
        /// 
        /// Note that this call is lightning-fast and built for massive requesting : it uses an internal cache to avoid calling the API too often
        /// The caching increase the resilience of your integration : in case of a temporary communication problem, an error is returned, but the last known usages will be returned too by this method
        /// </summary>
        /// <param name="usages">The customer usages</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="forceReloading">(optional) true to force reloading of the cache</param>
        RequestReport FastListUsages(out List<Usage> usages, object referenceCustomer, bool forceReloading);

        #endregion

        #region Usage

        /// <summary>
        /// Get usage for a given customer (or subscription) and feature
        /// If given feature is present in multiple subscriptions for the customer, then the usages are aggregated
        /// </summary>
        /// <param name="usage">The related usage</param>
        /// <param name="referenceFeature">(optional) reference of related feature, required if idFeature is null</param>
        /// <param name="idFeature">(optional) ProAbono id of the related feature, required if referenceFeature is null</param>
        /// <param name="referenceCustomer">(optional) reference of related customer, required if idSubscription is null</param>
        /// <param name="idSubscription">(optional) reference of related subscription, required if referenceCustomer is null</param>
        RequestReport GetUsage(out Usage usage, object referenceFeature, long? idFeature, object referenceCustomer, long? idSubscription);
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
        RequestReport SaveUsage(out Usage usage, object referenceFeature, long? idFeature, object referenceCustomer, long? idSubscription, int? increment, int? quantityCurrent, bool? isEnabled, DateTime? dateStamp);
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
        RequestReport ListUsages(out ListPaginated<Usage> usages, object referenceSegment, object referenceFeature, long? idFeature, object referenceCustomer, long? idSubscription, bool? aggregate, int? page, int? sizePage);

        #endregion

        #region Pricing

        /// <summary>
        /// Compute the exact price for given customer to subscribe to given offer
        /// If there is a trial, the pricing will contain the pricing for the first billing period and the pricing for the next term
        /// You can override the offer's parameters in case you need a customized subscription
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="referenceOffer">(mandatory) reference of the related offer, required if idOffer is null</param>
        /// <param name="idOffer">(optional) ProAbono id of the related offer, required if referenceOffer is null</param>
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
        /// <param name="ensureBillable">(optional)  true to ensure the customer is billable, meaning it can be charged</param>
        RequestReport GetSubscriptionPricing(out Pricing pricing, object referenceOffer, object referenceCustomer, object referenceCustomerBuyer, bool? tryStart, DateTime? dateStart, int? amountUpFront, int? amountTrial, UnitDuration? unitTrial, int? durationTrial, int? amountRecurrence, UnitDuration? unitRecurrence, int? durationRecurrence, int? countRecurrences, int? countMinRecurrences, int? amountTermination, string language, bool? html, bool? ensureBillable);
        /// <summary>
        /// Compute the exact price to upgrade given subscription (or customer's subscription) to given offer
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="idSubscription">(optional) related subscription, required if referenceCustomer is null or if customer has multiple subscriptions</param>
        /// <param name="referenceCustomer">(optional) reference of related customer, required if idSubscription is null</param>
        /// <param name="referenceOffer">(mandatory) reference of the related offer, required if idOffer is null</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        RequestReport GetSubscriptionUpgradePricing(out Pricing pricing, long? idSubscription, object referenceCustomer, object referenceOffer, string language, bool? html, bool? ensureBillable);
        /// <summary>
        /// Compute the exact price to start or restart given subscription
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="idSubscription">(mandatory) related subscription, required if referenceCustomer is null or if customer has multiple subscriptions</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        RequestReport GetSubscriptionStartPricing(out Pricing pricing, long? idSubscription, string language, bool? html, bool? ensureBillable);
        /// <summary>
        /// Compute the exact price for a usage update
        /// </summary>
        /// <param name="pricing">The related usage</param>
        /// <param name="referenceFeature">(optional) reference of the related feature, required if idFeature is null</param>
        /// <param name="idFeature">(optional) ProAbono id of the related feature, required if referenceFeature is null</param>
        /// <param name="referenceCustomer">(optional) reference of related customer</param>
        /// <param name="idSubscription">(optional) reference of related subscription, required if referenceCustomer is null</param>
        /// <param name="increment">(optional) the number of units to increment that usage, required if quantityCurrent and isEnabled are null</param>
        /// <param name="quantityCurrent">(optional) the new value of the usage (On-Off features only), required if increment and isEnabled are null</param>
        /// <param name="isEnabled">(optional) the new status of given on-off usage, required if increment and quantityCurrent are null</param>
        /// <param name="dateStamp">(optional) the date the usage update occurs. Required for concurrency issues. Defaults to now (UTC)</param>
        /// <param name="language">(optional) language of the localized texts</param>
        /// <param name="html">(optional) true to have the localized text as HTML string, false for plain text. Default is true</param>
        /// <param name="ensureBillable">(optional) true to ensure the customer is billable, meaning it can be charged</param>
        RequestReport GetUsagePricing(out Pricing pricing, object referenceFeature, object referenceCustomer, long? idSubscription, int? increment, int? quantityCurrent, bool isEnabled, DateTime? dateStamp, string language, bool? html, bool? ensureBillable);

        #endregion

        #region Cache

        /// <summary>
        /// Invalidate the internal cache
        /// </summary>
        void InvalidateCache();

        #endregion
    }
}