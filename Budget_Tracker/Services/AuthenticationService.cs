using Budget_Tracker.Database;
using Budget_Tracker.Models;
using Budget_Tracker.Requests;
using Budget_Tracker.Services.Interfaces;
using Budget_Tracker.VievModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services
{
    public class AuthenticationService : ServiceBase, IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AuthenticationService(BudgetTrackerContext context, SignInManager<User> signInManager, UserManager<User> userManager): base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public User Authenticate(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(
                    loginRequest.Email, loginRequest.Password, true, false);

            if (!result.Succeeded)
            {
                return Failure();
            }

            var user = Authenticate(loginRequest.Email);


            var client = new ClientVM()
            {
                Id = user.Id,
                Email = user.Email,
                Token = user.Token
            };
            return Success(client);
        }

        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest.Password != registerRequest.PasswordConfirmation)
            {
                return Failure();
            }

            var user = new User()
            {

                Email = registerRequest.Email,
                UserName = registerRequest.Email

            };

            var registerResult = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!registerResult.Succeeded)
            {
                return Failure();
            }

            return Success();
        }
    }
}
