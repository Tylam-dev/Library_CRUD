using AutoMapper;
using Library_CRUD.Dtos;
using Library_CRUD.Models;

namespace Library_CRUD.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorPostDto, Author>();
        CreateMap<AuthorUpdateDto, Author>().ForAllMembers((opts) => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<BookPostDto, Book>();
        CreateMap<BookUpdateDto, Book>();
        CreateMap<BorrowPostDto, Borrow>();
        CreateMap<BorrowUpdateDto, Borrow>();
    }
}