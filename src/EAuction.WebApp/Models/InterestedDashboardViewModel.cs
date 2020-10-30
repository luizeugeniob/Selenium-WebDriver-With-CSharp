using EAuction.Core;
using System.Collections.Generic;

namespace EAuction.WebApp.Models
{
    public class InterestedDashboardViewModel
    {
        public IEnumerable<Bid> MyOffers { get; set; }
        public IEnumerable<Auction> FavoriteAuctions { get; set; }
    }
}
