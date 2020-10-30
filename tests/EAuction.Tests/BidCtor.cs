using EAuction.Core;
using System;
using Xunit;

namespace EAuctionTests
{
    [Trait("Tipo", "Unidade")]
    public class BidCtor
    {
        [Fact]
        public void ThrowsArgumentExceptionWhenAmountIsNegative()
        {
            //Arrange
            var amount = -100;

            //Act
            Action act = () => new Bid(null, amount);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }

    }
}
