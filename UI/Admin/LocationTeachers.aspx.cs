using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Admin_LocationTeachers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        GridView1.AllowPaging = true;
        GridView1.PageSize = 10;
        GridView1.DataSource = AddSQLStringToDAL.GetTeachersInfo();
        GridView1.DataKeyNames = new string[] { "User_ID" };
        GridView1.DataBind();
    }

    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (AddSQLStringToDAL.DeleteRows("TabTeachers", "User_ID", GridView1.DataKeys[e.RowIndex].Value.ToString()))
            BindData();
    }

    //编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label lstus = (Label)GridView1.Rows[e.NewEditIndex].FindControl("Label1");
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
        DropDownList ddList = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("dStatus");
        //根据指定文字找到对应选项  
        ListItem item = ddList.Items.FindByText(lstus.Text);
        //如果该选项不为null，则让该选项处于选中状态  
        //如果不进行这个判断，而选项集合中没有对应的选项，则会抛出异常   
        if (item != null)
        {
            item.Selected = true;
        }
    }

    //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (AddSQLStringToDAL.UpdateRows("TabTeachers", "Role", ((DropDownList)GridView1.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedItem.Value.ToString().Trim(), "User_ID", GridView1.DataKeys[e.RowIndex].Value.ToString()))
        {
            GridView1.EditIndex = -1;
            BindData();
        }
    }

    //取消
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }

    //切换页数
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }

}