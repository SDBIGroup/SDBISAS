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
        public static DataTable GetDTBySQL(string Tname, string dl, string content)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname, dl, content);
            return ConnHelper.GetDataTable(strSQL);
        }

        public static DataTable GetDTBySQL(string Tname, string dl, string d2, string content1, string content2)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(Tname, dl, d2, content1, content2);
            return ConnHelper.GetDataTable(strSQL);
        }

        public static DataTable GetDTBySQL(string colum, string Tname)
        {
            string strSQL = SQLFactory.BuildSQLSelectString(colum, Tname);
            return ConnHelper.GetDataTable(strSQL);
        }
    }
}
