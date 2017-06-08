using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
    public class Auction:Entity<Guid>
    {
       
        public int Id { get; set; }
        [Required,StringLength(500)]
        public virtual string Title { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual Currency CurrentPrice { get; set; }

        public Guid? WinningBidId { get; set; }
        public virtual Bid WinningBid { get; private set; }

        public bool IsCompleted
        {
            get
            {
                return EndTime <= DateTime.Now;
            }
        }
        public virtual bool IsFeaturedAuction { get; private set; } //featured 特色的
        public virtual ICollection<Category> Categories { get; set; } //category 类别，目录
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<WebsiteImage> Images { get; set; }

        private long OwnerId { get; set; }
        

        public virtual CurrencyCode CurrencyCode {
            get { return (CurrentPrice != null) ? CurrentPrice.Code : null; }
        }

        public Auction() {
            Bids = new Collection<Bid>();
            Categories = new Collection<Category>();
            Images = new Collection<WebsiteImage>();
        }
        public void FeatureAuction() {
            IsFeaturedAuction = true;
        }
        public Bid PostBid(User user, double bidAmount) {
            return PostBid(user, new Currency(CurrencyCode, bidAmount));
        }
        public Bid PostBid(User user, Currency bidAmount) {
            Contract.Requires(user != null);
            if (bidAmount.Code != CurrencyCode) {
                throw new InvalidBidException(bidAmount, WinningBid);
            }
            if (bidAmount.Value <= CurrentPrice.Value) {
                throw new InvalidBidException(bidAmount, WinningBid);
            }
            var bid = new Bid(user, this, bidAmount);
            WinningBidId = bid.Id;
            Bids.Add(bid);

            return bid;
        }

    }
}
