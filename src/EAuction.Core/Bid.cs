using System.ComponentModel.DataAnnotations;

namespace EAuction.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public double Amount { get; private set; }
        [Required]
        public Interested Interested { get; set; }
        [Required]
        public Auction Auction { get; set; }

        private void VerifyIfBidIsValid(double amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentException("Valor do lance deve ser igual ou maior que zero.");
            }
        }

        public Bid(double amount)
        {
            VerifyIfBidIsValid(amount);
            Amount = amount;
        }

        public Bid(Interested interested, double amount)
        {
            VerifyIfBidIsValid(amount);
            Interested = interested;
            Amount = amount;
        }
    }
}
