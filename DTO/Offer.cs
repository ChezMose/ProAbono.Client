//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Offers displayed into a grid
    /// </summary>
    [DataContract]
    public class Offer : ResourceBase
    {
        #region Standard properties

        /// <summary>
        /// Related segment
        /// </summary>
        [DataMember(Order=11, EmitDefaultValue=false)]
        public long IdSegment { get; set; }

        /// <summary>
        /// Offer reference
        /// </summary>
        [DataMember(Order=20)]
        public string ReferenceOffer { get; set; }
        /// <summary>
        /// Offer reference
        /// </summary>
        [DataMember(Order=21, EmitDefaultValue=false)]
        public string ReferenceSegment { get; set; }

        /// <summary>
        /// True if offer is visible
        /// </summary>
        [DataMember(Order=30)]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Offer localized title
        /// </summary>
        [DataMember(Order=32, EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Offer localized title
        /// </summary>
        [DataMember(Order=35, EmitDefaultValue=false)]
        public string TitleLocalized { get; set; }
        /// <summary>
        /// Offer localized description
        /// </summary>
        [DataMember(Order=36, EmitDefaultValue=false)]
        public string DescriptionLocalized { get; set; }

        /// <summary>
        /// Amount charged up-front, charged when the subscription starts
        /// In cents
        /// </summary>
        [DataMember(Order=30)]
        public int? AmountUpFront { get; set; }
        /// <summary>
        /// Amount charged for the trial, charged when the trial starts (yes, that's the same moment as the subscription start)
        /// In cents
        /// </summary>
        [DataMember(Order=40)]
        public int? AmountTrial { get; set; }
        /// <summary>
        /// Trial duration (requires a unit)
        /// </summary>
        [DataMember(Order=45)]
        public int? DurationTrial { get; set; }
        /// <summary>
        /// Trial duration period (requires a duration)
        /// </summary>
        [DataMember(Order=46)]
        public UnitDuration? UnitTrial { get; set; }

        /// <summary>
        /// Amount charged at each recurrence
        /// In cents
        /// </summary>
        [DataMember(Order=50)]
        public int AmountRecurrence { get; set; }
        /// <summary>
        /// Recurrence duration (requires a unit)
        /// </summary>
        [DataMember(Order=55)]
        public int DurationRecurrence { get; set; }
        /// <summary>
        /// Recurrence duration period (requires a duration)
        /// </summary>
        [DataMember(Order=56)]
        public UnitDuration UnitRecurrence { get; set; }
        /// <summary>
        /// Recurrences count, if the subscription has a programmed end
        /// </summary>
        [DataMember(Order=58)]
        public int? CountRecurrences { get; set; }
        
        /// <summary>
        /// Min. recurrences count. Subscription cannot be terminated by the user before that count
        /// </summary>
        [DataMember(Order=60)]
        public int? CountMinRecurrences { get; set; }
        /// <summary>
        /// Amount charged at subscription termination
        /// In cents
        /// </summary>
        [DataMember(Order=70)]
        public int? AmountTermination { get; set; }
        
        #endregion

        #region Specifics - ByCustomer

        /// <summary>
        /// Filled if this offer is subscribed by the customer
        /// </summary>
        [DataMember(Order=70)]
        public long? IdSubscription { get; set; }
        /// <summary>
        /// Filled if this offer is subscribed by the customer
        /// </summary>
        [DataMember(Order=72)]
        public DateTime? DateSubscription { get; set; }

        #endregion

        #region Features

        /// <summary>
        /// Related features
        /// </summary>
        [DataMember(Order=800)]
        public List<Feature> Features { get; set; }

        #endregion
    }
}

