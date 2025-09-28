using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Model;
using MHZNet.PO.Core.System;
using MHZNet.DTO.Dto.Core.System;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.System;
using MHZNet.VO.Core.System;
using Microsoft.AspNetCore.Http;

namespace MHZNet.IBusiness.System;

/// <summary>
/// 文件记录接口
/// </summary>
public interface IFileRecordService : IBaseServices<FileRecord>
{
    #region 基础接口

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateFileRecordDto"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(CreateUpdateFileRecordDto createUpdateFileRecordDto, IFormFile file);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateFileRecordDto"></param>
    /// <returns></returns>
    Task<OperateResult> UpdateAsync(CreateUpdateFileRecordDto createUpdateFileRecordDto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<OperateResult> DeleteAsync(HashSet<long> ids);

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="fileRecordQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<List<FileRecordVo>> QueryAsync(FileRecordQueryCriteria fileRecordQueryCriteria, Pagination pagination);

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="fileRecordQueryCriteria"></param>
    /// <returns></returns>
    Task<List<ExportBase>> DownloadAsync(FileRecordQueryCriteria fileRecordQueryCriteria);

    #endregion
}
