using System.Security.Claims;

namespace SMS.Application.Common.Interfaces.Authentications;

public interface IAuthService
{
    string CreateToken(List<Claim> claims);
}