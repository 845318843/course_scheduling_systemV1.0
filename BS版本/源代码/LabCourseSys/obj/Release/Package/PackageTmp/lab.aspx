<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lab.aspx.cs" Inherits="LabCourseSys.lab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
   <%-- <script src="../../Js/fuyun001.js" type="text/javascript"></script>--%>
    <script src="../../js/lab.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="mytitle">
              <%--  实验室管理--%>
            </div>
            <div id="daohang" style="padding:10px">
                <table class='fuyuntable1322'>
                    <tr>
                        <td >
                            &nbsp;&nbsp;&nbsp;
                            <input type="button" name="B1" class="btn btn-success" value="添加" id="add" onclick=" addNewLab()" />
                         <%--   <a href='../file/实验室.xls' id='btnexport'>导出当页数据</a>--%></td>
                    </tr>
                </table>
            </div>
            <div id="contents">
            </div>
        </div>
    </form>
</body>
</html>
