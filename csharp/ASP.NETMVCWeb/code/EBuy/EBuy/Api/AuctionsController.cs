using Ebuy.Core.Inter;
using EBuy.Filters;
using EBuy.Models;
using EBuy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EBuy.Api
{
    public class AuctionsController : ApiController
    {
       
         //GET api/auctions
        public IEnumerable<Auction> Get()
        {
            return null;
        }
        [HttpGet]
        [CustomExceptionFilter]
        public Auction FindAuction(int id) {
            Auction auction = BeanUtil.GetById<Auction>(id,"Auctions");
            if (auction == null) {
                var errorMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                errorMessage.Content = new StringContent(string.Format("Invalid id,auction is Invalid for id:{0}.", id));
                errorMessage.ReasonPhrase="Not Found";
                throw new HttpResponseException(errorMessage);
            }
            return auction;
           
        }
       
        // POST api/auctions
        public void Post(Auction auction)
        {
          
        }

        // PUT api/auctions/5
        public void Put(int id, [FromBody]string value)
        {
          
        }

        // DELETE api/auctions/5
        public void Delete(int id)
        {
          
        }
    }
}
