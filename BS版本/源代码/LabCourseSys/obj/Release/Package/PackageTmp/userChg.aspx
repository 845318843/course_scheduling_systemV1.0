<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userChg.aspx.cs" Inherits="LabCourseSys.userChg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/user.js" type="text/javascript"></script>

    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <link href="../../Css/pageheader.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/button.css" />
<%--    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>--%>
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
            var mission = "";
            var id = sessionStorage["userID"];
            getone(id);
            $("#chg").click(function () {
                var name = $("#name").val();
                var pwd = $("#pwd").val();
                var des = $("#des").val();
                var role = $("#des").val();
                var Is = $('#Is option:selected').val();
                mission = sessionStorage["mission"];
                alert(mission);
                update(name, pwd, Is, des, id,mission);
            })
            $("#del").click(function () {
                del(id);
            })
        })
        function getone(id) {
            $.ajax(
            {
                type: "post",
                url: "../../webService/userService.asmx/getOne",
                data: '{"id":"' + id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    var res = eval(result.d);
                    $.each(res, function (i, d) {
                        mission = d.remark1;
                        sessionStorage["mission"] = mission;
                       
                        $("#name").val(d.name);
                        $("#pwd").val(d.pwd);
                        $("#des").val(d.describe);
                        $("#Is").val(d.role);
                    });
                },
                error: function (err) {

                }
            });
        }
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
                        <input value="修改" id="chg" class="button blue" type="button" />
                        <input value="删除" id="del" class="button blue" type="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


