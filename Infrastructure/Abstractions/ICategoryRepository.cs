using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Abstractions
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories(bool trackChanges);
    }
}