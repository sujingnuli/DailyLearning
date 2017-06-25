using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EBuy.Filters
{
    public class EbuyCustomConnection:PersistentConnection
    {
        /// <summary>
        /// SignalR ,定义了持久链接的两种编程模式，Hubs，PersistentConnection
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        //protected override Task OnReceived(IRequest request, string connectionId, string data)
        //{
           
        //    //向所有客户端广播消息
        //    return Connection.Broadcast(data);
        //}
    
    }
}