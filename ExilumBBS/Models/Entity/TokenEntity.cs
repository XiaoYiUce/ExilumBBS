using ExilumBBS.Models.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Models.Entity
{
    [SugarTable("token")]
    public class TokenEntity : BaseEntity
    {
        /// <summary>
        /// JWT Token值
        /// </summary>
        public string? TokenValue { get; set; }
    }
}
