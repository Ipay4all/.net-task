using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Response
{
    public class CurrencyDropdownListResponse
    {
        /// <summary>
        /// The unique string that we created to identify Entity.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// The string that assigend a value of key.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
