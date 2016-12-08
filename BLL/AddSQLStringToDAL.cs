using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BLL.Tools;

/// <summary>
/// 用于将SQL语句传入到DAL层，获得返回的数据集
/// </summary>
namespace BLL
{
    public class AddSQLStringToDAL
    {
        /// <summary>
        /// 查询一张表的所有数据
        /// </summary>
        /// <param name="Tname">查询的表名</param>
        /// <returns></returns>
        public static DataTable GetDTBySQL(string Tname)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname);
            return ConnHelper.GetDataTable(strSQL);
        }

        /// <summary>
        /// 发布通知
        /// </summary>
        /// <param name="text">数据</param>
        /// <param name="v2">权限</param>
        public static bool InsertMsgRow(string text, string v2)
        {
            string strSQL = "insert into TabMessage(message,role) values('" + text + "','" + v2 + "')";
            return ConnHelper.ExecuteNoneQueryOperation(strSQL);
        }

        /// <summary>
        /// 查询指定表中的所有符合条件的数据
        /// 接受一个约束条件
        /// </summary>
        /// <param name="Tname">查询的表名</param>
        /// <param name="dl">条件名</param>
        /// <param name="content">条件值</param>
        /// <returns></returns>
        public static DataTable GetDTBySQL(string Tname, string dl, string content)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname, dl, content);
            return ConnHelper.GetDataTable(strSQL);
        }

        /// <summary>
        /// 查询指定表中的所有符合条件的数据
        /// 接受三个约束参数
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="dl">约束条件1</param>
        /// <param name="d2">约束条件2</param>
        /// <param name="d3">约束条件3</param>
        /// <param name="content1">约束条件1的值</param>
        /// <param name="content2">约束条件2的值</param>
        /// <param name="content3">约束条件3的值</param>
        /// <returns></returns>
        public static DataTable GetDTBySQL(string Tname, string dl, string d2, string d3, string content1, string content2, string content3)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname, dl, d2, d3, content1, content2, content3);
            return ConnHelper.GetDataTable(strSQL);
        }

        /// <summary>
        /// 删除表内的数据，有一个约束条件
        /// </summary>
        /// <param name="v1">表名</param>
        /// <param name="v2">约束字段</param>
        /// <param name="v3">约束值</param>
        public static bool DeleteRows(string v1, string v2, string v3)
        {
            string strSQL = SQLFactory.BuildSQLDeleteString(v1, v2, v3);
            return ConnHelper.ExecuteNoneQueryOperation(strSQL);
        }

        /// <summary>
        /// 查询指定表中的所有符合条件的数据
        /// 接受两个约束参数
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="dl">约束条件1</param>
        /// <param name="d2">约束条件2</param>
        /// <param name="content1">约束条件1的值</param>
        /// <param name="content2">约束条件2的值</param>
        /// <returns></returns>
        public static DataTable GetDTBySQL(string Tname, string dl, string d2, string content1, string content2)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname, dl, d2, content1, content2);
            return ConnHelper.GetDataTable(strSQL);
        }

        /// <summary>
        /// 更新数据表
        /// 更新一个字段，有一个条件
        /// </summary>
        /// <param name="v1">表名</param>
        /// <param name="v2">更新的字段</param>
        /// <param name="v3">更新后的值</param>
        /// <param name="v4">约束名</param>
        /// <param name="v5">约束值</param>
        /// <returns></returns>
        public static bool UpdateRows(string v1, string v2, string v3, string v4, string v5)
        {
            string strSQL = SQLFactory.BuildSQLUpdate(v1, v2, v3, v4, v5);
            return ConnHelper.ExecuteNoneQueryOperation(strSQL);
        }

        /// <summary>
        /// 查询指定列的数据
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="colum">列名</param>
        /// <returns></returns>
        public static DataTable GetDTBySQL(string Tname, string colum)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname, colum);
            return ConnHelper.GetDataTable(strSQL);
        }

        /// <summary>
        /// 获取指定表中的指定字段中的所有数据
        /// 返回一个list，包含每一行的数据
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <param name="name">字段名【列名】</param>
        /// <returns>含有数据的list</returns>
        public static List<string> GetDistinctString(string strTable, string name)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(strTable, name);
            return ConnHelper.GetDistinceColoum(strSQL, name);
        }

        /// <summary>
        /// ！猜测代码
        /// 获取指定表中的指定字段中的所有数据
        /// 查询的字段拥有一个约束条件【字段约束】
        /// 返回一个list，包含每一行的数据
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <param name="name1">字段</param>
        /// <param name="name2">约束字段名</param>
        /// <param name="data">约束字段的值</param>
        /// <returns></returns>
        public static List<string> GetDistinctString(string strTable, string name1, string name2, string data)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(strTable, name1, name2, data);
            return ConnHelper.GetDistinceColoum(strSQL, name1);
        }

        public static bool DeleteTabTeachers(string strTName)
        {
            //string strSQL = SQLFactory.BuildSQLSelectString(strTName);
            //TODO
            return true;
        }

        public static bool DeleteTab(string TName)
        {
            string strSQL = SQLFactory.BuildSQLDeleteString(TName);
            return ConnHelper.ExecuteNoneQueryOperation(strSQL);
        }

        /// <summary>
        /// 获取教师部分信息，用于初始化的显示
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTeachersInfo()
        {
            return ConnHelper.GetDataTable("select department,user_id,user_name,role from TabTeachers");
        }

        public static bool AddNewUser(string userID, string sql)
        {
            string queryUserSQL = "SELECT * FROM TabTeachers WHERE User_ID = '" + userID + "'";
            DataSet ds = ConnHelper.GetDataSet(queryUserSQL);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else if (dt.Rows.Count == 0)
            {
                if (ConnHelper.ExecSQL(sql))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量更新数据表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Tname"></param>
        /// <returns></returns>
        public static bool UpdateDT4Copy(DataTable dt, string Tname)
        {
            try
            {
                ConnHelper.SQLBulkCopy(dt, Tname);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 查询指定表中的所有符合条件的数据
        /// 接受五个约束参数
        /// </summary>
        /// <param name="Tname">表名</param>
        /// <param name="v1">约束条件1</param>
        /// <param name="v2">约束条件2</param>
        /// <param name="v3">约束条件3</param>
        /// <param name="v4">约束条件4</param>
        /// <param name="v5">约束条件5</param>
        /// <param name="con1">约束条件值1</param>
        /// <param name="con2">约束条件值2</param>
        /// <param name="con3">约束条件值3</param>
        /// <param name="con4">约束条件值4</param>
        /// <param name="con5">约束条件值5</param>
        /// <returns></returns>
        public static DataTable GetDTBySQL(string Tname, string v1, string v2, string v3, string v4, string v5, string con1, string con2, string con3, string con4, string con5)
        {
            string strSQL = "select * from " + Tname + " where " + v1 + "='" + con1 + "' and " + v2 + "='" + con2 + "' and " + v3 + "='" + con3 + "' and " + v4 + "='" + con4 + "' and " + v5 + "='" + con5 + "'";
            return ConnHelper.GetDataTable(strSQL);
        }

        public static DataTable GetDT4Course(string v1, string v2, string con1, string con2)
        {
            string strSQL = "select DISTINCT week,time,course,area from TabCourses where is_attendance='未考勤' and " + v1 + "='" + con1 + "' and " + v2 + "='" + con2 + "'";
            return ConnHelper.GetDataTable(strSQL);
        }

        /// <summary>
        /// 更新数据表
        /// 更新一个字段，有一个条件
        /// </summary>
        /// <param name="v1">表名</param>
        /// <param name="v2">更新的字段</param>
        /// <param name="v3">更新后的值</param>
        /// <param name="v4">约束名1</param>
        /// <param name="v5">约束名2</param>
        /// <param name="v6">约束名3</param>
        /// <param name="v7">约束名4</param>
        /// <param name="v8">约束名5</param>
        /// <param name="c4">约束值1</param>
        /// <param name="c5">约束值2</param>
        /// <param name="c6">约束值3</param>
        /// <param name="c7">约束值4</param>
        /// <param name="c8">约束值5</param>
        public static bool UpdateRows(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string c4, string c5, string c6, string c7, string c8)
        {
            string strSQL = "update " + v1 + " set " + v2 + "='" + v3 + "' where " + v4 + "='" + c4 + "' and " + v5 + "='" + c5 + "' and " + v6 + "='" + c6 + "' and " + v7 + "='" + c7 + "' and " + v8 + "='" + c8 + "'";
            return ConnHelper.ExecuteNoneQueryOperation(strSQL);
        }

        /// <summary>
        /// 获取未读消息
        /// </summary>
        /// <param name="v1">权限</param>
        /// <param name="v2">构造字段</param>
        /// <returns></returns>
        public static DataTable GetDT4Message(string v1, string v2)
        {
            string strSQL = (v2 == "")? "select * from TabMessage where role='" + v1 + "'" : "select * from TabMessage where role='" + v1 + "' and id not in " + v2;
            return ConnHelper.GetDataTable(strSQL);
        }
    }
}
