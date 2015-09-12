using AutoMapper;
using Hydra.Api.DTO;
using Hydra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Api.Mappers
{
    public class DTOToDomainMapper : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DTOToDomainProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserUpdateDTO, User>();
            Mapper.CreateMap<UserDTO, User>();
            Mapper.CreateMap<SlideDTO, Slide>();
        }
    }
}