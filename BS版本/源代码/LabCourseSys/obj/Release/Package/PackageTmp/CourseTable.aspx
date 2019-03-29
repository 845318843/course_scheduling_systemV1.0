<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseTable.aspx.cs" Inherits="LabCourseSys.CourseTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Js/fuyun001.js" type="text/javascript"></script>
    <script src="js/table.js" type="text/javascript"></script>
    <script src="layer/layer.js" type="text/javascript"></script>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index2.css" rel="stylesheet" />
    <style type="text/css">
        table {
            word-break: break-all;
            border-collapse: collapse;
            width: 100%;
        }

        th {
            border: 2px solid #808080;
        }

        td {
            border: 1px solid #808080;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center; font-size: 25px; font-stretch: inherit" id="tit" >

            </div>
            <div id="contents" style="padding: 10px;">
                <a id="ds" aria-disabled="false"></a>
                <table>
                    <thead>
                        <tr>
                            <th></th>
                            <th>星期一</th>
                            <th>星期二</th>
                            <th>星期三</th>
                            <th>星期四</th>
                            <th>星期五</th>
                            <th>星期六</th>
                            <th>星期日</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
