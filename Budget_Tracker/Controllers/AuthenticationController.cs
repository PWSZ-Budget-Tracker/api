using Budget_Tracker.Models;
using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Budget_Tracker.VievModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        ////[Route("Logout")]
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> LogOut()
        //{
        //    try
        //    {
        //        await SignInManager.SignOutAsync();
        //        return Success();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "ERROR!, Unexcepted error in LogOut()");
        //        return Failure();
        //    }
        //}
    }
}
