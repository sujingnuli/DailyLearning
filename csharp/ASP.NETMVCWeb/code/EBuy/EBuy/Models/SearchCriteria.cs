using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBuy.Models
{
    public class SearchCriteria
    {
        public enum SearchFieldType { 
            Keyword,
            Price,
            RemainingTime
        }
        public string SearchKeywork { get; set; }
        public string SortByField { get; set; }
        public string PagingSize { get; set; }
        public int CurrentPage { get; set; }

        public int GetPageSize() {
            int result = 5;
            if (!string.IsNullOrEmpty(this.PagingSize)) {
                int.TryParse(this.PagingSize, out result);
            }
            return result;
        }

        public SearchFieldType GetSortByField() {
            SearchFieldType result = SearchFieldType.Keyword;
            switch(this.SortByField){
                case "Price":
                    result = SearchFieldType.Price;
                    break;
                case "Remaining Time":
                    result = SearchFieldType.RemainingTime;
                    break;
                default:
                    result = SearchFieldType.Keyword;
                    break;
            }
            return result;
        }

    }
}