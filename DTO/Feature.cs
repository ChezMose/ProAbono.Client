//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Feature
    /// </summary>
    [DataContract]
    public class Feature : ResourceBase
    {
        #region Standard properties

        /// <summary>
        /// Feature reference
        /// </summary>
        [DataMember(Order=10)]
        public string ReferenceFeature { get; set; }

        /// <summary>
        /// True if feature is visible to customers
        /// </summary>
        [DataMember(Order=12)]
        public bool IsVisible { get; set; }
        /// <summary>
        /// Feature type
        /// </summary>
        [DataMember(Order=16)]
        public TypeFeature TypeFeature { get; set; }

        /// <summary>
        /// Feature localized title
        /// </summary>
        [DataMember(Order=20)]
        public string TitleLocalized { get; set; }
        /// <summary>
        /// Feature localized description
        /// </summary>
        [DataMember(Order=22, EmitDefaultValue=false)]
        public string DescriptionLocalized { get; set; }

        #endregion

        #region Specifics - Quantity

        /// <summary>
        /// Feature's included quantity (if the requested)
        /// NULL means 'unlimited'
        /// </summary>
        [DataMember(Order=60, EmitDefaultValue=false)]
        public int? QuantityIncluded { get; set; }
        /// <summary>
        /// Feature's current quantity (if the requested)
        /// NULL means 'unlimited'
        /// </summary>
        [DataMember(Order=61, EmitDefaultValue=false)]
        public int? QuantityCurrent { get; set; }
        /// <summary>
        /// True if an On/Off feature is enabled by default (if requested)
        /// </summary>
        [DataMember(Order=65, EmitDefaultValue=false)]
        public bool? IsIncluded { get; set; }
        /// <summary>
        /// True if an On/Off feature is currently enabled (if requested)
        /// </summary>
        [DataMember(Order=66, EmitDefaultValue=false)]
        public bool? IsEnabled { get; set; }

        /// <summary>
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

        #region Specifics - Quantity Update only

        /// <summary>
        /// Feature's previous current quantity (if needed)
        /// Required to avoid concurrency and miscount problems
        /// NULL is probably a bad idea
        /// </summary>
        [DataMember(Order=80, EmitDefaultValue=false)]
        public int? QuantityCurrentPrevious { get; set; }

        #endregion
    }
}
