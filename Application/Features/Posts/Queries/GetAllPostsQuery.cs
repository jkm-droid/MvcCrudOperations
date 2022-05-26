using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Abstractions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Features.Posts.Queries
{
    public class GetAllPostsQuery : IRequest<IEnumerable<Post>>
    {
        public GetAllPostsQuery()
        {
            
        }
    }

    internal sealed class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<Post>>
    {
        private readonly IRepositoryManager _repository;

        public GetAllPostsQueryHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _repository.Post.GetAllPosts(trackChanges: false);

            return posts;
        }
    }
}