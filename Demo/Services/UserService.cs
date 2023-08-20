using Demo.Dtos;
using Demo.Models;
using Demo.Persistence;
using Demo.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class UserService : IUserService
    {
        private readonly DemoContext _db;

        public UserService(DemoContext db)
        {
            _db = db;
        }

        public async Task<UserDto> CreateAsync(UserCreateDto dto)
        {
            var user = M.Mapper.Map<User>(dto);
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return M.Mapper.Map<UserDto>(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _db.Users.ToListAsync();

            return M.Mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

            return M.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(UserUpdateDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
            M.Mapper.Map<UserUpdateDto, User>(dto, user);
            await _db.SaveChangesAsync();

            return M.Mapper.Map<UserDto>(user);
        }
    }
}
