$(function () {
    jQuery(document).ready(function () {
        $($(".Postpage")[0]).addClass("activePage");
        $($(".Newspage")[0]).addClass("activePage");
        $($(".Picturespage")[0]).addClass("activePage");
        $('.carousel').carousel({
            interval: 4000
        });
    });

    $(".Postpage").click(function (e) {
        var Pages = $(e.target).context.text - 1;
        $(".Postpage").removeClass("activePage");
        $(e.target).addClass("activePage");
        $.ajax({
            url: "/Ntust/TAPostPartial",
            type: "GET",
            data: { Pages: Pages }
        })
        .done(function (PostPartial) {
            $("#PostPartial").html(PostPartial);
        });
    });

    $(".Newspage").click(function (e) {
        var Pages = $(e.target).context.text - 1;
        $(".Newspage").removeClass("activePage");
        $(e.target).addClass("activePage");
        $.ajax({
            url: "/Ntust/TANewsPartial",
            type: "GET",
            data: { Pages: Pages }
        })
        .done(function (NewsPartial) {
            $("#NewsPartial").html(NewsPartial);
        });
    });

    $(".Picturespage").click(function (e) {
        var Pages = $(e.target).context.text - 1;
        $(".Picturespage").removeClass("activePage");
        $(e.target).addClass("activePage");
        $.ajax({
            url: "/Ntust/TAPicturesPartial",
            type: "GET",
            data: { Pages: Pages }
        })
        .done(function (PicturesPartial) {
            $("#PicturesPartial").html(PicturesPartial);
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

    $("#picture-tab").click(function () {
        if (!$("#picture-tab").hasClass("active")) {
            AllRemoveClass()
            $("#picture-tab").addClass("active");
            AllHide();
            $("#picture").show();
        }
    });

    $(".btn-danger").click(function (e) {
        swal({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then(function () {
            var url = $(e.target).val();
            console.log(url);
            $.ajax({
                url: url,
                type: "GET"
            })
            .done(function (PicturesPartial) {
                swal({
                    title: 'Deleted!',
                    text: 'Your file has been deleted.',
                    type: 'success',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'OK'
                }).then(function () { location.reload() });
            });

        })
    });

    $("#upload_img").click(function () {
        var image = new FormData();
        swal({
            title: 'Select image',
            text: "圖檔必須小於800kb",
            input: 'file',
            inputAttributes: {
                accept: 'image/*'
            }
        }).then(function (file) {
            var reader = new FileReader
            reader.onload = function (e) {
                swal({
                    imageUrl: e.target.result,
                }).then(function () {
                    $.ajax({
                        type: 'POST',
                        url: "/Ntust/UploadPicture",
                        data: image,
                        cache: false,
                        contentType: false,
                        processData: false,
                        success: function (data) {
                            if (data == 400) {
                                alert("檔案大於800Kb");
                            }
                            console.log("success");
                        },
                        error: function (data) {
                            console.log("error");
                        }
                    });
                });
            }
            reader.readAsDataURL(file);
            image.append("file", $(".swal2-file")[0].files[0]);
        });
    });
});

function AllHide() {
    $("#recent").hide();
    $("#post").hide();
    $("#picture").hide();
}

function AllRemoveClass() {
    $("#post-tab").removeClass("active");
    $("#recent-tab").removeClass("active");
    $("#picture-tab").removeClass("active");
}
