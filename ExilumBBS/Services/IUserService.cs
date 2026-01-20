using ExilumBBS.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services
{
    public interface IUserService
    {
        public Task<UserEntity> GetUserProfileAsync();
        public UserEntity GetUserProfile();
        public Task CreateOrUpdateUserProfile(UserEntity user);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <returns></returns>
        public Task DeleteUserProfile(long uid);
    }
}
