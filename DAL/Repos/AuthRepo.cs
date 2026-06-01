using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class AuthRepo
    {
        LibraryDbContext db;

        public AuthRepo(LibraryDbContext db)
        {
            this.db = db;
        }

        public Librarian? Login(string email, string password)
        {
            return db.Librarians.FirstOrDefault(l =>
                l.Email == email &&
                l.Password == password);
        }
    }
}