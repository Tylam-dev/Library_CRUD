using AutoMapper;
using Library_CRUD.Dtos;
using Library_CRUD.Models;

namespace Library_CRUD.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorPostDto, Author>();
        CreateMap<AuthorUpdateDto, Author>();
        CreateMap<BookPostDto, Book>();
        CreateMap<BookUpdateDto, Book>();
        CreateMap<AuthorPostDto, Author>();
        CreateMap<AuthorUpdateDto, Author>();
    }
}