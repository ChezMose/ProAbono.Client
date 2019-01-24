//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// Endpoints parameters
    /// </summary>
    public static class EndpointParametersV1
    {
        /// <summary>
        /// Segment reference
        /// </summary>
        public static string ReferenceSegment = "referenceSegment";
        /// <summary>
        /// Localization - Language
        /// </summary>
        public static string Language = "language";
        /// <summary>
        /// Localization - Html or plain text
        /// </summary>
        public static string Html = "html";
        /// <summary>
        /// Pagination - page index
        /// </summary>
        public static string Page = "page";
        /// <summary>
        /// Pagination - page size
        /// </summary>
        public static string SizePage = "sizePage";

        /// <summary>
        /// Feature id
        /// </summary>
        public static string IdFeature = "idFeature";
        /// <summary>
        /// Feature reference
        /// </summary>
        public static string ReferenceFeature = "referenceFeature";

        /// <summary>
        /// Offer id
        /// </summary>
        public static string IdOffer = "idOffer";
        /// <summary>
        /// Offer reference
        /// </summary>
        public static string ReferenceOffer = "referenceOffer";
        /// <summary>
        /// Filter - Offer reference prefix
        /// </summary>
        public static string PrefixReferenceOffer = "prefixReferenceOffer";
        /// <summary>
        /// Filter - Visibility
        /// </summary>
        public static string IsVisible = "isVisible";
        /// <summary>
        /// Content - returns feature or not
        /// </summary>
        public static string IgnoreFeatures = "ignoreFeatures";

        /// <summary>
        /// Customer reference
        /// </summary>
        public static string ReferenceCustomer = "referenceCustomer";
        /// <summary>
        /// Buyer reference
        /// </summary>
        public static string ReferenceCustomerBuyer = "referenceCustomerBuyer";

        /// <summary>
        /// Subscription id
        /// </summary>
        public static string IdSubscription = "idSubscription";
        /// <summary>
        /// Subscription status
        /// </summary>
        public static string StateSubscription = "stateSubscription";
        /// <summary>
        /// Subscription term date
        /// </summary>
        public static string DateTerm = "dateTerm";
        /// <summary>
        /// Subscription termination
        /// </summary>
        public static string DateTermination = "dateTermination";
        /// <summary>
        /// Subscription immediate termination
        /// </summary>
        public static string Immediate = "immediate";
        /// <summary>
        /// Used to indicate we'd have to test if the subscription can start right away
        /// </summary>
        public static string TryStart = "tryStart";
        /// <summary>
        /// Used to indicate we'd like upgrade links to be returned
        /// </summary>
        public static string Upgrade = "upgrade";
        /// <summary>
        /// Used to aggregate usages on a feature and a customer
        /// </summary>
        public static string Aggregate = "aggregate";
    }
}
