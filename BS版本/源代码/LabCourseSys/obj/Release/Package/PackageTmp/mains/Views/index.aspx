<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LabCourseSys.mains.Views.index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../js/main.js" type="text/javascript"></script>
    <script src="../../layer/layer.min.js" type="text/javascript"></script>
    <link href="../bootstrap2.3.2/css/bootstrap.min.css" rel="stylesheet" />
    <title>计算机学院实践教学排课系统</title>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index.css" rel="stylesheet" />
</head>
<body>
    <div class="header">
        <img class="logo" src="../images/logo.png" />
        <label class="logo-title" style="text-align:left">计算机学院实践教学排课系统</label>
        <ul class="inline">
            <li>
                <div id="divv"> <img src="../images/32/client.png" />&nbsp;&nbsp;欢迎您,</div>
            </li>
            <li>
                <img src="../images/32/200.png" />&nbsp;&nbsp;<a class="loginout" href="../../login.html">注销</a>
            </li>
        </ul>
    </div>
    <div class="nav">
    </div>
    <div class="container-fluid content">
        <div class="row-fluid" style="height:100%">
            <div class="span2 content-left"style="height:auto">
                <div class="accordion" style="height:auto">
                    <div class="accordion-group">
                        <div class="accordion-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapseOne">
                                <img class="left-icon" src="../images/32/159.png" /><span class="left-title">菜单导航</span>
                            </a>
                        </div>
                        <div id="collapseOne" class="accordion-body collapse in">
                            <div class="accordion-inner" id="../../lab.aspx">
                                <img class="left-icon-child" src="../images/32/221.png" /><span class="left-body"><a class='hover' id="lab" href='#'> 实验室管理</a></span>
                            </div>
                            <div class="accordion-inner" id="../../course.aspx">
                                <img class="left-icon-child" src="../images/32/287.png" /><span class="left-body"><a class='hover' id="course" href='#'> 实验室排课</a></span>
                            </div>
                            <div class="accordion-inner" id="../../records.aspx">
                                <img class="left-icon-child" src="../images/32/145.png" /><span class="left-body"><a class='hover' id="records" href='#'> 排课记录管理</a></span>

                            </div>
                            <div class="accordion-inner" id="../../users.aspx">
                                <img class="left-icon-child" src="../images/32/14.png" /><span class="left-body"><a class='hover' id="user" href='#'> 系统设置</a></span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="span10 content-right" id="mainDiv"  style="height:auto;float:right;width:84%;height:100%">

                <!-- <iframe src="Index2.html" class="iframe"></iframe>-->
            </div>
            
        </div>
    </div>
   <%-- <div class="clearfix"></div>
    <div class="foot">
        底部   简介
    </div>--%>
    <script src="../scripts/jquery-1.9.1.min.js"></script>
    <script src="../bootstrap2.3.2/js/bootstrap.min.js"></script>
    <script src="../scripts/Index.js"></script>
</body>
</html>
