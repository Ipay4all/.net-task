using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Response
{
    public class UserAuthenticationResponse
    {
        /// <summary>
        /// id of the user.
        /// </summary>
        [JsonProperty("id")]
        public int id { get; set; }

        /// <summary>
        /// sid of the user.
        /// </summary>
        [JsonProperty("sid")]
        public Guid sid { get; set; }
        /// <summary>
        ///  Email address.
        /// </summary>
        [JsonProperty("email")]
        public string email { get; set; }
        /// <summary>
        ///  First name of the user.
        /// </summary>
        [JsonProperty("first_name")]
        public string firstName { get; set; }

        /// <summary>
        ///  Last name of the user.
        /// </summary>
        [JsonProperty("last_name")]
        public string lastName { get; set; }
        /// <summary>
        /// The string that system assign you to call internal API's
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
        /// <summary>
        /// The string that system assign you to refresh Token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
