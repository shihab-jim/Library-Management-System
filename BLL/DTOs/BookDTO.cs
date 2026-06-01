using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Total copies is required")]
        [Range(1, 1000, ErrorMessage = "Total copies must be greater than 0")]
        public int TotalCopies { get; set; }

        [Required(ErrorMessage = "Available copies is required")]
        [Range(0, 1000, ErrorMessage = "Available copies cannot be negative")]
        public int AvailableCopies { get; set; }
    }
}