using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Data;
using Api.Domain.Dto.UserModelsDto;
using Api.Domain.Entity.UserModels;
using Api.Repository.Interfaces.UserInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly DataContxt _context;
        private readonly IuserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(DataContxt context, IuserService userService, ITokenService tokenService)
        {
            _context = context;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Index()
        {    
            return await _userService.GetUsers(); ;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {           
            return await _userService.GetUSerById(id);
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<UserDto>> Register (RegisterUserDto registerUser)
        {
            if (await _userService.UserExists(registerUser.UserName)) return BadRequest("მომხმარებელი უკვე არსებობს");
            var user = await _userService.RegisterUser(registerUser);
            return new UserDto {
                UserName = user.UserName,
                Token = _tokenService.CreateTOken(user)
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login (UserLoginDto userLogin)
        {
            if (string.IsNullOrEmpty(userLogin.UserName) || string.IsNullOrEmpty(userLogin.Password))
                return BadRequest("შეავსეთ აუცილებელი ველები");
            var user = await _userService.GetUserByUSerName(userLogin.UserName);
           
            if (user == null) return Unauthorized("არასწორი მონაცემები");
            if (_userService.PasswordCheck(user, userLogin.Password)) return Unauthorized("არასწორი მონაცემები");

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateTOken(user)
            };
        }
    }
}
