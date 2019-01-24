//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// List with pagination
    /// </summary>
    [DataContract]
    public class ListPaginated<TItem>
    {
        #region Public properties

        /// <summary>
        /// Current page
        /// </summary>
        [DataMember]
        public int? Page { get; set; }
        /// <summary>
        /// PAge size
        /// </summary>
        [DataMember]
        public int? SizePage { get; set; }
        /// <summary>
        /// Total items in that request
        /// </summary>
        [DataMember]
        public int? Count { get; set; }
        /// <summary>
        /// Total items in the timeline
        /// </summary>
        [DataMember]
        public int? TotalItems { get; set; }

        /// <summary>
        /// Timeline creation date
        /// </summary>
        [DataMember]
        public DateTime DateGenerated { get; set; }

        /// <summary>
        /// Items list
        /// </summary>
        [DataMember]
        public List<TItem> Items { get; set; }
        /// <summary>
        /// Hateoas links
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public List<Link> Links { get; set; }

        #endregion

        #region implicit casts

        /// <summary>
        /// Convert to a list
        /// </summary>
        public static implicit operator List<TItem>(ListPaginated<TItem> items)
        {
            return items.Items;
        }

        #endregion
    }
}
