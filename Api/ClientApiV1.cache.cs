//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System;
using ProAbonoApi.Tools;
using System.Collections.Generic;

namespace ProAbonoApi.Implementation
{
    /// <summary>
    /// ProAbono client for API
    /// </summary>
    partial class ClientApiV1
    {
        #region Cache

        /// <summary>
        /// Invalidate the internal cache
        /// </summary>
        public void InvalidateCache()
        {
            // lock to prevent multi-threading side-effects
            lock (this._UsagesByCustomer)
            {
                // just clear its content
                this._UsagesByCustomer.Clear();
            }
        }

        #endregion
    }
}