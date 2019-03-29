$(function () {
    loadAllC();
    $("#add").click(function(){
        add();
    })
    $("#reset").click(function () {
        reset();
    })
})
function reset() {
    if (confirm("您将重置所有实验室管理员任务完成情况？")) {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/reset",
            dataType: "json",
            async: false,
            success: function (result) {
                alert("任务完成情况已重置！");
                loadAllC();
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
}
function add() {
    layer.open({
        type: 2,
        title: '添加',
        shadeClose: true,
        shade: 0.5,
        area: ['300px', '50%'],
        content: '../../userAdd.aspx',
        end: function () {
            loadAllC();
        }
    });
}
function updates(id) {
    sessionStorage["userID"]=id;
    layer.open({
        type: 2,
        title: '编辑',
        shadeClose: true,
        shade: 0.5,
        area: ['300px', '50%'],
        content: '../../userChg.aspx',
        end: function () {
            loadAllC();
        }
    });
}
function loadAllC() {
    var htmltxt = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/userService.asmx/findAll",
        dataType: "json",
        async: false,
        success: function (result) {
            var res = eval(result.d);
            htmltxt = "<div class=\"span12\" style='padding:8px'><table class=\"table table-condensed table-bordered table-hover tab\">  <thead> <tr><th>序号</th><th>用户名</th><th>密码</th><th>角色</th><th>描述</th><th>任务完成情况</th><th>操作</th></tr> </thead><tbody id=\"tbody\">";
            $.each(res, function (i, d) {
                var n = i;
                var no = n + 1;
                htmltxt += " <tr><td>" + no + "</td><td>" + d.用户名 + "</td><td>" + d.密码 + "</td><td>" + d.角色 + "</td><td>" + d.描述 + "</td><td>" + d.备注1 + "</td><td> <span style=''><input type='button' class=\"btn btn-success\"  value='编辑' onclick='updates(" + d.主键 + ");' /></span></td></tr>";
            });
            htmltxt += "</tbody></table></div>";
            $("#contents").html(htmltxt);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}
function update(name, pwd, role, des, id,mission) {
    var b = "不";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/userService.asmx/judgeRepeat",
        data: '{"name":"' + name + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            b = result.d;
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
    if (b != "重复") {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/update",
            data: '{"name":"' + name + '","pwd":"' + pwd + '","role":"' + role + '","des":"' + des + '","id":"' + id + '","mission":"' + mission + '"}',
            dataType: "json",
            async: false,
            success: function (result) {
                alert("修改成功！");
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
    else
        alert("该用户名已存在，请重新输入！");
}
function insert(name, pwd, role, des) {
    var b = "不";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/userService.asmx/judgeRepeat",
        data: '{"name":"' + name + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            b = result.d;
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });

    if (b != "重复") {
        var htmltxt = "";
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/insert",
            data: '{"name":"' + name + '","pwd":"' + pwd + '","role":"' + role + '","des":"' + des + '"}',
            dataType: "json",
            async: false,
            success: function (result) {
                alert("添加成功！");
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
    else
        alert("该用户名已存在，请重新输入！");

}
function del(id) {
    //alert("12");
    //if (comfirm('您确定删除这条记录吗？'))
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/userService.asmx/delete",
        data: '{"id":"' + id + '"}',
        dataType: "json",
        async: false,
        success: function (result) {
            loadAllC();
            alert("删除成功！");
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}