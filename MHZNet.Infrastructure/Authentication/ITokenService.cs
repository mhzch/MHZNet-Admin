using System.IdentityModel.Tokens.Jwt;
using MHZNet.Common.WebApp;
using MHZNet.VO.Jwt;

namespace MHZNet.Infrastructure.Authentication;

public interface ITokenService
{
    /// <summary>
    /// Issue token
    /// </summary>
    /// <param name="loginUserInfo"></param>
    /// <param name="refresh"></param>
    /// <returns></returns>
    Task<TokenVo> IssueTokenAsync(LoginUserInfo loginUserInfo, bool refresh = false);

    Task<JwtSecurityToken> ReadJwtToken(string token);
}
