<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="week.aspx.cs" Inherits="LabCourseSys.week" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
  <%--  <script src="../../Js/week.js" type="text/javascript"></script>--%>
    <title></title>
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
        var a = 0;
        $(function () {
            $("input").click(function () {
                check();
                if (a >= 2) {
                    $(this).attr("checked", false);
                }
                else {
                    sessionStorage["weekss"] = $(this).attr("name");
                }

            })
        })
        function check() {
            a = 0;
            $(":checkbox").each(function () {
                if (this.checked == true) {
                    a++;
                }
            });
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>一
                        <input type='checkbox' id='ck1' name="1" /></td>
                    <td>二
                        <input type='checkbox' id='ck2' name="2" /></td>
                    <td>三
                        <input type='checkbox' id='ck3' name="3" /></td>
                    <td>四
                        <input type='checkbox' id='ck4' name="4" /></td>
                    <td>五
                        <input type='checkbox' id='ck5' name="5" /></td>
                    <td>六
                        <input type='checkbox' id='ck6' name="6" /></td>
                    <td>七
                        <input type='checkbox' id='ck7' name="7" /></td>
                    <td>八
                        <input type='checkbox' id='ck8' name="8" /></td>
                    <td>九
                        <input type='checkbox' id='ck9' name="9" /></td>
                    <td>十
                        <input type='checkbox' id='ck10' name="10" /></td>
                </tr>
                <tr>
                    <td>十一
                        <input type='checkbox' id='ck11' name="11" /></td>
                    <td>十二
                        <input type='checkbox' id='ck12' name="12" /></td>
                    <td>十三
                        <input type='checkbox' id='ck13' name="13" /></td>
                    <td>十四
                        <input type='checkbox' id='ck14' name="14" /></td>
                    <td>十五
                        <input type='checkbox' id='ck15' name="15" /></td>
                    <td>十六
                        <input type='checkbox' id='ck16' name="16" /></td>
                    <td>十七
                        <input type='checkbox' id='ck17' name="17" /></td>
                    <td>十八 
                        <input type='checkbox' id='ck18' name="18" /></td>
                    <td>十九
                        <input type='checkbox' id='ck19' name="19" /></td>
                    <td>二十 
                        <input type='checkbox' id='ck20' name="20" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

