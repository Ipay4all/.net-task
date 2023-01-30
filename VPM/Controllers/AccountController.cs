using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VPM.Domain.Interface;
using VPM.Models.Request;
using VPM.Models.Response;

namespace VPM.Controllers
{

    [Route("v1/Accounts")]
    [ApiController]
    public class AccountController : BaseController
    {
        public IAccount _IAccount { get; set; }
        public AccountController(IAccount Account)
        {
            _IAccount = Account;            
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("")]       
        [ProducesResponseType(typeof(UserDetailResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] CreateUserRequestModel model)
        {
            var data = await _IAccount.Post(model);
            return CreatedResult(data);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(UserAuthenticationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationRequest login)
        {
            var data = await _IAccount.Login(login);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        [ProducesResponseType(typeof(UserAuthenticationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshToken)
        {
            var data = await _IAccount.RefreshToken(refreshToken);
            return CreatedResult(data);
        }
    }
}
