using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Admin_SendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (teacher.Checked || fdy.Checked || ld.Checked || admin.Checked)
        {
            if (teacher.Checked)
            {
                if (AddSQLStringToDAL.InsertMsgRow(TextBox1.Text, "4"))
                {
                    Label1.Text = "发布成功！";
                }
            }
            if (fdy.Checked)
            {
                if (AddSQLStringToDAL.InsertMsgRow(TextBox1.Text, "3"))
                {
                    Label1.Text = "发布成功！";
                }
            }
            if (ld.Checked)
            {
                if (AddSQLStringToDAL.InsertMsgRow(TextBox1.Text, "2"))
                {
                    Label1.Text = "发布成功！";
                }
            }
            if (admin.Checked)
            {
                if (AddSQLStringToDAL.InsertMsgRow(TextBox1.Text, "1"))
                {
                    Label1.Text = "发布成功！";
                }
            }
        }
        else
        {
            Label1.Text = "请至少选择一项";
        }
    }
}