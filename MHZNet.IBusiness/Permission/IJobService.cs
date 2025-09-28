using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Model;
using MHZNet.PO.Core.Permission;
using MHZNet.DTO.Dto.Core.Permission;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.Permission;
using MHZNet.VO.Core.Permission.Job;

namespace MHZNet.IBusiness.Permission;

/// <summary>
/// 岗位接口
/// </summary>
public interface IJobService : IBaseServices<Job>
{
    #region 基础接口

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateJobDto"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(CreateUpdateJobDto createUpdateJobDto);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateJobDto"></param>
    /// <returns></returns>
    Task<OperateResult> UpdateAsync(CreateUpdateJobDto createUpdateJobDto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<OperateResult> DeleteAsync(HashSet<long> ids);

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="jobQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<List<JobVo>> QueryAsync(JobQueryCriteria jobQueryCriteria, Pagination pagination);

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="jobQueryCriteria"></param>
    /// <returns></returns>
    Task<List<ExportBase>> DownloadAsync(JobQueryCriteria jobQueryCriteria);

    #endregion

    #region 扩展接口

    /// <summary>
    /// 获取所有岗�?    /// </summary>
    /// <returns></returns>
    Task<List<JobVo>> QueryAllAsync();

    #endregion
}
