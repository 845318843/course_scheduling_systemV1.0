$(function () {
    load(1);
    //$("#files").hide();
    $("#close").click(function () {
        close();
    });
    $("#create").click(function () {
        //alert("coes");
        crateT();
    });
})

var labName = "";
var labNo = "";
var no = 0;
function crateT() {
    labName = sessionStorage["lab"];
    labNo = sessionStorage["labID"];
    var h = "", t = "";
    $.ajax(
    {
        type: "post",
        url: "webService/labCourseService.asmx/createT",
        data: '{"labNo":"' + labNo + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            alert("当前课表文档生成成功！");
        },
        error: function (err) {

        }
    });
}
function load(b) {
    labName = sessionStorage["lab"];
    labNo = sessionStorage["labID"];
    var h = "", t = "";
    $.ajax(
  {
      type: "post",
      url: "webService/labCourseService.asmx/createCourse",
      data: '{"labNo":"' + labNo + '"}',
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      async: false,
      success: function (result) {
          var res = eval(result.d);
          no = 0;
          htmltxt = "<table style='width:100%' id=tbmain><thead><tr>";
          htmltxt += " <th></th><th>星期一</th><th>星期二</th><th>星期三</th><th>星期四</th><th>星期五</th><th>星期六</th><th>星期日</th>";
          htmltxt += "  </tr></thead>";
          $.each(res, function (i, d) {
              if (i < 5) {
                  if (i == 0)
                      h = "1.2";
                  else if (i == 1)
                      h = "3.4";
                  else if (i == 2)
                      h = "5.6";
                  else if (i == 3)
                      h = "7.8";
                  else
                      h = "9.10";
                  htmltxt += "<tr><td style='width:6%'>" + h + "</td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "'>" + d.一 + "<br></td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "'>" + d.二 + "</td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "'> " + d.三 + "</td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "'> " + d.四 + "</td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "'> " + d.五 + "</td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "'> " + d.六 + "</td>";
                  no++;
                  htmltxt += "<td style='width:12%' onclick='plan(" + no + ")' id='" + no + "' height=\"100px\"> " + d.日 + "</td>";
                  htmltxt += "</tr>";
              }
              else
                  t = d.一;
          });
          htmltxt += "</table>";
          var html = "" + t + " <a href='../file/课表.doc' id='files' aria-disabled=\"false\" ><font style=\"color:blue;font-size:15px;float:right\">导出当前课表</font></a>  <input id=\"create\" style='float:right' value='生成课表' type='button'/>";
          if(b==1)
              $("#tit").html(html);

          $("#contents").html(htmltxt);
      },
      error: function (err) {

      }
  }
  );
}
function plan(no) {
    sessionStorage["flag"] = no;
    var la = sessionStorage["lab"];
    layer.open({
        type: 2,
        title: la+'排课',
        shadeClose: true,
        shade: 0.5,
        area: ['90%', '90%'],
        content: '../../labPlans.aspx',
        end: function () {
            fresh();
            load(0);
        }
    });
}
function fresh() {
    var user=sessionStorage["user"];
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
   }
   );
}
