using System;
using System.Collections.Generic;
using Domain.ViewModels;

namespace Domain.Boundary.Requests
{
    public class PostUpdateRequest
    {
        public PostUpdateRequest()
        {
            Categories = new List<Guid>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public CategorySelectionViewModel CategorySelectionViewModel { get; set; }
        public IList<Guid> Categories { get; set; }
    }
}