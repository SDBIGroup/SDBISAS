using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_School_Teachers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        q();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        queryByDep();
    }

    private void q()
    {
        string department = DropDownList1.SelectedValue;
        string sql = "SELECT department,user_id,user_name,sex,role FROM TabTeachers WHERE department ='" + department + "' ";
        DataTable dt = BLL.AddSQLStringToDAL.getDt(sql);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void queryByDep()
    {
        string department = DropDownList1.SelectedValue;
        string sql = "SELECT * FROM TabTeachers WHERE department ='" + department + "' ";
        DataTable dt = BLL.AddSQLStringToDAL.getDt(sql);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
}