
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBuy.Filters
{
    public class EbuyCustomHub:Hub
    {
        public void SendMessage(string message) {
            Clients.All.displayMessage(message);
        }
    }
}