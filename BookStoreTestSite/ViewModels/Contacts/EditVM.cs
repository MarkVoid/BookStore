using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Contacts
{
    public class EditVM
    {
        public int ContactId { get; set; }

        [DisplayName("Phone Number:")]
        [Required(ErrorMessage = "This field is required!")]
        public int PhoneNumber { get; set; }
    }
}
