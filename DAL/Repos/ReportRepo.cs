using DAL.EF;

namespace DAL.Repos
{
    public class ReportRepo
    {
        LibraryDbContext db;

        public ReportRepo(LibraryDbContext db)
        {
            this.db = db;
        }

        public int TotalBooks()
        {
            return db.Books.Count();
        }

        public int TotalStudents()
        {
            return db.Students.Count();
        }

        public int TotalBorrowRecords()
        {
            return db.BorrowRecords.Count();
        }

        public int TotalIssuedBooks()
        {
            return db.BorrowRecords.Count(b => b.Status == "Issued");
        }

        public int TotalReturnedBooks()
        {
            return db.BorrowRecords.Count(b => b.Status == "Returned");
        }

        public int TotalOverdueBooks()
        {
            return db.BorrowRecords.Count(b =>
                b.Status == "Issued" &&
                b.DueDate < DateTime.Now);
        }

        public decimal TotalFineAmount()
        {
            return db.BorrowRecords.Sum(b => (decimal?)b.FineAmount) ?? 0;
        }
    }
}