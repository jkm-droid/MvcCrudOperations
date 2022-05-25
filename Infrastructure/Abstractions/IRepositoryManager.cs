using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions
{
    public interface IRepositoryManager
    {
        IPostRepository Post { get; }
        ICategoryRepository Category { get; }
        ITagRepository Tag { get; }
        Task SaveAsync(string errorMessage = "Failed to perform save operation", CancellationToken cancellationToken = default);
    }
}