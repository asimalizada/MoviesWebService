using Business.Abstract;
using Core.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var userToLogin = this._authService.Login(userLoginDto);
            if (!userToLogin.Success) return BadRequest(userToLogin.Message);

            var result = this._authService.CreateAccessToken(userToLogin.Data);
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var registerResult = this._authService.Register(userRegisterDto, userRegisterDto.Password);
            var result = this._authService.CreateAccessToken(registerResult.Data);

            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }
    }
}
