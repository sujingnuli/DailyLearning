using Ebuy.Common.Entities;
using EBuy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace EBuy.Api
{
    public class AuctionCsvFormatter:BufferedMediaTypeFormatter
    {
        public AuctionCsvFormatter() {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }
        public override bool CanWriteType(Type type)
        {
            if (type == typeof(Auction))
            {
                return true;
            }
            else {
                Type enumerableType = typeof(IEnumerable<Auction>);
                return enumerableType.IsAssignableFrom(type);
            }
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }
        public override void WriteToStream(Type type, object value, Stream stream,HttpContent content)
        {
            var source = value as IEnumerable<Auction>;
            if (source != null) {
                foreach (var item in source) {
                    WriteItem(item, stream);
                }
            }
        }
        private void WriteItem(Auction Item, Stream stream) {
            var writer = new StreamWriter(stream);
            writer.Write("{0},{1},{2}",
                Encode(Item.Title),
                Encode(Item.Description),
                Encode(Item.CurrentPrice)
                );
            writer.Flush();
        }
        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };
        private string Encode(object o) {
            string result = "";
            if (o != null) {
                string data = o.ToString();
                if (data.IndexOfAny(_specialChars) != -1) {
                    result = String.Format("\"{0}\"", data.Replace("\"", "\"\""));
                }
            }
            return result;
        }
    }
}