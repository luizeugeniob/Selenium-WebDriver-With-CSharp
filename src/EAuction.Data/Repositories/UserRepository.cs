using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EAuction.WebApp.Data
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(EAuctionContext context) : base(context) { }

        public override User GetById(int id)
        {
            return _context.Users
                .Include(u => u.Interested)
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
