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

namespace Application.Features.Posts.Queries
{
    public class GetAllPostsQuery : IRequest<Result<IList<PostResponse>>>
    {
        public GetAllPostsQuery()
        {
            
        }
    }

    internal sealed class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, Result<IList<PostResponse>>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IList<PostResponse>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _repository.Post.GetAllPosts(trackChanges: false);
            var postResponse = _mapper.Map<IList<PostResponse>>(posts);

            return await Result<IList<PostResponse>>.SuccessAsync(postResponse, "Success");
        }
    }
}