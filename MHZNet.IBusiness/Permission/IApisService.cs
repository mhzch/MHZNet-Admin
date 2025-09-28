using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Model;
using MHZNet.PO.Core.Permission;
using MHZNet.DTO.Dto.Core.Permission;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.Permission;
using MHZNet.VO.Core.Permission;

namespace MHZNet.IBusiness.Permission;

/// <summary>
/// apis 接口
/// </summary>
public interface IApisService
{
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateApisDto"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(CreateUpdateApisDto createUpdateApisDto);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateApisDto"></param>
    /// <returns></returns>
    Task<OperateResult> UpdateAsync(CreateUpdateApisDto createUpdateApisDto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<OperateResult> DeleteAsync(HashSet<long> ids);

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="apisQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<List<ApisVo>> QueryAsync(ApisQueryCriteria apisQueryCriteria, Pagination pagination);

    /// <summary>
    /// 查询所�?    /// </summary>
    /// <returns></returns>
    Task<List<ApisVo>> QueryAllAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="apis"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(List<Apis> apis);
}
