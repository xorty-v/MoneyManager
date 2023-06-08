using System.Security.Claims;

namespace MoneyManager.Services.Interfaces;

public interface ITokenService
{
    public Task<string> GenerateAccessToken(IEnumerable<Claim> claims);
}