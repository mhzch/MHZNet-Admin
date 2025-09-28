using System;
using Serilog;

namespace MHZNet.Common.Helper.Serilog;

public class SerilogManager
{
    public static ILogger GetLogger(Type type)
    {
        return Log.ForContext("SourceContext", type.FullName);
    }
}
