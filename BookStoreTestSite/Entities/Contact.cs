using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public int UserId { get; set; }

        [Required]
        public int PhoneNumber { get; set; } 

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
