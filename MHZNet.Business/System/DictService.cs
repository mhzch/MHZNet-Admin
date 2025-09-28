using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHZNet.Common.Global;
using MHZNet.Common.Model;
using MHZNet.Core;
using MHZNet.Core.Utils;
using MHZNet.PO.Core.System.Dict;
using MHZNet.IBusiness.System;
using MHZNet.DTO.Dto.Core.System.Dict;
using MHZNet.DTO.Queries.Common;
using MHZNet.DTO.Queries.System;
using MHZNet.VO.Core.System.Dict;
using MHZNet.VO.Report.System;
using ConditionalModelExtensions = MHZNet.Common.Extensions.ConditionalModelExtensions;
using ExtObject = MHZNet.Common.Extensions.ExtObject;

namespace MHZNet.Business.System;

/// <summary>
/// 字典服务
/// </summary>
public class DictService : BaseServices<Dict>, IDictService
{
    #region 基础方法

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="createUpdateDictDto"></param>
    /// <returns></returns>
    public async Task<OperateResult> CreateAsync(CreateUpdateDictDto createUpdateDictDto)
    {
        if (await TableWhere(d => d.Name == createUpdateDictDto.Name).AnyAsync())
        {
            return OperateResult.Error(ValidationError.IsExist(createUpdateDictDto, nameof(createUpdateDictDto.Name)));
        }

        var result = await AddAsync(App.Mapper.MapTo<Dict>(createUpdateDictDto));
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="createUpdateDictDto"></param>
    /// <returns></returns>
    public async Task<OperateResult> UpdateAsync(CreateUpdateDictDto createUpdateDictDto)
    {
        var oldDict =
            await TableWhere(x => x.Id == createUpdateDictDto.Id).FirstAsync();
        if (ExtObject.IsNull(oldDict))
        {
            return OperateResult.Error(ValidationError.NotExist(createUpdateDictDto, LanguageKeyConstants.Dict,
                nameof(createUpdateDictDto.Id)));
        }

        if (oldDict.Name != createUpdateDictDto.Name &&
            await TableWhere(j => j.Name == createUpdateDictDto.Name).AnyAsync())
        {
            return OperateResult.Error(ValidationError.IsExist(createUpdateDictDto, nameof(createUpdateDictDto.Name)));
        }

        var result = await UpdateAsync(App.Mapper.MapTo<Dict>(createUpdateDictDto));
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<OperateResult> DeleteAsync(HashSet<long> ids)
    {
        var dictList = await TableWhere(x => ids.Contains(x.Id)).ToListAsync();
        if (dictList.Count <= 0)
        {
            return OperateResult.Error(ValidationError.NotExist());
        }

        var result = await LogicDelete<Dict>(x => ids.Contains(x.Id));
        return OperateResult.Result(result);
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="dictQueryCriteria"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    public async Task<List<DictVo>> QueryAsync(DictQueryCriteria dictQueryCriteria, Pagination pagination)
    {
        var queryOptions = new QueryOptions<Dict>
        {
            Pagination = pagination,
            ConditionalModels = ConditionalModelExtensions.ApplyQueryConditionalModel(dictQueryCriteria)
            //IsIncludes = true
        };
        var list = await TablePageAsync(queryOptions);
        var dicts = App.Mapper.MapTo<List<DictVo>>(list);
        // foreach (var item in dicts)
        // {
        //     item.DictDetails.ForEach(d => d.Dict = new DictDto2 { Id = d.DictId });
        // }

        return dicts;
    }

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="dictQueryCriteria"></param>
    /// <returns></returns>
    public async Task<List<ExportBase>> DownloadAsync(DictQueryCriteria dictQueryCriteria)
    {
        var conditionalModels = ConditionalModelExtensions.ApplyQueryConditionalModel(dictQueryCriteria);
        var dicts = await Table.Includes(x => x.DictDetails).Where(conditionalModels)
            .ToListAsync();
        List<ExportBase> dictExports = new List<ExportBase>();

        dicts.ForEach(x =>
        {
            dictExports.AddRange(x.DictDetails.Select(d => new DictExport
            {
                Id = x.Id,
                DictType = x.DictType,
                Name = x.Name,
                Description = x.Description,
                Lable = d.Label,
                Value = d.Value,
                CreateTime = x.CreateTime
            }));
        });

        return dictExports;
    }

    #endregion
}
