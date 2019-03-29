<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseDesign.aspx.cs" Inherits="LabCourseSys.courseDesign" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../Js/fuyun001.js" type="text/javascript"></script>
    <script src="../../js/plan.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <%--    <link type="text/css" rel="stylesheet" href="../../css/showBo.css" />
    <script type="text/javascript" src="../../js/showBo.js"></script>--%>
    <link rel="stylesheet" href="../../css/button.css" />
      <script src="../../layer/layer.js" type="text/javascript"></script>
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
            $("#ad").click(function () {
                layer.confirm('确认是否添加？添加成功后将不能修改！', {
                    btn: ['确认', '取消'] //按钮
                }, function () {
                    var course = $("#course").val();

                    var classs = $("#classs").val();
                    var tea = $("#teacher").val();
                    var count = parseInt($("#count").val());
                    var n = parseInt(sessionStorage["num"]);
                    var num = $("#num").val();
                    var labNo = sessionStorage["labID"];
                    var lab = sessionStorage["lab"];
                    if (count > n)
                        layer.alert('超过实验室可容纳人数上限！', {
                            skin: 'layui-layer-lan'
                  , closeBtn: 0
                  , anim: 4 //动画类型
                        });
                    else if (course == '' || classs == '' || tea == '')
                        layer.alert('有必填项为空,请重新核对！', {
                            skin: 'layui-layer-lan'
                         , closeBtn: 0
                           , anim: 4 //动画类型
                        });
                    else {

                        if (course.indexOf('课程设计') > 0) {
                            add(course, classs, tea, count, num, lab, labNo, 0);
                            $("#adds").attr('disabled', 'false');
                        }
                        else
                            layer.alert('请填写正确的课程名称，如C语言课程设计！', {
                                skin: 'layui-layer-lan'
                    , closeBtn: 0
                      , anim: 4 //动画类型
                            });
                    }
                }, function () {

                });
            })
        })
        function designOne(one) {
            var num = sessionStorage["courseID"];
            var user = sessionStorage["user"];
            if (num != 'null') {
                $.ajax(
            {
                type: "post",
                url: "../../webService/labCourseService.asmx/designOne",
                data: '{"one":"' + one + '","num":"' + num + '","user":"' + user + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    sessionStorage["sec"] = "1";
                },
                error: function (err) {

                }
            });
            }
            else {
                $("[name = 'sw']:checkbox").attr("checked", false);
                $("[name = 'xw']:checkbox").attr("checked", false);
                layer.alert('请先添加课程基本信息！', {
                    skin: 'layui-layer-lan'
                   , closeBtn: 0
                     , anim: 4 //动画类型
                });
            }
        }

        function addDesign() {
            var week = sessionStorage["week"];
            if (week == "1") {
                layer.confirm('是否确认添加该课程设计？', {
                    btn: ['确认', '取消'] //按钮
                }, function () {
                    for (var i = 0; i < secs.length; i++) {
                        updatess(weeks[i], days[i], secs[i]);
                    }
                    layer.alert('操作成功！', {
                        skin: 'layui-layer-lan'
                       , closeBtn: 0
                       , anim: 4 //动画类型
                    });
                    $("#addDesigns").attr('disabled', 'false');
                    sessionStorage["num"] = null;
                    sessionStorage["sec"] = "2";
                    sessionStorage["week"] = "2";
                }, function () {

                });
               
            }
            else {
                layer.alert('请先选择周次！', {
                    skin: 'layui-layer-lan'
                    , closeBtn: 0
                     , anim: 4 //动画类型
                });
            }
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
                        <td>
                            <input type="button" name="btnchildadd" value="添加课程基本信息" id="ad" class="button blue" />
                        </td>
                        <td>上午
                            <input type="checkbox" id="sw" name="sw" onclick="designOne(1)" />
                            下午
                            <input type="checkbox" id="xw" name="xw" onclick='designOne(2)' />
                            <input type="button" value="选择周次" id="week" class="button blue" />
                            <input type="button" value="添加选课信息" id="addDesigns" onclick='addDesign()' class="button blue" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
