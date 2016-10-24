using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Admin_LoadExcelToDataBase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //strTest.Length == 0 这种方式的执行效率最高
            if (Session["uid"].ToString().Length == 0)
            {
                //如果没有登陆，重定向到登陆页面
                Response.Redirect("~//Default.aspx");
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
            lbMessage1.Text = ExcelToDatabase.CheckFile("", identity);
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
        string department = "";
        department = ddlDepartmentName.SelectedItem.ToString();
        //todo...
        lbMessage2.Text = ExcelToDatabase.CheckFile(filecourse.ToString(), department);
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
        }
    }
}