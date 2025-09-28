using Newtonsoft.Json;

namespace MHZNet.VO.Jwt;

/// <summary>
/// µÇÂ¼½á¹û
/// </summary>
public class LoginResultVo
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("user")]
    public JwtUserVo JwtUserVo { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("token")]
    public TokenVo TokenVo { get; set; }
}
