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
            $("#chg").click(function () {
                chgPwd();
            })
        })
        function chkstrlen(str) {
            var strlen = 0;
            for (var i = 0; i < str.length; i++) {
                if (str.charCodeAt(i) > 255) //如果是汉字，则字符串长度加2
                    strlen += 2;
                else
                    strlen++;
            }
            if (str.length != strlen)
                return false;
            else
                return true;
        }
        function chgPwd() {
            var p1 = $("#p1").val();
            var p2 = $("#p2").val();
            if (p1 != p2)
                layer.alert('前后输入不一致！', {
                    skin: 'layui-layer-lan'
               , closeBtn: 0
               , anim: 4 //动画类型
                });
            
            else {
                var name = sessionStorage["user"];
                if (p1.length < 4)
                    layer.alert('密码长度不够！', {
                        skin: 'layui-layer-lan'
                        , closeBtn: 0
                       , anim: 4 //动画类型
                    });
                else {
                    if (chkstrlen(p1)) {
                        p1 = $.trim(p1);
                        $.ajax(
                        {
                            type: "post",
                            url: "../../webService/userService.asmx/pwd",
                            data: '{"name":"' + name + '","pwd":"' + p1 + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (result) {
                                layer.alert('修改成功 !', {
                                    skin: 'layui-layer-lan'
                                    , closeBtn: 0
                                    , anim: 4 //动画类型
                                });
                            },
                            error: function (err) {

                            }
                        });
                    }
                    else
                        layer.alert('密码不能含有非法字符！', {
                            skin: 'layui-layer-lan'
                                , closeBtn: 0
                                , anim: 4 //动画类型
                        });
                     
                }
            }
        }
    </script>
</head>
<body>
    <form method="post" runat="server" id="form1">
        <div class="maindiv">
            <div class="maindivhrheader">&nbsp;</div>
            <table class="createtb">
                <tr>
                    <td>新密码:
                    </td>
                    <td>
                        <input name="txtname" type="password" minlength="4" runat="server" id="p1" />
                    </td>
                </tr>
                <tr>
                    <td>确认输入:
                    </td>
                    <td>
                        <input name="txtprice" minlength="4" type="password" runat="server" id="p2" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input value="确认修改" id="chg" class="button blue" type="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

