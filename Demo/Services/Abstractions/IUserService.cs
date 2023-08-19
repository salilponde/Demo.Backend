using Demo.Dtos;

namespace Demo.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(UserCreateDto dto);
        Task<UserDto> UpdateAsync(UserUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
