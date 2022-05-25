using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}