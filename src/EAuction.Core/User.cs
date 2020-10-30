using System.ComponentModel.DataAnnotations;

namespace EAuction.Core
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Interested Interested { get; set; }
    }
}
