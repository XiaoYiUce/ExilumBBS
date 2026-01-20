using ExilumBBS.Models.Entity;
using ExilumBBS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    /// <summary>
    /// 用户状态机
    /// </summary>
    public class UserState(ITokenService token, IUserService user)
    {
        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin => token.GetToken() == null ? false : true;

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public UserEntity? CurrentUserProfile => user.GetUserProfile();

        /// <summary>
        /// Token
        /// </summary>
        public string? Token => token.GetToken();
    }
}
