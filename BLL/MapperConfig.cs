using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Book, BookDTO>().ReverseMap();
            cfg.CreateMap<Student, StudentDTO>().ReverseMap();

            cfg.CreateMap<BorrowRecord, BorrowRecordDTO>()
                .ForMember(dest => dest.StudentName,
                    opt => opt.MapFrom(src => src.Student.Name))
                .ForMember(dest => dest.StudentNo,
                    opt => opt.MapFrom(src => src.Student.StudentNo))
                .ForMember(dest => dest.BookTitle,
                    opt => opt.MapFrom(src => src.Book.Title));
        });

        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}