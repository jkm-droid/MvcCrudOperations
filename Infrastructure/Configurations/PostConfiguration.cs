using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    PostId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Title = "Post One",
                    Author = "Joseph Maina",
                    Slug = "post-one"
                }
            );
        }
    }
}