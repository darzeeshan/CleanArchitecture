$(function () {
    //ClientConnection Add/Edit
    $('input:radio[name="ConnectionType"]').click(function () {
        $.fn.connectiontype();
    });

    $.fn.connectiontype = function () {
        $("#ConnectionTypeKeyAttribute").hide();
        $("#ConnectionTypeJwtAttribute").hide();
        $("#ConnectionTypeFtpAttribute").hide();

        $('input:radio[name="ConnectionType"]:checked').each(function () {
            var title = this.title;
            $("#" + title).show();
        });
    }
    $.fn.connectiontype();
});