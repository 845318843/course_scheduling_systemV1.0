$(function () {
    load();
    $("input").click(function () {
        var no = $(this).attr("name");
        //alert(no);
        var type = "section";
        var num = sessionStorage["courseID"];
        var user = sessionStorage["user"];
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
function load() {
    var no = "section";
    $.ajax(
{
    type: "post",
    url: "../../webService/labCourseService.asmx/findSec",
    data: '{"type":"' + no + '"}',
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