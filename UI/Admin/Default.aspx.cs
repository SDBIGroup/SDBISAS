using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabAllCourses", "TeacherID", "CurrentWeek", "2012015001", "1");
        if (dt.Rows.Count == 0)
        {
            lbTitile.Text = "您本周无授课安排";
        }
        else
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        //作业处理
        int weekNum = Convert.ToInt32(Session["week"].ToString()), lastWeek = 0;
        if (weekNum > 1)
        {
            lastWeek = weekNum - 1;
        }
        if (lastWeek != 0)
        {
            //TODO
            DataTable dtHome = AddSQLStringToDAL.GetDTBySQL("TabAllCourses", "TeacherID", "CurrentWeek", "Count", "2012015001", lastWeek.ToString(), "已布置作业");
            if (dtHome.Rows.Count == 0)
            {
                lbWork.Text = "上周作业没有未批改情况！";
            }
            else
            {
                Repeater2.DataSource = dtHome;
                Repeater2.DataBind();
            }
        }
    }

    //用来响应Item模板中的控件的事件
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}