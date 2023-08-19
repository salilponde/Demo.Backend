using AutoMapper;
using Demo.Dtos;
using Demo.Models;

namespace Demo
{
    internal static class M
    {
        public static Mapper Mapper { get; private set; }

        static M()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<User, UserCreateDto>().ReverseMap();
                cfg.CreateMap<User, UserUpdateDto>().ReverseMap();
            });

            Mapper = new Mapper(config);
        }
    }
}
