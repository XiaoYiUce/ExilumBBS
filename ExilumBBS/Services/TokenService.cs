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
        public Task DeleteToken()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取Token值
        /// </summary>
        /// <returns></returns>
        public async Task<string?> GetToken()
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
    }
}
