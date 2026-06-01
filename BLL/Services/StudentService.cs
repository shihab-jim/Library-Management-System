using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo studentrepo;
        Mapper mapper;

        public StudentService(StudentRepo repo)
        {
            this.studentrepo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(StudentDTO dto)
        {
            if (studentrepo.EmailExists(dto.Email))
            {
                return false;
            }

            if (studentrepo.StudentNoExists(dto.StudentNo))
            {
                return false;
            }

            var data = mapper.Map<Student>(dto);
            return studentrepo.Create(data);
        }

        public StudentDTO Get(int id)
        {
            var data = studentrepo.Get(id);
            return mapper.Map<StudentDTO>(data);
        }

        public List<StudentDTO> Get()
        {
            var data = studentrepo.Get();
            return mapper.Map<List<StudentDTO>>(data);
        }

        public bool Update(StudentDTO dto)
        {
            if (studentrepo.EmailExistsForOtherStudent(dto.Email, dto.StudentId))
            {
                return false;
            }

            if (studentrepo.StudentNoExistsForOtherStudent(dto.StudentNo, dto.StudentId))
            {
                return false;
            }

            var data = mapper.Map<Student>(dto);
            return studentrepo.Update(data);
        }

        public bool Delete(int id)
        {
            return studentrepo.Delete(id);
        }

        public List<StudentDTO> Search(string text)
        {
            var data = studentrepo.Search(text);
            return mapper.Map<List<StudentDTO>>(data);
        }
    }
}