using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class ExcelToSQLServer
    {
        public static DataSet ds;

        /// <summary>
        /// 检查教师Excel中的列是否符合规范
        /// </summary>
        /// <returns>规范返回true，不规范返回false</returns>
        private static bool CheckExcelTableTeachers()
        {
            try
            {
                string[] str = { "部门", "工号", "密码", "姓名", "性别", "权限" };
                for (int i = 0; i <= 5; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 检查校历Excel中的列是否符合规范
        /// </summary>
        /// <returns>规范返回true，不规范返回false</returns>
        private static bool CheckExcelTableCalendar()
        {
            try
            {
                string[] str = { "周次", "起", "止" };
                for (int i = 0; i <= 2; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 检查课程Excel中的列是否符合规范
        /// </summary>
        /// <returns>规范返回true，不规范返回false</returns>
        private static bool CheckExcelTableCourses()
        {
            try
            {
                string[] str = { "承担单位", "任课教师", "上课时间/地点", "课程", "所属部门" };
                for (int i = 0; i <= 4; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取读取Excel引擎的连接
        /// </summary>
        /// <param name="fileName">Excel表的存放位置</param>
        /// <returns>拼接好的连接</returns>
        private static OleDbConnection getOleConn(string fileName)
        {
            System.GC.Collect();
            OleDbConnection oleConn;

            //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES  
            string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR=YES\"";

            string fileExtenSion = fileName.Substring(fileName.LastIndexOf(".") + 1);
            //建立连接，根据不同的扩展名，选择不同的引擎
            if (fileExtenSion.ToLower() == "xls")
            {
                oleConn = new OleDbConnection(connstr2003);
            }
            else
            {
                oleConn = new OleDbConnection(connstr2007);
            }
            return oleConn;
        }

        /// <summary>
        /// 读取Excel表的数据，并将数据插入到数据库的TabAllCourses表中
        /// </summary>
        /// <param name="fileName">Excel表的存放位置</param>
        /// <param name="strSQL">操作Excel表的sql语句</param>
        private static void ExcelToDatabaseByDataReader(string fileName, string strSQL)
        {
            OleDbConnection oleConn = getOleConn(fileName);
            oleConn.Open();

            OleDbCommand oleCmd = new OleDbCommand(strSQL, oleConn);
            OleDbDataReader oleDr = oleCmd.ExecuteReader();

            //进行数据库连接
            string sqlStr1 = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(sqlStr1);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;

            StringBuilder strconn = new StringBuilder();
            List<string> str = new List<string>();
            while (oleDr.Read())
            {
                str = SplitTeacherIDAndTeacherName(oleDr[1].ToString());
                strconn.Append("insert into TabAllCourses(TeacherDapartment,TeacherID,TeacherName,TimeAndArea,Course,t1,t2,t3,Class,StudentDepartment,StudentID,StudentName,t4,t5,t6,t7)values(");
                strconn.Append("'" + oleDr[0].ToString() + "','" + str[0] + "','" + str[1] + "'");
                for (int j = 2; j <= 14; j++)
                {
                    strconn.Append(",'" + oleDr[j].ToString() + "'");
                }
                strconn.Append(")");
                sqlCmd.CommandText = strconn.ToString();
                sqlCmd.ExecuteNonQuery();
                strconn.Remove(0, strconn.Length);
            }


            sqlConn.Close();
            oleDr.Close();
            oleConn.Close();
        }

        /// <summary>
        /// 获取Excel工作簿中表的名称
        /// 顺序不确定
        /// </summary>
        /// <param name="fileName">Excel的完整路径</param>
        /// <returns>含有表名的list</returns>
        private static List<string> GetSheetName(string fileName)
        {
            OleDbConnection conn = getOleConn(fileName);
            conn.Open();

            List<string> SheetNameList = new List<string>();
            //获取表结构信息，获取EXCEL表中的SHEET名称
            DataTable dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SheetName = "";
            for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
            {
                SheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                SheetNameList.Add(SheetName);
            }
            conn.Close();
            conn.Dispose();
            return SheetNameList;
        }

        /// <summary>
        /// 获取Excel表的信息
        /// 将装到ds【全局变量】中，表名重设为ExcellInfo
        /// </summary>
        /// <param name="fileName">Excel的完整路径</param>
        /// <param name="strSQL">要执行的SQL语句</param>
        public static void ReadExcelToDataSet(string fileName, string strSQL)
        {
            OleDbConnection conn = getOleConn(fileName);
            conn.Open();

            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, conn);
            da.SelectCommand.CommandTimeout = 600;

            ds = new DataSet();
            //在ds中规定表名为ExcelInfo
            da.Fill(ds, "ExcelInfo");

            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// 读取课程信息的Excel表
        /// </summary>
        /// <param name="fileName">Excel表的完整路径</param>
        /// <param name="identity">表名【非工作簿名】</param>
        /// <returns>错误/成功信息</returns>
        public static string ReadCoursesExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);

            string strSQL = "";
            if (SheetName[0] != identity + "$")
            {
                return "指定的Excel文件的工作表名不为" + identity + ",当前的表名为" + SheetName[0];
            }
            strSQL = "select * from [" + SheetName[0] + "]";
            ReadExcelToDataSet(fileName, strSQL);
            if (CheckExcelTableCourses())
            {
                DataTable dt = SplitString.SplitDT(ds.Tables["ExcelInfo"]);
                CoursesTOSQLServer(dt, "TabCourses");
                return "文件导入成功";
            }
            else
                return "选择的Excel文件中的内容与数据库要求不匹配。请确认！";
        }

        /// <summary>
        /// 读取校历信息的Excel表
        /// </summary>
        /// <param name="fileName">Excel表的完整路径</param>
        /// <param name="identity">表名【非工作簿名】</param>
        /// <returns>错误/成功信息</returns>
        public static string ReadCalendarExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";

            if (SheetName[0] != "Sheet1$")
            {
                return "指定的Excel文件的工作表不为“Sheet1”,当前的表名为" + SheetName[0];
            }
            strSQL = "select * from [Sheet1$]";
            ReadExcelToDataSet(fileName, strSQL);

            if (CheckExcelTableCalendar())
            {
                CoursesTOSQLServer(ds.Tables["ExcelInfo"], identity);
                return "文件导入成功";
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }
        }

        /// <summary>
        /// 读取教师信息的Excel表
        /// </summary>
        /// <param name="fileName">Excel表的完整路径</param>
        /// <param name="identity">表名【非工作簿名】</param>
        /// <returns>错误/成功信息</returns>
        public static string ReadTeachersExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";

            if (SheetName[0] != "Sheet1$")
            {
                return "指定的Excel文件的工作表名不为“Sheet1”,当前的表明为" + SheetName[0];
            }
            strSQL = "select * from [Sheet1$]";
            ReadExcelToDataSet(fileName, strSQL);

            if (CheckExcelTableTeachers())
            {
                DataTable dt = SplitString.SplitTeacher4DT(ds.Tables["ExcelInfo"]);
                CoursesTOSQLServer(dt, identity);
                return "文件导入成功";
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }
        }

        /// <summary>
        /// 将课程信息导入到数据库
        /// 数据来源为全局变量DS集合
        /// </summary>
        /// <param name="identity">表名【非工作簿名】</param>
        public static void CoursesTOSQLServer(DataTable dt, string identity)
        {
            ConnHelper.SQLBulkCopy(dt, identity);
        }

        /// <summary>
        /// 拆分教师ID和姓名为两个字符串
        /// 按照字符'['，']'拆分，去除空项
        /// 将string数组转换成list集合
        /// </summary>
        /// <param name="str">需要拆分的字符串</param>
        /// <returns>拆分后的list</returns>
        private static List<string> SplitTeacherIDAndTeacherName(string str)
        {
            List<string> strSplit = new List<string>();
            string[] newStr = str.Split(new char[]
                { '[',']'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < newStr.Length; i++)
            {
                strSplit.Add(newStr[i]);
            }
            return strSplit;
        }

    }
}
