using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Models;
using Aranda.Users.BackEnd.Repositories.Definition;
using Aranda.Users.BackEnd.Services.Definition;
using AutoMapper;

namespace Aranda.Users.BackEnd.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public UserDataDto GetUser(string userName, string password)
        {
            var user = _userRepository.GetUser(userName, password);
            var userDto = Mapper.Map<UserDataDto>(user);
            var rol = _roleRepository.GetPermissionsByRol(user.RoleId);
            userDto.Role.RolePermission = rol.RolePermission.Select(x => new PermissionDto { Id = x.Permission.Id, Action = x.Permission.Action });
            return userDto;
        }

        public IEnumerable<UserDto> GetAll(Func<User, bool> filter)
        {
            return _userRepository.GetAll(filter).Select(Mapper.Map<UserDto>);
        }

        public UserDto AddUser(UserDto user)
        {
            var userDto = _userRepository.AddUser(Mapper.Map<User>(user));
            userDto.Role = _roleRepository.GetRolById(userDto.RoleId);
            return Mapper.Map<UserDto>(userDto);
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var user = await _userRepository.UpdateUser(Mapper.Map<User>(userDto));
            return Mapper.Map<UserDto>(user);
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }
    }
}
