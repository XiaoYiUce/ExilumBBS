using ExilumBBS.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services
{
    public interface IUserService
    {
        public Task<UserEntity> GetUserProfileAsync();
        public Task CreateOrUpdateUserProfile(UserEntity user);

        /// <summary>
        /// 删除指定UID的用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Task DeleteUserProfile(long uid);
    }
}
