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
        q();
    }

    private void q()
    {
        string sql = "select * from Test";
        DataTable dt = BLL.AddSQLStringToDAL.GetDTBySQL(sql);
        Label2.Text = dt.Columns.Count.ToString();
        GridView1.DataSource = dt;
        Response.Write(dt.Columns.Count + "");
    }
}