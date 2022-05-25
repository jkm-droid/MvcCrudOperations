using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PostCategory
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}