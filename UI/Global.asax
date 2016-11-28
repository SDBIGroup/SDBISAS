﻿<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // 在应用程序启动时运行的代码
        Application.Lock();
        Application["Online"] = 0;
        Application.UnLock();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码
        //测试代码TODO
        Session["UserID"] = "2012015001";
        Session["Username"] = "";
        Session["Role"] = "1";
        Session["week"] = "14";
        Session["code"] = "";
        Session["course"] = "[370411]建筑基础(9)";
        Session["gWeek"] = "星期一";
        Session["time"] = "3-4节";
        Session["CurrentCourse"] = "";
        Session["Homework"] = "";

        Application.Lock();
        Application["Online"] = (int)Application["Online"] + 1;
    }

    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。
        Application.Lock();
        Application["Online"] = (int)Application["Online"] - 1;
        Application.UnLock();
    }

</script>
