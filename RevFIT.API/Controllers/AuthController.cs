using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevFIT.Services.AuthenticationService;
using RevFIT.Services.ViewModels;

namespace RevFIT.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;
        public AuthController(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(ServiceResponseModel<int>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] APIRegisterViewModel request)
        {
            var response = await _authentication.Register(request);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ServiceResponseModel<string>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ServiceResponseModel<string>>> Login([FromBody] APIUserLoginModel request )
        {
            var response = await _authentication.Login(request.Email, request.Password);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
