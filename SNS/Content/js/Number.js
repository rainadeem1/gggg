$(function () {
    $(".num").keypress(function (event) { return isNumber(event) });
    $(".zero").val("0");
    $(".num").blur(function () {
        if ($(this).val().trim() == "") {
            $(this).val("0");
        }

    });


    // THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
    function isNumber(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (charCode != 45 && (charCode != 46 ||
                $(this).val().indexOf('.') != -1) && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
});