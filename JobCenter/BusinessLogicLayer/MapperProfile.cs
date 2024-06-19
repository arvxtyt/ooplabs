using BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AutoMapper;

namespace BusinessLogicLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Application, Models.Application>().ReverseMap();

            CreateMap<Category, Models.Category>().ReverseMap();

            CreateMap<Field, Models.Field>().ReverseMap();

            CreateMap<Firm, Models.Firm>().ReverseMap();

            CreateMap<Resume, Models.Resume>().ReverseMap();

            CreateMap<Unemployed, Models.Unemployed>().ReverseMap();

            CreateMap<Vacancy, Models.Vacancy>().ReverseMap();
        }
    }
}
