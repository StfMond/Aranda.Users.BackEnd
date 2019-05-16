using System.Collections.Generic;
using System.Linq;
using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Repositories.Definition;
using Aranda.Users.BackEnd.Services.Definition;
using AutoMapper;

namespace Aranda.Users.BackEnd.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public IEnumerable<RoleDto> GetAll()
        {
           return _roleRepository.GetAll().Select(Mapper.Map<RoleDto>);
        }

        public RoleDto GetPermissionsByRol(int rolId)
        {
            var rol = _roleRepository.GetPermissionsByRol(rolId);
            return Mapper.Map<RoleDto>(rol);
        }
    }
}
