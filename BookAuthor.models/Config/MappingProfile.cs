﻿using AutoMapper;
using BookAuthor.Models.Dto;
using BookAuthor.Models.models;
using BookAuthor.Models.Models;
using Models.models;

namespace BookAuthor.Models.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<Role, RoleDTO>();
        }
    }
}
