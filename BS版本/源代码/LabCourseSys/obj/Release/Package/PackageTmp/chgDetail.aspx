<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chgDetail.aspx.cs" Inherits="LabCourseSys.chgDtail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <script src="../../Js/lab.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../css/button.css" />
    <link href="../../Css/pageheader.css" rel="stylesheet" type="text/css" />

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
            var id = sessionStorage["detail"];
            getone(id);
            $("#chg").click(function () {
                var name = $("#name").val();
                var Is = $('#Is option:selected').val();
                if (Is == "否")
                    Is = "0";
                else
                    Is = "1";
                update(id, name, Is);
            })
            $("#del").click(function () {
                del(id);
            })
            $("#delAll").click(function () {
                var cid = sessionStorage["cid"];
                delAll(cid);
            })
            $("#create").click(function () {
                var cid = sessionStorage["cid"];
                create(cid);
            })
        })
        function create(id) {
            $.ajax(
            {
                type: "post",
                url: "../../webService/recordsService.asmx/mission",
                data: '{"labID":"' + id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    alert("实验教学任务书生成成功 !");
                },
                error: function (err) {

                }
            });
        }
        function getone(id) {
            $.ajax(
            {
                type: "post",
                url: "../../webService/recordsService.asmx/getone",
                data: '{"id":"' + id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    var res = eval(result.d);
                    $.each(res, function (i, d) {
                        $("#name").val(d.project);
                        var s = "";
                        if (d.iscomprehensive == "1")
                            s = "是";
                        else
                            s = "否";
                        $("#Is").val(s);
                    });
                },
                error: function (err) {

                }
            });
        }
        function update(id, name, Is) {
            $.ajax(
            {
                type: "post",
                url: "../../webService/recordsService.asmx/update",
                data: '{"project":"' + name + '","Is":"' + Is + '","id":"' + id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                  alert("更新成功!");
                },
                error: function (err) {

                }
            });
        }
        function del(id) {
            var r = confirm("确认是否删除该条记录？删除后将不能恢复！");
            if (r == true) {
                $.ajax(
                {
                    type: "post",
                    url: "../../webService/recordsService.asmx/delete",
                    data: '{"id":"' + id + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        alert("成功删除该条记录！");
                    },
                    error: function (err) {

                    }
                });
            }
        }
        function delAll(id) {
            var r = confirm("确认是否删除整个课程？删除后将不能恢复！");
            if (r == true) {
                $.ajax(
                {
                    type: "post",
                    url: "../../webService/recordsService.asmx/deleteAll",
                    data: '{"id":"' + id + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        alert("成功删除整个课程！");
                    },
                    error: function (err) {

                    }
                });
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
                    <td>项目名称:
                    </td>
                    <td>
                        <input name="txtname" type="text" runat="server" id="name" />
                    </td>
                </tr>
                <tr>
                    <td>是否综合性:
                    </td>
                    <td>
                        <select id="Is" style="width: 100px">
                            <option value="是">是</option>
                            <option value="否">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input value="修改" id="chg" class="button blue" type="button" />
                        <input value="删除单条记录" id="del" class="button blue" type="button" />
                        <input value="删除课程记录" id="delAll" class="button blue" type="button" />
                        <br />
                        <br />
                        <input value="生成实验教学任务书" id="create" class="button blue" type="button" />
                        <a href='../file/实验教学任务书.doc' id='A1111'>下载实验教学任务书</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
