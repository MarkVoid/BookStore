using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Home
{
    public class LoginVM
    {
        [DisplayName("Username:")]
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [DisplayName("Password:")]
        [Required(ErrorMessage = "This field is required!")]

        public string Password { get; set; }
    }
}
