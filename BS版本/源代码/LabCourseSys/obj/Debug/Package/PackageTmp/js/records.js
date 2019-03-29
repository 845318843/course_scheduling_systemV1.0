var co, classs, tea, lab, user, process = "";
$(function () {
    loadLabNo();
    $("#find").click(function () {
        fresh();
    })
    $("#weekCourse").click(function () {
        wordProcess();
        if (process == "未运行")
            weekCourse();
        else
            layer.alert('当前word文档生成通道被占用，请稍等片刻后重试！', {
                skin: 'layui-layer-lan'
                  , closeBtn: 0
                  , anim: 4 //动画类型
            });
    })
    $("#design").click(function () {
        wordProcess();
        if (process == "未运行")
            design();
        else
            layer.alert('当前word文档生成通道被占用，请稍等片刻后重试！', {
                skin: 'layui-layer-lan'
                             , closeBtn: 0
                             , anim: 4 //动画类型
            });
    })
    $("#send").click(function () {
        send();
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
function fresh() {
    co = $("#courses").val();
    classs = $("#classs").val();
    tea = $("#teacher").val();
    lab = $("#labNo").val();
    //alert(tea);
    //alert(lab);
    if (lab == "所有实验室")
        lab = "";
    user = sessionStorage["user"];
    loadAllC(co, classs, tea, lab, user);
}
function send() {
    var name = sessionStorage["user"];
    layer.confirm('您将会把排课完成情况提交给系统管理员！提交后将不能修改，是否提交？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/updateMission",
            data: '{"name":"' + name + '"}',
            dataType: "json",
            async: false,
            success: function (result) {
                layer.alert('信息成功提交！', {
                    skin: 'layui-layer-lan'
                    , closeBtn: 0
                    , anim: 4 //动画类型
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }, function () {

    });
}
function design() {
    var user = "user000";
    co = $("#courses").val();
    classs = $("#classs").val();
    tea = $("#teacher").val();
    lab = $("#labNo").val();
    if (lab == "所有实验室")
        lab = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/recordsService.asmx/findCourseDesign",
        data: '{"courseName":"' + co + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","user":"' + user + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            //alert(生成成功！);
            //alert("课程设计汇总生成成功！");

        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}
function weekCourse() {
    var user = "user000";
    co = $("#courses").val();
    classs = $("#classs").val();
    tea = $("#teacher").val();
    lab = $("#labNo").val();
    if (lab == "所有实验室" && (co == "" && classs == "" && tea == ""))
        layer.alert('请先选择需要生成周课表的实验室！', {
            skin: 'layui-layer-lan'
                  , closeBtn: 0
                  , anim: 4 //动画类型
        });
    else {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/recordsService.asmx/weekCourse",
            data: '{"courseName":"' + co + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","user":"' + user + '"}',
            dataType: "json",
            async: false,
            success: function (result) {
                //fresh();
                //Showbo.Msg.alert("当前周课表文档生成成功！");
                //alert("当前周课表文档生成成功！");
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
}
function loadAllC(courseName, classs, tea, lab, user) {
    var htmltxt = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/recordsService.asmx/findBy",
        data: '{"courseName":"' + courseName + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","user":"' + user + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.d != '') {
                var res = eval(result.d);
                htmltxt = "<div class=\"span12\" style='padding:8px'><table class=\"table table-condensed table-bordered table-hover tab\">  <thead> <tr><th>序号</th><th>课程</th><th>班级</th><th>教师</th><th>项目名称</th><th>是否综合性</th><th>周次</th><th>星期</th><th>节次</th><th>人数</th><th>组别</th><th>实验室</th><th>操作</th></tr> </thead><tbody id=\"tbody\">";
                $.each(res, function (i, d) {
                    //alert(result.d);
                    var k = d.detailid;
                    var cid = d.courseid;
                    var n = i;
                    var no = n + 1;
                    htmltxt += " <tr><td>" + no + "</td><td>" + d.课程 + "</td><td>" + d.班级 + "</td><td>" + d.教师 + "</td><td>" + d.项目名称 + "</td><td>" + d.是否综合性 + "</td><td>" + d.周次 + "</td><td>" + d.星期 + "</td><td>" + d.节次 + "</td><td>" + d.人数 + "</td><td>" + d.组别 + "</td><td>" + d.实验室 + "</td><td> <span style=''><input type='button' class=\"btn btn-success\"  value='编辑' onclick='plan(" + k + "," + cid + ");' /></span></td></tr>";
                });
                htmltxt += "</tbody></table></div>";
                $("#contents").html(htmltxt);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function loadLabNo() {
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/labInfoService.asmx/findAll",
        //data: '{"courseName":"' + courseName + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","user":"' + user + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.d != '') {
                var res = eval(result.d);
                $.each(res, function (i, d) {
                    $("#labNo").append("<option value='" + d.名称 + "'>" + d.名称 + "</option>");
                });

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}
function plan(detailid, cid) {
    sessionStorage["detail"] = detailid;
    sessionStorage["cid"] = cid;
    layer.open({
        type: 2,
        title: '编辑',
        shadeClose: true,
        shade: 0.5,
        area: ['450px', '50%'],
        content: '../../chgDetail.aspx',
        end: function () {
            fresh();
        }
    });
}