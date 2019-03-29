//$(function () {
//    //var user = sessionStorage["user"];
//    ////alert(user);
//    //$("#divv").load("<img src=\"../images/32/client.png\" />&nbsp;&nbsp;欢迎您," + user + "");
//    //$("div").click(function () {
//    //    var page = $(this).attr("id");
//    //    $("#mainDiv").load(page);
//    //});

//})
$(function () {
    var user = sessionStorage["user"];
    if (typeof(user) == "undefined") {
        location.href = "../../login.html";
    }
    $("#divv").html("<img src=\"../images/32/client.png\" />&nbsp;&nbsp;欢迎您," + user + "");
    var role = sessionStorage["role"];
    $("div").click(function () {
        var page = $(this).attr("id");
        if (role == "管理员") {
            if (page == "../../lab.aspx" || page == "../../users.aspx")
                window.location.href = "../../mains/views/index.aspx";
            else
                $("#mainDiv").load(page);
        }
        else
            $("#mainDiv").load(page);
    });
    $("#pwd").click(function () {
        layer.open({
            type: 2,
            title: '修改用户密码',
            shadeClose: true,
            shade: 0.5,
            area: ['20%', '30%'],
            content: '../../chgPWD.aspx',
            end: function () {
                fresh();
            }
        });
    });
})

