namespace EAuction.Core
{
    public class Favorite
    {
        public int AuctionId { get; set; }
        public int InterestedId { get; set; }
        public Auction FavoriteAuction { get; set; }
        public Interested Follower { get; set; }
    }
}
