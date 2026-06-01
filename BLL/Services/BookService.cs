using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class BookService
    {
        BookRepo repo;
        Mapper mapper;

        public BookService(BookRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(BookDTO dto)
        {
            if (repo.IsbnExists(dto.Isbn))
            {
                return false;
            }

            if (dto.AvailableCopies > dto.TotalCopies)
            {
                return false;
            }

            var data = mapper.Map<Book>(dto);
            return repo.Create(data);
        }

        public BookDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<BookDTO>(data);
        }

        public List<BookDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<BookDTO>>(data);
        }

        public bool Update(BookDTO dto)
        {
            if (repo.IsbnExistsForOtherBook(dto.Isbn, dto.BookId))
            {
                return false;
            }

            if (dto.AvailableCopies > dto.TotalCopies)
            {
                return false;
            }

            var data = mapper.Map<Book>(dto);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<BookDTO> Search(string text)
        {
            var data = repo.Search(text);
            return mapper.Map<List<BookDTO>>(data);
        }
    }
}