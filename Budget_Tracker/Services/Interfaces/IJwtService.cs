using Budget_Tracker.Models;

namespace Budget_Tracker.Services.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateJwtToken(string email);
        int GetUserId();
    }
}
