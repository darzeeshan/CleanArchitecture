// Write your JavaScript code.
$(function () {
    //Login
    var userLogin = $('#frmLogin').validate({
        errorClass: 'text-danger',
        rules: {
            txtUserName: {
                required: true,
                minlength: 5
            },
            txtPassword: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            txtUserName: {
                required: "Please enter a login id",
                minlength: "Login id must be at least 5 characters long"
            },
            txtPassword: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            }
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

    //SignUp
    var userSignUp = $('#frmSignUp').validate({
        rules: {
            txtName: {
                required: true,
            },
            txtRole: {
                min: function () {
                    if ($('#txtRole').val() == '0')
                        return '1';
                    else
                        return '0';
                }
            },
            txtUserName: {
                required: true,
                minlength: 5
            },
            txtEmail: {
                required: true,
                email: true,
            },
            txtPassword: {
                required: true,
                minlength: 5
            },
            txtConfirmPassword: {
                required: true,
                equalTo: "#txtPassword"
            },
        },
        messages: {
            txtName: {
                required: "Please enter a name",
            },
            txtRole: {
                min: "Please select user type.",
            },
            txtUserName: {
                required: "Please enter a login id",
                minlength: "Login id must be at least 5 characters long"
            },
            txtEmail: {
                required: "Please enter a email address",
                email: "Please enter a vaild email address"
            },
            txtPassword: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            txtConfirmPassword: {
                equalTo: "Confirm password mismatch"
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

    //Network path needed
    var networkPath = $('#frmInbound').validate({
        rules: {
            txtNetworkPath: {
                required: true
            }
        },
        messages: {
            txtNetworkPath: {
                required: "Please enter network path to load inbound files",
            }
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

    //button click
    //var loadFilenames = $("button").click(function () {
    //    if (this.id == "btnStructure")
    //    {
    //        $('#frmCheck').attr('action', 'Sheets/');
    //        $('#frmCheck').submit();
    //    }
    //    else if (this.id == "btnData")
    //    {
    //        $('#frmCheck').attr('action', 'Sheets/ValidateData');
    //        $('#frmCheck').submit();
    //    }
    //});

});