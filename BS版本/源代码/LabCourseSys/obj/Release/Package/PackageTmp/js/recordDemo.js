$(function () {

    $("#find").click(function () {
        //alert("12");
        var co = $("#course").val();
        var classs = $("#class").val();
        var tea = $("#tea").val();
        var lab = $("#labNo").val();
        var sec = sessionStorage["secss"];
        var week = sessionStorage["weekss"];
        loadAllC(co, classs, tea, lab, week, sec);
        sessionStorage["secss"] = "undefined";
        sessionStorage["weekss"] = "undefined";
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

function loadAllC(courseName, classs, tea, lab, week, sec) {
    var htmltxt = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/recordsService.asmx/recordDemo",
        data: '{"courseName":"' + courseName + '","classs":"' + classs + '","tea":"' + tea + '","lab":"' + lab + '","week":"' + week + '","sec":"' + sec + '"}',
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




