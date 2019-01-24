//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.IO;
using System.Text;

namespace ProAbonoApi.Tools
{
    /// <summary>
    /// Encapsulates a stream writer which does not close the underlying stream
    /// 
    /// Required for .Net 4.0, provided in .Net 4.5
    /// </summary>
    public class StreamWriterEx : StreamWriter
    {
        /// <summary>
        /// Creates a new stream writer object
        /// </summary>
        /// <param name="stream">The underlying stream to write to.</param>
        /// <param name="encoding">The encoding for the stream.</param>
        public StreamWriterEx(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }

        /// <summary>
        /// Creates a new stream writer object using default encoding.
        /// </summary>
        /// <param name="stream">The underlying stream to write to.</param>
        public StreamWriterEx(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Disposes of the stream writer.
        /// </summary>
        /// <param name="disposeManaged">True to dispose managed objects.</param>
        protected override void Dispose(bool disposeManaged)
        {
            // Dispose the stream writer but pass false to the dispose
            // method to stop it from closing the underlying stream
            base.Dispose(false);
        }
    }
}
