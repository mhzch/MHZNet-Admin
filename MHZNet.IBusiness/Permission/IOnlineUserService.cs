using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.WebApp;
using MHZNet.VO.Core.Permission.User;
using MHZNet.VO.Jwt;

namespace MHZNet.IBusiness.Permission;

/// <summary>
/// 在线用户接口
/// </summary>
public interface IOnlineUserService
{
    #region 基础接口

    /// <summary>
    /// 保存在线用户
    /// </summary>
    /// <param name="jwtUserVo"></param>
    /// <param name="remoteIp"></param>
    Task<LoginUserInfo> SaveLoginUserAsync(JwtUserVo jwtUserVo, string remoteIp);

    /// <summary>
    /// jwt用户信息
    /// </summary>
    /// <param name="userVo"></param>
    /// <param name="permissionRoles"></param>
    /// <returns></returns>
    Task<JwtUserVo> CreateJwtUserAsync(UserVo userVo, List<string> permissionRoles);

    #endregion
}
