//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Base class for a resource DTO
    /// 
    /// A resource is an object that is to be exposed at some point
    /// It's minimal features is to be identifiable by a 64-bits integer, and to have an update date (if readonly, it will be the creation date)
    /// </summary>
    [DataContract]
    public abstract class ResourceBase
    {
        #region IIdentifiable<long> implementation

        /// <summary>
        /// Resource id
        /// </summary>
        [DataMember(Order=1, EmitDefaultValue = false)]
        public virtual long Id { get; set; }

        #endregion

        #region Extra

        /// <summary>
        /// Resource links
        /// </summary>
        [DataMember(Order=2000, EmitDefaultValue = false)]
        public virtual LinkCollection Links { get; set; }

        #endregion
    }
}
