using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Model;
using MHZNet.PO.Logs;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.System;
using MHZNet.VO.Core.Monitor;

namespace MHZNet.IBusiness.Monitor;

/// <summary>
/// 系统日志接口
/// </summary>
public interface IExceptionLogService : IBaseServices<ExceptionLog>
{
    #region 基础接口

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="exceptionLog"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(ExceptionLog exceptionLog);

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="logQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<List<ExceptionLogVo>> QueryAsync(LogQueryCriteria logQueryCriteria, Pagination pagination);

    #endregion
}
