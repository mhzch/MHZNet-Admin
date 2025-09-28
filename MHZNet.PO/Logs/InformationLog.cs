using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using SqlSugar;

namespace MHZNet.PO.Logs
{
    /// <summary>
    /// 信息日志
    /// </summary>
    [LogDataBase]
    [SplitTable(SplitType.Month)]
    [SugarTable($@"{"log_information"}_{{year}}{{month}}{{day}}")]
    public class InformationLog : SerilogBase
    {
    }
}
