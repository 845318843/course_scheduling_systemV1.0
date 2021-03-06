﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="LabCourseSys.users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/user.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index2.css" rel="stylesheet" />
    <script src="../../js/ajaxfileupload.js"></script>
    <style type="text/css">
        a {
            text-decoration: underline;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#up").click(function () {
                up();
            });
        })
        function up() {
            layer.confirm('请注意，该操作将会覆盖原有数据备份，如需保留原有已备份数据，请立即下载并保存该备份文件！同时保证上传的备份文件名称为LabCourseSystem.bak  。继续则点击确认？', {
                btn: ['确认', '取消'] //按钮
            }, function () {
                $.ajaxFileUpload({
                    url: '../../webservice/upload.ashx', //你处理上传文件的服务端  
                    secureuri: false,//是否启用安全机制  
                    fileElementId: 'file1',//file的id  
                    dataType: 'application/json',//返回的类型  
                    success: function (data) {//调用成功时怎么处理  
                        layer.msg("数据库文件覆盖成功！");
                    }
                });
            }, function () {

            });

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="maindiv">
                <div id="daohang" style="padding: 15px">
                    <table class='fuyuntable1322'>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;
                                <input type="button" name="B1" class="btn btn-success" value="添加用户" id="add" />
                                <input type="button" name="B1" class="btn btn-success" value="重启word文档通道" id="wordProcess" />
                                <input type="button" name="B1" class="btn btn-success" value="重置任务完成情况" id="reset" />
                                <input type="button" name="B1" class="btn btn-success" value="清空排课记录" id="clear" />
                                <input type="button" name="B1" class="btn btn-success" value="备份数据库文件" id="copyss" onclick="f();" />
                                <input type="button" name="B1" class="btn btn-success" value="还原数据库" id="reback" />
                                <a href='../../backUp/LabCourseSystem.bak' id='upload'>下载备份数据库文件</a>
                                &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
                                <button runat="server" style="float: right" id="up" type="button">上传文件</button>
                                <input style="float: right" type="file" value="选择数据库文件" title="选择数据库文件" id="file1" name="file" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="contents" style="padding: 5px">
                    <div class="span12" style='padding: 8px'>
                        <table class="table table-condensed table-bordered table-hover tab">
                            <thead>
                                <tr>
                                    <th>序号</th>
                                    <th>用户名</th>
                                    <th>密码</th>
                                    <th>角色</th>
                                    <th>描述</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody id="tbody"></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
