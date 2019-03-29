<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="labPlans.aspx.cs" Inherits="LabCourseSys.labPlans" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <script src="../../js/plan.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        $(function () {
            sessionStorage["sec"] = "1";
            var f = sessionStorage["flag"];
            var ff = parseInt(f);
            var type = 'section';
            var num = sessionStorage["courseID"];
            var no;
            if (ff <= 7)
                no = "1.2";
            else if (ff > 7 && ff <= 14)
                no = "3.4";
            else if (ff > 14 && ff <= 21)
                no = "5.6";
            else if (ff > 21 && ff <= 28)
                no = "7.8";
            else
                no = "9.10";
            var s = intToChinese((ff % 7));
            $("#flag").val("当前选中：星期" + s + ",第" + no + "节");

        })
        function intToChinese(str) {
            str = str + '';
            var len = str.length - 1;
            var idxs = ['', '十', '百', '千', '万', '十', '百', '千', '亿', '十', '百', '千', '万', '十', '百', '千', '亿'];
            var num = ['日', '一', '二', '三', '四', '五', '六', '七', '捌', '玖'];
            return str.replace(/([1-9]|0+)/g, function ($, $1, idx, full) {
                var pos = 0;
                if ($1[0] != '0') {
                    pos = len - idx;
                    if (idx == 0 && $1[0] == 1 && idxs[len - idx] == '十') {
                        return idxs[len - idx];
                    }
                    return num[$1[0]] + idxs[len - idx];
                } else {
                    var left = len - idx;
                    var right = len - idx + $1.length;
                    if (Math.floor(right / 4) - Math.floor(left / 4) > 0) {
                        pos = left - left % 4;
                    }
                    if (pos) {
                        return idxs[pos] + num[$1[0]];
                    } else if (idx + $1.length >= len) {
                        return '';
                    } else {
                        return num[$1[0]]
                    }
                }
            });
        }
    </script>
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
                            <input type="button" name="btnchildadd" value="添加基本信息" id="addss" class="button blue" />
                            <input type="text" name="btnchildadd" id="flag" disabled="disabled" style="width: 200px" />
                           <%-- <input type="button" name="btnchildadd" value="选择节次" id="section" class="button blue" />--%>
                            <input type="button" name="btnchildadd" value="选择周次" id="week" class="button blue" />
                        </td>
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
