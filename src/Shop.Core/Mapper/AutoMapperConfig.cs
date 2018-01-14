using AutoMapper;
using Shop.Core.Domain;
using Shop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
            }).CreateMapper();


    }
}
