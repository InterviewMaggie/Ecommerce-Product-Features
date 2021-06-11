using AutoMapper;
using EcommerceAPI.DTO;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Mapper
{
    public class EcommerceMappings : Profile
    {
        public EcommerceMappings()
        {
            
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
