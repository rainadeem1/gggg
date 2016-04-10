$(function () {
    $(".date").datepicker();
    date(".now");
    $(".date").focusout(function () {
        if ($(this).val().trim() == "") {
            date(".date");
        }
    });

    function date(sekector) {
        var dNow = new Date();
        var localdate = (dNow.getMonth() + 1) + '/' + dNow.getDate() + '/' + dNow.getFullYear();
        $(sekector).val(localdate);
    }

});