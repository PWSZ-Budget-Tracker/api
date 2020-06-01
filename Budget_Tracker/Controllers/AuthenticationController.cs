using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        //[Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid) 
                {
                    return Failure();
                }
            return await _authenticationService.Register(registerRequest);
        }
        //[Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                {
                    return Failure();
                }
            return await _authenticationService.Login(loginRequest);
        }
    }
}
