using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace Store.Infrastructe.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDTOForInsertion, Product>();
            CreateMap<ProductDTOForUpdate, Product>().ReverseMap();
        }
    }
}
