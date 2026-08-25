using AutoMapper;
using Norton.Abstractions.Models;
using Norton.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Data
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BookEdm, Book>().ReverseMap();
            CreateMap<BookEdm, UpdateBook>().ReverseMap();
        }
    }
}
