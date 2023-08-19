using Demo.Dtos;
using Demo.Models;
using Demo.Services.Abstractions;

namespace Demo.Services
{
    public class InMemUserService : IUserService
    {
        private readonly static List<User> _users = new List<User>();

        public async Task<List<UserDto>> GetAllAsync()
        {
            return M.Mapper.Map<List<UserDto>>(_users.ToList());
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(_ => _.Id == id);
            return M.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(UserCreateDto dto)
        {
            var user = M.Mapper.Map<User>(dto);

            var maxId = 0;
            if(_users.Any())
            {
                maxId = _users.Max(x => x.Id);
            }

            user.Id = maxId  + 1;
            _users.Add(user);

            return M.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(UserUpdateDto dto)
        {
            var user = _users.FirstOrDefault(_ => _.Id == dto.Id);

            M.Mapper.Map<UserUpdateDto, User>(dto, user);

            return M.Mapper.Map<UserDto>(user);
        }

        public async Task DeleteAsync(int id)
        {
            if(_users.Any(_ => _.Id == id))
            {
                var user = _users.SingleOrDefault(_ => _.Id == id);
                _users.Remove(user);
            }
        }
    }
}
