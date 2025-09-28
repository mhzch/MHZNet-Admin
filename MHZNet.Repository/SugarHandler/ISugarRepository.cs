using SqlSugar;

namespace MHZNet.Repository.SugarHandler;

/// <summary>
/// sqlSugar接口
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface ISugarRepository<TEntity> where TEntity : class
{
    ISqlSugarClient SugarClient { get; }
}
