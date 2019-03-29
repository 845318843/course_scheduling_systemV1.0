$(function () {
    loadLabNo();
    $("#find").click(function () {
        //alert("12");
        var co = $("#courses").val();
        var classs = $("#classs").val();
        var tea = $("#teacher").val();
        var lab = $("#labNo").val();
        if (lab == "所有实验室")
            lab = "";
        var sec1 = sessionStorage["sec1"];
        var sec2 = sessionStorage["sec2"];
        var sec3 = sessionStorage["sec3"];
        var sec4 = sessionStorage["sec4"];
        var sec5 = sessionStorage["sec5"];
        var week = sessionStorage["weekss"];
        loadAllC(co, classs, tea, lab, week, sec1, sec2, sec3, sec4, sec5);
        sessionStorage["weekss"] = "undefined";
        sessionStorage["sec1"] = "undefined";
        sessionStorage["sec2"] = "undefined";
        sessionStorage["sec3"] = "undefined";
        sessionStorage["sec4"] = "undefined";
        sessionStorage["sec5"] = "undefined";
    })
    $("#sec").click(function () {
        layer.open({
            type: 2,
            title: '节次选择',
            shadeClose: true,
            shade: 0.5,
            area: ['450px', '30%'],
            content: '../../sec.aspx',
            end: function () {

            }
        });
    })

    $("#week").click(function () {
        layer.open({
            type: 2,
            title: '周次选择',
            shadeClose: true,
            shade: 0.5,
            area: ['450px', '30%'],
            content: '../../week.aspx',
            end: function () {

            }
        });
    })
})
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
function loadAllC(courseName, classs, tea, lab, week, sec1, sec2, sec3, sec4, sec5) {
    var htmltxt = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/recordsService.asmx/recordDemo",
        data: '{"courseName":"' + courseName + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","week":"' + week + '","sec1":"' + sec1 + '","sec2":"' + sec2 + '","sec3":"' + sec3 + '","sec4":"' + sec4 + '","sec5":"' + sec5 + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.d != '') {
                var res = eval(result.d);
                htmltxt = "<div class=\"span12\" style='padding:8px'><table class=\"table table-condensed table-bordered table-hover tab\">  <thead> <tr><th>序号</th><th>课程</th><th>班级</th><th>教师</th><th>项目名称</th><th>是否综合性</th><th>周次</th><th>星期</th><th>节次</th><th>人数</th><th>组别</th><th>实验室</th></tr> </thead><tbody id=\"tbody\">";
                $.each(res, function (i, d) {
                    //alert(result.d);
                    var k = d.detailid;
                    var cid = d.courseid;
                    var n = i;
                    var no = n + 1;
                    htmltxt += " <tr><td>" + no + "</td><td>" + d.课程 + "</td><td>" + d.班级 + "</td><td>" + d.教师 + "</td><td>" + d.项目名称 + "</td><td>" + d.是否综合性 + "</td><td>" + d.周次 + "</td><td>" + d.星期 + "</td><td>" + d.节次 + "</td><td>" + d.人数 + "</td><td>" + d.组别 + "</td><td>" + d.实验室 + "</td></tr>";
                });
                htmltxt += "</tbody></table></div>";
                $("#contents").html(htmltxt);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}




