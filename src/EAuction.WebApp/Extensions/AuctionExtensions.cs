using EAuction.Core;
using EAuction.WebApp.Models;

namespace EAuction.WebApp.Extensions
{
    public static class AuctionExtensions
    {
        public static AuctionViewModel ToViewModel(this Auction auction)
        {
            return new AuctionViewModel
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                Category = auction.Category,
                Image = auction.Image,
                StartAuctionDate = auction.StartAuctionDate,
                FinishAuctionDate = auction.FinishAuctionDate,
                InitialAmount = auction.InitialAmount,
                State = auction.State,
                Bids = auction.Bids
            };
        }

        public static Auction ToModel(this AuctionViewModel auction)
        {
            return new Auction(auction.Title, null)
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                Category = auction.Category,
                Image = auction.Image,
                StartAuctionDate = auction.StartAuctionDate,
                FinishAuctionDate = auction.FinishAuctionDate,
                InitialAmount = auction.InitialAmount
            };
        }
    }
}
