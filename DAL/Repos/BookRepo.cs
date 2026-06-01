using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class BookRepo
    {
        LibraryDbContext db;

        public BookRepo(LibraryDbContext db)
        {
            this.db = db;
        }

        public bool Create(Book obj)
        {
            db.Books.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        public bool Update(Book obj)
        {
            var exobj = Get(obj.BookId);

            if (exobj == null)
            {
                return false;
            }

            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            try
            {
                var exobj = Get(id);

                if (exobj == null)
                {
                    return false;
                }

                db.Books.Remove(exobj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Book> Search(string text)
        {
            var data = db.Books.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                data = data.Where(b =>
                    b.Title.Contains(text) ||
                    b.Isbn.Contains(text) ||
                    b.AuthorName.Contains(text) ||
                    b.CategoryName.Contains(text)
                );
            }

            return data.ToList();
        }

        public bool IsbnExists(string isbn)
        {
            return db.Books.Any(b => b.Isbn == isbn);
        }

        public bool IsbnExistsForOtherBook(string isbn, int id)
        {
            return db.Books.Any(b => b.Isbn == isbn && b.BookId != id);
        }
    }
}