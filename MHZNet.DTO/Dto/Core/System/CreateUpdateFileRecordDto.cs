using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.PO.Core.System;

namespace MHZNet.DTO.Dto.Core.System;

/// <summary>
/// 文件记录Dto
/// </summary>
[AutoMapping(typeof(FileRecord), typeof(CreateUpdateFileRecordDto))]
public class CreateUpdateFileRecordDto : BaseEntityDto<long>
{
    /// <summary>
    /// 描述 Sys.Description
    /// </summary>
    [Display(Name = "Sys.Description")]
    [Required(ErrorMessage = "{0}required")]
    public string Description { get; set; }

    /// <summary>
    /// 文件类型
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// 文件类型名称
    /// </summary>
    public string ContentTypeName { get; set; }

    /// <summary>
    /// 文件类型名称(EN)
    /// </summary>
    public string ContentTypeNameEn { get; set; }

    /// <summary>
    /// 源名�?    /// </summary>
    public string OriginalName { get; set; }

    /// <summary>
    /// 新名�?    /// </summary>
    public string NewName { get; set; }

    /// <summary>
    /// 存储路径
    /// </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// 文件大小
    /// </summary>
    public string Size { get; set; }
}
