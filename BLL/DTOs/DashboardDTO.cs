namespace BLL.DTOs
{
    public class DashboardDTO
    {
        public int TotalBooks { get; set; }
        public int TotalStudents { get; set; }
        public int TotalBorrowRecords { get; set; }
        public int TotalIssuedBooks { get; set; }
        public int TotalReturnedBooks { get; set; }
        public int TotalOverdueBooks { get; set; }
        public decimal TotalFineAmount { get; set; }
    }
}