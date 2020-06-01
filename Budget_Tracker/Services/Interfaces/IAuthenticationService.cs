using Budget_Tracker.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IAuthenticationService 
    {
        public Task<IActionResult> Register(RegisterRequest registerRequest);
        public Task<IActionResult> Login(LoginRequest loginRequest);
    }
}
