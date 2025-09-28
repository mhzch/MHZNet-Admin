using MHZNet.Common.Attributes;
using MHZNet.Common.Model;
using SqlSugar;

namespace MHZNet.DTO.Queries.System;

/// <summary>
/// 日志查询参数
/// </summary>
public class LogQueryCriteria : DateRange, IConditionalModel
{
    /// <summary>
    /// 关键�?    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like, FieldName = "Description")]
    public string KeyWords { get; set; }
}
