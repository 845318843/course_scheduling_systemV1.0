﻿$(function () {
    //得到焦点
    //$("#password").focus(function () {
    //    $("#left_hand").animate({
    //        left: "150",
    //        top: " -38"
    //    }, {
    //        step: function () {
    //            if (parseInt($("#left_hand").css("left")) > 140) {
    //                $("#left_hand").attr("class", "left_hand");
    //            }
    //        }
    //    }, 2000);
    //    $("#right_hand").animate({
    //        right: "-64",
    //        top: "-38px"
    //    }, {
    //        step: function () {
    //            if (parseInt($("#right_hand").css("right")) > -70) {
    //                $("#right_hand").attr("class", "right_hand");
    //            }
    //        }
    //    }, 2000);
    //});
    ////失去焦点
    //$("#password").blur(function () {
    //    $("#left_hand").attr("class", "initial_left_hand");
    //    $("#left_hand").attr("style", "left:100px;top:-12px;");
    //    $("#right_hand").attr("class", "initial_right_hand");
    //    $("#right_hand").attr("style", "right:-112px;top:-12px");
    //});
    $("#lo").click(function () {
        login();
    })
    $("#record").click(function () {
        window.location.href = "mains/views/browseRecords.aspx";
    })
});
function login() {
    var name = $("#name").val();
    var pwd = $("#password").val();
    //if (name == "" && pwd == "") {
    //    //跳转到查询系统页面
    //    window.location.href = "mains/views/browseRecords.aspx";
    //}
    //else {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/login",
            data: '{"name":"' + name + '","pwd":"' + pwd + '"}',
            dataType: "json",
            async: false,
            success: function (result) {
                sessionStorage["role"] = result.d;
                //alert(result.d);
                if (result.d != "用户名与密码不匹配") {
                    sessionStorage["user"] = name;
                    window.location.href = "mains/views/index.aspx";
                }
                else
                    alert("用户名和密码不匹配，请重新核对！");
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    //}
}