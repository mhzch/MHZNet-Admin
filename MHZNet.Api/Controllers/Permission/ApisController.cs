using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MHZNet.Api.Controllers.Base;
using MHZNet.Common.Extensions;
using MHZNet.Common.Global;
using MHZNet.Common.IdGenerator;
using MHZNet.Common.Model;
using MHZNet.Core;
using MHZNet.PO.Core.Permission;
using MHZNet.IBusiness.Permission;
using MHZNet.DTO.Dto.Core.Permission;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.Permission;
using MHZNet.VO.Core.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MHZNet.Api.Controllers.Permission;

/// <summary>
/// Apis管理
/// </summary>
[Area("Area.ApiManagement")]
[Route("/api/apis", Order = 20)]
public class ApisController : BaseApiController
{
    #region 字段

    private readonly IApisService _apisService;

    #endregion

    #region 构造函数

    public ApisController(IApisService apisService)
    {
        _apisService = apisService;
    }

    #endregion

    #region 内部接口

    /// <summary>
    /// 创建Api
    /// </summary>
    /// <param name="createUpdateApisDto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    [Description("Sys.Create")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ActionResultVm))]
    public async Task<ActionResult> Create(
        [FromBody] CreateUpdateApisDto createUpdateApisDto)
    {
        if (!ModelState.IsValid)
        {
            var actionError = ModelState.GetErrors();
            return Error(actionError);
        }

        var result = await _apisService.CreateAsync(createUpdateApisDto);
        return Ok(result);
    }

    /// <summary>
    /// 更新Api
    /// </summary>
    /// <param name="createUpdateApisDto"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("edit")]
    [Description("Sys.Edit")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Update(
        [FromBody] CreateUpdateApisDto createUpdateApisDto)
    {
        if (!ModelState.IsValid)
        {
            var actionError = ModelState.GetErrors();
            return Error(actionError);
        }

        var result = await _apisService.UpdateAsync(createUpdateApisDto);
        return Ok(result);
    }

    /// <summary>
    /// 删除Api
    /// </summary>
    /// <param name="idCollection"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete")]
    [Description("Sys.Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResultVm))]
    public async Task<ActionResult> Delete([FromBody] IdCollection idCollection)
    {
        if (!ModelState.IsValid)
        {
            var actionError = ModelState.GetErrors();
            return Error(actionError);
        }

        var result = await _apisService.DeleteAsync(idCollection.IdArray);
        return Ok(result);
    }

    /// <summary>
    /// 查看Apis列表
    /// </summary>
    /// <param name="apisQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("query")]
    [Description("Sys.Query")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResultVm<List<ApisVo>>))]
    public async Task<ActionResult> Query(ApisQueryCriteria apisQueryCriteria, Pagination pagination)
    {
        var apisList = await _apisService.QueryAsync(apisQueryCriteria, pagination);

        return JsonContent(apisList, pagination);
    }


    /// <summary>
    /// 刷新Api列表 只实现增量更新api接口
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("refresh")]
    [Description("Action.RefreshApi")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResultVm))]
    public async Task<ActionResult> RefreshApis()
    {
        List<Apis> apis = new List<Apis>();
        var allApis = await _apisService.QueryAllAsync();
        var types = GlobalType.ApiTypes.Where(x =>
                x.IsClass && typeof(Controller).IsAssignableFrom(x) && x.Name != "TestController" &&
                x.Namespace != "MHZNet.Api.Controllers.Base")
            .OrderBy(x => x.GetCustomAttributes<RouteAttribute>().FirstOrDefault()?.Order).ToList();
        foreach (var type in types)
        {
            var areaAttr = type.GetCustomAttributes(typeof(AreaAttribute), true)
                .OfType<AreaAttribute>()
                .FirstOrDefault();
            var routeAttr = type.GetCustomAttributes(typeof(RouteAttribute), true)
                .OfType<RouteAttribute>()
                .FirstOrDefault();
            var methods = type.GetMethods().Where(m =>
                m.DeclaringType == type && !Attribute.IsDefined(m, typeof(NonActionAttribute)));

            foreach (var methodInfo in methods)
            {
                var methodAttr = methodInfo.GetCustomAttributes(typeof(HttpMethodAttribute), true)
                    .OfType<HttpMethodAttribute>()
                    .FirstOrDefault();
                var methodRouteAttr = methodInfo.GetCustomAttributes(typeof(RouteAttribute), true)
                    .OfType<RouteAttribute>()
                    .FirstOrDefault();
                var url = $"{routeAttr?.Template}/{methodRouteAttr?.Template}".ToLower();
                var method = methodAttr?.HttpMethods.FirstOrDefault()?.Trim();
                if (!allApis.Any(x =>
                        x.Url.Equals(url, StringComparison.CurrentCultureIgnoreCase) && x.Method == method))
                {
                    apis.Add(new Apis
                    {
                        Id = IdHelper.NextId(),
                        Group = areaAttr != null ? areaAttr.RouteValue : type.Name,
                        Url = url,
                        Description = methodInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)
                            .OfType<DescriptionAttribute>()
                            .FirstOrDefault()?.Description,
                        Method = method
                    });
                }
            }
        }

        if (apis.Count == 0)
        {
            return Ok(OperateResult.Success(App.L.R("Action.ApiRefresh.Success")));
        }

        var result = await _apisService.CreateAsync(apis);
        if (result.IsSuccess)
        {
            return Ok(OperateResult.Success(App.L.R("Action.ApiRefresh.Success")));
        }

        return Ok(OperateResult.Success(App.L.R("Action.ApiRefresh.Fail")));
    }

    #endregion
}
