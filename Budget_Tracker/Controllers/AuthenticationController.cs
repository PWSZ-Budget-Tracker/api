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
        private readonly ILogger<AuthenticationController> logger = null;
        public AuthenticationController(IAuthenticationService authenticationService, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {

            _authenticationService = authenticationService;
        }
        //[Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return Failure();
                }

                return await _authenticationService.Register(registerRequest);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in Register()!");
                return Failure();
            }
        }
        //[Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Failure();
                }

                return await _authenticationService.Login(loginRequest);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Error in LogIn()");
                return Failure();
            }
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
        //[HttpPost]
        //public async Task<IActionResult> IsLoggedIn()
        //{
        //    try
        //    {
        //        if (HttpContext.User.Identity.IsAuthenticated)
        //        {
        //            var user = await UserManager.GetUserAsync(HttpContext.User);
        //            if (user != null)
        //            {
        //                return Success(new { Email = HttpContext.User.Identity.Name });
        //            }

        //            await signInManager.SignOutAsync();
        //            return Failure();
        //        }
        //        else
        //        {
        //            return Failure();
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Error in IsLoggedIn()");
        //        return Failure();
        //    }
        //}

    }
}
