using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Visible = false;
        Label5.Visible = false;
        Label6.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (ymm.Text.Length != 0)
        {
            if (xmm.Text.Length != 0)
            {
                if (qrmm.Text.Length != 0)
                {
                    if (xmm.Text == qrmm.Text)
                    {
                        string User_PWD = qrmm.Text.ToString();
                        switch (changePWD(ymm.Text.ToString().Trim(), User_PWD))
                        {
                            case 0:
                                Label7.Visible = true;
                                Label7.Text = "修改失败";
                                break;
                            case 1:
                                Label7.Visible = true;
                                Label7.Text = "修改成功";
                                break;
                            case 2:
                                Label7.Visible = true;
                                Label7.Text = "不正确";
                                break;
                        }
                    }
                    else
                    {
                        Label6.Visible = true;
                        Label6.Text = "新密码与确认密码不一致";
                    }
                }
                else
                {
                    Label6.Visible = true;
                    Label6.Text = "确认密码不能为空";
                }
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "新密码不能为空";
            }
        }
        else
        {
            Label4.Visible = true;
            Label4.Text = "原密码不能为空";
        }
    }

    private int changePWD(string ymm, string newPWD)
    {
        string ymm1 = BLL.Tools.PWDProcess.Encrypt(ymm);
        string sql = "SELECT user_pwd from TabTeachers where user_id='" + Session["UserID"] + "'";

        DataTable dt = AddSQLStringToDAL.getDt(sql);

        if (dt.Rows.Count == 1)
        {
            if (ymm1 == dt.Rows[0]["user_pwd"].ToString())
            {
                string sql1 = "UPDATE tabteachers SET user_pwd='" + ymm1 + "' WHERE user_id = '" + Session["UserID"] + "'  ";
                bool flag = AddSQLStringToDAL.changePWD(sql1);
                if (flag)
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }
        return 0;
    }
}