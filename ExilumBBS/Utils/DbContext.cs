using ExilumBBS.Models.Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ExilumBBS.Utils
{
    public class DbContext
    {
        /// <summary>
        /// 创建 SqlSugar 数据库实例
        /// </summary>
        public static SqlSugarScope CreateSugarScope()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "db.sqlite");
            return new SqlSugarScope(
           [
               new()
                    {
                        ConnectionString = "DataSource="+dbPath,
                        DbType = DbType.Sqlite,
                        IsAutoCloseConnection = true,
                        ConfigId="default",
                        MoreSettings = new ConnMoreSettings()
                                       {
                                           //禁止删列，正式版必须开启，避免修改表时错误删除列
                                           SqliteCodeFirstEnableDropColumn = false
                                       },
                        ConfigureExternalServices =
                            new ConfigureExternalServices
                            {
                                EntityService = ( c,
                                                  p ) =>
                                                {
                                                    if ( p.IsPrimarykey == false &&
                                                         new NullabilityInfoContext()
                                                             .Create( c )
                                                             .WriteState is NullabilityState.Nullable )
                                                    {
                                                        p.IsNullable = true;
                                                    }

                                                    p.DbColumnName =
                                                        UtilMethods.ToUnderLine( p.DbColumnName ); //驼峰转下划线方法
                                                },
                                EntityNameService = ( x,
                                                      p ) => //处理表名
                                                    {
                                                        //禁止删列
                                                        p.IsDisabledDelete = true;

                                                        p.DbTableName =
                                                            UtilMethods.ToUnderLine( p.DbTableName ); //驼峰转下划线方法
                                                    }
                            }
                    }
           ],
       db =>
       {
           // 这里配置全局事件，比如拦截执行 SQL
           db.Aop.OnLogExecuting = (sql,
                                     pars) =>
           {
#if DEBUG
               Debug.Print(UtilMethods.GetNativeSql(sql, pars));
#endif
           };
       });
        }

        public static void InitDb(ISqlSugarClient db)
        {
            Debug.WriteLine("数据库初始化");
            //初始化库
            db.DbMaintenance.CreateDatabase();

            //初始化表
            Type[] types = typeof(TokenEntity).Assembly.GetTypes()
                                             .Where(it => it.FullName!.Contains("Models.Entity") &&
                                             !it.FullName!.Contains("Models.Entity.Base") &&
                                             it.FullName!.EndsWith("Entity"))
                                             .ToArray();

            db.CodeFirst.SetStringDefaultLength(255).InitTables(types); //根据types创建表
        }
    }
}
