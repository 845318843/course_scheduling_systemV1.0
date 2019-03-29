<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="browseRecords.aspx.cs" Inherits="LabCourseSys.mains.Views.browseRecords" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="../../js/jquery-1.9.1.min.js" type="text/javascript"></script>
   <%-- <script src="../../js/main.js" type="text/javascript"></script>--%>
    <script src="../../layer/layer.min.js" type="text/javascript"></script>
    <link href="../bootstrap2.3.2/css/bootstrap.min.css" rel="stylesheet" />
    <title>计算机学院实验室排课记录查询系统</title>
    <link href="../styles/Common.css" rel="stylesheet" />
    <link href="../styles/Index.css" rel="stylesheet" />
     <script type="text/javascript">
         $(function () {
             $("#mainDiv").load("../../recordDemo.aspx");
         })
    </script>
</head>
<body>
    <div class="header">
        <img class="logo" src="../images/logo.png" />
        <label class="logo-title" style="text-align:left">计算机学院实验室排课记录查询系统</label>
        <ul class="inline">
            <li>
                <div id="divv"> <img src="../images/32/client.png" />&nbsp;&nbsp;欢迎您使用！</div>
            </li>
             <li>
                <img src="../images/32/200.png" />&nbsp;&nbsp;<a class="loginout" href="../../login.html">返回登录页面</a>
            </li>
        </ul>
    </div>
    <div class="nav">
    </div>
    <div class="container-fluid content">
        <div class="row-fluid" style="height:100%">

            <div class="span10 content-right" id="mainDiv"  style="height:auto;float:none;width:100%;height:100%">

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

