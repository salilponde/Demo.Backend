using Demo.Dtos;
using Demo.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("list")]
        public async Task<List<UserDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<UserDto> GetById(int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<UserDto> Create(UserCreateDto dto)
        {
            return await _userService.CreateAsync(dto);
        }

        [HttpPut]
        public async Task<UserDto> Update(UserUpdateDto dto)
        {
            return await _userService.UpdateAsync(dto);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _userService.DeleteAsync(id);
        }
    }
}