using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class StudentRepo
    {
        LibraryDbContext db;

        public StudentRepo(LibraryDbContext db)
        {
            this.db = db;
        }

        public bool Create(Student obj)
        {
            db.Students.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public bool Update(Student obj)
        {
            var exobj = Get(obj.StudentId);

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

                db.Students.Remove(exobj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Student> Search(string text)
        {
            var data = db.Students.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                data = data.Where(s =>
                    s.StudentNo.Contains(text) ||
                    s.Name.Contains(text) ||
                    s.Email.Contains(text) ||
                    s.Phone.Contains(text));
            }

            return data.ToList();
        }

        public bool EmailExists(string email)
        {
            return db.Students.Any(s => s.Email == email);
        }

        public bool StudentNoExists(string studentNo)
        {
            return db.Students.Any(s => s.StudentNo == studentNo);
        }

        public bool EmailExistsForOtherStudent(string email, int id)
        {
            return db.Students.Any(s => s.Email == email && s.StudentId != id);
        }

        public bool StudentNoExistsForOtherStudent(string studentNo, int id)
        {
            return db.Students.Any(s => s.StudentNo == studentNo && s.StudentId != id);
        }
    }
}