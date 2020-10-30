using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EAuction.WebApp.Data
{
    public class InterestedRepository : BaseRepository<Interested>
    {
        public InterestedRepository(EAuctionContext context) : base(context) { }

        public override Interested GetById(int id)
        {
            return _context.Interesteds
                .Where(i => i.Id == id)
                .Include(i => i.Favorites)
                .ThenInclude(f => f.FavoriteAuction)
                .Include(i => i.Bids)
                .ThenInclude(l => l.Auction)
                .FirstOrDefault();
        }
    }
}
