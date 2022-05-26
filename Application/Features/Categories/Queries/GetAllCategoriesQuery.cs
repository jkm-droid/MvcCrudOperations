using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Boundary.Responses;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<Result<IList<CategoryResponse>>>
    {
        public GetAllCategoriesQuery()
        {
            
        }
    }

    internal sealed class
        GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<IList<CategoryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public GetAllCategoriesQueryHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<IList<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.Category.GetAllCategories(trackChanges: false);
            var categoryResponse = _mapper.Map<IList<CategoryResponse>>(categories);

            return await Result<IList<CategoryResponse>>.SuccessAsync(categoryResponse, "Success");
        }
    }
}