using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Abstractions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Features.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public GetAllCategoriesQuery()
        {
            
        }
    }

    internal sealed class
        GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public GetAllCategoriesQueryHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.Category.GetAllCategories(trackChanges: false);
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoryDto;
        }
    }
}