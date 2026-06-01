using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class BorrowService
    {
        BorrowRepo repo;
        Mapper mapper;

        public BorrowService(BorrowRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<BorrowRecordDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<BorrowRecordDTO>>(data);
        }

        public BorrowRecordDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<BorrowRecordDTO>(data);
        }

        public bool BorrowBook(BorrowRecordDTO dto)
        {
            BorrowRecord data = new BorrowRecord();

            data.StudentId = dto.StudentId;
            data.BookId = dto.BookId;

            return repo.BorrowBook(data);
        }

        public bool ReturnBook(int id)
        {
            return repo.ReturnBook(id);
        }

        public List<BorrowRecordDTO> GetOverdue()
        {
            var data = repo.GetOverdue();
            return mapper.Map<List<BorrowRecordDTO>>(data);
        }

        public List<BorrowRecordDTO> Search(string text)
        {
            var data = repo.Search(text);
            return mapper.Map<List<BorrowRecordDTO>>(data);
        }
    }
}