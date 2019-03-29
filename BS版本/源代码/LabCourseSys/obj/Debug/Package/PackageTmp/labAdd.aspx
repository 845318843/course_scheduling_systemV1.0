<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="labAdd.aspx.cs" Inherits="LabCourseSys.labAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="js/lab.js" type="text/javascript"></script>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <link href="../../Css/pageheader.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/button.css" />
    <%--    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>--%>
      <script src="../../layer/layer.js" type="text/javascript"></script>
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
            loadUser();
            $("#adds").click(function () {
                insert();
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
                        <input name="txtname" type="text" runat="server" id="labName" />
                    </td>
                </tr>
                <tr>
                    <td>实验室门标:
                    </td>
                    <td>
                        <input name="txtname" type="text" runat="server" id="name" />
                    </td>
                </tr>
                <tr>
                    <td>可容纳人数:
                    </td>
                    <td>
                        <input name="txtprice" type="text" runat="server" id="count" />
                    </td>
                </tr>
                <tr>
                    <td>管理员:
                    </td>
                    <td>
                        <select name="DDLBelong"  style="width:100px"  runat="server" id="user">
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
                        <input value="保存数据" id="adds" class="button blue" type="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

