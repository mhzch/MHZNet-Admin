using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.PO.Core.Message.Email;

namespace MHZNet.DTO.Dto.Core.Message.Email;

/// <summary>
/// 邮箱模板Dto
/// </summary>
[AutoMapping(typeof(EmailMessageTemplate), typeof(CreateUpdateEmailMessageTemplateDto))]
public class CreateUpdateEmailMessageTemplateDto : BaseEntityDto<long>
{
    /// <summary>
    /// 模板名称
    /// </summary>
    [Display(Name = "EmailTemplate.Name")]
    [Required(ErrorMessage = "{0}required")]
    public string Name { get; set; }

    /// <summary>
    /// 抄送邮箱地址
    /// </summary>
    public string BccEmailAddresses { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [Display(Name = "EmailTemplate.Subject")]
    [Required(ErrorMessage = "{0}required")]
    public string Subject { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [Display(Name = "EmailTemplate.Body")]
    [Required(ErrorMessage = "{0}required")]
    public string Body { get; set; }

    /// <summary>
    /// 是否激�?    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// 邮箱账户标识�?    /// </summary>
    public long EmailAccountId { get; set; }
}
