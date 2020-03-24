using Budget_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateJwtToken(string email);
    }
}
