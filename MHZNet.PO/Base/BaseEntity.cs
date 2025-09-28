using System;
using MHZNet.Common.Model;
using SqlSugar;

namespace MHZNet.PO.Base
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [SugarIndex("index_{table}_CreateBy", nameof(CreateBy), OrderByType.Asc)]
    [SugarIndex("index_{table}_IsDeleted", nameof(IsDeleted), OrderByType.Asc)]
    public class BaseEntity : RootKey<long>, ICreateByEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 创建者名�?        /// </summary>
        [SugarColumn(IsNullable = true, IsOnlyIgnoreUpdate = true)]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = true, IsOnlyIgnoreUpdate = true)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新者名�?        /// </summary>
        [SugarColumn(IsNullable = true, IsOnlyIgnoreInsert = true)]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时�?        /// </summary>
        [SugarColumn(IsNullable = true, IsOnlyIgnoreInsert = true)]
        public DateTime? UpdateTime { get; set; }


        /// <summary>
        /// 是否已删�?        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
