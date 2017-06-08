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
using Ebuy.Common.DataAccess;
using Ebuy.Common.Clz;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EBuy.Controllers
{
    public class SearchController : AsyncController
    {
        private readonly IRepository _repository;
       
        public SearchController() {
            DataContext dbContext = new DataContext();
            _repository = new Repository(dbContext);

        }
      
      
        public ActionResult Index(SearchCriteria criteria) {
            IQueryable<Auction> auctionData = null;
            if (!string.IsNullOrEmpty(criteria.SearchKeyword))
            {
                auctionData = _repository.Query<Auction>(q => q.Description.Contains(criteria.SearchKeyword));
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
            viewModel.SearchResult = ConvertToViewModel(auctionData);// Mapper.DynamicMap<IEnumerable<AuctionViewModel>>(auctionData);
            viewModel.PagingSizeList=new List<int>(){10,20,30};
            viewModel.SortByFieldList = new List<string>() { "Price", "RemainingTime", "SearchKeyword" };
            viewModel.CurrentPage = 1; viewModel.PagingSize = 10; viewModel.MaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(auctionData.Count() / (double)viewModel.PagingSize)));
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

        private IEnumerable<AuctionViewModel> ConvertToViewModel(IQueryable<Auction> auctionData) {
            IEnumerable<AuctionViewModel> result = null;
            foreach (var auction in auctionData) {
                AuctionViewModel model = new AuctionViewModel();
                model.Id =auction.Id;
                model.Title = auction.Title;
                model.Description = auction.Description;
                model.CurrentPrice = auction.CurrentPrice;
                model.RemainingTimeDisplay = (DateTime.Now-auction.EndTime).ToString();
                model.Image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1496754607375&di=e8e313f9a0c24aae8acb59da098a2553&imgtype=0&src=http%3A%2F%2Fmvimg1.meitudata.com%2F56495268396777670.jpg";
                yield return model;
            }
        }

        #region Async 异步操作，ASP.NET MVC4 之前使用
        public void SearchForBidsAsync(int Id,DateTime start, DateTime end) {
            AsyncManager.OutstandingOperations.Increment();
            var worker = new BackgroundWorker();
            worker.DoWork += (o, e) => SearchForBids(Id, e, start, end);
            worker.RunWorkerCompleted += (o, e) =>
            {
                AsyncManager.Parameters["bids"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            };
            worker.RunWorkerAsync();
        }
        private void SearchForBids(int Id, DoWorkEventArgs e, DateTime start, DateTime end) {
            var bids = _repository.Query<Bid>(x => x.Timestamp >= start && x.Timestamp <= end).OrderByDescending(x => x.Timestamp);
            e.Result = bids;
        }
        public ActionResult SearchForBidsCompleted(IEnumerable<Bid> bids) {
            return Json(bids, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ASP.NET MCV4.5 异步编程
        //[AysncTimeout(2500)]
        [HandleError(ExceptionType=typeof(TaskCanceledException),View="AjaxTimedOut")]
        public async Task<ActionResult> SearchForBids(string Id, DateTime start, DateTime end) {
            var bids = await Search(Id, start, end);
            return Json(bids, JsonRequestBehavior.AllowGet);
        }
        
        private async Task<IEnumerable<Bid>> Search(string Id,DateTime start,DateTime end) {
            var bids = _repository.Query<Bid>(x => x.Timestamp >= start && x.Timestamp <= end).OrderByDescending(x => x.Timestamp);
            return  bids;
        }
        #endregion
    }
}
