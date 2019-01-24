//////////////////////////////////////////////////////////////////////
// SubscriptionTech SAS 2016 - all rights reserved
//////////////////////////////////////////////////////////////////////

using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProAbonoApi.Tools
{
    /// <summary>
    /// Serializer for JSON
    /// 
    /// Offensive : throw an exception if serialization / deserialization failed
    /// Do not forget the DataContract & DataMember attributes on your objects
    /// </summary>
    public static class SerializerForJson
    {
        #region Public

        /// <summary>
        /// Deserialize the content from given stream
        /// </summary>
        public static TContent Deserialize<TContent>(Stream inputStream)
            where TContent : class
        {
            TContent result = null;

            // if we got a stream
            if (inputStream != null)
            {
                // create the serializer
                var serializer = JsonSerializer.Create(SettingsDefault);

                ////////////////////////////////////////
                // As JsonTextReader consumes the stream, we dump it into a MemoryStrem for a second-chance deserialization
                using(var memStream = new MemoryStream())
                {
                    ////////////////////////////////////////
                    // dump the stream

                    // create a buffer
                    var buffer = new byte[1024];
                    int byteCount;

                    // read
                    do
                    {
                        byteCount = inputStream.Read(buffer, 0, buffer.Length);
                        memStream.Write(buffer, 0, byteCount);
                    }
                    // read until end of stream
                    while (byteCount > 0);

                    // reset memory stream position
                    memStream.Position = 0;
                    ////////////////////////////////////////

                    // reset the input stream, in case it was previously read
                    memStream.Position = 0;
                    // push the input stream as a StreamReader
                    using (var textReader = new StreamReader(memStream))
                    {
                        // open the Json Reader
                        using (var reader = new JsonTextReader(textReader))
                        {
                            // deserialize
                            result = (serializer.Deserialize(reader, typeof (TContent)) as TContent);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Serailize the content into given stream
        /// </summary>
        public static bool Serialize<TContent>(Stream outputStream, TContent content, Encoding encoding)
            where TContent : class
        {
            var result = false;

            // if we got a content
            if(content != null)
            {
                // create the serializer
                var serializer = JsonSerializer.Create(SettingsDefault);
                // convert the output stream as an encoded StreamWriter
                using(var textWriter = new StreamWriterEx(outputStream))
                {
                    // open the Json Writer
                    using (var writer = new JsonTextWriter(textWriter))
                    {
                        // we want indented json in output
                        writer.Formatting = Formatting.Indented;

                        // serialize
                        serializer.Serialize(writer, content);
                        // flush the writer
                        writer.Flush();
                    }
                }
                // success
                result = true;
            }
            return result;
        }

        #endregion

        #region SettingsDefault

        /// <summary>
        /// Default settings
        /// </summary>
        private static JsonSerializerSettings _Settings = null;
        /// <summary>
        /// Default settings
        /// </summary>
        private static JsonSerializerSettings SettingsDefault
        {
            get
            {
                // is no settings yet
                if (_Settings == null)
                {
                    // base settings
                    _Settings = new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                    , MissingMemberHandling = MissingMemberHandling.Ignore
                                };

                    // DateTime conversion
                    _Settings.Converters.Add(new IsoDateTimeConverter
                                                 {
                                                     DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.ff'Z'"
                                                 });

                    // Enum conversion
                    _Settings.Converters.Add(new StringEnumConverter());
                }
                return _Settings;
            }
        }

        #endregion
    }
}