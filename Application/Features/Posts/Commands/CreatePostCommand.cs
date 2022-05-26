using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions;
using Domain.Boundary.Requests;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;

namespace Application.Features.Posts.Commands
{
    public class CreatePostCommand : IRequest<Result<string>>
    {
        public PostCreationRequest PostCreationRequest { get; set; }
        public CreatePostCommand(PostCreationRequest postCreationRequest)
        {
            PostCreationRequest = postCreationRequest;
        }
    }

    internal sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<string>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public CreatePostCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Result<string>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            //save post 
            var post = new Post()
            {
                Title = request.PostCreationRequest.Title,
                Author = request.PostCreationRequest.Author,
                Content = request.PostCreationRequest.Content,
                Slug = SlugifyPostTitle.SlugifyTitle(request.PostCreationRequest.Title),
                PostCategories = request.PostCreationRequest.Categories.Select(c => new PostCategory{CategoryId = c}).ToList()
            };
            
            _repositoryManager.Post.CreatePost(post);

            await _repositoryManager.SaveAsync("save failed", cancellationToken);

            return await Result<string>.SuccessAsync("Post {} Created", request.PostCreationRequest.Title);
        }
    }
}