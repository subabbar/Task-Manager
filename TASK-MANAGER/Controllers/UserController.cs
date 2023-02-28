using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TASK_MANAGER.Service;
using TASK_MANAGER.Models;


namespace TASK_MANAGER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveUser(UserRequest userModel)
        {
            try
            {
                var model = _userService.SaveUser(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetusersList();
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var employees = _userService.GetUserDetailsById(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}