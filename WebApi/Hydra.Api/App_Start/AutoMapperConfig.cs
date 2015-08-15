using AutoMapper;
using Hydra.Api.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<DomainToDTOMapper>();
                c.AddProfile<DTOToDomainMapper>();
            });
        }
    }
}