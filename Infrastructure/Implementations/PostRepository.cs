using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        
        public async Task<IEnumerable<Post>> GetAllPosts(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p => p.Title).Include(p =>p.PostCategories).ToListAsync();
        }

        public void CreatePost(Post post)
        {
            Create(post);
        }
        
        public async Task<Post> GetPostById(Guid postId, bool trackChanges)
        {
            return await FindByCondition(p => p.PostId.Equals(postId), trackChanges).SingleOrDefaultAsync();
        } 
        
        public async Task<Post> GetAllPostCategories(Guid postId, bool trackChanges)
        {
            return await FindByCondition(pc => pc.PostId == postId, trackChanges).Include(pc => pc.PostCategories)
                .SingleOrDefaultAsync();
        }
    }
}