using MHZNet.PO.Base;
using SqlSugar;

namespace MHZNet.PO.Core.System
{
    /// <summary>
    /// Token黑名单
    /// </summary>
    [SugarTable("sys_token_blacklist")]
    public class TokenBlacklist : BaseEntity
    {
        /// <summary>
        /// 令牌 登录token的MD5值
        /// </summary>
        public string AccessToken { get; set; }
    }
}
