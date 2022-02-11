
$(function () {
    var $el,
        leftPos,
        newWidth,
        $mainNav = $(".navbar-nav");

    $mainNav.append("<li id='magic-line'></li>");
    var $magicLine = $("#magic-line");

    $magicLine
        .width($(".active").width())
        .css("left", $(".active a").position().left)
        .data("origLeft", $magicLine.position().left)
        .data("origWidth", $magicLine.width());

    $(".navbar-nav li a").hover(
        function () {
            $el = $(this);
            leftPos = $el.position().left;
            newWidth = $el.parent().width();
            $magicLine.stop().animate({
                left: leftPos,
                width: newWidth
            });
        },
        function () {
            $magicLine.stop().animate({
                left: $magicLine.data("origLeft"),
                width: $magicLine.data("origWidth")
            });
        }
    );
});
// Credit: https://css-tricks.com/jquery-magicline-navigation

function initMap() {
    const mepm = { lat: 36.560007113641745, lng: - 82.20629139082862 };
        const map = new google.maps.Map(document.getElementById("map"), {
            zoom: 12,
            center: mepm,
        });
        const marker = new google.maps.Marker({
            position: mepm,
            map: map,
        });
    }

$(document).ready(function () {
    $("#btnShowModal").click(function () {
        $("#SuccessModal").modal('show');
    });
});
$(document).click(function (e) {
    if ($(e.target).is('#SuccessModal')) {
        $('#SuccessModal').modal('hide');
    }

});