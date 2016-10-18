using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            loadData2TreeView();
            Label1.Text = Session["Username"].ToString() + "<br> " + Application["Online"].ToString() + "人";
        }
    }

    private void loadData2TreeView()
    {
        //测试无法转换为DataSet
        //DataSet ds = (DataSet)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        //dt = ds.Tables[0];
        DataView ds = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        DataTable dt = new DataTable();
        dt = ds.Table;
        TreeNode root = new TreeNode(dt.Rows[0][1].ToString());//定义一个根节点
        root.NavigateUrl = dt.Rows[0][2].ToString();
        TreeNode softdipartment = null;
        for (int i = 1; i < dt.Rows.Count; i++)
        {
            int no = (int)dt.Rows[i][0];
            if (no == 3 && softdipartment != null)
            {
                TreeNode netdirection = new TreeNode(dt.Rows[i][1].ToString());
                netdirection.NavigateUrl = dt.Rows[i][2].ToString();
                softdipartment.ChildNodes.Add(netdirection);//将子节点添加到父节(softdipartment)点中
            }
            else
            {
                softdipartment = new TreeNode(dt.Rows[i][1].ToString());
                softdipartment.NavigateUrl = dt.Rows[i][2].ToString();
                root.ChildNodes.Add(softdipartment);//将子节点添加到父节点中
            }
        }
        this.TreeView1.Nodes.Add(root);//将根节点添加到treeview中（就将根节点及子节点都装到了treeview中）
    }
}
