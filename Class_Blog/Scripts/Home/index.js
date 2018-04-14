var obj = [0, 1, 2];
var time = 1;
$(function () {
    $(".1").hide();
    $(".2").hide();
    jQuery(document).ready(function () {
        setTimeout(function () {
            runEffect(1);
        }, 4000);
    });
});

$(document).ready(function () {
    $(".animsition").animsition({
        inClass: 'fade-in-up-lg',
        outClass: 'fade-out-up-lg',
        inDuration: 1500,
        outDuration: 800,
        linkElement: '.animsition-link',
        // e.g. linkElement: 'a:not([target="_blank"]):not([href^="#"])'
        loading: true,
        loadingParentElement: 'body', //animsition wrapper element
        loadingClass: 'animsition-loading',
        loadingInner: '', // e.g '<img src="loading.svg" />'
        timeout: false,
        timeoutCountdown: 5000,
        onLoadEvent: true,
        browser: ['animation-duration', '-webkit-animation-duration'],
        // "browser" option allows you to disable the "animsition" in case the css property in the array is not supported by your browser.
        // The default setting is to disable the "animsition" in a browser that does not support "animation-duration".
        overlay: false,
        overlayClass: 'animsition-overlay-slide',
        overlayParentElement: 'body',
        transition: function (url) { window.location.href = url; }
    });
});

function runEffect(number) {
    var directions = ['left', 'up'];

    $($("." + number)[0]).delay(Math.floor((Math.random() * 1500) + 1)).show("slide", { direction: directions[Math.floor((Math.random() * 3))] }, 1000);
    $($("." + number)[1]).delay(Math.floor((Math.random() * 1500) + 1)).show("slide", { direction: directions[Math.floor((Math.random() * 3))] }, 1000);
    $($("." + number)[2]).delay(Math.floor((Math.random() * 1500) + 1)).show("slide", { direction: directions[Math.floor((Math.random() * 3))] }, 1000);

    Image_hide(number);

    if (obj[number + 1] != undefined) {
        setTimeout(function () {
            runEffect(obj[number + 1]);
        }, 4000);
    }
    else {
        setTimeout(function () {
            runEffect(obj[0]);
        }, 4000);
    }
}

function Image_hide(number) {
    var prev = number - 2;
    if (prev < 0) prev = obj.length + prev;
    $($("." + prev)[0]).hide().css("z-index", time);
    $($("." + prev)[1]).hide().css("z-index", time);
    $($("." + prev)[2]).hide().css("z-index", time);
    time++
}

function callback(number) {
    setTimeout(function () {
        $("." + number).effect("slide", {}, 1000);
    }, 2000);
};