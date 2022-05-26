using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Abstractions
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts(bool trackChanges);
        void CreatePost(Post post);
        Task<Post> GetPostById(Guid postId, bool trackChanges);
        Task<Post> GetAllPostCategories(Guid postId, bool trackChanges);
    }
}