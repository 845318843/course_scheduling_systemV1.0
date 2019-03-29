$(function () {
    $(".content-left,.content-right").height($(window).height() - 130);
})
$(".accordion-inner").click(function () {
    $(".active").html($(this).find(".left-body").text());
})

$(window).resize(function () {
    $(".content-left,.content-right").height($(window).height() - 130);
})