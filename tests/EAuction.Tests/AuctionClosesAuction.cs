using EAuction.Core;
using System;
using Xunit;

namespace EAuctionTests
{
    [Trait("Tipo", "Unidade")]
    public class AuctionClosesAuction
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void ReturnNearestUpperAmountWhenAuctionIsNearestUpperAmountModality(double targetAmount, double expectedAmount, double[] amounts)
        {
            //Arrange
            IEvaluationMode mode = new NearestUpperAmount(targetAmount);
            var auction = new Auction("Van Gogh", mode);
            var johnDoe = new Interested("John Doe");
            var janeDoe = new Interested("Jane Doe");

            auction.StartAuction();

            for (int i = 0; i < amounts.Length; i++)
            {
                double amount = amounts[i];
                if ((i % 2) == 0)
                {
                    auction.ReceiveBid(johnDoe, amount);
                }
                else
                {
                    auction.ReceiveBid(janeDoe, amount);
                }
            }

            //Act
            auction.FinishAuction();

            //Assert
            Assert.Equal(expectedAmount, auction.Winner.Amount);
        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void ReturnMaxAmountWhenHaveAtLastOneBid(double expectedAmount, double[] amounts)
        {
            //Arrange
            var modality = new UpperAmount();
            var auction = new Auction("Van Gogh", modality);
            var johnDoe = new Interested("John Doe");
            var janeDoe = new Interested("Jane Doe");

            auction.StartAuction();

            for (int i = 0; i < amounts.Length; i++)
            {
                double amount = amounts[i];
                if ((i % 2) == 0)
                {
                    auction.ReceiveBid(johnDoe, amount);
                }
                else
                {
                    auction.ReceiveBid(janeDoe, amount);
                }
            }

            //Act
            auction.FinishAuction();

            //Assert
            Assert.Equal(expectedAmount, auction.Winner.Amount);
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenCloseAuctionNotStarted()
        {
            //Arrange
            var evaluation = new UpperAmount();
            var auction = new Auction("Van Gogh", evaluation);

            //Act
            Action act = () => auction.FinishAuction();

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal($"Não é possível fechar um leilão sem iniciá-lo. Utilize o método {nameof(auction.StartAuction)}.", exception.Message);
        }

        [Fact]
        public void ReurnZeroWhenHaveNoBids()
        {
            //Arrange
            var evaluation = new UpperAmount();
            var auction = new Auction("Van Gogh", evaluation);
            auction.StartAuction();

            //Act
            auction.FinishAuction();

            //Assert
            Assert.Equal(0, auction.Winner.Amount);
        }
    }
}
