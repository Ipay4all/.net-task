using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Response
{
    public class UserDetailResponse
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

    }
}
