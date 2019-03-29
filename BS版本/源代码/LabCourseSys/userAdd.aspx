<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userAdd.aspx.cs" Inherits="LabCourseSys.userAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../Js/user.js" type="text/javascript"></script>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <link href="../../Css/pageheader.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/button.css" />
      <script src="../../layer/layer.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>
    <title></title>
    <style type="text/css">
        body {
            background: url("../../images/99.png");
            width: 100%;
            height: 100%;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $("#adds").click(function () {
                var name = $("#name").val();
                name = $.trim(name);
                var pwd = $("#pwd").val();
                pwd = $.trim(pwd);
                var des = $("#des").val();
                var Is = $('#Is option:selected').val();
                insert(name, pwd, Is, des);
            })
        })
    </script>
</head>
<body>
    <form method="post" runat="server" id="form1">
        <div class="maindiv">
            <div class="maindivhrheader">&nbsp;</div>
            <table class="createtb">
                <tr>
                    <td>用户名:
                    </td>
                    <td>
                        <input name="txtname" type="text" runat="server" id="name" />
                    </td>
                </tr>
                <tr>
                    <td>密码:
                    </td>
                    <td>
                        <input name="txtprice" type="text" runat="server" id="pwd" />
                    </td>
                </tr>
                <tr>
                    <td>角色:
                    </td>
                    <td>
                        <select id="Is" style="width: 120px">
                            <option value="管理员">管理员</option>
                            <option value="系统管理员">系统管理员</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>描述:
                    </td>
                    <td>
                        <input name="txtprice" type="text" runat="server" id="des" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input value="保存数据" id="adds" class="button blue" type="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

