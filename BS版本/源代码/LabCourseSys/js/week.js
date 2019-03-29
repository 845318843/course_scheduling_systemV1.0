$(function () {
    load();
    state();
    $("input").click(function () {
        var no = $(this).attr("name");
        var type = "week";
        var num = sessionStorage["courseID"];
        var user=sessionStorage["user"];
        $.ajax(
       {
           type: "post",
           url: "../../webService/labCourseService.asmx/function",
           data: '{"no":"' + no + '","type":"' + type + '","num":"' + num + '","user":"' + user + '"}',
           contentType: "application/json; charset=utf-8",
           dataType: "json",
           async: false,
           success: function (result) {

           },
           error: function (err) {

           }
       });
    });
})
function state() {
    var no = sessionStorage["labID"];
    $.ajax(
{
    type: "post",
    url: "../../webService/labCourseService.asmx/findRecord",
    data: '{"labNo":"' + no + '"}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    async: false,
    success: function (result) {
        var res = eval(result.d);
        $.each(res, function (i, d) {
            $("[name = '" + d.week + "']:checkbox").attr("disabled", true);
        })
    },
    error: function (err) {

    }
});
}
function load() {
    var type = "week";
    $.ajax(
{
    type: "post",
    url: "../../webService/labCourseService.asmx/findSec",
    data: '{"type":"' + type + '"}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    async: false,
    success: function (result) {
        var res = eval(result.d);
        $.each(res, function (i, d) {
            $("[name = '" + d.no + "']:checkbox").attr("checked", true);
        })
    },
    error: function (err) {

    }
});
}