using AutoMapper;
using Core.Entities;
using Library_Management_System.Dtos;

namespace Library_Management_System.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Patron, PatronDto>().ReverseMap();
            CreateMap<Borrowing_Record, Bororowingdto>().ReverseMap();


        }
    }
}
