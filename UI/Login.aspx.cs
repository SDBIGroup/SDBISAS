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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length != 0 && TextBox2.Text.Length != 0)
        {
            DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabTeachers", "UserID", "UserPWD", TextBox1.Text, TextBox2.Text);
            if (dt.Rows.Count == 1)
            {
                string role = dt.Rows[0]["Role"].ToString();
                //保存用户数据
                Session["uid"] = TextBox1.Text.Trim();  //去一下空格
                Session["su"] = role;
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
                Label1.Text = "用户名或密码错误！";
            }
        }
        else
        {
            Label1.Text = "请完整填写用户名或密码";
        }
    }
}