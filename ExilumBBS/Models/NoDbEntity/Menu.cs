using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Models.NoDbEntity
{
    /// <summary>
    /// 菜单相关常量
    /// </summary>
    public static class Menu
    {
        public static MenuItem[] MenuItems = new MenuItem[]
        {
            new MenuItem { Text= "发现", Icon= "mdi-folder",Id=1 },
            new MenuItem { Text= "关注", Icon= "mdi-account-multiple",Id=100,Type=MenuType.NewTab,Route="/follow" },
            new MenuItem { Text= "休息室", Icon= "mdi-star",Id=2 },
            new MenuItem { Text= "攻略", Icon= "mdi-history",Id=3 },
            new MenuItem { Text= "同人", Icon= "mdi-check-circle",Id=7 },
            new MenuItem { Text= "世界观", Icon= "mdi-upload",Id=4 },
            new MenuItem { Text= "官方", Icon= "mdi-cloud-upload",Id=5 },
            new MenuItem { Text= "互助厅",Icon= "mdi-cloud-upload",Id=8},
            new MenuItem { Text="设置",Icon="mdi-cog",Id=200,Type=MenuType.NewTab,Route="/settings"}
        };
    }

    /// <summary>
    /// 菜单项
    /// </summary>
    public class MenuItem
    {
        public string Text { get; set; } = "";
        public string Icon { get; set; } = "";
        public int Id { get; set; }
        /// <summary>
        /// 菜单类型，预留
        /// </summary>
        public MenuType Type { get; set; } = MenuType.Category;

        /// <summary>
        /// 如果不是社区分类并且是跳转到其他页面的菜单，那需要设置路由
        /// </summary>
        public string? Route { get; set; }
    }

    public enum MenuType
    {
        /// <summary>
        /// 社区页面分类
        /// </summary>
        Category,
        /// <summary>
        /// 切换到新页面
        /// </summary>
        NewTab
    }
}
