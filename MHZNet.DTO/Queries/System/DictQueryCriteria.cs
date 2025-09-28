using MHZNet.Common.Attributes;
using MHZNet.Common.Enums;
using MHZNet.Common.Model;
using SqlSugar;

namespace MHZNet.DTO.Queries.System;

/// <summary>
/// 字典查询参数
/// </summary>
public class DictQueryCriteria : DateRange, IConditionalModel
{
    /// <summary>
    /// 关键�?    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like, FieldNameItems = ["Name", "Description"])]
    public string KeyWords { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Equal)]
    public DictType? DictType { get; set; }
}
