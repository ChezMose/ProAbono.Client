//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// HATEOAS link
    /// </summary>
    [DataContract]
    public class Link
    {
        #region Public properties

        /// <summary>
        /// Relationship of this link with containg entity
        /// </summary>
        [DataMember(Name="rel", EmitDefaultValue=false)]
        public string Relationship { get; set; }
        /// <summary>
        /// Link uri
        /// </summary>
        [DataMember(Name="href", EmitDefaultValue=false)]
        public string Url { get; set; }
        /// <summary>
        /// Resource content-type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        #endregion
    }
}
