using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EBuy.Models
{
    /**
     * 数据上下文类
     * */
    public class EbuyDataContext : DbContext {
        public DbSet<Auction> Auctions { get; set; }
        //public EbuyDataContext()
        //{
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EbuyDataContext>());
        //}
    }

    public class Auction
    {
        public int id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="Title cannot be longer than 50 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Href { get; set; }
        [Range(1,10000,ErrorMessage="The auction's price must be at least 1")]
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}