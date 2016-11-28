using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 用于将参数封装成SQL语句返回
/// </summary>
namespace BLL.Tools
{
    class SQLFactory
    {
        //关于查询语句的各种重载

        /// <summary>
        /// 查询一整张表
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <returns></returns>
        public static string BuildSQLSelectString(string Tname)
        {
            return "select * from " + Tname;
        }

        /// <summary>
        /// 返回有一个条件限制的SQL语句
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="dl">条件名</param>
        /// <param name="text">条件值</param>
        /// <returns></returns>
        public static string BuildSQLSelectString(string Tname, string dl, string text)
        {
            return "select * from " + Tname + " where " + dl + "='" + text + "'";
        }

        /// <summary>
        /// 查询指定表，三个条件限制
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="dl">条件一名</param>
        /// <param name="d2">条件二名</param>
        /// <param name="d3">条件三名</param>
        /// <param name="text1">条件一值</param>
        /// <param name="text2">条件二值</param>
        /// <param name="text3">条件三值</param>
        /// <returns></returns>
        public static string BuildSQLSelectString(string Tname, string dl, string d2, string d3, string text1, string text2, string text3)
        {
            return "select * from " + Tname + " where " + dl + "='" + text1 + "' and " + d2 + "='" + text2 + "'" + "' and " + d3 + "='" + text3 + "'";
        }

        /// <summary>
        /// 更新数据表
        /// </summary>
        /// <param name="v1">表名</param>
        /// <param name="v2">更新的字段</param>
        /// <param name="v3">更新后的值</param>
        /// <param name="v4">约束名</param>
        /// <param name="v5">约束值</param>
        /// <returns></returns>
        internal static string BuildSQLUpdate(string v1, string v2, string v3, string v4, string v5)
        {
            return "update " + v1 + " set " + v2 + "='" + v3 + "' where " + v4 + "='" + v5 + "'";
        }

        /// <summary>
        /// 查询指定表，两个条件限制
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="dl">条件一名</param>
        /// <param name="d2">条件二名</param>
        /// <param name="text1">条件一值</param>
        /// <param name="text2">条件二值</param>
        /// <returns></returns>
        public static string BuildSQLSelectString(string Tname, string dl, string d2, string text1, string text2)
        {
            return "select * from " + Tname + " where " + dl + "='" + text1 + "' and " + d2 + "='" + text2 + "'";
        }

        /// <summary>
        /// 查询指定列的数据
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="column">列名</param>
        /// <returns></returns>
        public static string BuildSQLSelectString(string Tname, string column)
        {
            return "select " + column + " from " + Tname;
        }

        /// <summary>
        /// 删除表中的数据，一个约束值
        /// </summary>
        /// <param name="TName">表名</param>
        /// <param name="y1">约束条件</param>
        /// <param name="z1">约束值</param>
        /// <returns></returns>
        public static string BuildSQLDeleteString(string TName, string y1, string z1)
        {
            return "delete from " + TName + " where " + y1 + "='" + z1 + "'";
        }

        /// <summary>
        /// !猜测代码
        /// 查询指定表的指定列，按照另一个约束
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <param name="name1">查询的列名</param>
        /// <param name="name2">约束条件列</param>
        /// <param name="data">约束条件值</param>
        /// <returns></returns>
        public static string BuildSQLSelectString(string strTable, string name1, string name2, string data)
        {
            return "select " + name1 + " from " + strTable + " where " + name2 + "='" + data + "';";
        }

        /// <summary>
        /// 删除表中的所有数据
        /// </summary>
        /// <param name="TName">表名</param>
        /// <returns></returns>
        public static string BuildSQLDeleteString(string TName)
        {
            return "delete from " + TName;
        }
    }
}
