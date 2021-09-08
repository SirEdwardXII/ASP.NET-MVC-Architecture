$(document).ready(function () {

    // dynamically add * when required based on Required attribute in ViewModel
    $('input[data-val-required]').each(function () {
        $(this).parent(".input-group").find("label").addClass("required");
    });

});