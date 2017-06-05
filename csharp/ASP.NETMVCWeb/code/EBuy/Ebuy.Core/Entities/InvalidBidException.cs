using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
    public class InvalidBidException:Exception
    {
        public InvalidBidException(Currency bidAmount,Bid winningBid) { 
            
        }
      
    }
}
