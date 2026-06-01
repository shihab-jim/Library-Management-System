using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class BorrowRepo
    {
        LibraryDbContext db;

        public BorrowRepo(LibraryDbContext db)
        {
            this.db = db;
        }

        public bool Create(BorrowRecord obj)
        {
            db.BorrowRecords.Add(obj);
            return db.SaveChanges() > 0;
        }

        public BorrowRecord? Get(int id)
        {
            return db.BorrowRecords
                .Include(b => b.Student)
                .Include(b => b.Book)
                .FirstOrDefault(b => b.BorrowRecordId == id);
        }

        public List<BorrowRecord> Get()
        {
            return db.BorrowRecords
                .Include(b => b.Student)
                .Include(b => b.Book)
                .ToList();
        }

        public bool Update(BorrowRecord obj)
        {
            var exobj = Get(obj.BorrowRecordId);

            if (exobj == null)
            {
                return false;
            }

            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            if (exobj == null)
            {
                return false;
            }

            db.BorrowRecords.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public bool BorrowBook(BorrowRecord obj)
        {
            var book = db.Books.Find(obj.BookId);

            if (book == null)
            {
                return false;
            }

            if (book.AvailableCopies <= 0)
            {
                return false;
            }

            book.AvailableCopies--;

            obj.Book = null;
            obj.Student = null;

            obj.BorrowDate = DateTime.Now;
            obj.DueDate = DateTime.Now.AddDays(7);
            obj.ReturnDate = null;
            obj.Status = "Issued";
            obj.FineAmount = 0;

            db.BorrowRecords.Add(obj);

            return db.SaveChanges() > 0;
        }

        public bool ReturnBook(int id)
        {
            var borrow = Get(id);

            if (borrow == null)
            {
                return false;
            }

            if (borrow.Status == "Returned")
            {
                return false;
            }

            var book = db.Books.Find(borrow.BookId);

            if (book != null)
            {
                book.AvailableCopies++;
            }

            borrow.ReturnDate = DateTime.Now;
            borrow.Status = "Returned";

            if (borrow.ReturnDate > borrow.DueDate)
            {
                int lateDays = (borrow.ReturnDate.Value - borrow.DueDate).Days;
                borrow.FineAmount = lateDays * 10;
            }
            else
            {
                borrow.FineAmount = 0;
            }

            return db.SaveChanges() > 0;
        }

        public List<BorrowRecord> GetOverdue()
        {
            return db.BorrowRecords
                .Include(b => b.Student)
                .Include(b => b.Book)
                .Where(b => b.Status == "Issued" && b.DueDate < DateTime.Now)
                .ToList();
        }

        public List<BorrowRecord> Search(string text)
        {
            var data = db.BorrowRecords
                .Include(b => b.Student)
                .Include(b => b.Book)
                .AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                data = data.Where(b =>
                    b.Student.Name.Contains(text) ||
                    b.Student.StudentNo.Contains(text) ||
                    b.Book.Title.Contains(text) ||
                    b.Status.Contains(text));
            }

            return data.ToList();
        }
    }
}