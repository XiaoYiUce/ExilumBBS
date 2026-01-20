using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// 设置Token值
        /// </summary>
        /// <param name="token"></param>
        public Task SetTokenAsync(string token);

        /// <summary>
        /// 获取Token值
        /// </summary>
        /// <returns></returns>
        public Task<string?> GetTokenAsync();

        public string? GetToken();

        /// <summary>
        /// 删除Token
        /// </summary>
        /// <returns></returns>
        public Task DeleteToken();
    }
}
