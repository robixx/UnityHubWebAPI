using UnityHubWebAPI.Models;

namespace UnityHubWebAPI.IServices
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<int> UpDateAsync(int id, Category category);
        Task<int> DeleteAsync(int id);
    }
}
