function register() {
    var username = $('#username').val();
    var password = $('#password').val();
    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var email = $('#email').val();

    $.ajax({
        url: portalApiEndpoint + '/iam/users',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            "username": username,
            "password": password,
            "firstName": firstName,
            "lastName": lastName,
            "email": email,
        }),
        success: function (response) {
            window.location.href = "/home";
        },
        error: function (error, xhr, status) {
            alert("Hata Oluştu!");
        }
    });
}