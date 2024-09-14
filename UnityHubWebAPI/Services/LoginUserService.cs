using Microsoft.EntityFrameworkCore;
using UnityHubWebAPI.Data;
using UnityHubWebAPI.IServices;
using UnityHubWebAPI.Models;

namespace UnityHubWebAPI.Services
{
    public class LoginUserService : ILoginUserService
    {
        private readonly DataBaseConnection _connection;

        public LoginUserService(DataBaseConnection connection)
        {
            _connection = connection;
        }
        public async Task<LoginUser> CreateAsync(LoginUser model)
        {
            await _connection.LoginUser.AddAsync(model);
            await _connection.SaveChangesAsync();
            return model;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var data = await _connection.LoginUser.FindAsync(id);
            if (data == null)
            {
                return 0;
            }

            _connection.LoginUser.Remove(data);
            return await _connection.SaveChangesAsync();


        }

        public async Task<List<LoginUser>> GetAllAsync()
        {
            var list = await _connection.LoginUser.ToListAsync();
            return list;
        }

        public async Task<LoginUser> GetByIdAsync(string username)
        {
            try
            {
                var data = await _connection.LoginUser.Where(p => p.Username == username).FirstOrDefaultAsync() ?? new LoginUser();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public async Task<int> UpDateAsync(int id, LoginUser model)
        {
            var existingData = await _connection.LoginUser.FindAsync(id);
            if (existingData == null)
            {
                return 0;
            }
            existingData.PasswordHash = model.PasswordHash;
            existingData.PasswordSalt = model.PasswordSalt;
            existingData.UPDATE_BY = model.UPDATE_BY;
            existingData.UPDATE_DATE = model.UPDATE_DATE;

            _connection.LoginUser.Update(existingData);
            return await _connection.SaveChangesAsync();
        }

    }
}
