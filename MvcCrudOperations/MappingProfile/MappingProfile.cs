using AutoMapper;
using Domain.Entities;
using Shared.DataTransferObjects;

namespace MvcCrudOperations.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}