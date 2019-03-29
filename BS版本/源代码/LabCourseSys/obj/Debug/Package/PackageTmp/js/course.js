var labs = "";
$(function () {
    loadAllC();
    fresh();
})
function plan(id, course, num) {
    //alert(num);
    sessionStorage["num"] = num;
    sessionStorage["lab"] = course;
    sessionStorage["labID"] = id;
    layer.open({
        type: 2,
        title: course + '排课',
        shadeClose: true,
        shade: 0.5,
        area: ['60%', '70%'],
        content: '../../labPlan.aspx',
        end: function () {
            fresh();
        }
    });
}
function CourseDesige(id, course, num) {
    sessionStorage["num"] = num;
    sessionStorage["lab"] = course;
    sessionStorage["labID"] = id;
    layer.open({
        type: 2,
        title: course + '课程设计排课',
        shadeClose: true,
        shade: 0.5,
        area: ['60%', '40%'],
        content: '../../courseDesign.aspx',
        end: function () {
            fresh();
            sessionStorage["num"] = null;
            sessionStorage["sec"] = "2";
            sessionStorage["week"] = "2";
        }
    });
}
function fresh() {
    var user = sessionStorage["user"];
    sessionStorage["courseID"] = null;
    sessionStorage["sec"] = null;
    sessionStorage["week"] = null;
    $.ajax(
     {
         type: "post",
         url: "../../webService/labCourseService.asmx/fresh",
         data: '{"user":"' + user + '"}',
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         async: false,
         success: function (result) {

         },
         error: function (err) {

         }
     });
}

function table(id, course, num) {
    sessionStorage["num"] = num;
    sessionStorage["lab"] = course;
    sessionStorage["labID"] = id;
    layer.open({
        type: 2,
        //skin: 'layui-layer-lan',
        title: course + '课表',
        fix: false,
        shadeClose: true,
        maxmin: true,
        area: ['78%', '89%'],
        content: '../../CourseTable.aspx',
        end: function () {
            //layer.tips('试试相册模块？', '#photosDemo', { tips: 1 })
        }
    });
}

function loadAllC() {
    var user = sessionStorage["user"];
    var role = new Array();
    $.ajax(
   {
       type: "post",
       url: "../../webService/labCourseService.asmx/findUserRole",
       data: '{"name":"' + user + '"}',
       contentType: "application/json; charset=utf-8",
       dataType: "json",
       async: false,
       success: function (result) {
           var res = eval(result.d);
           $.each(res, function (i, d) {
               role[i] = d.name;
           });
       },
       error: function (err) {

       }
   }
  );
    var no = 1, flag = 0;
    var htmltxt = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/labInfoService.asmx/findAll",
        dataType: "json",
        async: false,
        success: function (result) {
            var res = eval(result.d);
            htmltxt = "<div class=\"span12\" style='padding:8px'><table class=\"table table-condensed table-bordered table-hover tab\">  <thead> <tr><th>序号</th><th>实验室门标</th><th>可容纳人数</th><th>简介</th><th>操作</th></tr> </thead><tbody id=\"tbody\">";
            $.each(res, function (i, d) {
                for (var i = 0; i < role.length; i++) {
                
                    if (role[i] == d.名称) {
                        flag = 1;
                        break;
                    }
                }
                if (d.备注1 == "1" && flag == 1) {
                    htmltxt += " <tr><td>" + no + "</td><td>" + d.名称 + "</td><td>" + d.容纳人数 + "</td><td>" + d.简介 + "</td><td> <span ><input type='button' class=\"btn btn-success\"  value='查看课表' onclick='table(" + d.主键 + ",\"" + d.名称 + "\"," + d.容纳人数 + ");' /></span><span style=''><input type='button' class=\"btn btn-success\"  value='普通排课' onclick='plan(" + d.主键 + ",\"" + d.名称 + "\"," + d.容纳人数 + ");' /></span><span style=''><input type='button' class=\"btn btn-success\"  value='课程设计排课' onclick='CourseDesige(" + d.主键 + ",\"" + d.名称 + "\"," + d.容纳人数 + ");' /></span></td></tr>";
                    flag = 0;
                    no++;
                }

            });
            htmltxt += "</tbody></table></div>";

            $("#contents").html(htmltxt);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}