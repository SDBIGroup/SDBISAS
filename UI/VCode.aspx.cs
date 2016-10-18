using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Test_Code : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///生成验证码
        Random rd = new Random();
        string strCode = "";
        //循环以保证验证码第一位可以取0
        for (int i = 0; i < 4; i++)
        {
            strCode += rd.Next(10).ToString();
        }
        Bitmap bmp = new Bitmap(80, 46);
        Graphics g = Graphics.FromImage(bmp);
        Font f = new Font("Times New Roman", 17, FontStyle.Bold);
        //设置居中点
        StringFormat fat = new StringFormat();
        fat.Alignment = StringAlignment.Center;
        //写字符串,以40 10为中心居中
        g.DrawString(strCode, f, Brushes.AliceBlue, 40, 10,fat);
        bmp.Save(Response.OutputStream, ImageFormat.Gif);
        g.Dispose();
        Session["VCode"] = strCode;
    }
}