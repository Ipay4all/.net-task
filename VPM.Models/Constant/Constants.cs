using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Constant
{
    public class Constants
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
        public class SearchParameters
        {
            public const string PageSize = "PageSize";
            public const string UserId = "user_id";
            public const string IsFromDevice = "IsFromDevice";
            public const string ScrollId = "ScrollId";
            public const string ShowOnlyActive = "ShowOnlyActive";
            public const string ShowShared = "ShowShared";
            public const string ShowMy = "ShowMy";
            public const string ShowAll = "ShowAll";
            public const string ModifiedAfter = "ModifiedAfter";
            public const string RequiredFields = "RequiredFields";
            public const string Filters = "Filters";
            public const string ContinuationToken = "ContinuationToken";
            public const string SortOrder = "SortOrder";
            public const string SortColumn = "SortColumn";
            public const string SearchText = "SearchText";
            public const string PageStart = "Page";
            public const string Conjuction = "Conjuction";

        }
        public static class DatabaseErrorCodes
        {
            public const string NotExist = "51000";
            public const string NotAllowed = "52000";
        }

    }
}
