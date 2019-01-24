//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Address of a physical or moral person
    /// </summary>
    [DataContract]
    public class Address : ResourceBase
    {
        #region Public properties

        /// <summary>
        /// Related customer
        /// </summary>
        [DataMember(Order=90, EmitDefaultValue=false)]
        public string ReferenceCustomer { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        [DataMember(Order=100, EmitDefaultValue=false)]
        public string Company { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        [DataMember(Order=105, EmitDefaultValue=false)]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        [DataMember(Order=106, EmitDefaultValue=false)]
        public string LastName { get; set; }
        /// <summary>
        /// Line 1
        /// </summary>
        [DataMember(Order=110, EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Line 2
        /// </summary>
        [DataMember(Order=111, EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }
        /// <summary>
        /// zip code
        /// </summary>
        [DataMember(Order=120, EmitDefaultValue=false)]
        public string ZipCode { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [DataMember(Order=121, EmitDefaultValue=false)]
        public string City { get; set; }
        /// <summary>
        /// Country ISO code
        /// </summary>
        [DataMember(Order=130, EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        /// Region of a country ISO code
        /// </summary>
        [DataMember(Order=131, EmitDefaultValue=false)]
        public string Region { get; set; }
        /// <summary>
        /// Tax information
        /// </summary>
        [DataMember(Order=200, EmitDefaultValue=false)]
        public string TaxInformation { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        [DataMember(Order=210, EmitDefaultValue=false)]
        public string Phone { get; set; }

        #endregion
    }
}