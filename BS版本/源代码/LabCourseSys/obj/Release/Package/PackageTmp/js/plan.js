var ad = "";
var sec = "";
var week = "";
var courseid = "";
var data = new Array();
var weeks = new Array();
var secs = new Array();
var days = new Array();
$(function () {
    fresh();
    var id = sessionStorage["labID"];
    //getone(id);
    $("#section").click(function () {
        ad = sessionStorage["courseID"];
        if (ad != null) {
            layer.open({
                type: 2,
                title: '节次选择',
                shadeClose: true,
                shade: 0.5,
                area: ['450px', '55%'],
                content: '../../section.aspx',
                end: function () {
                    sessionStorage["sec"] = "1";
                }
            });
        }
        else
           alert('请先添加课程基本信息！');
    });
    $("#week").click(function () {
        sec = sessionStorage["sec"];
        if (sec == "1") {
            layer.open({
                type: 2,
                title: '周次选择',
                shadeClose: true,
                shade: 0.5,
                area: ['450px', '55%'],
                content: '../../weeks.aspx',
                end: function () {
                    loadMain();
                    checkRa();
                    sessionStorage["week"] = "1";
                }
            });
        }
        else
            alert('请先选择节次！');
    });
    $("#adds").click(function () {
        var r = confirm("确认是否添加？添加成功后将不能修改！");
        if (r == true) {
            var course = $("#course").val();
            var classs = $("#classs").val();
            var tea = $("#teacher").val();
            var count = parseInt($("#count").val());
            var n = parseInt(sessionStorage["num"]);
            var num = $("#num").val();
            var labNo = sessionStorage["labID"];
            var lab = sessionStorage["lab"];
            if (count > n)
                alert("超过实验室可容纳人数上限！");
            else if (course == '' || classs == '' || tea == '')
               alert("有必填项为空,请重新核对！")
            else {
                add(course, classs, tea, count, num, lab, labNo, 0);
                $("#adds").attr('disabled', 'false');
            }
        }
    })
    $("#addss").click(function () {
        var r = confirm("确认是否添加？添加成功后将不能修改！");
        if (r == true) {
            var course = $("#course").val();
            var classs = $("#classs").val();
            var tea = $("#teacher").val();
            var count = parseInt($("#count").val());
            var n = parseInt(sessionStorage["num"]);
            var num = $("#num").val();
            var labNo = sessionStorage["labID"];
            var lab = sessionStorage["lab"];
            if (count > n)
                alert("超过实验室可容纳人数上限！");
            else if (course == '' || classs == '' || tea == '')
                alert("有必填项为空,请重新核对！")
            else {
                add(course, classs, tea, count, num, lab, labNo, 1);
                $("#addss").attr('disabled', 'false');
            }
        }
    })

})
function checkRa() {
    for (var i = 0; i < data.length; i++) {
        $("#rd" + data[i] + "2").attr('checked', 'true');
    }
}
function flag() {
    var f = sessionStorage["flag"];
    var ff = parseInt(f);
    var parent = sessionStorage["courseID"];
    var sec = "section";
    var user = sessionStorage["user"];
    if (f != '') {
        $.ajax(
        {
            type: "post",
            url: "../../webService/labCourseService.asmx/function",
            contentType: "application/json; charset=utf-8",
            data: '{"no":"' + ff + '","type":"' + sec + '","num":"' + parent + '","user":"' + user + '"}',
            dataType: "json",
            async: false,
            success: function (result) {

            },
            error: function (err) {

            }
        });
    }
}
function fresh() {
    $.ajax(
     {
         type: "post",
         url: "../../webService/labCourseService.asmx/fresh",
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         async: false,
         success: function (result) {

         },
         error: function (err) {

         }
     });
}
function updates(week, day, section, id) {
    var cour = sessionStorage["courseID"];
    var name = $("#name" + id + "").val();
    var Is = "0";
    if ($("#rd" + id + "1").is(':checked')) {
        Is = "1";
    }
    $.ajax(
   {
    type: "post",
    url: "../../webService/labCourseService.asmx/insertDetail",
    data: '{"project":"' + name + '","Is":"' + Is + '","week":"' + week + '","day":"' + day + '","section":"' + section + '","courseID":"' + cour + '"}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    async: false,
    success: function (result) {
        //$("#btt" + id + "").attr('disabled', 'false');

    },
    error: function (err) {

    }
});
}


function updatess(week, day, section) {
    var cour = sessionStorage["courseID"];
    var name = " ";
    var Is = "0";
    $.ajax(
   {
       type: "post",
       url: "../../webService/labCourseService.asmx/insertDetail",
       data: '{"project":"' + name + '","Is":"' + Is + '","week":"' + week + '","day":"' + day + '","section":"' + section + '","courseID":"' + cour + '"}',
       contentType: "application/json; charset=utf-8",
       dataType: "json",
       async: false,
       success: function (result) {
           //$("#btt" + id + "").attr('disabled', 'false');

       },
       error: function (err) {

       }
   });
}

function loadMain() {
    var num = sessionStorage["courseID"];
    $.ajax(
      {
          type: "post",
          url: "../../webService/labCourseService.asmx/findFunction",
          data: '{"num":"' + num + '"}',
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          async: false,
          success: function (result) {
              var res = eval(result.d);
              htmltxt = "<table><thead><tr><th>项目名称</th> <th>是否是综合性，设计性项目</th><th>周次</th><th>星期</th><th>节次</th></tr></thead>";
              $.each(res, function (i, d) {
                  var s = d.id;
                  data[i] = s;
                  weeks[i] = d.周次;
                  secs[i] = d.节次;
                  days[i] = d.星期;
                  htmltxt += "<tr><td><input type='text' id='name" + s + "'style='width:90%;height:100%' /></td>";
                  htmltxt += "<td>是<input type='radio'  id='rd" + s + "1' name='ra"+s+"' />  否<input type='radio' name='ra"+s+"'  id='rd" + s + "2'  /></td>";
                  htmltxt += "<td>" + d.周次 + "</td>";
                  htmltxt += "<td> " + d.星期 + "</td>";
                  htmltxt += "<td> " + d.节次 + "</td>";
                  //htmltxt += "<td><input type='button'id='btt" + s + "'  value='添加' onclick='updates(\"" + d.周次 + "\",\"" + d.星期 + "\",\"" + d.节次 + "\"," + s + ");'  />";
                  htmltxt += "</tr>";
              });
              htmltxt += "<tr><td colspan='5'><div style='float:right'><input type=\"button\" name='insertall' onclick='f()'  value=\"批量添加\" id=\"insertAll\" class=\"button blue\" /></div></td></tr>";
              htmltxt += "</table>";
              $("#contents").html(htmltxt);
          },
          error: function (err) {

          }
      }
      );
}
function loadMains() {
    var num = sessionStorage["courseID"];
    $.ajax(
      {
          type: "post",
          url: "../../webService/labCourseService.asmx/findFunction",
          data: '{"num":"' + num + '"}',
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          async: false,
          success: function (result) {
              $.each(res, function (i, d) {
                  weeks[i] = d.周次;
                  secs[i] = d.节次;
                  days[i] = d.星期;
              });
          },
          error: function (err) {

          }
      }
      );
}
function f() {
    for (var i = 0; i < days.length; i++) {
        updates(weeks[i], days[i], secs[i], data[i]);
    }
    //alert("112");
    alert("操作成功！");
    $("#insertAll").attr('disabled', 'false');
    sessionStorage["num"] = null;
    sessionStorage["sec"] = "2";
    sessionStorage["week"] = "2";
}
function add(course, classs, teacher, count, num, lab, labNo, ff) {
    var person =sessionStorage["user"];
    $.ajax(
  {
      type: "post",
      url: "../../webService/labCourseService.asmx/insert",
      data: '{"course":"' + course + '","classs":"' + classs + '","teacher":"' + teacher + '","count":"' + count + '","num":"' + num + '","lab":"' + lab + '","labNo":"' + labNo + '","person":"' + person + '"}',
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      async: false,
      success: function (result) {
          var res = eval(result.d);
          courseid = res;
          sessionStorage["courseID"] = res;
          fresh();
          if(ff==1)
          flag();
          alert("操作成功！");
      },
      error: function (err) {

      }
  });
}
