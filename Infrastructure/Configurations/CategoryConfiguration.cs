using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Title = "Category One",
                    Author = "Joseph Maina"
                },
                
                new Category
                {
                    CategoryId = new Guid("c5f8634a-fa78-424d-85b9-4066113eb2bb"),
                    Title = "Category Two",
                    Author = "Joseph Maina"
                },
                
                new Category
                {
                    CategoryId = new Guid("9ae8d2e9-c241-4abc-9d20-d6c6c2ad3540"),
                    Title = "Category Three",
                    Author = "Joseph Maina"
                }
            );
        }
    }
}