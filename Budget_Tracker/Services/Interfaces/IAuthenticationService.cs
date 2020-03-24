using Budget_Tracker.Models;
using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IAuthenticationService 
    {
        public Task<IActionResult> Register(RegisterRequest registerRequest);
        public Task<IActionResult> Login(LoginRequest loginRequest);
        //public Task<IActionResult> Logout();


    }
}
