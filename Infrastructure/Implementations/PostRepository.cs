using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Contexts;

namespace Infrastructure.Implementations
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}