using Ebuy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBuy.Models
{
    public class EBuyContext
    {
        public List<Auction> Auctions { get {
            return new List<Auction>();
        } }
    }
}