using System;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Abstractions;
using Infrastructure.Contexts;

namespace Infrastructure.Implementations
{
    
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ITagRepository> _tagRepository;
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _tagRepository = new Lazy<ITagRepository>(() => new TagRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(()=> new CategoryRepository(repositoryContext));
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
            _repositoryContext = repositoryContext;
        }

        public IPostRepository Post => _postRepository.Value;
        public ICategoryRepository Category => _categoryRepository.Value;
        public ITagRepository Tag => _tagRepository.Value;
        public async Task SaveAsync(string errorMessage = "Failed to perform save operation", 
            CancellationToken cancellationToken = default) =>
            await _repositoryContext.SaveChangesAsync(cancellationToken);
    }
}