using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using SqlSugar;

namespace MHZNet.PO.Logs
{
    /// <summary>
    ///  ß∞‹»’÷æ
    /// </summary>
    [LogDataBase]
    [SplitTable(SplitType.Month)]
    [SugarTable($@"{"log_fatal"}_{{year}}{{month}}{{day}}")]
    public class FatalLog : SerilogBase
    {
    }
}
