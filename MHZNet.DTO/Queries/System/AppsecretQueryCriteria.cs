using MHZNet.Common.Attributes;
using MHZNet.Common.Model;
using SqlSugar;

namespace MHZNet.DTO.Queries.System;

/// <summary>
/// 密钥查询参数
/// </summary>
public class AppsecretQueryCriteria : DateRange, IConditionalModel
{
    /// <summary>
    /// 关键�?    /// </summary>
    [QueryCondition(ConditionType = ConditionalType.Like, FieldNameItems = ["AppId", "AppName", "Remark"])]
    public string KeyWords { get; set; }
}
