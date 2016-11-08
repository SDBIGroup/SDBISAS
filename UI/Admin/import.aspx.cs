using System;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_import : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private DataTable xsldata()
    {
        if (fuload.FileName == "")
        {
            lbmsg.Text = "请选择文件";
            return null;
        }
        string fileExtenSion;//文件扩展名
        //获取选择文件的扩展名
        fileExtenSion = Path.GetExtension(fuload.FileName);
        //检测文件扩展名(格式)
        if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
        {
            lbmsg.Text = "上传的文件格式不正确";
            return null;
        }
        try
        {
            string FileName = "App_Data/" + Path.GetFileName(fuload.FileName);
            //判断文件是否存在，如果存在先删除
            if (File.Exists(Server.MapPath(FileName)))
            {
                File.Delete(Server.MapPath(FileName));
            }
            //上传文件到指定目录
            fuload.SaveAs(Server.MapPath(FileName));
            //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES  
            string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties=\"Excel 12.0;HDR=YES\"";

            //建立连接，根据不同的扩展名，选择不同的引擎
            OleDbConnection conn;
            if (fileExtenSion.ToLower() == ".xls")
            {
                conn = new OleDbConnection(connstr2003);
            }
            else
            {
                conn = new OleDbConnection(connstr2007);
            }
            conn.Open();

            string strSQL = "select * from [Sheet1$]";
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataTable dt = new DataTable();
            OleDbDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);

            sdr.Close();
            conn.Close();
            //处理完成后，删除服务器里上传的文件  
            if (File.Exists(Server.MapPath(FileName)))
            {
                File.Delete(Server.MapPath(FileName));
            }
            return dt;
        }
        catch (Exception e)
        {
            lbmsg.Text = "导入发生错误！" + e;
            return null;
        }
    }

    protected void Btn1_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = xsldata();
            //dataGridView2.DataSource = dt;


            int errorcount = 0;//记录错误信息条数  
            int insertcount = 0;//记录插入成功条数  
            int updatecount = 0;//记录更新信息条数  

            string strcon = "Data Source=192.168.53.110;Initial Catalog=15softDB02;uid=15soft02;pwd=2245;";
            SqlConnection conn = new SqlConnection(strcon);//链接数据库  
            conn.Open();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string t1 = dt.Rows[i][0].ToString();//dt.Rows[i]["Name"].ToString(); "Name"即为Excel中Name列的表头  
                string t2 = dt.Rows[i][1].ToString();
                string t3 = dt.Rows[i][2].ToString();
                string t4 = dt.Rows[i][3].ToString();
                string t5 = dt.Rows[i][4].ToString();
                if (t1 != "" && t2 != "" && t3 != "" && t4 != "")
                {
                    SqlCommand selectcmd = new SqlCommand("select count(*) from Test where number='" + t1 + "' and pwd='" + t2 + "' and name='" + t3 + "' and sex='" + t4 + "' and role='" + t5 + "'", conn);
                    int count = Convert.ToInt32(selectcmd.ExecuteScalar());
                    if (count > 0)
                    {
                        updatecount++;
                    }
                    else
                    {
                        SqlCommand insertcmd = new SqlCommand("insert into Test(number,pwd,name,sex,role) values('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "')", conn);
                        insertcmd.ExecuteNonQuery();
                        insertcount++;
                    }
                }
            }
            lbmsg.Text = ((insertcount + "条数据导入成功！" + updatecount + "条数据重复！" + errorcount + "条数据部分信息为空没有导入！"));
        }
        catch (Exception ex)
        {
            lbmsg.Text = ex.ToString();
        }

    }


    private void test()
    {
        HttpPostedFile file = fuload.PostedFile;
        string fileName = file.FileName;
        string tempPath = System.IO.Path.GetTempPath();
        fileName = System.IO.Path.GetFileName(fileName);
        string currFileExtension = System.IO.Path.GetExtension(fileName);
        string currFilePath = tempPath + fileName;
        file.SaveAs(currFilePath);

    }
}