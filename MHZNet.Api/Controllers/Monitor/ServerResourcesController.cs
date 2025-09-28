using System.ComponentModel;
using System.Threading.Tasks;
using MHZNet.Api.Controllers.Base;
using MHZNet.Common.Attributes;
using MHZNet.IBusiness.Monitor;
using MHZNet.VO.ServerInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MHZNet.Api.Controllers.Monitor;

/// <summary>
/// 服务器管�?/// </summary>
[Area("Area.ServerResourceManagement")]
[Route("/api/service", Order = 16)]
public class ServerResourcesController : BaseApiController
{
    private readonly IServerResourcesService _serverResourcesService;

    public ServerResourcesController(IServerResourcesService serverResourcesService)
    {
        _serverResourcesService = serverResourcesService;
    }

    #region 对内接口

    [HttpGet]
    [Route("resources/info")]
    [Description("Action.ServerResourceInfo")]
    [NotAudit]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServerResourcesInfo))]
    public async Task<ActionResult> Query()
    {
        var resourcesInfo = await _serverResourcesService.Query();

        return JsonContent(resourcesInfo);
    }

    #endregion
}
