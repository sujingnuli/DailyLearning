using AutoMapper;
using Ebuy.Common.Entities;
using Ebuy.Common.Inter;
using EBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebuy.Common.Extensions;

namespace EBuy.Controllers
{
    public class SearchController : Controller
    {
        private readonly IRepository _repository;
        public SearchController(IRepository repository) {
            this._repository = repository;
        }

   
        public ActionResult Index(SearchCriteria criteria) {
            IQueryable<Auction> auctionData = null;
            if (!string.IsNullOrEmpty(criteria.SearchKeywork))
            {
                auctionData = _repository.Query<Auction>(q => q.Description.Contains(criteria.SearchKeywork));
            }
            else {
                auctionData = _repository.All<Auction>();
            }

            switch (criteria.GetSortByField()) { 
                case SearchCriteria.SearchFieldType.Price:
                    auctionData = auctionData.OrderBy(q => q.CurrentPrice.Value);
                    break;
                case SearchCriteria.SearchFieldType.RemainingTime:
                    auctionData = auctionData.OrderBy(q => q.EndTime);
                    break;
                case SearchCriteria.SearchFieldType.Keyword:
                default:
                    auctionData = auctionData.OrderBy(q => q.Title);
                    break;
            }
            auctionData = PageSearchResult(criteria, auctionData);

            var viewModel = new SearchViewModel();
            Mapper.DynamicMap(criteria, viewModel);
            viewModel.SearchResult = Mapper.DynamicMap<IEnumerable<AuctionViewModel>>(auctionData);
            return View("Search",viewModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="auctionData"></param>
        /// <returns></returns>
        private IQueryable<Auction> PageSearchResult(SearchCriteria criteria, IQueryable<Auction> auctionData) {
            IQueryable<Auction> result;
            var numbersOfItems = auctionData.Count();
            if (numbersOfItems > criteria.GetPageSize())
            {
                var maxNumberOfPages = numbersOfItems / criteria.GetPageSize();
                if (criteria.CurrentPage > maxNumberOfPages) {
                    criteria.CurrentPage = maxNumberOfPages;
                }
                result = auctionData.Page(criteria.CurrentPage, criteria.GetPageSize()).AsQueryable();
            }
            else {
                result = auctionData;
            }
            return result;
        }
      
    }
}
