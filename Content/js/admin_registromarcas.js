$(document).ready(function () {
    //var url = new URL(location.href); //Mediante esta propiedad accedemos a la dirección URL completa de la página mostrada en una ventana
    //alert(url);
    //var tipo = JSON.parse(url.searchParams.get('tipo')); //Capturar el valor
    //var url = new URL(location.href); //Mediante esta propiedad accedemos a la dirección URL completa de la página mostrada en una ventana
    //const urlParams = new URLSearchParams(url.search);
    //var tipo = urlParams.get('tipo');
    //alert(tipo);
    //var nrows = 0;
    //$("table tr").each(function () {
    //    nrows++;
    //})
    //alert(nrows);
    //var $num = document.getElementById('tabla01').getElementsByTagName('tr').length - 1;
    //alert($num);
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
                    var fila = "<tr><th><b>Tipo solicitud</b></th><td>" + registro.solicitud_tipo_desc + "</td><th><b>Nombre</b></th><td>" + registro.nombre + "</td></tr>" + "<tr><th><b>Empresa propietaria</b></th><td>" + registro.empresa_desc + "</td><th><b>Antigua empresa propietaria</b></th><td>" + registro.empresa_anterior_desc + "</td></tr>" + "<tr><th><b>Número de registro</b></th><td>" + registro.no_registro + "</td><th><b>Fecha legal</b></th><td>" + registro.fecha_legalS + "</td></tr>" + "<tr><th><b>Fecha de vencimiento</b></th><td>" + registro.fecha_vencimientoS + "</td><th><b>Fecha concesión</b></th><td>" + registro.fecha_concesionS + "</td></tr>" + "<tr><th><b>Clase</b></th><td>" + registro.clase_desc + "</td><th><b>País</b></th><td>" + registro.pais_desc + "</td></tr>" + "<tr><th><b>Estatus</b></th><td>" + registro.estatus_desc + "</td><th><b>Uso</b></th><td>" + registro.uso_desc + "</td></tr>";
                    document.getElementById("tablita").innerHTML = fila;
                    var fila1 = "<tr><th><b>Número de solicitud</b></th><td>" + registro.no_solicitud + "</td><th><b>Persona que pidio el registro</b></th><td>" + registro.autor_registro_desc + "</td></tr>" + "<tr><th><b>Despacho</b></th><td>" + registro.despacho_desc + "</td><th><b>Corresponsal</b></th><td>" + registro.corresponsal_desc + "</td></tr>";
                    document.getElementById("tablita1").innerHTML = fila1;
                    var fila2 = "<tr><th><b>Persona que solicito la licencia</b></th><td>" + registro.solicitante_licencia + "</td><th><b>Licencia</b></th><td>" + registro.licencia_desc + "</td></tr>";
                    document.getElementById("tablita2").innerHTML = fila2;
                    var fila3 = "<tr><th><b>Persona que solicito la cesión</b></th><td>" + registro.solicitante_cesion + "</td><th><b>Cesión</b></th><td>" + registro.cesion_desc + "</td></tr>";
                    document.getElementById("tablita3").innerHTML = fila3;
                    var fila4 = "<tr><th width='50 %'><b>Requerimiento del negocio</b></th><td width='10 %'>" + registro.fecha_requerimientoS + "</td><th width='30 %'><b>Completo</b></th><td width='10 %'>" + registro.fecha_requerimiento_completoS + "</td></tr>" + "<tr><th><b>Instrucciones al corresponsal</b></th><td>" + registro.fecha_instruccionesS + "</td><th><b>Completo</b></th><td>" + registro.fecha_instrucciones_completoS + "</td></tr>" + "<tr><th><b>Solicitud de registro ante la autoridad competente</b></th><td>" + registro.fecha_registroS + "</td><th><b>Completo</b></th><td>" + registro.fecha_registro_completoS + "</td></tr>" + "<tr><th><b>Solicitud de busqueda</b></th><td>" + registro.fecha_busquedaS + "</td><th><b>Completo</b></th><td>" + registro.fecha_busqueda_completoS + "</td></tr>" + "<tr><th><b>Información de resultados al negocio</b></th><td>" + registro.fecha_resultadosS + "</td><th><b>Completo</b></th><td>" + registro.fecha_resultados_completoS + "</td></tr>" + "<tr><th><b>Comprobación de uso</b></th><td>" + registro.fecha_comprobacionS + "</td><th><b>Completo</b></th><td>" + registro.fecha_comprobacion_completoS + "</td></tr>" + "<tr><th><b>Declaración de uso</b></th><td>" + registro.fecha_declaracionS + "</td><th><b>Completo</b></th><td>" + registro.fecha_declaracion_completoS + "</td></tr>";
                    document.getElementById("tablita4").innerHTML = fila4;

                    $("#alertModal").modal("hide");
                    $("#modalview1 .form-error").remove();
                    $("#modalview1 .form-control").removeClass("control-error");
                    $("#modalview1 .form-control").removeAttr("disabled");
                    $("#modalview1 .modal-title").html("<span>Información de la solicitud</span>");
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
