using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHZNet.Common.Enums;
using MHZNet.Common.Extensions;
using MHZNet.Common.Global;
using MHZNet.Common.Model;
using MHZNet.Core;
using MHZNet.Core.Utils;
using MHZNet.PO.Core.System;
using MHZNet.IBusiness.System;
using MHZNet.DTO.Dto.Core.System;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.System;
using MHZNet.VO.Core.System;
using MHZNet.VO.Report.System;

namespace MHZNet.Business.System;

/// <summary>
/// 租户服务
/// </summary>
public class TenantService : BaseServices<Tenant>, ITenantService
{
    #region 基础方法

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateTenantDtoDto"></param>
    /// <returns></returns>
    public async Task<OperateResult> CreateAsync(CreateUpdateTenantDto createUpdateTenantDtoDto)
    {
        if (await TableWhere(r => r.TenantId == createUpdateTenantDtoDto.TenantId).AnyAsync())
        {
            return OperateResult.Error(ValidationError.IsExist(createUpdateTenantDtoDto,
                nameof(createUpdateTenantDtoDto.TenantId)));
        }

        if (createUpdateTenantDtoDto.TenantType == TenantType.Db)
        {
            if (createUpdateTenantDtoDto.DbType.IsNull())
            {
                return OperateResult.Error(App.L.R("{0}required",
                    App.L.R("Tenant.DbType")));
            }

            if (createUpdateTenantDtoDto.ConfigId.IsNullOrEmpty())
            {
                return OperateResult.Error(App.L.R("{0}required",
                    App.L.R("Tenant.ConfigId")));
            }

            if (createUpdateTenantDtoDto.Connection.IsNullOrEmpty())
            {
                return OperateResult.Error(App.L.R("{0}required",
                    App.L.R("Tenant.Connection")));
            }

            if (await TableWhere(r => r.ConfigId == createUpdateTenantDtoDto.ConfigId).AnyAsync())
            {
                return OperateResult.Error(ValidationError.IsExist(createUpdateTenantDtoDto,
                    nameof(createUpdateTenantDtoDto.ConfigId)));
            }
        }

        var tenant = App.Mapper.MapTo<Tenant>(createUpdateTenantDtoDto);
        var result = await AddAsync(tenant);
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateTenantDtoDto"></param>
    /// <returns></returns>
    public async Task<OperateResult> UpdateAsync(CreateUpdateTenantDto createUpdateTenantDtoDto)
    {
        //取出待更新数据
        var oldTenant = await TableWhere(x => x.Id == createUpdateTenantDtoDto.Id).FirstAsync();
        if (oldTenant.IsNull())
        {
            return OperateResult.Error(ValidationError.NotExist(createUpdateTenantDtoDto, LanguageKeyConstants.Tenant,
                nameof(createUpdateTenantDtoDto.Id)));
        }

        if (oldTenant.TenantId != createUpdateTenantDtoDto.TenantId &&
            await TableWhere(x => x.TenantId == createUpdateTenantDtoDto.TenantId).AnyAsync())
        {
            return OperateResult.Error(ValidationError.IsExist(createUpdateTenantDtoDto,
                nameof(createUpdateTenantDtoDto.TenantId)));
        }

        if (createUpdateTenantDtoDto.TenantType == TenantType.Db)
        {
            if (createUpdateTenantDtoDto.DbType.IsNull())
            {
                return OperateResult.Error(App.L.R("{0}required",
                    App.L.R("Tenant.DbType")));
            }

            if (createUpdateTenantDtoDto.ConfigId.IsNullOrEmpty())
            {
                return OperateResult.Error(App.L.R("{0}required",
                    App.L.R("Tenant.ConfigId")));
            }

            if (createUpdateTenantDtoDto.Connection.IsNullOrEmpty())
            {
                return OperateResult.Error(App.L.R("{0}required",
                    App.L.R("Tenant.Connection")));
            }

            if (oldTenant.ConfigId != createUpdateTenantDtoDto.ConfigId &&
                await TableWhere(x => x.ConfigId == createUpdateTenantDtoDto.ConfigId).AnyAsync())
            {
                return OperateResult.Error(ValidationError.IsExist(createUpdateTenantDtoDto,
                    nameof(createUpdateTenantDtoDto.ConfigId)));
            }
        }

        var tenant = App.Mapper.MapTo<Tenant>(createUpdateTenantDtoDto);
        var result = await UpdateAsync(tenant, null, x => x.TenantId);
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<OperateResult> DeleteAsync(HashSet<long> ids)
    {
        var tenants = await TableWhere(x => ids.Contains(x.Id)).Includes(x => x.Users).ToListAsync();
        if (tenants.Any(x => x.Users != null && x.Users.Count != 0))
        {
            return OperateResult.Error(ValidationError.DataAssociationExists());
        }

        var result = await LogicDelete<Tenant>(x => ids.Contains(x.Id));
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="tenantQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    public async Task<List<TenantVo>> QueryAsync(TenantQueryCriteria tenantQueryCriteria, Pagination pagination)
    {
        var queryOptions = new QueryOptions<Tenant>
        {
            Pagination = pagination,
            ConditionalModels = tenantQueryCriteria.ApplyQueryConditionalModel()
        };
        return App.Mapper.MapTo<List<TenantVo>>(
            await TablePageAsync(queryOptions));
    }

    /// <summary>
    /// 查询全部
    /// </summary>
    /// <returns></returns>
    public async Task<List<TenantVo>> QueryAllAsync()
    {
        return App.Mapper.MapTo<List<TenantVo>>(
            await Table.ToListAsync());
    }

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="tenantQueryCriteria"></param>
    /// <returns></returns>
    public async Task<List<ExportBase>> DownloadAsync(TenantQueryCriteria tenantQueryCriteria)
    {
        var tenants = await TableWhere(tenantQueryCriteria.ApplyQueryConditionalModel()).ToListAsync();
        List<ExportBase> tenantExports = new List<ExportBase>();
        tenantExports.AddRange(tenants.Select(x => new TenantExport
        {
            Id = x.Id,
            TenantId = x.TenantId,
            Name = x.Name,
            Description = x.Description,
            TenantType = x.TenantType,
            ConfigId = x.ConfigId,
            DbType = x.DbType,
            ConnectionString = x.ConnectionString,
            CreateTime = x.CreateTime
        }));
        return tenantExports;
    }

    #endregion
}
