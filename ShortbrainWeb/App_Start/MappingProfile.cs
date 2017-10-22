using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ShortbrainWeb.Dtos;
using ShortbrainWeb.Models;

namespace ShortbrainWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<User, UserDto>();
            this.CreateMap<UserDto, User>();
        }
    }
}