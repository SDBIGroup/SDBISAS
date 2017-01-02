using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Secretary_GetMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
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

    //已读按钮的点击
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label msgID = e.Item.FindControl("msgID") as Label;
        string readMsgTemp = Session["readMsg"].ToString() == "" ? msgID.Text : Session["readMsg"].ToString() + " " + msgID.Text;
        AddSQLStringToDAL.UpdateRows("TabTeachers", "read_msg", readMsgTemp, "user_id", Session["userID"].ToString());
        Session["readMsg"] = readMsgTemp;
        bindData();
    }
}