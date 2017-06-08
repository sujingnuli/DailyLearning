using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
    public class Bid:Entity<Guid>
    {
        public Guid Id { get; set; }
        public Auction Auction { get; set; }
        public DateTime Timestamp { get; set; }
        public Bid(User user, Auction auction, Currency bidAmount) { 
            
        }
    }
}
