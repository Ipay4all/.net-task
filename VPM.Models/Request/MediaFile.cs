using Newtonsoft.Json;
using System;

namespace VPM.Models.Request
{
    public class MediaFile
    {
        /// <summary>
        /// The physical file that you upload for the Asset.
        /// </summary>
        [JsonProperty("file")]
        public byte[] file { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string filename { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string fileType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long fileSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public Int64 fileWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public Int64 fileHeight { get; set; }


        /// <summary>
        /// The physical file that you upload for the Asset.
        /// </summary>
        [JsonProperty("file")]
        public byte[] thumbfile { get; set; }
    }
}
