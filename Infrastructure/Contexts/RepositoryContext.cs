using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.Entity<PostCategory>().HasKey(nk => new {nk.PostId, nk.CategoryId});
            modelBuilder.Entity<PostTag>().HasKey(nk => new {nk.PostId, nk.TagId});
        }
        
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<PostCategory>? PostCategories { get; set; }
        public DbSet<PostTag>? PostTags { get; set; }
    }
}