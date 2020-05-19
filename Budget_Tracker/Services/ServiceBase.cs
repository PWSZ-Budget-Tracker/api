using Budget_Tracker.Database;
using Budget_Tracker.Responses;
using Budget_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services
{

    public class ServiceBase
    {
        protected readonly BudgetTrackerContext _context;
        protected readonly IJwtService _jwtService;

        public ServiceBase(BudgetTrackerContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
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
    }
}
