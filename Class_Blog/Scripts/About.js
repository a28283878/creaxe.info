$(function () {
    $(".close").click(function () {
        $("#teacher-detail").fadeOut(500);
        $(".teacher-detail-container").fadeOut(500);
    });
    $(".teacher-detail-container").click(function () {
        $("#teacher-detail").fadeOut(500);
        $(".teacher-detail-container").fadeOut(500);
    });
    $(".teacher-card").click(function (e) {
        var target = $(e.currentTarget);
        $("#detail").html(target.data("detail"));
        $("#picture").html($(target.children("img")[0]).clone().removeAttr("height").removeAttr("width"));
        $("#name").html(target.data("name"));
        $("#title").html(target.data("title").replace(',', '\n'));
        $("#teacher-detail").fadeIn(500);
        $(".teacher-detail-container").fadeIn(500);
    });
})