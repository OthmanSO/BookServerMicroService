using System;
using AutoMapper;
using BooksServer.API.Entities;
using BooksServer.API.Models;

namespace BooksServer.API.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Entities.Books, Models.BookAsItemDto>()
                .ForMember(
                    dest => dest.id, 
                    opt => opt.MapFrom(src => $"s{src.bookId}")
                )
                .ForMember(
                    dest => dest.title, 
                    opt => opt.MapFrom(src => $"{src.title}"));
            CreateMap<Entities.Books, Models.BookAsInfoDto>();
                
        }
    }
}