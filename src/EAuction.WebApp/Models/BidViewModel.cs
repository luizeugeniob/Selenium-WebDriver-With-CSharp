using System.ComponentModel.DataAnnotations;

namespace EAuction.WebApp.Models
{
    public class BidViewModel
    {
        [Required]
        public int AuctionId { get; set; }

        [Required]
        public int LoggedUserId { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
