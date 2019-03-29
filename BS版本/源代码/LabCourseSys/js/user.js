$(function () {
    loadAllC();
    $("#add").click(function () {
        add();
    })
    $("#reset").click(function () {
        reset();
    })
    $("#clear").click(function () {
        clear();
    })

    $("#reback").click(function () {
        reback();
    })
    $("#wordProcess").click(function () {
        wordProcess();
    })
})


function wordProcess() {
    layer.confirm('是否确认重启word文档生成通道,该操作将会中断当前用户正在操作生成word文档！', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/closeWordProcess",
            dataType: "json",
            async: false,
            success: function (result) {
                layer.alert('重启成功！', {
                    skin: 'layui-layer-lan'
              , closeBtn: 0
              , anim: 4 //动画类型
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }, function () {

    });
}
function reback() {
    layer.confirm('是否确认还原数据库？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/reBack",
            dataType: "json",
            async: false,
            success: function (result) {
                layer.alert('已成功还原数据！', {
                    skin: 'layui-layer-lan'
              , closeBtn: 0
              , anim: 4 //动画类型
                });
                loadAllC();
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }, function () {

    });
}
function f() {
    layer.confirm('是否确认备份数据库？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/backUp",
            dataType: "json",
            async: false,
            success: function (result) {
                layer.alert('已成功备份数据！', {
                    skin: 'layui-layer-lan'
              , closeBtn: 0
              , anim: 4 //动画类型
                });
                loadAllC();
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }, function () {

    });
}
function clear() {
    layer.confirm('是否确认清除所有已添加的课程记录？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/clear",
            dataType: "json",
            async: false,
            success: function (result) {
                layer.alert('已清除成功！', {
                    skin: 'layui-layer-lan'
              , closeBtn: 0
              , anim: 4 //动画类型
                });
                loadAllC();
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }, function () {

    });
}
function reset() {
    layer.confirm('您将重置所有实验室管理员任务完成情况为未完成？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "../../webService/userService.asmx/reset",
            dataType: "json",
            async: false,
            success: function (result) {


                layer.alert('任务完成情况已重置！', {
                    skin: 'layui-layer-lan'
              , closeBtn: 0
              , anim: 4 //动画类型
                });
                loadAllC();
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }, function () {

    });
}
function add() {
    layer.open({
        type: 2,
        title: '添加',
        shadeClose: true,
        shade: 0.5,
        area: ['20%', '50%'],
        content: '../../userAdd.aspx',
        end: function () {
            loadAllC();
        }
    });
}
function updates(id) {
    sessionStorage["userID"] = id;
    layer.open({
        type: 2,
        title: '编辑',
        shadeClose: true,
        shade: 0.5,
        area: ['20%', '50%'],
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
//判断是否有汉字
function chkstrlen(str) {
    var strlen = 0;
    for (var i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) > 255) //如果是汉字，则字符串长度加2
            strlen += 2;
        else
            strlen++;
    }
    if (str.length != strlen)
        return false;
    else
        return true;
}
function update(name, pwd, role, des, id, mission) {
    if (chkstrlen(name) && chkstrlen(pwd)) {
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
                    layer.alert('修改成功！', {
                        skin: 'layui-layer-lan'
              , closeBtn: 0
              , anim: 4 //动画类型
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {

                }
            });
        }
        else
            layer.alert('该用户名已存在，请重新输入！', {
                skin: 'layui-layer-lan'
           , closeBtn: 0
               , anim: 4 //动画类型
            });
    }
    else {
        layer.alert('用户名和密码不能有非法字符！', {
            skin: 'layui-layer-lan'
         , closeBtn: 0
             , anim: 4 //动画类型
        });
    }
}
function insert(name, pwd, role, des) {
    if (chkstrlen(name) && chkstrlen(pwd)) {
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
                    layer.alert('添加成功！', {
                        skin: 'layui-layer-lan'
                       , closeBtn: 0
                        , anim: 4 //动画类型
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {

                }
            });
        }
        else
            layer.alert('该用户名已存在，请重新输入！', {
                skin: 'layui-layer-lan'
                      , closeBtn: 0
                       , anim: 4 //动画类型
            });
    }
    else
        layer.alert('用户名和密码不能有非法字符！', {
            skin: 'layui-layer-lan'
 , closeBtn: 0
     , anim: 4 //动画类型
        });

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
            layer.alert('删除成功！', {
                skin: 'layui-layer-lan'
          , closeBtn: 0
           , anim: 4 //动画类型
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}