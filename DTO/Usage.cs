//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Usage
    /// </summary>
    [DataContract]
    public class Usage
    {
        #region Standard properties

        /// <summary>
        /// Segment id
        /// </summary>
        [DataMember(Order=10)]
        public long? IdSegment { get; set; }
        /// <summary>
        /// Quantity id
        /// </summary>
        [DataMember(Order=11)]
        public long? IdFeature { get; set; }
        /// <summary>
        /// Customer id
        /// </summary>
        [DataMember(Order=12)]
        public long? IdCustomer { get; set; }
        /// <summary>
        /// Subscription id
        /// </summary>
        [DataMember(Order=13)]
        public long? IdSubscription { get; set; }

        /// <summary>
        /// Segment reference
        /// </summary>
        [DataMember(Order=20, EmitDefaultValue=false)]
        public string ReferenceSegment { get; set; }
        /// <summary>
        /// Feature reference
        /// </summary>
        [DataMember(Order=21)]
        public string ReferenceFeature { get; set; }
        /// <summary>
        /// Customer reference
        /// </summary>
        [DataMember(Order=22, EmitDefaultValue=false)]
        public string ReferenceCustomer { get; set; }
        /// <summary>
        /// Feature type
        /// </summary>
        [DataMember(Order=60, EmitDefaultValue=false)]
        public TypeFeature? TypeFeature { get; set; }

        /// <summary>
        /// Feature's included quantity (if requested)
        /// NULL meaning 'unlimited'
        /// </summary>
        [DataMember(Order=62, EmitDefaultValue=false)]
        public virtual int? QuantityIncluded { get; set; }
        /// <summary>
        /// Feature's current quantity (if requested)
        /// NULL meaning 'unlimited'
        /// </summary>
        [DataMember(Order=63, EmitDefaultValue=false)]
        public virtual int? QuantityCurrent { get; set; }
        /// <summary>
        /// True if an On/Off feature is enabled by default (if requested)
        /// </summary>
        [DataMember(Order=62, EmitDefaultValue=false)]
        public virtual bool? IsIncluded { get; set; }
        /// <summary>
        /// True if an On/Off feature is currently enabled (if requested)
        /// </summary>
        [DataMember(Order=66, EmitDefaultValue=false)]
        public virtual bool? IsEnabled { get; set; }

        /// <summary>
        /// Start date of the working period
        /// </summary>
        [DataMember(Order=70, EmitDefaultValue=false)]
        public virtual DateTime? DatePeriodStart { get; set; }
        /// <summary>
        /// End date of the working period
        /// </summary>
        [DataMember(Order=75, EmitDefaultValue=false)]
        public virtual DateTime? DatePeriodEnd { get; set; }

        /// <summary>
        /// Post-only : the increment to apply to the quantity
        /// </summary>
        [DataMember(Order=80, EmitDefaultValue=false)]
        public int? Increment { get; set; }
        /// <summary>
        /// Post-only : the datestamp - must be an ISO 8601 UTC datetime
        /// </summary>
        [DataMember(Order=81, EmitDefaultValue=false)]
        public DateTime? DateStamp { get; set; }

        /// <summary>
        /// True to ensure customer is billable
        /// (POST only)
        /// </summary>
        [DataMember(Order = 150)]
        public bool? EnsureBillable { get; set; }

        #endregion
    }
}
