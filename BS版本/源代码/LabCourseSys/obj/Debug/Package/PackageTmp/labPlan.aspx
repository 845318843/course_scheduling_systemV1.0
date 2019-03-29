<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="labPlan.aspx.cs" Inherits="LabCourseSys.labPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <script src="../../js/plan.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
<%--    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>--%>
    <link rel="stylesheet" href="../../css/button.css" />
    <style type="text/css">
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th {
            border: 1px solid #666666;
        }

        td {
            border: 1px solid #666666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div>
                <table>
                    <tr>
                        <td>课程名称:</td>
                        <td>
                            <input name="txtchildtitle" type="text" id="course" style="width: 220px" /></td>
                        <td>班级:</td>
                        <td>
                            <input name="txtchilddesc" type="text" id="classs" style="width: 220px" /></td>
                    </tr>
                    <tr>
                        <td>人数:</td>
                        <td>
                            <input name="txtchilddesc" type="text" id="count" style="width: 220px" /></td>
                        <td>指导教师(年龄，职称(学历)):</td>
                        <td>
                            <input name="txtchildurl" type="text" id="teacher" style="width: 220px" /></td>
                    </tr>
                    <tr>
                        <td>组别:</td>
                        <td>
                            <input name="txtchilddesc" type="text" id="num" style="width: 220px" /></td>
                        <td colspan="2">
                            <input type="button" name="btnchildadd" value="添加基本信息" id="adds" class="button blue" />
                            <input type="button" name="btnchildadd" value="选择节次" id="section" class="button blue" />
                            <input type="button" name="btnchildadd" value="选择周次" id="week" class="button blue" /></td>
                    </tr>
                </table>
            </div>
            <div id="contents" style="padding: 10px;">
                <table>
                    <thead>
                        <tr>
                            <th>项目名称</th>
                            <th>是否是综合性，设计性项目</th>
                            <th>周次</th>
                            <th>星期</th>
                            <th>节次</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
