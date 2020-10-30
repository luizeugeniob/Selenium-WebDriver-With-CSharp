using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EAuction.WebApp.Data
{
    public class AuctionRepository : BaseRepository<Auction>
    {
        public AuctionRepository(EAuctionContext context) : base(context) { }

        public override Auction GetById(int id)
        {
            return _context.Auctions
                .Include(l => l.Bids)
                .Include(l => l.Followers)
                .FirstOrDefault(l => l.Id == id);
        }
    }
}
