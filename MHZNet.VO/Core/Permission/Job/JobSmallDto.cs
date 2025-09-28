using MHZNet.Common.Attributes;

namespace MHZNet.VO.Core.Permission.Job;

/// <summary>
/// ¸ÚÎ»Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Job), typeof(JobSmallDto))]
public class JobSmallDto
{
    /// <summary>
    /// ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Ãû³Æ
    /// </summary>
    public string Name { get; set; }
}

