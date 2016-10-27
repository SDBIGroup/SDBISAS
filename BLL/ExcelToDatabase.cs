using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Excel导入到数据库的中转层
    /// 负责检测文件的合法性以及调用DAL层导入到数据库
    /// </summary>
    public class ExcelToDatabase
    {
        /// <summary>
        /// 检测文件名是否符合Excel后缀规范，以及文件的大小
        /// 通过后上传到数据库的指定表
        /// </summary>
        /// <param name="fileName">文件完整路径包括后缀</param>
        /// <param name="identity">要导入到的表名</param>
        /// <returns>错误信息或者成功信息</returns>
        public static string CheckFile(string fileName, string identity)
        {
            try
            {
                if (fileName != string.Empty)
                {
                    //TODO 检测文件大小感觉有问题
                    if (fileName.Length == 0)
                    {
                        return "导入的Excel文件大小为0，请检查！";
                    }

                    //获取选择文件的扩展名
                    string fileExtenSion = fileName.Substring(fileName.LastIndexOf(".") + 1);
                    //检测文件扩展名(格式)
                    if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
                    {
                        return "上传的文件格式不正确";
                    }

                    return ToSQLServer(fileName, identity);
                }
                else
                {
                    return "选择的文件为空，请重新选择！";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO
        public static string ToSQLServer(string fileName, string identity)
        {
            if (identity == "TabTeachers" || identity == "TabOtherTeachers")
            {
                //return DAL.ExcelToSQLServer.ReadTeachersExcel(fileName, identity);
            }
            else
            {

            }

            return "";
        }
    }
}
