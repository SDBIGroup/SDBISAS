using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DataChart : System.Web.UI.Page
{
    string[] departments = { "信息工程系", "食品工程系", "商务外语系"
                        , "经济管理系", "建筑工程系", "机械工程系", "会计系" };

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt1 = CreateDataTable("旷课", "");
        Chart1.DataSource = dt1;

        Chart1.Series[0].YValueMembers = "number";
        Chart1.Series[0].XValueMember = "department";

        Chart1.DataBind();

        DataTable dt2 = CreateDataTable("迟到", "");
        Chart2.DataSource = dt2;

        Chart2.Series[0].YValueMembers = "number";
        Chart2.Series[0].XValueMember = "department";

        Chart2.DataBind();

    }

    private DataTable CreateDataTable(string type, string dep)
    {
        if (type == "旷课")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("number");
            dt.Columns.Add("department");
            for (int i = 0; i < departments.Length; i++)
            {
                DataTable dt1 = GetDtByDep(departments[i], "旷课");
                DataRow dr = dt.NewRow();
                dr["number"] = dt1.Rows.Count;
                dr["department"] = departments[i];
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
            return dt;
        }
        else if (type == "迟到")
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("number");
            dt2.Columns.Add("department");
            for (int i = 0; i < departments.Length; i++)
            {
                DataTable dt3 = GetDtByDep(departments[i], "迟到");

                DataRow dr = dt2.NewRow();
                dr["number"] = dt3.Rows.Count;
                dr["department"] = departments[i];
                dt2.Rows.Add(dr);
                dr = dt2.NewRow();
            }
            return dt2;
        }
        else
        {
            return null;
        }
    }

    private DataTable GetDtByDep(string dep, string type)
    {
        if (dep == "")
        {
            string strSQL = "SELECT * FROM     TabStudentAttendance";
            return AddSQLStringToDAL.getDt(strSQL);
        }
        else
        {
            string strSQL = "SELECT * FROM TabStudentAttendance WHERE StudentDepartment = '" + dep + "' and AttendanceType = '" + type + "'";
            return AddSQLStringToDAL.getDt(strSQL);
        }
    }
}