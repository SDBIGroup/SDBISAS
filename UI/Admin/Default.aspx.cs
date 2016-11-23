using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.AllowPaging = true;
        GridView1.PageSize = 10;
        GridView1.DataSource = AddSQLStringToDAL.GetTeachersInfo();
        GridView1.DataBind();
    }
}