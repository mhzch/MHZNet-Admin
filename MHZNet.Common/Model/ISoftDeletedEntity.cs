namespace MHZNet.Common.Model;

/// <summary>
/// É¾³ý½Ó¿Ú
/// </summary>
public interface ISoftDeletedEntity
{
    /// <summary>
    /// ÊÇ·ñÉ¾³ý
    /// </summary>
    bool IsDeleted { get; set; }
}
