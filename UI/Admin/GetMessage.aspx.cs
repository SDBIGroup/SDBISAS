using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Admin_GetMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
        string reads = "";
        if (Session["readMsg"].ToString() != "")
        {
            string[] ids = Session["readMsg"].ToString().Split(' ');
            reads = "(";
            for (int i = 0; i < ids.Length; i++)
            {
                reads += (i == ids.Length - 1)?ids[i] + ")":ids[i] + ",";
            }
        }
        Repeater1.DataSource = AddSQLStringToDAL.GetDT4Message(Session["currentRole"].ToString(), reads);
        Repeater1.DataBind();
    }
}