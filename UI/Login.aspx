<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="zh-CN">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <title>webos</title>
    <meta name="keywords" content="webos" />
    <meta name="description" content="webos" />
    <meta name="Language" content="zh-CN" />
    <meta name="Copyright" content="webos" />
    <meta name="Designer" content="webos" />
    <meta name="Publisher" content="webos" />
    <meta name="Distribution" content="Global" />
    <meta name="author" content="webos" />
    <meta name="robots" content="index,follow" />
    <meta name="googlebot" content="index,follow,archive" />
    <link href="css/main1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="login">
            <div class="box png">
                <div class="logo"></div>
                <div class="input">
                    <div class="log">
                        <div class="name">
                            <label>用户名</label>
                            <asp:TextBox type="text" class="text" ID="value_1" placeholder="用户名" name="value_1" TabIndex="1" runat="server"></asp:TextBox>
                        </div>
                        <div class="pwd">
                            <label>密　码</label>
                            <asp:TextBox type="password" class="text" ID="value_2" placeholder="密码" name="value_2" TabIndex="2" runat="server"></asp:TextBox>
                            <asp:Button type="button" class="submit" TabIndex="3" runat="server" OnClick="Button1_Click" Text="登录" />
                            <div class="check"></div>
                        </div>
                        <div class="tip"></div>
                    </div>
                </div>
            </div>
            <div class="air-balloon ab-1 png"></div>
            <div class="air-balloon ab-2 png"></div>
            <div class="air-balloon ab-1 png">
            </div>
            <div class="footer"></div>
        </div>

        <script type="text/javascript" src="jslib/jQuery.js"></script>
        <script type="text/javascript" src="js/fun.base.js"></script>
        <script type="text/javascript" src="js/login.js"></script>

        <p>
            &nbsp;
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>

    </form>
</body>
</html>
