//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Subscription displayed into a grid
    /// </summary>
    [DataContract]
    public class Subscription : ResourceBase
    {
        #region Public properties

        /// <summary>
        /// Last modified date
        /// </summary>
        [DataMember(Order=4, EmitDefaultValue = false)]
        public virtual DateTime DateUpdate { get; set; }

        /// <summary>
        /// Related segment
        /// </summary>
        [DataMember(Order=10, EmitDefaultValue=true)]
        public long IdSegment { get; set; }
        /// <summary>
        /// Related offer
        /// </summary>
        [DataMember(Order=11, EmitDefaultValue=true)]
        public long? IdOffer { get; set; }
        /// <summary>
        /// Related customer
        /// </summary>
        [DataMember(Order=12, EmitDefaultValue=true)]
        public long? IdCustomer { get; set; }
        /// <summary>
        /// Related buyer
        /// </summary>
        [DataMember(Order=13, EmitDefaultValue=true)]
        public long? IdCustomerBuyer { get; set; }

        /// <summary>
        /// Related segment
        /// </summary>
        [DataMember(Order=20, EmitDefaultValue=true)]
        public string ReferenceSegment { get; set; }
        /// <summary>
        /// Related offer reference
        /// </summary>
        [DataMember(Order=21, EmitDefaultValue=true)]
        public string ReferenceOffer { get; set; }
        /// <summary>
        /// Related customer reference
        /// </summary>
        [DataMember(Order=22, EmitDefaultValue=true)]
        public string ReferenceCustomer { get; set; }
        /// <summary>
        /// Related buyer
        /// </summary>
        [DataMember(Order=23, EmitDefaultValue=true)]
        public string ReferenceCustomerBuyer { get; set; }

        /// <summary>
        /// Subscription status
        /// </summary>
        [DataMember(Order=50, EmitDefaultValue=true)]
        public StateSubscription StateSubscription { get; set; }

        /// <summary>
        /// Subscription start date
        /// </summary>
        [DataMember(Order=55, EmitDefaultValue=false)]
        public DateTime? DateStart { get; set; }
        /// <summary>
        /// Start of the current period
        /// </summary>
        [DataMember(Order=56)]
        public DateTime? DatePeriodStart { get; set; }
        /// <summary>
        /// End of the current period
        /// </summary>
        [DataMember(Order=57)]
        public DateTime? DatePeriodEnd { get; set; }
        /// <summary>
        /// Subscription next renewal date
        /// </summary>
        [DataMember(Order=58)]
        public DateTime? DateTerm { get; set; }
        /// <summary>
        /// True if subscription is (or was interrupted) in trial
        /// </summary>
        [DataMember(Order=60)]
        public bool? IsTrial { get; set; }
        /// <summary>
        /// True if subscription is currently in an engagement
        /// </summary>
        [DataMember(Order=61)]
        public bool? IsEngaged { get; set; }
        /// <summary>
        /// True if customer is billable
        /// (GET only)
        /// </summary>
        [DataMember(Order = 62)]
        public bool? IsCustomerBillable { get; set; }
        /// <summary>
        /// True if too much late payments
        /// </summary>
        [DataMember(Order=64)]
        public bool? IsPaymentCappingReached { get; set; }

        /// <summary>
        /// Subscription localized title
        /// </summary>
        [DataMember(Order=80, EmitDefaultValue=true)]
        public string TitleLocalized { get; set; }
        /// <summary>
        /// Subscription localized description
        /// </summary>
        [DataMember(Order=81, EmitDefaultValue=false)]
        public string DescriptionLocalized { get; set; }

        /// <summary>
        /// Amount charged up-front, charged when the subscription starts
        /// In cents
        /// </summary>
        [DataMember(Order=100, EmitDefaultValue=true)]
        public int? AmountUpFront { get; set; }
        /// <summary>
        /// Amount charged for the trial, charged when the trial starts (yes, that's the same moment as the subscription start)
        /// In cents
        /// </summary>
        [DataMember(Order=101, EmitDefaultValue=true)]
        public int? AmountTrial { get; set; }
        /// <summary>
        /// Trial duration (requires a unit)
        /// </summary>
        [DataMember(Order=110, EmitDefaultValue=true)]
        public int? DurationTrial { get; set; }
        /// <summary>
        /// Trial duration period (requires a duration)
        /// </summary>
        [DataMember(Order=111)]
        public UnitDuration? UnitTrial { get; set; }

        /// <summary>
        /// Amount charged at each recurrence
        /// In cents
        /// </summary>
        [DataMember(Order=120, EmitDefaultValue=true)]
        public int? AmountRecurrence { get; set; }
        /// <summary>
        /// Recurrence duration (requires a unit)
        /// </summary>
        [DataMember(Order=121, EmitDefaultValue=true)]
        public int? DurationRecurrence { get; set; }
        /// <summary>
        /// Recurrence duration period (requires a duration)
        /// </summary>
        [DataMember(Order=122, EmitDefaultValue=true)]
        public UnitDuration? UnitRecurrence { get; set; }
        /// <summary>
        /// Recurrences count, if the subscription has a programmed end
        /// </summary>
        [DataMember(Order=123, EmitDefaultValue=true)]
        public int? CountRecurrences { get; set; }
        
        /// <summary>
        /// Min. recurrences count. Subscription cannot be terminated by the user before that count
        /// </summary>
        [DataMember(Order=130, EmitDefaultValue=true)]
        public int? CountMinRecurrences { get; set; }
        /// <summary>
        /// Amount charged at subscription termination
        /// In cents
        /// </summary>
        [DataMember(Order=131, EmitDefaultValue=true)]
        public int? AmountTermination { get; set; }

        /// <summary>
        /// True to ensure customer is billable
        /// (POST only)
        /// </summary>
        [DataMember(Order = 150)]
        public bool? EnsureBillable { get; set; }
        /// <summary>
        /// Related subscription
        /// (POST only)
        /// </summary>
        [DataMember(Order = 152, EmitDefaultValue = false)]
        public long? IdSubscription { get; set; }

        #endregion

        #region Features

        /// <summary>
        /// Related features
        /// </summary>
        public List<Feature> Features { get; set; }

        #endregion
    }
}

