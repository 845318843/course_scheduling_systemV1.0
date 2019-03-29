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
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <%--    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>--%>
    <title></title>
    <style type="text/css">
        a {
            text-decoration: underline;
        }

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
            $("#new").click(function () {
                var s = sessionStorage["cid"];
                sessionStorage["courseID"] = s;
                parent.layer.open({
                    type: 2,
                    title: '追加新项目：（新增的内容将追加到该课程里面）',
                    shadeClose: true,
                    shade: 0.5,
                    area: ['60%', '70%'],
                    content: '../../labPlan.aspx',
                    end: function () {
                        sessionStorage["sec"] = "1";
                    }
                });
            })
            $("#delAll").click(function () {
                var cid = sessionStorage["cid"];
                delAll(cid);
            })
            $("#create").click(function () {
                wordProcess();
                if (process == "未运行") {
                    var cid = sessionStorage["cid"];
                    create(cid);
                }
                else
                    layer.alert('当前word文档生成通道被占用，请稍等片刻后重试！', {
                        skin: 'layui-layer-lan'
                                     , closeBtn: 0
                                     , anim: 4 //动画类型
                    });
            })
            $("#newStyle").click(function () {
                wordProcess();
                if (process == "未运行") {
                    var cid = sessionStorage["cid"];
                    createNew(cid);
                }
                else
                    layer.alert('当前word文档生成通道被占用，请稍等片刻后重试！', {
                        skin: 'layui-layer-lan'
                         , closeBtn: 0
                      , anim: 4 //动画类型
                    });
            })
        })
        function wordProcess() {
            $.ajax({
                type: "post",
                contentType: "application/json",
                url: "../../webService/recordsService.asmx/wordProcess",
                //data: '{"courseName":"' + courseName + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","user":"' + user + '"}',
                dataType: "json",
                async: false,
                success: function (result) {
                    process = result.d;
                },
                error: function (jqXHR, textStatus, errorThrown) {

                }
            });
        }
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
                    layer.alert('旧样式实验教学任务书生成成功 !', {
                        skin: 'layui-layer-lan'
                        , closeBtn: 0
                        , anim: 4 //动画类型
                    });
                },
                error: function (err) {

                }
            });
        }
        function createNew(id) {
            layer.msg("请稍等,这可能需要耗费一些时间.");
            $.ajax(
            {
                type: "post",
                url: "../../webService/recordsService.asmx/newmission",
                data: '{"labID":"' + id + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    layer.alert('新样式实验教学任务书生成成功 !', {
                        skin: 'layui-layer-lan'
                        , closeBtn: 0
                       , anim: 4 //动画类型
                    });
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
                    layer.alert('更新成功!', {
                        skin: 'layui-layer-lan'
                        , closeBtn: 0
                        , anim: 4 //动画类型
                    });
                },
                error: function (err) {

                }
            });
        }
        function del(id) {
            layer.confirm('确认是否删除该条记录？删除后将不能恢复！', {
                btn: ['确认', '取消'] //按钮
            }, function () {
                $.ajax(
                 {
                     type: "post",
                     url: "../../webService/recordsService.asmx/delete",
                     data: '{"id":"' + id + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (result) {
                         $("#del").attr('disabled', 'false');
                         $("#chg").attr('disabled', 'false');
                         layer.alert('成功删除该条记录！', {
                             skin: 'layui-layer-lan'
                       , closeBtn: 0
                       , anim: 4 //动画类型
                         });
                     },
                     error: function (err) {

                     }
                 });
            }, function () {

            });
            //layer.confirm('确认是否删除该条记录？删除后将不能恢复！', {
            //    btn: ['确认', '取消'] //按钮
            //}, function () {
                
            //}, function () {

            //});
        }
        function delAll(id) {
            layer.confirm('确认是否删除整个课程？删除后将不能恢复！', {
                btn: ['确认', '取消'] //按钮
            }, function () {
                $.ajax(
                 {
                     type: "post",
                     url: "../../webService/recordsService.asmx/deleteAll",
                     data: '{"id":"' + id + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (result) {
                         $("#delAll").attr('disabled', 'false');
                     
                         layer.alert('成功删除整个课程！', {
                             skin: 'layui-layer-lan'
                       , closeBtn: 0
                       , anim: 4 //动画类型
                         });
                     },
                     error: function (err) {

                     }
                 });
            }, function () {

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
                        <input value="生成旧样式实验任务书" id="create" class="button blue" type="button" />
                        <input value="生成新样式实验任务书" id="newStyle" class="button blue" type="button" />
                        <br />
                        <a href='../file/实验教学任务书.doc' id='A1111'>下载实验教学任务书</a>
                        <br />
                        <br />
                        <input value="新增实验项目" id="new" class="button blue" type="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
