using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Boundary.Responses;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;

namespace Application.Features.Posts.Queries
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public  Guid PostId { get; set; }
        public bool WithCategories { get; set; }

        public GetPostByIdQuery(Guid postId, bool withCategories)
        {
            PostId = postId;
            WithCategories = withCategories;
        }
    }

    internal sealed class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        
        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _repositoryManager.Post.GetPostById(request.PostId, trackChanges: false);
            var postResponse = _mapper.Map<PostResponse>(post);
            if (request.WithCategories == false)
            {
                // return await Result<PostResponse>.SuccessAsync(postResponse, "success");
                return post;
            }

            var postWithCategories =
                await _repositoryManager.Post.GetAllPostCategories(request.PostId, trackChanges: false);
            
            // var postResponseWithCategories = _mapper.Map<PostResponse>(postWithCategories);

            // return await Result<PostResponse>.SuccessAsync(postWithCategories, "Success");
            return postWithCategories;
        }
    }
}