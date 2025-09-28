using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Extensions;
using MHZNet.Common.Model;
using MHZNet.Core;
using MHZNet.PO.Logs;
using MHZNet.IBusiness.Monitor;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.System;
using MHZNet.VO.Core.Monitor;

namespace MHZNet.Business.Monitor;

/// <summary>
/// 系统日志服务
/// </summary>
public class ExceptionLogService : BaseServices<ExceptionLog>, IExceptionLogService
{
    #region 基础方法

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="exceptionLog"></param>
    /// <returns></returns>
    public async Task<OperateResult> CreateAsync(ExceptionLog exceptionLog)
    {
        var result = await SugarRepository.SugarClient.Insertable(exceptionLog).SplitTable().ExecuteCommandAsync() > 0;
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="logQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    public async Task<List<ExceptionLogVo>> QueryAsync(LogQueryCriteria logQueryCriteria, Pagination pagination)
    {
        var queryOptions = new QueryOptions<ExceptionLog>
        {
            Pagination = pagination,
            ConditionalModels = logQueryCriteria.ApplyQueryConditionalModel(),
            IsSplitTable = true
        };
        var logs = await TablePageAsync(queryOptions);
        return App.Mapper.MapTo<List<ExceptionLogVo>>(logs);
    }

    #endregion
}
