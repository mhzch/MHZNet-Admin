using MHZNet.Common.Attributes;
using MHZNet.Common.Model;
using SqlSugar;

namespace MHZNet.DTO.Queries.Message;

/// <summary>
/// 邮箱账户查询参数
/// </summary>
public class EmailAccountQueryCriteria : DateRange, IConditionalModel
{
    /// <summary>
    /// 邮箱
    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like)]
    public string Email { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like)]
    public string DisplayName { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like)]
    public string Username { get; set; }
}
