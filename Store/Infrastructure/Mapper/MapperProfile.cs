using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Store.Infrastructure.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDTOForInsertion, Product>();
            CreateMap<ProductDTOForUpdate, Product>().ReverseMap();
            CreateMap<UserDTOForCreation, IdentityUser>();
            CreateMap<UserDTOForUpdate, IdentityUser>().ReverseMap();
        }
    }
}
