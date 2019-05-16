using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Models;
using AutoMapper;

namespace Aranda.Users.BackEnd.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>()
                    .ReverseMap();

                cfg.CreateMap<User, UserDataDto>()
                    .ReverseMap();

                cfg.CreateMap<Role, RoleDto>()
                    .ReverseMap();
            });
        }
    }
}
