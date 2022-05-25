using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            PostCategories = new HashSet<PostCategory>();
        }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}