using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using MHZNet.Api.Controllers.Base;
using MHZNet.Common.Attributes;
using MHZNet.Common.Model;
using MHZNet.IBusiness.Monitor;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.System;
using MHZNet.VO.Core.Monitor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MHZNet.Api.Controllers.Monitor;

/// <summary>
/// 异常日志管理
/// </summary>
[Area("Area.ExceptionLogManagement")]
[Route("/api/exception", Order = 14)]
public class ExceptionLogController : BaseApiController
{
    #region 字段

    private readonly IExceptionLogService _exceptionLogService;

    #endregion

    #region 构造函数
    public ExceptionLogController(IExceptionLogService exceptionLogService)
    {
        _exceptionLogService = exceptionLogService;
    }

    #endregion

    #region 内部接口

    /// <summary>
    /// 查看异常日志列表
    /// </summary>
    /// <param name="logQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("query")]
    [Description("Sys.Query")]
    [NotAudit]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResultVm<List<ExceptionLogVo>>))]
    public async Task<ActionResult> Query(LogQueryCriteria logQueryCriteria,
        Pagination pagination)
    {
        var exceptionLogs = await _exceptionLogService.QueryAsync(logQueryCriteria, pagination);

        return JsonContent(exceptionLogs, pagination);
    }

    #endregion
}
