using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Domain.ViewModels
{
    public class CategorySelectionViewModel
    {
        public List<SelectCategoryEditorViewModel> Categories { get; set; }

        public CategorySelectionViewModel()
        {
            Categories = new List<SelectCategoryEditorViewModel>();
        }

        public IList<Guid> GetSelectedIds()
        {
            return (from c in Categories where c.Selected select c.CategoryId).ToList();
        }
    }
}