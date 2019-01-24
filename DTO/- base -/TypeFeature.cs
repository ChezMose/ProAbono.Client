//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

namespace ProAbonoApi
{
    /// <summary>
    /// Type of features
    /// </summary>
    public enum TypeFeature
    {
        /// <summary>
        /// Feature is not metered, it's enabled or disabled
        /// </summary>
        OnOff,

        /// <summary>
        /// Feature represents something limited
        /// In a subscription, if the current quantity is changed and exceed the included quantity, then a prorata is computed and billed
        /// At renewal, if the quantity exceed the included quantity, it's billed
        /// </summary>
        Limitation,

        /// <summary>
        /// Feature represents something consumed
        /// In a subscription, the quantity is reseted at renewal, and might be billed if it exceeds the included quantity.
        /// </summary>
        Consumption,
    }
}