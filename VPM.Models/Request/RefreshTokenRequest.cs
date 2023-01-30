using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Request
{
    public class RefreshTokenRequest
    {
        /// <summary>
        /// The string that system assign for refresh token.
        /// </summary>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The string that you assign as name.
        /// </summary>
        [JsonProperty("sid")]
        public Guid SID { get; set; }

    }
}
