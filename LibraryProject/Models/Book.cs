using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    //Each book will have the following
    public class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage ="Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter a publisher")]
        public string Publisher { get; set; }

        [RegularExpression(@"/((978[\--– ])?[0-9][0-9\--– ]{10}[\--– ][0-9xX])|((978)?[0-9]{9}[0-9Xx])/")]
        [Required(ErrorMessage = "Please enter a ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter a category/class")]
        public string ClassCat { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        public double Price { get; set; }

        public int NumPages { get; set; }
    }
}
