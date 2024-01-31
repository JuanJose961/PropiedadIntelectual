
$(document).on("submit", "#loginform", function (event) {
    event.preventDefault();
    TryLogin();
});
function TryLogin() {
    if (Validate() != false) {
        $("#locc-loginsubmit").attr("disabled", "disabled");
        $("#locc-loginsubmit").text("Verificando ...");
        var uname = $("#lg00").val();
        var upass = $("#lg01").val();
        var return_url = $("#returnurl").val();
        var sended_url = mainurl + "api/WebAPI/Login";

        if (!uname.includes("@")) {
            uname += "@gis.com.mx";
        }

        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({ username: uname, password: upass }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    setTimeout(function () {
                        if (return_url != "") {
                            location.href = mainurl + return_url;
                        } else {
                            location.href = mainurl + "PI";
                        }
                    }, 3000);
                } else {
                    //
                    //$("#lgerrores").append("<p class='form-error text-danger'>" + jsonResponse.description + "</p>");
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#lgerrores").append("<p class='form-error text-danger'>" + jsonResponse.errors[i] + "</p>")
                    }
                    console.log("success");
                    console.log(jsonResponse.errors);
                    $("#locc-loginsubmit").removeAttr("disabled");
                    $("#locc-loginsubmit").text("Iniciar Sesión");
                }
            },
            failure: function (response) {
                console.log("failure");
                console.log(response);
                $("#locc-loginsubmit").removeAttr("disabled");
                $("#locc-loginsubmit").text("Iniciar Sesión");
            },
            error: function (response) {
                console.log("error");
                console.log(response);
                $("#locc-loginsubmit").removeAttr("disabled");
                $("#locc-loginsubmit").text("Iniciar Sesión");
            }
        });
    }
}
function Validate() {
    $("#loginform .form-error").remove();
    $("#loginform .form-control").removeClass("control-error");

    var uname = $("#lg00").val();
    var upass = $("#lg01").val();

    var errores = 0;
    var flag = false;

    if (uname.length <= 0) {
        $("#lg00").addClass("control-error");
        $("#lg00c").append("<p class='form-error text-danger'>El campo est&aacute; vac&iacute;o</p>");
        errores += 1;
    }
    if (upass.length <= 0) {
        $("#lg01").addClass("control-error");
        $("#lg01c").append("<p class='form-error text-danger'>El campo est&aacute; vac&iacute;o</p>");
        errores += 1;
    }
    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}