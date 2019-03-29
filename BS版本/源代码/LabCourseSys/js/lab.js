$(function () {
    loadAllC();
});
function addNewLab() {
    layer.open({
        type: 2,
        title: '添加',
        shadeClose: true,
        shade: 0.5,
        area: ['450px', '58%'],
        content: '../../labAdd.aspx',
        end: function () {
            $("#mainDiv").load("../../lab.aspx");
        }
    });
}
function edit(id) {
    sessionStorage["labID"] = id;
    layer.open({
        type: 2,
        title: '编辑',
        shadeClose: true,
        shade: 0.5,
        area: ['450px', '58%'],
        content: '../../labUpdate.aspx',
        end: function () {
            $("#mainDiv").load("../../lab.aspx");
        }
    });
}
function getone(id) {
    $.ajax(
    {
        type: "post",
        url: "../../webService/labInfoService.asmx/getone",
        data: '{"id":"' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            var res = eval(result.d);
            $.each(res, function (i, d) {
                //alert(d.remark2);
                $("#labName").val(d.remark2);
                $("#name").val(d.name);
                sessionStorage["thisName"] = d.name;
                $("#count").val(d.count);
                $("#des").val(d.describe);
                $("#user option[value='" + d.remark3 + "']").attr("selected", true);
            });
        },
        error: function (err) {

        }
    });
}
function state(id) {
    $.ajax(
    {
        type: "post",
        url: "../../webService/labInfoService.asmx/state",
        data: '{"id":"' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "text",
        async: false,
        success: function (result) {
            $("#mainDiv").load("../../lab.aspx");
        },
        error: function (err) {

        }
    }
    );
}

function loadAllC() {
    var htmltxt = "";
    $.ajax({
        type: "post",
        contentType: "application/json",
        url: "../../webService/labInfoService.asmx/findAll",
        dataType: "json",
        async: false,
        success: function (result) {
            var res = eval(result.d);
            var state;
            var flag;
            htmltxt = " <div class=\"span12\" style='padding:8px'><table class=\"table table-condensed table-bordered table-hover tab\">  <thead><tr ><th>序号</th><th>实验室名称</th><th>实验室门标</th><th>可容纳人数</th><th>简介</th><th>管理员</th><th>状态</th><th>操作</th></tr> </thead><tbody id=\"tbody\">";
            $.each(res, function (i, d) {
                var n = i;
                var no = n + 1;
                if (d.备注1 == "1") {
                    state = "启用";
                    flag = "关闭";
                }
                else {
                    state = "关闭";
                    flag = "启用";
                }
                htmltxt += " <tr><td>" + no + "</td><td>" + d.备注2 + "</td><td>" + d.名称 + "</td><td>" + d.容纳人数 + "</td><td>" + d.简介 + "</td><td>" + d.备注3 + "</td> <td>" + state + "</td><td> <span ><input type='button' class=\"btn btn-success\"  value='编辑' onclick='edit(" + d.主键 + ");' /></span><span style=''><input type='button' class=\"btn btn-success\"  value='" + flag + "' onclick='state(" + d.主键 + ");' /></span></td></tr>";
            });
            htmltxt += "</tbody></table></div>";
            $("#contents").html(htmltxt);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR + textStatus + errorThrown);
        }
    });
}

function insert() {
    var labName = $("#labName").val();
    var name = $("#name").val();
    var count = $("#count").val();
    var des = $("#des").val();
    var user = $("#user").val();
    var re = "";
    $.ajax(
        {
            type: "post",
            url: "../../webService/labInfoService.asmx/ReLabNo",
            data: '{"no":"' + name + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                re = result.d;
            },
            error: function (err) {

            }
        });
    if (re == "不重复") {

        if (/^\d+$/.test(name) && /^\d+$/.test(count)) {
            $.ajax(
             {
                 type: "post",
                 url: "../../webService/labInfoService.asmx/insert",
                 data: '{"labName":"' + labName + '","name":"' + name + '","count":"' + count + '","des":"' + des + '","user":"' + user + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "text",
                 async: false,
                 success: function (result) {
                     layer.alert('操作成功！', {
                         skin: 'layui-layer-lan'
                                , closeBtn: 0
                                , anim: 4 //动画类型
                     });
                 },
                 error: function (err) {

                 }
             }
             );
        }
        else
            layer.alert('存在非法字符！门标和容纳量必须为数字。', {
                skin: 'layui-layer-lan'
                               , closeBtn: 0
                               , anim: 4 //动画类型
            });
    }
    else
        layer.alert('该实验室门标已经存在！', {
            skin: 'layui-layer-lan'
                         , closeBtn: 0
                         , anim: 4 //动画类型
        });
}
function update(id) {
    var name = $("#name").val();
    var count = $("#count").val();
    var des = $("#des").val();
    var labName = $("#labName").val();
    var user = $("#user").val();
    var re = "";
    var thisName=sessionStorage["thisName"];
    if (thisName != name) {
        $.ajax(
            {
                type: "post",
                url: "../../webService/labInfoService.asmx/ReLabNo",
                data: '{"no":"' + name + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    re = result.d;
                },
                error: function (err) {

                }
            });
    }
    else
        re = "不重复";
    if (re == "不重复") {
        if (/^\d+$/.test(name) && /^\d+$/.test(count)) {
            $.ajax(
             {
                 type: "post",
                 url: "../../webService/labInfoService.asmx/update",
                 data: '{"labName":"' + labName + '","id":"' + id + '","name":"' + name + '","count":"' + count + '","des":"' + des + '","user":"' + user + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "text",
                 async: false,
                 success: function (result) {
                     layer.alert('操作成功！', {
                         skin: 'layui-layer-lan'
                                , closeBtn: 0
                                , anim: 4 //动画类型
                     });
                 },
                 error: function (err) {

                 }
             });
        }
        else
        layer.alert('存在非法字符！门标和容纳量必须为数字。', {
            skin: 'layui-layer-lan'
                            , closeBtn: 0
                            , anim: 4 //动画类型
        });
    }
    else
        layer.alert('该实验室门标已经存在！', {
            skin: 'layui-layer-lan'
                           , closeBtn: 0
                           , anim: 4 //动画类型
        });
}
function loadUser() {
    $.ajax(
          {
              type: "post",
              url: "../../webService/userService.asmx/findAll",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              async: false,
              success: function (result) {
                  var res = eval(result.d);
                  $.each(res, function (i, d) {
                      $("#user").append("<option  value='" + d.用户名 + "'>" + d.用户名 + "</option>");
                  });
              },
              error: function (err) {

              }
          });
}
function del(id) {
    layer.confirm('您确定删除这条记录吗？', {
        btn: ['确认', '取消'] //按钮
    }, function () {
        $.ajax(
         {
             type: "post",
             url: "../../webService/labInfoService.asmx/delete",
             data: '{"id":"' + id + '"}',
             contentType: "application/json; charset=utf-8",
             dataType: "text",
             async: false,
             success: function (result) {
                 layer.alert('操作成功！', {
                     skin: 'layui-layer-lan'
                      , closeBtn: 0
                      , anim: 4 //动画类型
                 });
             },
             error: function (err) {

             }
         });
    }, function () {

    });

}