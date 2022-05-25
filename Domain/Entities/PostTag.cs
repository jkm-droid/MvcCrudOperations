using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PostTag
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }
        public Guid TagId { get; set; }
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}