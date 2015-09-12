using AutoMapper;
using Hydra.Api.DTO;
using Hydra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Api.Mappers
{
    public class DomainToDTOMapper : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToDTOProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserUpdateDTO>();
            Mapper.CreateMap<Slide, SlideDTO>();
        }
    }
}