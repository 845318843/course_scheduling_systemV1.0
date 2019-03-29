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
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="maindiv">
                <div id="daohang" style="padding: 10px">
                    <table class='fuyuntable1322'>
                        <tr style="float: left">
                            <td>&nbsp;&nbsp;&nbsp;课&nbsp;&nbsp;&nbsp;&nbsp;程：
                            <input type="text" name="B1" id="courseName" />
                                &nbsp;&nbsp;&nbsp;班级：
                            <input type="text" name="B1" id="classs" />
                                &nbsp;&nbsp;&nbsp;教师：
                            <input type="text" name="B1" id="teacher" />
                                &nbsp;&nbsp;&nbsp;实验室门标：
                            <input type="text" name="B1" id="labNo" />
                                <input type="button" name="B1" class="btn btn-success" value="查询" id="find" />
                                
                            </td>
                            <%-- <a href='../file/实验室.xls' id='btnexport'>导出当页数据</a></td>--%>
                        </tr>
                        <tr>
                            <td style="float: left">&nbsp;&nbsp;&nbsp;<input type="button"  name="B1" class="btn btn-success" value="生成实验室周课表" id="weekCourse"   />
                                <a href='../../file/实验教学周课表.doc' id='A4'>下载实验教学周课表</a>
                                <input type="button" name="B1" class="btn btn-success" value="生成课程设计汇总" id="design" />
                                <a href='../../file/课程设计汇总.doc' id='A3'>下载课程设计汇总</a>
                                 &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; 
                                <input type="button" name="B1" class="btn btn-success" value="反馈本账号已完成排课任务" id="send" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="contents" style="padding: 10px">
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

