using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Post
    {
        public Post()
        {
            PostCategories = new HashSet<PostCategory>();
            PostTags = new HashSet<PostTag>();
        }
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Slug { get; set; }
        
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}