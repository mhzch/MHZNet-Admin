using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Model;
using MHZNet.PO.Core.Permission;
using MHZNet.DTO.Dto.Core.Permission;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.Permission;
using MHZNet.VO.Core.Permission.Department;

namespace MHZNet.IBusiness.Permission;

/// <summary>
/// 部门接口
/// </summary>
public interface IDepartmentService : IBaseServices<Department>
{
    #region 基础接口

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateDepartmentDto"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateDepartmentDto"></param>
    /// <returns></returns>
    Task<OperateResult> UpdateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<OperateResult> DeleteAsync(List<long> ids);

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="deptQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<List<DepartmentVo>> QueryAsync(DeptQueryCriteria deptQueryCriteria, Pagination pagination);

    /// <summary>
    /// 查询全部
    /// </summary>
    /// <returns></returns>
    Task<List<DepartmentVo>> QueryAllAsync();

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="deptQueryCriteria"></param>
    /// <returns></returns>
    Task<List<ExportBase>> DownloadAsync(DeptQueryCriteria deptQueryCriteria);

    #endregion

    #region 扩展接口

    /// <summary>
    /// 根据父ID获取全部
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<DepartmentVo>> QueryByPIdAsync(long id);

    /// <summary>
    /// 根据ID获取一个部门
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<DepartmentSmallVo> QueryByIdAsync(long id);


    /// <summary>
    /// 获取子级所有部门
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<DepartmentVo>> QuerySuperiorDeptAsync(long id);

    /// <summary>
    /// 获取所选部门及全部下级部门ID
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="allIds"></param>
    /// <returns></returns>
    Task<List<long>> GetChildIds(List<long> ids, List<long> allIds);

    #endregion
}
