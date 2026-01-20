using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Models.NoDbEntity
{
    public class Category
    {
        public string CategoryName { get; set; } = "";
        public int CategoryId { get; set; }
    }

    public class CategoryInfo
    {
        public static List<Category> categoryList = [
            new Category{ CategoryName= "发现",CategoryId=1 },
            new Category { CategoryName= "休息室",CategoryId=2 },
            new Category { CategoryName= "攻略",CategoryId=3 },
            new Category { CategoryName= "同人",CategoryId=7 },
            new Category { CategoryName= "世界观",CategoryId=4 },
            new Category { CategoryName= "官方",CategoryId=5 },
            new Category { CategoryName= "互助厅",CategoryId=8},
    ];
    }
}
