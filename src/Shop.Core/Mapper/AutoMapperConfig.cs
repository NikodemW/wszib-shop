using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper GteConfig()
            => new MapperConfiguration(cfg =>
            {

            })

    }
}
