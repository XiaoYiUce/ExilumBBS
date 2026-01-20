using ExilumBBS.Models.Entity;
using ExilumBBS.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services
{
    public class TokenService(Repository<TokenEntity> tokenDb) : ITokenService
    {
        /// <summary>
        /// 删除Token
        /// </summary>
        /// <returns></returns>
        public async Task DeleteToken()
        {
            // 暂时不考虑多用户登录 先全部清空
            await tokenDb.AsDeleteable().SelectAll().ExecuteCommandAsync();
        }

        /// <summary>
        /// 获取Token值
        /// </summary>
        /// <returns></returns>
        public async Task<string?> GetTokenAsync()
        {
            var result = await tokenDb.AsQueryable().FirstAsync();

            if (result != null)
            {
                return result.TokenValue;
            }

            return null;
        }

        /// <summary>
        /// 设置Token值
        /// </summary>
        /// <param name="token">Token值</param>
        public async Task SetTokenAsync(string token)
        {
            await tokenDb.InsertAsync(new TokenEntity() { TokenValue = token });
        }

        /// <summary>
        /// 获取Token值，非Async方法
        /// </summary>
        /// <returns></returns>
        public string? GetToken()
        {
            var result = tokenDb.AsQueryable().First();
            if (result != null)
            {
                return result.TokenValue;
            }

            return null;
        }
    }
}
