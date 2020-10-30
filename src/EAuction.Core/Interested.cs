using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EAuction.Core
{
    public class Interested
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; private set; }
        public IEnumerable<Bid> Bids { get; set; }
        public IEnumerable<Favorite> Favorites { get; set; }

        public Interested(string name)
        {
            Name = name;
        }
    }
}
