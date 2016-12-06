using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int departmentPos = DropDownList1.SelectedIndex;
        int rolePos = DropDownList2.SelectedIndex;
        string[] departments = { "信息与艺术设计系", "经管系", "商务外语系" };

        string[] roles = { "1", "2", "3" };

        string userID = TextBox1.Text.ToString();
        string username = TextBox2.Text.ToString();
        string sex = TextBox3.Text.ToString();

        if (userID != "" && username != "" && sex != "")
        {
            string sql = "INSERT INTO TabTeachers (department,user_id,user_pwd,user_name,sex,role) VALUES ('" + departments[departmentPos] + "','" + userID + "','" + userID + "','" + username + "','" + sex + "','" + roles[rolePos] + "')";
            if (AddSQLStringToDAL.AddNewUser(userID, sql))
            {
                Response.Write(sql);
                Response.Write(userID + " 用户添加成功，默认密码为工号");
            }
            else
            {
                Response.Write("添加用户失败");
            }
        }

        else
        {
            Response.Write("请输入完整数据！");
        }
    }
}