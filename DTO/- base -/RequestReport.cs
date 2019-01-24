//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace ProAbonoApi
{
    /// <summary>
    /// ProAbono error report
    /// </summary>
    [DataContract]
    public class RequestReport
    {
        #region Construction

        /// <summary>
        /// Empty
        /// </summary>
        public RequestReport()
        {
            this.StatusCode = 500;
        }
        /// <summary>
        /// With a status code
        /// </summary>
        public RequestReport(HttpStatusCode statusCode)
        {
            this.StatusCode = (int) statusCode;
        }

        #endregion

        #region Public tools

        /// <summary>
        /// Check if request is a success
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return (this.StatusCode >= 200)
                       && (this.StatusCode < 300);
            }
        }

        #endregion

        #region Public data properties

        /// <summary>
        /// Returned status code
        /// </summary>
        [DataMember]
        public int StatusCode { get; set; }
        /// <summary>
        /// Error status
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Target { get; set; }
        /// <summary>
        /// Error code
        /// </summary>
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// Exception
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public string Exception { get; set; }

        #endregion

        #region String conversion

        /// <summary>
        /// Package in a single string
        /// </summary>
        public override string ToString()
        {
            var result = new StringBuilder(200);

            // append the status code
            result.Append("[");
            result.Append(this.StatusCode);

            // append the status
            result.Append("] ");

            // if we got a message
            if(this.Message!= null)
            {
                result.Append(this.Message);
            }

            // if we got an excepiton
            if(this.Target != null)
            {
                result.Append(" (target: ");
                result.Append(this.Target);
                result.Append(")");
            }

            // if we got an excepiton
            if(this.Exception != null)
            {
                result.Append(" (");
                result.Append(this.Exception);
                result.Append(")");
            }

            return result.ToString();
        }

        #endregion
    }
}
