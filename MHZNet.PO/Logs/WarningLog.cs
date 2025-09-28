using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using SqlSugar;

namespace MHZNet.PO.Logs
{
    /// <summary>
    /// æØ∏Ê»’÷æ
    /// </summary>
    [LogDataBase]
    [SplitTable(SplitType.Month)]
    [SugarTable($@"{"log_warning"}_{{year}}{{month}}{{day}}")]
    public class WarningLog : SerilogBase
    {
    }
}
