using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Models.Entity.Base
{
    /// <summary>
    /// 基础类
    /// </summary>
    public class BaseEntity
    {
        [SugarColumn(IsPrimaryKey = true)]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
