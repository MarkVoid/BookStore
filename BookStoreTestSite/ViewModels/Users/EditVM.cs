using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Users
{
    public class EditVM
    {
        public int UserId { get; set; }

        [DisplayName("Username:")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [DisplayName("Password:")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

        [DisplayName("First Name:")]
        [Required(ErrorMessage = "This field is required!")]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "This field is required!")]
        public string LastName { get; set; }
    }
}
