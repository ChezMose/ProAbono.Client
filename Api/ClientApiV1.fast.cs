//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Threading;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    public partial class ClientApiV1
    {
        #region Public - Usage - fast version

        /// <summary>
        /// Get a usage from the cache for given customer and given feature
        /// 
        /// Note that this call is lightning-fast and built for massive requesting : it uses an internal cache to avoid calling the API too often
        /// The caching increase the resilience of your integration : in case of a temporary communication problem, an error is returned, but the last known usage will be returned too by this method
        /// </summary>
        /// <param name="usages">The customer usage</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="referenceFeature">(mandatory) the feature reference</param>
        public virtual RequestReport FastGetUsage(out Usage usage, object referenceCustomer, object referenceFeature, bool forceReloading)
        {
            usage = null;
            RequestReport result;

            // we need a customer and a feature
            if ((referenceCustomer != null)
                && referenceFeature != null)
            {
                // get cached usages for customer
                List<Usage> usages;
                result = this.FastListUsages(out usages, referenceCustomer, forceReloading);
                // if any
                if((usages != null)
                    && (usages.Count > 0))
                    // find the one for given feature
                    usage = usages.Find(u => u.ReferenceFeature == referenceFeature.ToString());
            }
            // if we miss a mandatory parameter
            else
                // return an error 
                result = new RequestReport
                {
                    Code = "Api.Client.FastGetUsage.MissingParameter",
                    Message = "Missing parameter - FastGetUsage requires a ReferenceCustomer and a ReferenceFeature"
                };

            return result;
        }
        /// <summary>
        /// List the usages from the cache for given customer
        /// 
        /// Note that this call is lightning-fast and built for massive requesting : it uses an internal cache to avoid calling the API too often
        /// The caching increase the resilience of your integration : in case of a temporary communication problem, an error is returned, but the last known usages will be returned too by this method
        /// </summary>
        /// <param name="usages">The customer usages</param>
        /// <param name="referenceCustomer">(mandatory) the customer reference</param>
        /// <param name="forceReloading">(optional) true to force reloading of the cache</param>
        public virtual RequestReport FastListUsages(out List<Usage> usages, object referenceCustomer, bool forceReloading)
        {
            RequestReport result = null;
            usages = null;

            // if input is valid
            if (referenceCustomer != null)
            {
                // get cached usages for that customer
                CacheUsageByCustomer cache;
                if (!this._UsagesByCustomer.TryGetValue(referenceCustomer, out cache))
                {
                    // lock to prevent multi-threading side-effects
                    lock (this._UsagesByCustomer)
                    {
                        // get cached usages for that customer
                        // yes, we HAVE to do it again at this point (double check pattern)
                        if (!this._UsagesByCustomer.TryGetValue(referenceCustomer, out cache))
                        {
                            // if still not found, create a cache
                            cache = new CacheUsageByCustomer
                            {
                                // set it as expired to have an immediate loading
                                DateCache = DateTime.MinValue,
                                Usages = new List<Usage>()
                            };
                            // and store it
                            this._UsagesByCustomer.Add(referenceCustomer, cache);
                        }
                    }
                }

                // if we have a cache at this point (and we should)
                if(cache != null)
                {
                    // if reloading is forced
                    if (forceReloading)
                        // set the date as expired to force a reload
                        cache.DateCache = DateTime.MinValue;

                    // get current date
                    var now = DateTime.UtcNow;
                    // compute validity date
                    var dateValidity = now.AddMinutes(-CountMinutesCacheExpiration);
                    // if expired
                    if (cache.DateCache < dateValidity)
                    {
                        // lock it
                        lock (cache)
                        {
                            // if still expired
                            // yes, we HAVE to do it again at this point (double check pattern)
                            if (cache.DateCache < dateValidity)
                            {
                                // list customer's usages
                                ListPaginated<Usage> allUsages;
                                result = this.ListUsages(out allUsages, null, null, null, referenceCustomer, null, DoCacheAggregationByDefault, null, 1000);
                                // if any
                                if (allUsages != null)
                                    // store them
                                    cache.Usages = allUsages.Items;
                                // if no usages but we had NO error
                                else if (result == null)
                                    // then clear the cached usages : the customer has no usages anymore
                                    cache.Usages.Clear();

                                // if an error occured, do not clear the cached usages
                                // as the problem might be a temporary communication problem between the plateforms
                                // and we don't want the user be impacted

                                // finally, update the cache date
                                cache.DateCache = now;
                            }
                        }
                    }

                    // finally, get the usages in the cache
                    usages = cache.Usages;
                }
            }
            // if we miss a mandatory parameter
            else
                // return an error 
                result = new RequestReport
                {
                    Code = "Api.Client.FastListUsages.MissingParameter",
                    Message = "Missing parameter - FastListUsages requires a ReferenceCustomer"
                };

            return result;
        }

        #endregion

        #region Inner data

        /// <summary>
        /// Usages for given customer
        /// Note that the cached usages are automatically aggregated by customer, meaning it works perfectly fine if the customer has multiple subscriptions
        /// To prevent aggregation, just change the 'DoAggregateDefault' constant
        /// </summary>
        private Dictionary<object, CacheUsageByCustomer> _UsagesByCustomer = new Dictionary<object, CacheUsageByCustomer>();

        #endregion

        #region CacheUsageByCustomer

        /// <summary>
        /// Cache by customer definition
        /// </summary>
        internal class CacheUsageByCustomer
        {
            /// <summary>
            /// Cache date, used for expiration
            /// </summary>
            public DateTime DateCache { get; set; }
            /// <summary>
            /// Usages for given customer
            /// </summary>
            public List<Usage> Usages { get; set; }
        }

        #endregion
    }
}