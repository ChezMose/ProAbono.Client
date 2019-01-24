//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// Working endpoints
    /// </summary>
    public static class EndpointsV1
    {
        /// <summary>
        /// Single feature
        /// </summary>
        public static string Feature = "/v1/Feature";
        /// <summary>
        /// Multiple features
        /// </summary>
        public static string Features = "/v1/Features";

        /// <summary>
        /// Single offer
        /// </summary>
        public static string Offer = "/v1/Offer";
        /// <summary>
        /// Multiple offers
        /// </summary>
        public static string Offers = "/v1/Offers";

        /// <summary>
        /// Single customer
        /// </summary>
        public static string Customer = "/v1/Customer";
        /// <summary>
        /// Multiple customers
        /// </summary>
        public static string Customers = "/v1/Customers";

        /// <summary>
        /// Customer - billing address
        /// </summary>
        public static string CustomerAddressBilling = "/v1/CustomerAddressBilling";
        /// <summary>
        /// Customer - shipping address
        /// </summary>
        public static string CustomerAddressShipping = "/v1/CustomerAddressShipping";
        /// <summary>
        /// Customer - payment settings
        /// </summary>
        public static string CustomerSettingsPayment = "/v1/CustomerSettingsPayment";

        /// <summary>
        /// Single subscription
        /// </summary>
        public static string Subscription = "/v1/Subscription";
        /// <summary>
        /// Multiple subscriptions
        /// </summary>
        public static string Subscriptions = "/v1/Subscriptions";

        /// <summary>
        /// Subscription suspension
        /// </summary>
        public static string SubscriptionSuspension = "/v1/Subscription/{0}/Suspension";
        /// <summary>
        /// Subscription start/restart
        /// </summary>
        public static string SubscriptionStart = "/v1/Subscription/{0}/Start";
        /// <summary>
        /// Subscription termination
        /// </summary>
        public static string SubscriptionTermination = "/v1/Subscription/{0}/Termination";
        /// <summary>
        /// Subscription upgrade
        /// </summary>
        public static string SubscriptionUpgrade = "/v1/Subscription/{0}/Upgrade";
        /// <summary>
        /// Subscription change term date
        /// </summary>
        public static string SubscriptionDateTerm = "/v1/Subscription/{0}/DateTerm";

        /// <summary>
        /// Single usage
        /// </summary>
        public static string Usage = "/v1/Usage";
        /// <summary>
        /// Multiple usages
        /// </summary>
        public static string Usages = "/v1/Usages";

        /// <summary>
        /// Pricing - subscription
        /// </summary>
        public static string PricingSubscription = "/v1/PricingSubscription";
        /// <summary>
        /// Pricing - usage
        /// </summary>
        public static string PricingUsage = "/v1/PricingUsage";
    }
}
