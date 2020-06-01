using System.Collections.Generic;
using System.Linq;
using Budget_Tracker.Models;
using Budget_Tracker.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Budget_Tracker.Controllers
{

    public class BaseController : ControllerBase
    {
        protected readonly SignInManager<User> signInManager = null;
        protected readonly UserManager<User> userManager = null;

        public BaseController(){}

        protected IActionResult Success()
        {
            return new JsonResult(new Response() { Successful = true });
        }

        protected IActionResult Failure()
        {
            return new JsonResult(new Response() { Successful = false, Errors = new Dictionary<string, List<string>>() });
        }

        protected IActionResult Failure(Dictionary<string, List<string>> errors = null)
        {
            return new JsonResult(new Response() { Successful = false, Errors = errors });
        }

        protected IActionResult Success<T>(T payload)
        {
            return new JsonResult(new Result<T>() { Successful = true, Payload = payload });
        }

        protected IActionResult Failure<T>(Dictionary<string, List<string>> errors = null)
        {
            return new JsonResult(new Result<T>() { Successful = false, Errors = errors });
        }

        protected Dictionary<string, List<string>> GetModelStateErrors()
        {
            if (!ModelState.IsValid)
            {
                var result = ModelState.ToDictionary(i => i.Key, i => i.Value.Errors.Select(j => j.ErrorMessage).ToList());
                return result;
            }
            else
                return new Dictionary<string, List<string>>();
        }
    }
}


