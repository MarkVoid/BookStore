using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Books
{
    public class EditVM
    {
        public int BookId { get; set; }

        [DisplayName("Author:")]
        [Required(ErrorMessage = "This field is required!")]
        public string Author { get; set; }

        [DisplayName("Genre:")]
        [Required(ErrorMessage = "This field is required!")]
        public string Genre { get; set; }

        [DisplayName("Name:")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }
    }
}
