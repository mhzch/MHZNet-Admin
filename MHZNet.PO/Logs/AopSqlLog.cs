using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using SqlSugar;

namespace MHZNet.PO.Logs
{
    /// <summary>
    /// SQL»’÷æ
    /// </summary>
    [LogDataBase]
    [SplitTable(SplitType.Month)]
    [SugarTable($@"{"log_sql"}_{{year}}{{month}}{{day}}")]
    public class AopSqlLog : SerilogBase
    {
    }
}
