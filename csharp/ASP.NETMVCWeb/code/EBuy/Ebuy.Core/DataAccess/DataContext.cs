using Ebuy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.DataAccess
{
    public class DataContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Auction> Auctions { get; set; }

        public IList<Auction> GetAuctionsByCategory(Category category) {
            IList<Auction> result = null;
            var db = new DataContext();
            result = db.Auctions.Where(q => q.Categories.Equals(category)).ToList();
            return result;
        }
        /// <summary>
        /// 实现多对多的关系，以Bid和Auction为例
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>().HasRequired(x => x.Auction).WithMany().WillCascadeOnDelete(false);
        }

    }
  
}
