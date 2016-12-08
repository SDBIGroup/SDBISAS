using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (value_1.Text.Length != 0 && value_2.Text.Length != 0)
        {
            DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabTeachers", "User_ID", "User_PWD", value_1.Text, BLL.Tools.PWDProcess.Encrypt(value_2.Text));
            if (dt.Rows.Count == 1)
            {
                string role = dt.Rows[0]["role"].ToString();
                Session["userID"] = value_1.Text.Trim();
                //保存用户数据
                Session["userName"] = dt.Rows[0]["User_Name"].ToString(); //去一下空格
                Session["readMsg"] = dt.Rows[0]["read_msg"].ToString();
                CurrentWeek();

                switch (role)
                {
                    case "1":
                        //页面跳转
                        Session["role"] = "系统管理员";
                        Session["currentRole"] = "1";
                        Response.Redirect("./Admin/Default.aspx");
                        //Response.Redirect("./Admin/GetMessage.aspx");
                        break;
                    case "2":
                        //页面跳转
                        Session["role"] = "院系领导";
                        Session["currentRole"] = "2";
                        Response.Redirect("./Leader/Default.aspx");
                        break;
                    case "3":
                        //页面跳转
                        Session["role"] = "辅导员";
                        Session["currentRole"] = "3";
                        Response.Redirect("./Secretary/Default.aspx");
                        break;
                    case "4":
                        //页面跳转
                        Session["role"] = "教师";
                        Session["currentRole"] = "4";
                        Response.Redirect("./Teacher/Default.aspx");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "用户名或密码错误！";
            }
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "请完整填写用户名或密码";
        }
    }

    /// <summary>
    /// 处理校历，确定处于第几周
    /// </summary>
    private void CurrentWeek()
    {
        DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabCalendar");
        foreach (DataRow dr in dt.Rows)
        {
            if (Convert.ToDateTime(dr[1]) < DateTime.Now && Convert.ToDateTime(dr[2]) > DateTime.Now)
            {
                string strWeek = dr[0].ToString();
                if (strWeek.Length == 1)
                    strWeek = "0" + strWeek;
                Session["currentWeek"] = strWeek;
            }
        }
    }
}