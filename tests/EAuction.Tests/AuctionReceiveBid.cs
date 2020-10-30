using Xunit;
using EAuction.Core;
using System.Linq;

namespace EAuctionTests
{
    [Trait("Tipo", "Unidade")]
    public class AuctionReceiveBid
    {
        [Fact]
        public void DoesNotAllowReceiveBidWhenLastBidIsFromSameInterested()
        {
            //Arrange
            var evaluation = new UpperAmount();
            var auction = new Auction("Van Gogh", evaluation);
            var johnDoe = new Interested("John Doe");
            auction.StartAuction();
            auction.ReceiveBid(johnDoe, 800);

            //Act
            auction.ReceiveBid(johnDoe, 1000);

            //Assert
            Assert.Single(auction.Bids);
        }

        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void DoesNotAllowReceiveNewBidWhenAuctionIsClosed(
            int quantityBidsExpected, double[] amounts)
        {
            //Arranje
            var evaluation = new UpperAmount();
            var auction = new Auction("Van Gogh", evaluation);
            var johnDoe = new Interested("John Doe");
            var janeDoe = new Interested("Jane Doe");

            auction.StartAuction();

            for (int i = 0; i < amounts.Length; i++)
            {
                var amount = amounts[i];
                if ((i%2)==0)
                {
                    auction.ReceiveBid(johnDoe, amount);
                }
                else
                {
                    auction.ReceiveBid(janeDoe, amount);
                }
            }

            auction.FinishAuction();

            //Act
            auction.ReceiveBid(johnDoe, 1000);

            //Assert
            Assert.Equal(quantityBidsExpected, auction.Bids.Count());
        }
    }
}
