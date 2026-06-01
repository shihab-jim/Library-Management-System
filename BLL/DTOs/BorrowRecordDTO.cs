using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class BorrowRecordDTO
    {
        public int BorrowRecordId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Student is required")]
        public int StudentId { get; set; }

        public string? StudentName { get; set; }
        public string? StudentNo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Book is required")]
        public int BookId { get; set; }

        public string? BookTitle { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? Status { get; set; }

        public decimal FineAmount { get; set; }
    }
}