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
})
