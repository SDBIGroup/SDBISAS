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
        DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabCourses", "Teacher_id", "Current_Week", Session["userID"].ToString(), Session["currentWeek"].ToString());
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
        int weekNum = Convert.ToInt32(Session["currentWeek"].ToString()), lastWeek = 0;
        if (weekNum > 1)
        {
            lastWeek = weekNum - 1;
        }
        if (lastWeek != 0)
        {
            //TODO
            DataTable dtHome = AddSQLStringToDAL.GetDTBySQL("TabCourses", "Teacher_ID", "Current_Week", "Count", Session["userID"].ToString(), lastWeek.ToString(), "已布置作业");
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
        CheckBox chk = e.Item.FindControl("CheckBox1") as CheckBox;
        Session["homeWork"] = chk.Checked ? "已布置作业" : "未布置作业";

        Label tb1 = e.Item.FindControl("TBcour") as Label;
        Session["currentCourse"] = tb1.Text.Trim();

        Label tb2 = e.Item.FindControl("TBweek") as Label;
        Session["week"] = tb1.Text.Trim();

        Label tb3 = e.Item.FindControl("TBtime") as Label;
        Session["time"] = tb1.Text.Trim();

        Label tb4 = e.Item.FindControl("TBarea") as Label;
        Session["weekRange"] = tb1.Text.Trim();

        //页面跳转
        Response.Redirect("AttendanceDetails.aspx");
    }
}