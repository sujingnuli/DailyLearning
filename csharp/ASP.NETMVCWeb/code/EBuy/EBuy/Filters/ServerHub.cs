using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace EBuy.Filters
{
    public class ServerHub : Hub
    {
        public Task Message(string message) {
          return  Clients.All.Message(message);
           
        }
    }
}