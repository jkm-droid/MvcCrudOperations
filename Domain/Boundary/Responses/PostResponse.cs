using System;
using System.Collections.Generic;

namespace Domain.Boundary.Responses
{
    public class PostResponse
    {
        public PostResponse()
        {
            Categories = new List<CategoryResponse>();
        }
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Slug { get; set; }
        
        public virtual IList<CategoryResponse> Categories { get; set; }
    }
}