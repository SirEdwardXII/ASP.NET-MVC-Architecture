$(document).ready(function () {

    $('#success').hide();

    if (createdContact !== null && createdContact !== '') {
        $('#success').show();
    }
});