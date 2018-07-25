$(document).ready(function() {
    $("#loginButton").click(function () {
        var email = $("#email").val();
        var password = $("#password").val();
        $.ajax({
            url: '/Account/Login',
            method: 'post',
            data: { 'email': email, 'password': password },
            success: function (result) {
                if (result == 0) {
                    $('#error').html('გთხოვთ შეავსოთ ყველა ველი');
                }
                else if (result == 1) {
                    $('#error').html('ასეთი მომხმარებელი არ არსებობს');
                } else {
                    location.href = '/Home/Index';
                }

            }
        });
    });
});