using MHZNet.Common.Attributes;
using MHZNet.Common.Model;
using SqlSugar;

namespace MHZNet.DTO.Queries.Message;

/// <summary>
/// 邮箱模板查询参数
/// </summary>
public class EmailMessageTemplateQueryCriteria : DateRange, IConditionalModel
{
    /// <summary>
    /// 名称
    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like)]
    public string Name { get; set; }

    /// <summary>
    /// 是否激活
    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Equal)]
    public bool? IsActive { get; set; }
}
