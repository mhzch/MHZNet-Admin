using System.Collections.Generic;
using System.Threading.Tasks;
using MHZNet.Common.Model;
using MHZNet.PO.Core.Message.Email;
using MHZNet.DTO.Dto.Core.Message.Email;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.Message;
using MHZNet.VO.Core.Message.Email;

namespace MHZNet.IBusiness.Message.Email;

/// <summary>
/// 邮箱账户接口
/// </summary>
public interface IEmailAccountService : IBaseServices<EmailAccount>
{
    #region 基础接口

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateEmailAccountDto"></param>
    /// <returns></returns>
    Task<OperateResult> CreateAsync(CreateUpdateEmailAccountDto createUpdateEmailAccountDto);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateEmailAccountDto"></param>
    /// <returns></returns>
    Task<OperateResult> UpdateAsync(CreateUpdateEmailAccountDto createUpdateEmailAccountDto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<OperateResult> DeleteAsync(HashSet<long> ids);

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="emailAccountQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<List<EmailAccountVo>> QueryAsync(EmailAccountQueryCriteria emailAccountQueryCriteria,
        Pagination pagination);

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="emailAccountQueryCriteria"></param>
    /// <returns></returns>
    Task<List<ExportBase>> DownloadAsync(EmailAccountQueryCriteria emailAccountQueryCriteria);

    #endregion
}
