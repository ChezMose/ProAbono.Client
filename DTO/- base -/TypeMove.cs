//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

namespace ProAbonoApi
{
    /// <summary>
    /// Type of movement on a customer balance, used in invoices and pricing computing as well
    /// </summary>
    public enum TypeMove
    {
        /// <summary>
        /// Not specified
        /// </summary>
        None = 0,

        /// <summary>
        /// Customer billing operation
        /// </summary>
        Billing = 100,
        /// <summary>
        /// Billing report operation
        /// </summary>
        BillingReport = 110,
        /// <summary>
        /// Invoice cancellation
        /// </summary>
        InvoiceCancelled = 120,

        /// <summary>
        /// Subscription - recurring flat fee
        /// </summary>
        SubscriptionRecurringAmount = 200,
        /// <summary>
        /// Subscription - update prorata
        /// </summary>
        SubscriptionProrata = 210,
        /// <summary>
        /// Subscription - recurring flat fee
        /// </summary>
        SubscriptionUpFront = 220,
        /// <summary>
        /// Subscription - recurring flat fee
        /// </summary>
        SubscriptionTrial = 230,
        /// <summary>
        /// Subscription - recurring flat fee
        /// </summary>
        SubscriptionTermination = 240,

        /// <summary>
        /// Subscription - recurring flat fee
        /// </summary>
        SubscriptionRefundOnUpgrade = 290,
        /// <summary>
        /// Subscription - recurring flat fee
        /// </summary>
        SubscriptionChargeOnUpgrade = 295,

        /// <summary>
        /// Feature - update prorata
        /// </summary>
        FeatureProrata = 300,
        /// <summary>
        /// Feature - standard
        /// </summary>
        Feature = 320,
        /// <summary>
        /// Feature - consumption
        /// </summary>
        FeatureIndivisible = 340,

        /// <summary>
        /// Customer - Referral program
        /// </summary>
        CustomerReferral = 600,
    }
}