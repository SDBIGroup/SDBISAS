using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;

public partial class Admin_LoadExcelToDataBase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //strTest.Length == 0 这种方式的执行效率最高
            if (Session["UserID"].ToString().Length == 0 )
            {
                //如果没有登陆，重定向到登陆页面
                //Response.Redirect("~//Login.aspx");
            }
            else
            {
                btnClearPreData.Attributes.Add("onclick", "return confirm('本操作将清空所以数据表，你确定要执行么？');");
                btnPreOperation.Attributes.Add("onclick", "return confirm('本操作将覆盖原有数据，你确定要执行么？');");
                btnTeacherAttendance.Attributes.Add("onclick", "return confirm('本操作将覆盖原有数据，你确定要执行么？');");
            }
        }
    }

    /// <summary>
    /// 导入教师基本信息
    /// 将Excel的数据导入到数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImportTeachers_Click(object sender, EventArgs e)
    {
        Clear();
        string identity = "";
        if (rdoOthers.Checked || rdoTeachers.Checked)
        {
            identity = rdoTeachers.Checked ? "TabTeachers" : "TabOtherTeachers";
            //todo...
            lbMessage1.Text = "正在对数据进行初始化处理...";
            string filePath = Upload(FileUpload1);
            if (filePath != null && filePath.Length != 0)
            {
                lbMessage1.Text = ExcelToDatabase.CheckFile(filePath, identity);
            }
            else
            {
                lbMessage1.Text = "您选择的文件不符合规范";
            }
        }
        else
        {
            lbMessage1.Text = "请先选择导入数据的类型！";
        }
    }

    /// <summary>
    /// 导入教师授课信息
    /// 从Excel导入到数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImportCourse_Click(object sender, EventArgs e)
    {
        Clear();
        string department = "";  //系部
        department = ddlDepartmentName.SelectedValue;
        //todo...
        string filePath = Upload(filecourse);
        if (filePath != null && filePath.Length != 0)
        {
            lbMessage2.Text = ExcelToDatabase.CheckFile(filePath, department);
        }
        else
        {
            lbMessage2.Text = "您选择的文件不符合规范";
        }
    }

    /// <summary>
    /// 导入校历信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnImportCalendar_Click(object sender, EventArgs e)
    {
        AddSQLStringToDAL.DeleteTab("TabCalendar");
        lbMessage3.Text = "正在对数据进行初始化处理...";
        string filePath = Upload(FileUpload2);
        if (filePath != null && filePath.Length != 0)
        {
            lbMessage3.Text = ExcelToDatabase.CheckFile(filePath, "TabCalendar");
        }
        else
        {
            lbMessage3.Text = "您选择的文件不符合规范";
        }
    }

    /// <summary>
    /// 清除所有label标签的提示信息
    /// </summary>
    private void Clear()
    {
        lbMessage1.Text = "";
        lbMessage2.Text = "";
        lbMessage3.Text = "";
        lbMessage4.Text = "";
        lbMessage5.Text = "";
        lbMessage6.Text = "";
        lbMessage7.Text = "";
    }

    //下拉框被更改
    protected void ddlDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
    }

    //单选框被改变
    protected void rdo_CheckedChanged(object sender, EventArgs e)
    {
        Clear();
    }

    private void InsertTeacherStatus()
    {
        Clear();
        List<string> strList = new List<string>();
        //查询课程信息
        strList = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TeacherID");
        for (int i = 0; i < strList.Count; i++)
        {
            //TODO
            if (true)
            {
                lbMessage3.Text = "正在进行第一步预处理";
            }
        }
        lbMessage3.Text = "第一步：教师信息对比完成，正在进行第二步...";
        InsertTeacherCourseSimpleMap(strList);
        lbMessage3.Text = "所有信息核对无误！等待对数据进行处理！";
    }

    //TODO
    private void InsertTeacherCourseSimpleMap(List<string> strList)
    {
        for (int i = 0; i < strList.Count; i++)
        {
            List<string> strDD = new List<string>();
            //根据教师的ID查询出授课时间表，装到一个list中
            strDD = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TimeAndArea", "TeacherID", strList[i].ToString());
            for (int k = 0; k < strDD.Count; k++)
            {
                List<string> strResult = new List<string>();
                //strResult = SplitString.GetSplitCountAndDetails(strDD[k]);
                //DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabAllCourses", "TeacherID", strList[i].ToString(), "TimeAndArea", strDD[k].ToString());

            }
        }
    }

    protected void btnClearPreData_Click(object sender, EventArgs e)
    {
        Clear();
        if (AddSQLStringToDAL.DeleteTabTeachers("TabTeacherstatus") && AddSQLStringToDAL.DeleteTabTeachers("TabTeacherCourseSimpleMap") && AddSQLStringToDAL.DeleteTabTeachers("TabTeacherAttendance") && AddSQLStringToDAL.DeleteTabTeachers("TabStudentAttendance") && AddSQLStringToDAL.DeleteTabTeachers("TabTeacherHome"))
        {
            lbMessage4.Text = "异常数据清空完毕！请对数据进行分析和处理";
        }
    }


    /// <summary>
    /// 上传Excel到服务器，返回服务器中的路径
    /// </summary>
    /// <param name="fuload"></param>
    /// <returns></returns>
    private string Upload(FileUpload fuload)
    {
        //获取选择文件的扩展名
        string fileExtenSion = Path.GetExtension(fuload.FileName);
        //检测文件扩展名(格式)
        if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
        {
            return null;
        }
        try
        {
            string FileName = "App_Data\\" + Path.GetFileName(fuload.FileName);
            //判断文件是否存在，如果存在先删除
            if (File.Exists(Server.MapPath(FileName)))
            {
                File.Delete(Server.MapPath(FileName));
            }
            //上传文件到指定目录
            fuload.SaveAs(Server.MapPath(FileName));
            return Server.MapPath("./") + FileName;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}