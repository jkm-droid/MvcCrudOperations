using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions;
using AutoMapper;
using Domain.Boundary.Requests;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;

namespace Application.Features.Posts.Commands
{
    public class UpdatePostCommand : IRequest<Result<string>>
    {
        public Guid PostId { get; set; }
        public PostUpdateRequest PostUpdateRequest { get; set;}
        public bool TrackChanges { get; set; }
        public UpdatePostCommand( Guid postId, PostUpdateRequest postUpdateRequest, bool trackChanges)
        {
            PostUpdateRequest = postUpdateRequest;
            TrackChanges = trackChanges;
            PostId = postId;
        }
    }

    internal sealed class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result<string>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<Result<string>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            //get the post
            var post = await _repositoryManager.Post.GetPostById(request.PostId, request.TrackChanges);

            post.Title = request.PostUpdateRequest.Title.Trim();
            post.Author = request.PostUpdateRequest.Author.Trim();
            post.Content = request.PostUpdateRequest.Content;
            post.Slug = SlugifyPostTitle.SlugifyTitle(request.PostUpdateRequest.Title.Trim());
            post.PostCategories = request.PostUpdateRequest.Categories.Select(c => new PostCategory {CategoryId = c})
                .ToList();
      
            post.PostCategories.Clear();
            await _repositoryManager.SaveAsync($"Failed to update post {request.PostUpdateRequest.Title}",cancellationToken);

            return await Result<string>.SuccessAsync($"Post {post.Title} updated");
        }
    }
}