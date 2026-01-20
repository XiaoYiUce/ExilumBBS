using ExilumBBS.Models.Entity;
using ExilumBBS.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services
{
    public class UserService(Repository<UserEntity> userDb) : IUserService
    {
        /// <summary>
        /// 向本地数据库内插入一条用户缓存信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateUserProfile(UserEntity user)
        {
            await userDb.InsertOrUpdateAsync(user);
        }

        /// <summary>
        /// 删除指定UID的用户信息
        /// </summary>
        /// <returns></returns>
        public async Task DeleteUserProfile(long uid)
        {
            await userDb.AsDeleteable().Where(u => u.Uid == uid).ExecuteCommandAsync();
        }

        public UserEntity GetUserProfile()
        {
            return userDb.AsQueryable().First();
        }

        /// <summary>
        /// 获取用户配置文件
        /// </summary>
        /// <returns></returns>
        public async Task<UserEntity> GetUserProfileAsync()
        {
            return await userDb.AsQueryable().FirstAsync();
        }
    }
}
