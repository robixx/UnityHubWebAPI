using Microsoft.EntityFrameworkCore;
using UnityHubWebAPI.Data;
using UnityHubWebAPI.IServices;
using UnityHubWebAPI.Models;

namespace UnityHubWebAPI.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly DataBaseConnection _connection;

        public CategoryServices(DataBaseConnection connection)
        {
            _connection = connection;
        }
        public Task<Category> CreateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _connection.Category.ToListAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpDateAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
