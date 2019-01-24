//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ProAbonoApi
{
    /// <summary>
    /// Collection of Restful links
    /// </summary>
    /// <summary>
    /// HATEOAS link
    /// </summary>
    [DataContract(Name="Links")]
    public class LinkCollection : System.Collections.Generic.List<Link>
    {
        #region Tools

        /// <summary>
        /// Add a link
        /// </summary>
        public void AddLink(string relationship, string url, string contentType = null)
        {
            // append
            this.Add(new Link {Relationship = relationship, Url = url, ContentType = contentType});
        }
        /// <summary>
        /// Get a link
        /// </summary>
        public bool TryGetLink(out string url, string relationship)
        {
            // get the url
            url =
                (from link in this

                 // filter : given relationship
                 where link.Relationship == relationship

                 select link.Url
                ).FirstOrDefault();

            // compute success
            return !string.IsNullOrEmpty(url);
        }
        /// <summary>
        /// Get a link
        /// </summary>
        public string GetLink(string relationship)
        {
            // get the url
            return
                (from link in this

                 // filter : given relationship
                 where link.Relationship == relationship

                 select link.Url
                ).FirstOrDefault();
        }

        #endregion
    }
}
