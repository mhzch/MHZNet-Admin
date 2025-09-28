using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using SqlSugar;

namespace MHZNet.PO.Logs
{
    /// <summary>
    /// ¥ÌŒÛ»’÷æ
    /// </summary>
    [LogDataBase]
    [SplitTable(SplitType.Month)]
    [SugarTable($@"{"log_error"}_{{year}}{{month}}{{day}}")]
    public class ErrorLog : SerilogBase
    {
    }
}
