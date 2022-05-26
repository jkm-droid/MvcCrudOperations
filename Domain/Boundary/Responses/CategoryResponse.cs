using System;

namespace Domain.Boundary.Responses
{
    public class CategoryResponse
    {
        public Guid CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}