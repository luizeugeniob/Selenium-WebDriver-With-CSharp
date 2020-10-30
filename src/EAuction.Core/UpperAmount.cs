using System.Linq;

namespace EAuction.Core
{
    public class UpperAmount : IEvaluationMode
    {
        public Bid Rate(Auction auction)
        {
            return auction.Bids
                    .DefaultIfEmpty(new Bid(null, 0))
                    .OrderBy(l => l.Amount)
                    .LastOrDefault();
        }
    }
}
