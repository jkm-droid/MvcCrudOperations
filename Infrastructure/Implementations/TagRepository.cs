using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Contexts;

namespace Infrastructure.Implementations
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}