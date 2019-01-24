//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Pricing
    /// </summary>
    [DataContract]
    public class Pricing
    {
        #region Public properties

        /// <summary>
        /// Related suscription, if any
        /// </summary>
        [DataMember(Order = 10, EmitDefaultValue = false)]
        public long IdSubscription { get; set; }
        /// <summary>
        /// Related suscription, if any
        /// </summary>
        [DataMember(Order = 16, EmitDefaultValue = false)]
        public long? IdFeature { get; set; }

        /// <summary>
        /// Offer localized pricing
        /// </summary>
        [DataMember(Order=38, EmitDefaultValue=false)]
        public string PricingLocalized { get; set; }
        /// <summary>
        /// Scheme label, optional
        /// </summary>
        [DataMember(Order = 21, EmitDefaultValue = false)]
        public string LabelLocalized { get; set; }

        /// <summary>
        /// Operation type
        /// </summary>
        [DataMember(Order = 30)]
        public TypeMove TypeMove { get; set; }
        /// <summary>
        /// Amount before tax
        /// in cents
        /// </summary>
        [DataMember(Order=35)]
        public int AmountSubtotal { get; set; }
        /// <summary>
        /// Amount after tax
        /// in cents
        /// </summary>
        [DataMember(Order=36)]
        public int AmountTotal { get; set; }
        
        /// <summary>
        /// Detailed amounts
        /// </summary>
        [DataMember(Order=50, EmitDefaultValue=false)]
        public List<Pricing> Details { get; set; }
        /// <summary>
        /// Next period amounts, in case they have been reuired
        /// </summary>
        [DataMember(Order=60, EmitDefaultValue=false)]
        public Pricing NextTerm { get; set; }

        #endregion
    }
}
