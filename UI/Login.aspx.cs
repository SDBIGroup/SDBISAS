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
            DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabTeachers", "User_ID", "User_PWD", value_1.Text, value_2.Text);
            if (dt.Rows.Count == 1)
            {
                string role = dt.Rows[0]["role"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                //保存用户数据
                Session["UserID"] = value_1.Text.Trim();  //去一下空格
                Session["Username"] = username;
                Session["Role"] = role;
                switch (role)
                {
                    case "1":
                        //页面跳转
                        Response.Redirect("./Admin/Default.aspx");
                        break;
                    case "2":
                        //页面跳转
                        Response.Redirect("./Leader/Default.aspx");
                        break;
                    case "3":
                        //页面跳转
                        Response.Redirect("./Secretary/Default.aspx");
                        break;
                    case "4":
                        //页面跳转
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
}