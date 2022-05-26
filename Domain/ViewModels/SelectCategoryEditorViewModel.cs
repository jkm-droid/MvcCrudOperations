using System;

namespace Domain.ViewModels
{
    public class SelectCategoryEditorViewModel
    {
        public Guid CategoryId { get; set; }
        public string? Title { get; set; }
        public bool Selected { get; set; }
    }
}