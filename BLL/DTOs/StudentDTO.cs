using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student number is required")]
        public string StudentNo { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
    }
}