using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Drawing;
using System.Text;

public partial class Leader_AttendanceDetails : System.Web.UI.Page
{
    private Color c;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["currentCourse"].ToString() != "")
            {
                //InitialOperation();
                btnClose.Visible = true;
            }
            else
            {
                //未获取到当前课程信息
            }

            //课程是否已结束
            if (CompareWeek())
            {
                //是否已经考勤过
                if (CheckIsRecords())
                {
                    SetControlsVisibleFalse();  //隐藏所有
                    Label1.Text = "您已经录入本次考勤记录！";
                    btnClose.Visible = true;

                }
                else
                {
                    string strCourse = Session["currentCourse"].ToString();
                    Label2.Text = Session["week"].ToString() + Session["time"].ToString()
                        + "|" + strCourse.Substring(8) + "|" + this.GridView1.Rows.Count.ToString() + "人";
                    c = this.GridView1.BackColor;
                }
            }
            else
            {
                SetControlsVisibleFalse();
                Label1.Text = "本门课程尚未结束，请于课程结束后录入！";
                btnClose.Visible = true;
            }
        }
    }

    private void SetControlsVisibleFalse()
    {
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;
        Label6.Visible = false;
        GridView1.Visible = false;
    }

    /// <summary>
    /// 检测是否已经考勤
    /// </summary>
    /// <returns></returns>
    private bool CheckIsRecords()
    {
        DataTable dt = AddSQLStringToDAL.GetDTBySQL("TabCourses", "Teacher_id", "Current_Week", "Course",
            "Week", "Time", Session["userID"].ToString(), Session["currentWeek"].ToString(), Session["currentCourse"].ToString(),
            Session["week"].ToString(), Session["time"].ToString());

        if (dt.Rows[0]["is_attendance"].ToString().Trim() == "未考勤")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// 比较是否处于考勤时间范围
    /// </summary>
    /// <returns></returns>
    private bool CompareWeek()
    {
        int Week = 0; //获取数据的周次
        int CurrentWeek = 0; //当前周次
        switch (DateTime.Now.DayOfWeek.ToString())
        {
            case "Monday":
                CurrentWeek = 1;
                break;
            case "Tuesday":
                CurrentWeek = 2;
                break;
            case "Wednesday":
                CurrentWeek = 3;
                break;
            case "Thursday":
                CurrentWeek = 4;
                break;
            case "Friday":
                CurrentWeek = 5;
                break;
            case "Saturday":
                CurrentWeek = 6;
                break;
            case "Sunday":
                CurrentWeek = 7;
                break;
            default:
                CurrentWeek = 0;
                break;

        }
        switch (Session["week"].ToString())
        {
            case "星期一":
                Week = 1;
                break;
            case "星期二":
                Week = 2;
                break;
            case "星期三":
                Week = 3;
                break;
            case "星期四":
                Week = 4;
                break;
            case "星期五":
                Week = 5;
                break;
            case "星期六":
                Week = 6;
                break;
            case "星期日":
                Week = 7;
                break;
            default:
                Week = 0;
                break;
        }//当前 5  考勤 4，前周的
        if (CurrentWeek > Week)
        {
            return true;
        }
        //同一周，判断小时来确定是否已过上课时间
        else if (CurrentWeek == Week)
        {
            int tt = 0; //小时
            switch (Session["time"].ToString())
            {
                case "1-2节":
                    tt = 10;
                    break;
                case "2-4节":
                    tt = 12;
                    break;
                case "5-6节":
                    tt = 16;
                    break;
                case "7-8节":
                    tt = 18;
                    break;
                case "9-10节":
                    tt = 20;
                    break;
                default:
                    tt = 0;
                    break;
            }
            if (DateTime.Now.Hour >= tt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            //超前情况，一般不会遇到
            return false;
        }
    }

    /// <summary>
    /// 实现点击不同的状态更换不同的背景
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdo_CheckChange(object sender, EventArgs e)
    {
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            Control ctl1 = row.FindControl("RadioButton1");
            Control ctl2 = row.FindControl("RadioButton2");
            Control ctl3 = row.FindControl("RadioButton3");
            Control ctl4 = row.FindControl("RadioButton4");
            Control ctl5 = row.FindControl("RadioButton5");

            TableCellCollection cell = row.Cells;
            if ((ctl1 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor = c;
            }
            if ((ctl2 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.Yellow;
            }
            if ((ctl3 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.Red;
            }
            if ((ctl4 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.Yellow;
            }
            if ((ctl5 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.SkyBlue;
            }

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变
            e.Row.Attributes.Add("onmouseover", "currColor=this.style.backgroundColor;this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currColor");
        }
    }

    /// <summary>
    /// 提交按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAtten_Click(object sender, EventArgs e)
    {
        StringBuilder strLate = new StringBuilder("迟到名单：");
        StringBuilder strAbsence = new StringBuilder("旷课名单：");
        StringBuilder strEarly = new StringBuilder("早退名单：");
        StringBuilder strLeave = new StringBuilder("请假名单：");
        //获取表结构
        DataTable attendanceList = AddSQLStringToDAL.GetDTBySQL("TabStudentAttendance", "0", "1");
        //创建符合表结构的一行
        DataRow attendanceRow = attendanceList.NewRow();
        int sum = 0; //总人数

        foreach (GridViewRow row in this.GridView1.Rows)
        {
            //单选框属性对象
            Control ctl2 = row.FindControl("RadioButton2");
            Control ctl3 = row.FindControl("RadioButton3");
            Control ctl4 = row.FindControl("RadioButton4");
            Control ctl5 = row.FindControl("RadioButton5");
            TableCellCollection cell = row.Cells;//获取GridView本行中的值的集合
            if ((ctl2 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["userID"];
                attendanceRow[1] = Session["userName"];
                attendanceRow[2] = Session["course"];  //课程名
                attendanceRow[3] = Session["currentWeek"];  // 周 数字
                attendanceRow[4] = Session["week"];  // 周，格式化显示
                attendanceRow[5] = Session["time"];  // 第几节
                attendanceRow[6] = cell[0].Text.ToString(); //系部
                attendanceRow[7] = cell[1].Text.ToString(); //t4 班级名称
                attendanceRow[8] = cell[2].Text.ToString(); //Id
                attendanceRow[9] = cell[3].Text.ToString(); //Name
                attendanceRow[10] = "迟到";
                attendanceRow[11] = cell[1].Text.ToString();    //t4 班级名称  并不知道啥用
                attendanceList.Rows.Add(attendanceRow);
                sum++;
                strLate.Append(cell[3].Text.ToString() + ";");
                attendanceRow = attendanceList.NewRow();
            }
            else
            if ((ctl3 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["userID"];
                attendanceRow[1] = Session["userName"];
                attendanceRow[2] = Session["course"];  //课程名
                attendanceRow[3] = Session["currentWeek"];  // 周 数字
                attendanceRow[4] = Session["week"];  // 周，格式化显示
                attendanceRow[5] = Session["time"];  // 第几节
                attendanceRow[6] = cell[0].Text.ToString(); //系部
                attendanceRow[7] = cell[1].Text.ToString(); //t4 班级名称
                attendanceRow[8] = cell[2].Text.ToString(); //Id
                attendanceRow[9] = cell[3].Text.ToString(); //Name
                attendanceRow[10] = "旷课";
                attendanceRow[11] = cell[1].Text.ToString();    //t4 班级名称  并不知道啥用
                attendanceList.Rows.Add(attendanceRow);
                sum++;

                strAbsence.Append(cell[3].Text.ToString() + ";");
                attendanceRow = attendanceList.NewRow();
            }
            else
            if ((ctl4 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["userID"];
                attendanceRow[1] = Session["userName"];
                attendanceRow[2] = Session["course"];  //课程名
                attendanceRow[3] = Session["currentWeek"];  // 周 数字
                attendanceRow[4] = Session["week"];  // 周，格式化显示
                attendanceRow[5] = Session["time"];  // 第几节
                attendanceRow[6] = cell[0].Text.ToString(); //系部
                attendanceRow[7] = cell[1].Text.ToString(); //t4 班级名称
                attendanceRow[8] = cell[2].Text.ToString(); //Id
                attendanceRow[9] = cell[3].Text.ToString(); //Name
                attendanceRow[10] = "早退";
                attendanceRow[11] = cell[1].Text.ToString();    //t4 班级名称  并不知道啥用
                attendanceList.Rows.Add(attendanceRow);
                sum++;

                strEarly.Append(cell[3].Text.ToString() + ";");
                attendanceRow = attendanceList.NewRow();
            }
            else
            if ((ctl5 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["userID"];
                attendanceRow[1] = Session["userName"];
                attendanceRow[2] = Session["course"];  //课程名
                attendanceRow[3] = Session["currentWeek"];  // 周 数字
                attendanceRow[4] = Session["week"];  // 周，格式化显示
                attendanceRow[5] = Session["time"];  // 第几节
                attendanceRow[6] = cell[0].Text.ToString(); //系部
                attendanceRow[7] = cell[1].Text.ToString(); //t4 班级名称
                attendanceRow[8] = cell[2].Text.ToString(); //Id
                attendanceRow[9] = cell[3].Text.ToString(); //Name
                attendanceRow[10] = "请假";
                attendanceRow[11] = cell[1].Text.ToString();    //t4 班级名称  并不知道啥用
                attendanceList.Rows.Add(attendanceRow);
                sum++;

                strLeave.Append(cell[3].Text.ToString() + ";");
                attendanceRow = attendanceList.NewRow();
            }
        }
        if (!AddSQLStringToDAL.UpdateDT4Copy(attendanceList, "TabStudentAttendance"))
        {
            return;
        }

        //更新老师状态为已考勤
        bool isUpdate = AddSQLStringToDAL.UpdateRows("TabCourses", "is_attendance", "已考勤", "teacher_id", "Current_Week", "Course",
            "Week", "Time", Session["userID"].ToString(), Session["currentWeek"].ToString(), Session["currentCourse"].ToString(),
            Session["week"].ToString(), Session["time"].ToString());
        if (isUpdate)
        {
            if (strLate.ToString() == "迟到名单：")
                strLate.Append("无");
            if (strEarly.ToString() == "早退名单：")
                strEarly.Append("无");
            if (strAbsence.ToString() == "旷课名单：")
                strAbsence.Append("无");
            if (strLeave.ToString() == "请假名单：")
                strLeave.Append("无");

            Label2.Text = strAbsence.ToString();
            Label3.Text = strLate.ToString();
            Label4.Text = strEarly.ToString();
            Label5.Text = strLeave.ToString();
            //清空数据
            strLate.Clear();
            strAbsence.Clear();
            strEarly.Clear();
            strLeave.Clear();
            GridView1.Visible = false;
            btnAtten.Visible = false;
            Label6.Text = "本次考勤记录已经上报成功！本次课您" + Session["homeWork"].ToString() + ",请返回主界面！";
            btnClose.Visible = true;

        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}