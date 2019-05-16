using System;
using System.Threading.Tasks;
using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Services.Definition;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aranda.Users.BackEnd.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll([FromHeader]string user)
        {
            try
            {
                var userFilter = !string.IsNullOrEmpty(user) ? JsonConvert.DeserializeObject<UserFilterDto>(user) : null;
                var users = _userService.GetAll(x => (userFilter == null) || (string.IsNullOrEmpty(userFilter?.Name) || x.Name.Contains(userFilter.Name)) && (userFilter?.RoleId == 0 || x.RoleId.Equals(userFilter?.RoleId)));
                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occurred calling the otp service {e}, {e.Message}");
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult AddUser([FromBody]UserDto user)
        {
            try
            {

                var userDto = _userService.AddUser(user);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occurred calling the otp service {e}, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserDto user)
        {
            try
            {

                var userDto = await _userService.UpdateUser(user);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occurred calling the otp service {e}, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {

                var result = _userService.DeleteUser(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occurred calling the otp service {e}, {e.Message}");
                return BadRequest(e.Message);
            }
        }
    }
}
