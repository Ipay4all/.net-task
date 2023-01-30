using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.CustomModels
{
    public class SearchResult<T> : ISearchResult<T>
    {
        //public int PageSize { get; set; }
        //public int TotalResults { get; set; }
        //public IList<BsonDocument> Results { get; set; }
        public IList<T> Results { get; set; }

        public Meta Meta { get; set; }

    }
}
