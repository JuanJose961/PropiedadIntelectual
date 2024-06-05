$(document).ready(function () {
    //var url = new URL(location.href); //Mediante esta propiedad accedemos a la dirección URL completa de la página mostrada en una ventana
    //alert(url);
    //var tipo = JSON.parse(url.searchParams.get('tipo')); //Capturar el valor
    //var url = new URL(location.href); //Mediante esta propiedad accedemos a la dirección URL completa de la página mostrada en una ventana
    //const urlParams = new URLSearchParams(url.search);
    //var tipo = urlParams.get('tipo');
    //alert(tipo);
});

function VerMarca(id) {
   
    $("#alertModal .close").hide();
    $("#alertModal .modal-title").text("Obteniendo información");
    $("#alertModal .modal-footer").empty();
    $("#alertModal .form-group").empty();
    $("#alertModal .modal-spinner").show();
    $("#alertModal").modal("show");
    var sended_url = services_url + "SelectRegistroMarcaById";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({
            id: id
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    registro = jsonResponse.content[0];
                    //comentarios = jsonResponse.content[1];
                    //var fila = "<tr><th>Tipo solicitud</th><td>" + registro.solicitud_tipo_desc + "</td></tr>" + "<tr><th>Nombre</th><td>" + registro.nombre + "</td></tr>";
                    //var fila = "<tr><th><b>GENERAL</b></th><td></td><th></th><td></td></tr>" + "<tr><th><b>Tipo solicitud</b></th><td>" + registro.solicitud_tipo_desc + "</td><th><b<Nombre</b></th><td>" + registro.nombre + "</td></tr>";
                    var fila = "<tr><th><b>Tipo solicitud</b></th><td>" + registro.solicitud_tipo_desc + "</td><th><b>Nombre</b></th><td>" + registro.nombre + "</td></tr>" + "<tr><th><b>Empresa propietaria</b></th><td>" + registro.empresa_desc + "</td><th><b>Antigua empresa propietaria</b></th><td>" + registro.empresa_anterior_desc + "</td></tr>" + "<tr><th><b>Número de registro</b></th><td>" + registro.no_registro + "</td><th><b>Fecha legal</b></th><td>" + registro.fecha_legalS + "</td></tr>";
                    document.getElementById("tablita").innerHTML = fila;
                    var fila1 = "<tr><th><b>Número de solicitud</b></th><td>" + registro.no_solicitud + "</td><th><b>Persona que pidio el registro</b></th><td>" + registro.autor_registro_desc + "</td></tr>" + "<tr><th><b>Despacho</b></th><td>" + registro.despacho_desc + "</td><th><b>Corresponsal</b></th><td>" + registro.corresponsal_desc + "</td></tr>";
                    document.getElementById("tablita1").innerHTML = fila1;

                    $("#alertModal").modal("hide");
                    $("#modalview1 .form-error").remove();
                    $("#modalview1 .form-control").removeClass("control-error");
                    $("#modalview1 .form-control").removeAttr("disabled");
                    $("#modalview1 .modal-title").html("<span>Ver registro</span>");
                    $("#modalview1").modal("show");
                } else {
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-default"><i class="fa fa-undo"></i> Ok</button>');
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                    console.log("success");
                    console.log(jsonResponse.description);
                }
            }, 1500);
        },
        failure: function (response) {
            $(".form-control").removeAttr("disabled");
            console.log("failure");
            console.log(response);
        },
        error: function (response) {
            $(".form-control").removeAttr("disabled");
            console.log("error");
            console.log(response);
        }
    });

}
