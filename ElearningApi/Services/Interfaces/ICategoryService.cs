using ElearningApi.DTOs.Categories;
using ElearningApi.Models;

namespace ElearningApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto request);
        Task EditAsync(Category category, CategoryEditDto request);
        Task DeleteAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();     
        Task<Category> GetByIdAsync(int id);
        Task<bool> ExistAsync(string name);
    }
}
