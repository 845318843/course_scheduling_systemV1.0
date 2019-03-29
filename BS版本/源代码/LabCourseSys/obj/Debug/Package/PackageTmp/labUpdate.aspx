<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="labUpdate.aspx.cs" Inherits="LabCourseSys.labUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <%--    <script src="../../Js/fuyun001.js" type="text/javascript"></script>--%>
    <script src="../../Js/lab.js" type="text/javascript"></script>
    <%--   <link href="Css/pageheader.css" rel="stylesheet" type="text/css" />--%>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <link href="../../Css/pageheader.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>
      <script src="../../layer/layer.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../css/button.css" />
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
            var id = sessionStorage["labID"];
            loadUser();
            getone(id);
            $("#chg").click(function () {
                update(id);
            })
            $("#del").click(function () {
                $("#del").attr('disabled', 'false');
                $("#chg").attr('disabled', 'false');
                del(id);
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
                    <td>实验室名称:
                    </td>
                    <td>
                        <input name="txtname" type="text" id="labName" />
                    </td>
                </tr>
                <tr>
                    <td>实验室门标:
                    </td>
                    <td>
                        <input name="txtname" type="text" id="name" />
                    </td>
                </tr>
                <tr>
                    <td>可容纳人数:
                    </td>
                    <td>
                        <input name="txtprice" type="text" id="count" />
                    </td>
                </tr>
                 <tr>
                    <td>管理员:
                    </td>
                    <td>
                        <select name="DDLBelong" runat="server" style="width:100px" id="user">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>简介:
                    </td>
                    <td>
                        <textarea runat="server" name="txtdesc" rows="2" cols="20" id="des" style="height: 110px; width: 250px">
</textarea>
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
