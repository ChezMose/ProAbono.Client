//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Settings for payment
    /// </summary>
    [DataContract]
    public class SettingsPayment
    {
        #region Public properties

        /// <summary>
        /// Payment type
        /// </summary>
        [DataMember(Order=100, EmitDefaultValue=true)]
        public TypePayment? TypePayment { get; set; }
        /// <summary>
        /// Next billing date
        /// </summary>
        [DataMember(Order=110, EmitDefaultValue=true)]
        public DateTime? DateNextBilling { get; set; }

        #endregion
    }
}