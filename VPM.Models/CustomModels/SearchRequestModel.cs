using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.CustomModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchRequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchRequestModel()
        {
            Page = 1;
            PageSize = 10;
        }

        /// <summary>
        /// Search string to look up for matching results. 
        /// </summary>
        [JsonProperty(PropertyName = "search_text")]
        public string SearchText { get; set; }

        /// <summary>
        /// Expected page number in the result set.
        /// </summary>
        [JsonProperty(PropertyName = "page")]

        public int Page { get; set; }

        /// <summary>
        /// Page size of the result set.
        /// </summary>
        [JsonProperty(PropertyName = "page_size")]


        public int PageSize { get; set; }

        /// <summary>
        /// The column / attribute by which the results shall be sorted.
        /// </summary>
        [JsonProperty(PropertyName = "sort_column")]
        public string SortColumn { get; set; }

        /// <summary>
        /// The order by which the results shall be sorted.  Possible values are 'asc' for ascending order, 'desc' for descending order.
        /// </summary>
        [JsonProperty(PropertyName = "sort_order")]

        public string SortOrder { get; set; }
        public object ResponseClassName { get; set; }

        /// <summary>
        /// Search filter list to look up for matching results. If must be in format '[{key:'keyname',value:'keyvalue'},{key:'keyname',value:'keyvalue'}]'.
        /// </summary>
        public string Filters { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FilterRequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "key", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "condition", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "from", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object From { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object To { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AppointmentsSearchRequestModel : SearchRequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string organisation_sid { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "from_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public object from_date { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "to_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public object to_date { get; set; }

        /// <summary>
        /// string to look up for matching appointement status.
        /// </summary>
        public string appointements_status { get; set; }

        /// <summary>
        /// Search string to look up for matching results in patient's city,country and region details.
        /// </summary>
        public string region_search_text { get; set; }

        /// <summary>
        /// Search string to look up for matching results in organisation details.
        /// </summary>
        public string organisation_search_text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string organisation_specialty_map_sid { get; set; }

        /// <summary>
        /// Search string to look up for matching results in clinician details.
        /// </summary>
        public string clinician_search_text { get; set; }

        /// <summary>
        /// Search string to look up for matching results in patient details. 
        /// </summary>
        public string patient_search_text { get; set; }

    }
}
