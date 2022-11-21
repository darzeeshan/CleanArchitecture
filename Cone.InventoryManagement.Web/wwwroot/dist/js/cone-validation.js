$(function () {
    $('#frmClients').validate({
        rules: {
            ClientName: {
                required: true
            },
            ClientId: {
                required: true
            },
            FolderLocation: {
                required: true,
                alphanumeric: true
            },
        },
        messages: {
            ClientName: {
                required: "Client name is required.",
            },
            ClientId: {
                required: "Account number is required.",
            },
            FolderLocation: {
                required: "Folder name is required.",
                alphanumeric: "Spaces and special characters not allowed."
            },
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
    $('#frmConnection').validate({
        rules: {
            txtKey: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeKey"]').is(':checked');
                }
            },
            txtJwtBaseUrl: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeJwt"]').is(':checked');
                }
            },
            txtJwtUser: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeJwt"]').is(':checked');
                }
            },
            txtJwtPassword: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeJwt"]').is(':checked');
                }
            },
            txtFtpUrl: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeFtp"]').is(':checked');
                }
            },
            txtFtpUser: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeFtp"]').is(':checked');
                }
            },
            txtFtpPassword: {
                required: function (e) {
                    return $('input:radio[id="ConnectionTypeFtp"]').is(':checked');
                }
            },
        },
        messages: {
            txtKey: {
                required: "Key is required.",
            },
            txtJwtBaseUrl: {
                required: "Base url is required.",
            },
            txtJwtUser: {
                required: "User name is required.",
            },
            txtJwtPassword: {
                required: "Password is required.",
            },
            txtFtpUrl: {
                required: "FTP url is required.",
            },
            txtFtpUser: {
                required: "User name is required.",
            },
            txtFtpPassword: {
                required: "Password is required.",
            },
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
});

