using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Repositorys
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, GetUserDto>().ReverseMap();
        }
    }
}
