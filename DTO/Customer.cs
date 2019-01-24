//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Customer
    /// </summary>
    [DataContract]
    public class Customer : ResourceBase
    {
        #region Standard properties

        /// <summary>
        /// Related segment
        /// </summary>
        [DataMember(Order=11, EmitDefaultValue=false)]
        public long IdSegment { get; set; }

        /// <summary>
        /// Customer reference
        /// </summary>
        [DataMember(Order=20)]
        public string ReferenceCustomer { get; set; }
        /// <summary>
        /// Related segment
        /// </summary>
        [DataMember(Order=21, EmitDefaultValue=false)]
        public string ReferenceSegment { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        [DataMember(Order=12, EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Customer e-mail
        /// </summary>
        [DataMember(Order=15, EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// Customer language
        /// </summary>
        [DataMember(Order=20)]
        public string Language { get; set; }
        /// <summary>
        /// Customer affiliation key
        /// </summary>
        [DataMember(Order=40, EmitDefaultValue=false)]
        public string ReferenceAffiliation { get; set; }
        /// <summary>
        /// Affiliation date
        /// </summary>
        [DataMember(Order=41, EmitDefaultValue=false)]
        public DateTime? DateAffiliation { get; set; }

        #endregion

        #region Specifics - ByFeature

        /// <summary>
        /// Feature type
        /// </summary>
        [DataMember(Order=16, EmitDefaultValue=false)]
        public TypeFeature? TypeFeature { get; set; }

        /// <summary>
        /// Feature's included quantity (if requested)
        /// NULL meaning 'unlimited'
        /// </summary>
        [DataMember(Order=60, EmitDefaultValue=false)]
        public int? QuantityIncluded { get; set; }
        /// <summary>
        /// Feature's current quantity (if requested)
        /// NULL meaning 'unlimited'
        /// </summary>
        [DataMember(Order=61, EmitDefaultValue=false)]
        public int? QuantityCurrent { get; set; }
        /// <summary>
        /// True if an On/Off feature is enabled by default (if requested)
        /// </summary>
        [DataMember(Order=65, EmitDefaultValue=false)]
        public bool? IsIncluded { get; set; }
        /// <summary>
        /// True if an On/Off feature is enabled by default (if requested)
        /// </summary>
        [DataMember(Order=66, EmitDefaultValue=false)]
        public bool? IsEnabled { get; set; }        /// <summary>
        /// Start date of the working period
        /// </summary>
        [DataMember(Order=70, EmitDefaultValue=false)]
        public DateTime? DatePeriodStart { get; set; }
        /// <summary>
        /// End date of the working period
        /// </summary>
        [DataMember(Order=75, EmitDefaultValue=false)]
        public DateTime? DatePeriodEnd { get; set; }
        
        #endregion
    }
}
