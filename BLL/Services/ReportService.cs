using BLL.DTOs;
using DAL.Repos;

namespace BLL.Services
{
    public class ReportService
    {
        ReportRepo repo;

        public ReportService(ReportRepo repo)
        {
            this.repo = repo;
        }

        public DashboardDTO GetDashboard()
        {
            DashboardDTO dto = new DashboardDTO();

            dto.TotalBooks = repo.TotalBooks();
            dto.TotalStudents = repo.TotalStudents();
            dto.TotalBorrowRecords = repo.TotalBorrowRecords();
            dto.TotalIssuedBooks = repo.TotalIssuedBooks();
            dto.TotalReturnedBooks = repo.TotalReturnedBooks();
            dto.TotalOverdueBooks = repo.TotalOverdueBooks();
            dto.TotalFineAmount = repo.TotalFineAmount();

            return dto;
        }
    }
}