$(function () {
    jQuery(document).ready(function () {
        $($(".Postpage")[0]).addClass("activePage");
        $($(".Newspage")[0]).addClass("activePage");
        $('.carousel').carousel({
            interval: 4000
        });
    });

    $(".Postpage").click(function (e) {
        var Pages = $(e.target).context.text -1;
        $(".Postpage").removeClass("activePage");
        $(e.target).addClass("activePage");
        $.ajax({
            url: "/Creativity/PostPartial",
            type: "GET",
            data: { Pages: Pages }
        })
        .done(function (PostPartial) {
            $("#PostPartial").html(PostPartial);
            $('html, body').animate({
                scrollTop: $("#newpagehere").offset().top -50
            }, 200);
        });
    });

    $(".Newspage").click(function (e) {
        var Pages = $(e.target).context.text -1;
        $(".Newspage").removeClass("activePage");
        $(e.target).addClass("activePage");
        $.ajax({
            url: "/Creativity/NewsPartial",
            type: "GET",
            data: { Pages: Pages }
        })
        .done(function (NewsPartial) {
            $("#NewsPartial").html(NewsPartial);
            $('html, body').animate({
                scrollTop: $("#newpagehere").offset().top -50
            }, 200);
        });
    });

    $(".downward").click(function () {
        $('html, body').animate({
            scrollTop: $("#here").offset().top - 50
        }, 1500);
    });

    $("#recent-tab").click(function () {
        if (!$("#recent-tab").hasClass("active")) {
            AllRemoveClass()
            $("#recent-tab").addClass("active");
            AllHide();
            $("#recent").show();
        }
    });

    $("#post-tab").click(function () {
        if (!$("#post-tab").hasClass("active")) {
            AllRemoveClass()
            $("#post-tab").addClass("active");
            AllHide();
            $("#post").show();
        }
    });
});

function AllHide() {
    $("#recent").hide();
    $("#post").hide();
}

function AllRemoveClass() {
    $("#post-tab").removeClass("active");
    $("#recent-tab").removeClass("active");
}
