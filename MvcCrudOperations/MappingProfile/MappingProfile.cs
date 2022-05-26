using AutoMapper;
using Domain.Boundary.Requests;
using Domain.Boundary.Responses;
using Domain.Entities;
using Shared.DataTransferObjects;

namespace MvcCrudOperations.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<PostCreationRequest,Post>();
            CreateMap<Post, PostResponse>();
        }
    }
}