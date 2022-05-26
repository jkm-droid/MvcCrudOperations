using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Boundary.Responses;
using Domain.Entities;
using Infrastructure.Abstractions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
    {
        public GetAllCategoriesQuery()
        {
            
        }
    }

    internal sealed class
        GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public GetAllCategoriesQueryHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.Category.GetAllCategories(trackChanges: false);
            var categoryResponse = _mapper.Map<IEnumerable<CategoryResponse>>(categories);

            return categoryResponse;
        }
    }
}