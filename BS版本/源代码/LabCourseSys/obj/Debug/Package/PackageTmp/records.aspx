<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="records.aspx.cs" Inherits="LabCourseSys.records" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/records.js" type="text/javascript"></script>
    <script src="../../layer/layer.js" type="text/javascript"></script>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index2.css" rel="stylesheet" />
    <style type="text/css">
        a {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="maindiv">
                <div id="daohang" style="padding: 0.5%">
                    <table class='fuyuntable1322'>
                        <tr style="float: left">
                        
                            <td>课程：
                            <input type="text" name="B1" id="courses" style="width: 15%" />
                                班级：
                            <input type="text" name="B1" id="classs" style="width: 15%" />
                                教师：
                            <input type="text" name="B1" id="teacher" style="width: 15%" />
                                实验室门标：
                            <select name="B1" id="labNo" style="width: 15%"><option value="所有实验室">所有实验室</option></select>
                                <input type="button" name="B1" class="btn btn-success" value="检索数据" id="find" />
                            </td>
                        </tr>
                        <tr>
                            <td style="float: left">&nbsp;&nbsp;&nbsp;<input type="button" name="B1" class="btn btn-success" value="生成实验教学周课表" id="weekCourse" />
                                <a href='../../file/实验教学周课表.doc' id='A4'>下载实验教学周课表</a>
                                <input type="button" name="B1" class="btn btn-success" value="生成课程设计汇总" id="design" />
                                <a href='../../file/课程设计汇总.doc' id='A3'>下载课程设计汇总</a>
                                &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; 
                                <input type="button" name="B1" class="btn btn-success" style="float: right" value="反馈本账号已完成排课任务" id="send" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="contents" style="padding: 0.5%">
                    <div class="span12" style='padding: 8px'>
                        <table class="table table-condensed table-bordered table-hover tab">
                            <thead>
                                <tr>
                                    <th>序号</th>
                                    <th>课程</th>
                                    <th>班级</th>
                                    <th>教师</th>
                                    <th>项目名称</th>
                                    <th>是否综合性</th>
                                    <th>周次</th>
                                    <th>星期</th>
                                    <th>节次</th>
                                    <th>人数</th>
                                    <th>组别</th>
                                    <th>实验室</th>
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

