using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net7_Web_API.Dtos.User;

namespace Net7_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationContoller : ControllerBase
    {
        private readonly IAuthenticationRepository _authRep;

        public AuthenticationContoller(IAuthenticationRepository authRep)
        {
            _authRep = authRep;
            
        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRep.Register(
                new User { Username = request.Username }, request.Password
            );
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRep.Login(request.Username, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
   
    }
}