using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
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

        [Required(ErrorMessage = "Please enter a ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter a category/class")]
        public string ClassCat { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        public double Price { get; set; }
    }
}
