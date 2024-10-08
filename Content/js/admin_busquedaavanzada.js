$(document).ready(function () {
   
    $('#uu_04').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        numberOfMonths: 2
    });
    $('#uu_05').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_06').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_21').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_22').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_23').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_24').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_25').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_26').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_37').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        numberOfMonths: 2
    });
});

function Validar() {
    $(".form-error").remove();
    $(".form-control").removeClass("control-error");
    $(".select2-selection").removeClass("control-error");
    var tab = '#tab01';

    var errores = 0;
    var flag = false;
    var solicitud_tipo = $("#uu_02 option:selected").val();
    if (solicitud_tipo <=0) {
        //$("#uu_06").addClass("control-error");
        $("#uu_02_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        //tab = '#tab05';
    }
    if (errores > 0) {
        flag = false;
        //$(".nav-link[href='" + tab + "']").click();
    } else {
        flag = true;
    }

    return flag;
}

function Limpiar() {
    location.href = hosturl + "PI/BusquedaAvanzada?tipo=1";
}
function BuscarRegistroMarca() {
    if (Validar() != false) {
        var solicitud_tipo = $("#uu_02 option:selected").val();
        var id_usuario = eu_lu.id;
        var empresa = $("#uu_00 option:selected").val();
        var empresa_anterior = $("#uu_01 option:selected").val();
        var clase = $("#uu_07 option:selected").val();
        var pais = $("#uu_09 option:selected").val();
        var estatus = $("#uu_10 option:selected").val();
        var uso = $("#uu_39 option:selected").val();
        var tipo_registro_solicitud = $("#uu_12 option:selected").val();
        var nombre = $("#uu_022").val();
        var sended_url = services_url + "BusquedaRegistroMarca";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({
                solicitud_tipo: solicitud_tipo,
                id_usuario: id_usuario,
                empresa: empresa,
                empresa_anterrior: empresa_anterior,
                clase: clase,
                pais: pais,
                estatus: estatus,
                uso: uso,
                tipo_registro_solicitud: tipo_registro_solicitud,
                nombre: nombre
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        // $("#tabla02").html('');
                        //document.getElementById("cTabla1_3").querySelector("thead").innerHTML = "<tr style='background-color:#254368;color:white;' align='center'><th>Tipo Solicitud</th><th>Nombre</th><th>Empresa Propietaria</th><th>Enpresa Anterior</th><th>Fecha Legal</th><th>Fecha Vencimiento</th><th>Fecha Concesión</th><th>No. Registro</th><th>Pais</th><th>Clase</th><th>Estatus</th><th>Uso</th><th>No. Solicitud</th><th>Tipo Registro</th><th>Solicito Registro</th><th>Despacho</th><th>Corresponsal</th><th>Licencia</th><th>Solicito Licencia</th><th>Cesión</th><th>Solicito Cesión</th></tr>";
                        //$("#tabla01").empty();
                        //$('#cTabla1_3').remove()
                        registro = jsonResponse.content[0];
                        //alert(registro.length);
                        //var renglones = "<table id='cTabla1_3' class='table table - bordered table - hover table - striped w - 100'>< thead ><tr style='background-color:#254368;color:white;' align='center'><th>Tipo Solicitud</th><th>Nombre</th><th>Empresa Propietaria</th><th>Enpresa Anterior</th><th>Fecha Legal</th><th>Fecha Vencimiento</th><th>Fecha Concesión</th><th>No. Registro</th><th>Pais</th><th>Clase</th><th>Estatus</th><th>Uso</th><th>No. Solicitud</th><th>Tipo Registro</th><th>Solicito Registro</th><th>Despacho</th><th>Corresponsal</th><th>Licencia</th><th>Solicito Licencia</th><th>Cesión</th><th>Solicito Cesión</th></tr></thead >";
                        document.getElementById("titulobusquedavanzada").innerHTML = "Busqueda Avanzada de Solicitudes (" + registro.length + " registros)";
                        var renglones = "";
                        if (registro.length > 0) {
                            for (let i = 0; i < registro.length; i++) {
                                renglones += "<tr><td>" + registro[i].solicitud_tipo_desc + "</td><td>" + registro[i].nombre + "</td><td>" + registro[i].empresa_desc + "</td><td>" + registro[i].empresa_anterior_desc + "</td><td>" + registro[i].fecha_legalS + "</td><td>" + registro[i].fecha_vencimientoS + "</td><td>" + registro[i].fecha_concesionS + "</td><td>" + registro[i].no_registro + "</td><td>" + registro[i].pais_desc + "</td><td>" + registro[i].clase_desc + "</td><td>" + registro[i].estatus_desc + "</td><td>" + registro[i].uso_desc + "</td><td>" + registro[i].no_solicitud + "</td><td>" + registro[i].tipo_registro_solicitud_desc + "</td><td>" + registro[i].autor_registro_desc + "</td><td>" + registro[i].despacho_desc + "</td><td>" + registro[i].corresponsal_desc + "</td><td>" + registro[i].licencia_desc + "</td><td>" + registro[i].solicitante_licencia_desc + "</td><td>" + registro[i].cesion_desc + "</td><td>" + registro[i].solicitante_cesion_desc + "</td><td>" + registro[i].fecha_requerimientoS + "</td><td>" + registro[i].fecha_instruccionesS + "</td><td>" + registro[i].fecha_registroS + "</td><td>" + registro[i].fecha_busquedaS + "</td><td>" + registro[i].fecha_resultadosS + "</td><td>" + registro[i].fecha_comprobacionS + "</td><td>" + registro[i].fecha_declaracionS + "</td></tr>";
                            }
                        }
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML += renglones;
                        //renglones += "</tbody>";
                        //document.getElementById('cTabla1_3').innerHTML += renglones;

                        //document.getElementById('tabla01').innerHTML = "<table><thead><tr style='background-color:#254368; color: white;'><th>Tipo de solicitud</th><th>Nombre</th></tr></thead><tbody><tr><td>" + registro[0].solicitud_tipo_desc + "</td><td>" + registro[0].nombre +"</td></tr></tbody></table>";
                        /*document.getElementById('tabla01').innerHTML = "<tr><td>"+registro[0].solicitud_tipo_desc+"</td><td>"+registro[0].nombre+"</td></tr>";*/
                        //comentarios = jsonResponse.content[1];
                        //RedibujaComentarios(desabilitar);

                    } else {
                        registro = {
                            id: 0,
                            empresa: 0,
                            empresa_desc: "",
                            empresa_anterior: 0,
                            empresa_anterior_desc: "",
                            nombre: "",
                            no_registro: "",
                            titulo: "",
                            fecha_legalS: "",
                            fecha_vencimientoS: "",
                            fecha_concesionS: "",
                            clase: 0,
                            clase_desc: "",
                            tipo_registro: 0,
                            tipo_registro_desc: "",
                            pais: 0,
                            pais_desc: "",
                            estatus: 0,
                            estatus_desc: "",
                            no_solicitud: "",
                            tipo_registro_solicitud: 0,
                            tipo_registro_solicitud_desc: "",
                            autor_registro: "",
                            autor_registro_desc: "",
                            despacho: 0,
                            despacho_desc: "",
                            corresponsal: 0,
                            corresponsal_desc: "",
                            solicitante_licencia: "",
                            solicitante_licencia_desc: "",
                            licencia: 0,
                            licencia_desc: "",
                            solicitante_cesion: "",
                            solicitante_cesion_desc: "",
                            cesion: 0,
                            cesion_desc: "",
                            usuario: "",
                            usuario_desc: "",
                            activo: 0,
                            solicitud: 0,
                            solicitud_desc: "",
                            solicitud_tipo: 0,
                            solicitud_tipo_desc: "",
                            fecha_requerimientoS: "",
                            fecha_requerimiento_completoS: "",
                            fecha_instruccionesS: "",
                            fecha_instrucciones_completoS: "",
                            fecha_registroS: "",
                            fecha_registro_completoS: "",
                            fecha_busquedaS: "",
                            fecha_busqueda_completoS: "",
                            fecha_resultadosS: "",
                            fecha_resultados_completoS: "",
                            fecha_comprobacionS: "",
                            fecha_comprobacion_completoS: "",
                            fecha_vencimiento_workflowS: "",
                            fecha_vencimiento_workflow_completoS: "",
                            fecha_concesion_workflowS: "",
                            fecha_concesion_workflow_completoS: "",
                            fecha_quinquenio_anualidadS: "",
                            tipo_pago: 0,
                            tipo_pago_desc: "",
                            prioridad: "",
                            fecha_vencimiento_prioridadS: "",
                            autor: "",
                            uso: 0,
                            uso_desc: "",
                            fecha_declaracionS: "",
                            fecha_declaracion_completoS: "",
                            nueva_fecha_vencimientoS: "",
                        };
                        document.getElementById("titulobusquedavanzada").innerHTML = "Busqueda Avanzada de Solicitudes (0 registros)";
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        //$("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-default"><i class="fa fa-undo"></i> Ok</button>');
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
}

function Excel() {
    if (Validar() != false) {
        var solicitud_tipo = $("#uu_02 option:selected").val();
        var id_usuario = eu_lu.id;
        var empresa = $("#uu_00 option:selected").val();
        var empresa_anterior = $("#uu_01 option:selected").val();
        var clase = $("#uu_07 option:selected").val();
        var pais = $("#uu_09 option:selected").val();
        var estatus = $("#uu_10 option:selected").val();
        var uso = $("#uu_39 option:selected").val();
        var tipo_registro_solicitud = $("#uu_12 option:selected").val();
        var nombre = $("#uu_022").val();
        var sended_url = services_url + "ExcelRegistroMarca";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({
                solicitud_tipo: solicitud_tipo,
                id_usuario: id_usuario,
                empresa: empresa,
                empresa_anterrior: empresa_anterior,
                clase: clase,
                pais: pais,
                estatus: estatus,
                uso: uso,
                tipo_registro_solicitud: tipo_registro_solicitud,
                nombre: nombre
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        // $("#tabla02").html('');
                        //document.getElementById("cTabla1_3").querySelector("thead").innerHTML = "<tr style='background-color:#254368;color:white;' align='center'><th>Tipo Solicitud</th><th>Nombre</th><th>Empresa Propietaria</th><th>Enpresa Anterior</th><th>Fecha Legal</th><th>Fecha Vencimiento</th><th>Fecha Concesión</th><th>No. Registro</th><th>Pais</th><th>Clase</th><th>Estatus</th><th>Uso</th><th>No. Solicitud</th><th>Tipo Registro</th><th>Solicito Registro</th><th>Despacho</th><th>Corresponsal</th><th>Licencia</th><th>Solicito Licencia</th><th>Cesión</th><th>Solicito Cesión</th></tr>";
                        //$("#tabla01").empty();
                        //$('#cTabla1_3').remove()
                        //registro = jsonResponse.content[0];
                        //alert(registro.length);
                        //var renglones = "<table id='cTabla1_3' class='table table - bordered table - hover table - striped w - 100'>< thead ><tr style='background-color:#254368;color:white;' align='center'><th>Tipo Solicitud</th><th>Nombre</th><th>Empresa Propietaria</th><th>Enpresa Anterior</th><th>Fecha Legal</th><th>Fecha Vencimiento</th><th>Fecha Concesión</th><th>No. Registro</th><th>Pais</th><th>Clase</th><th>Estatus</th><th>Uso</th><th>No. Solicitud</th><th>Tipo Registro</th><th>Solicito Registro</th><th>Despacho</th><th>Corresponsal</th><th>Licencia</th><th>Solicito Licencia</th><th>Cesión</th><th>Solicito Cesión</th></tr></thead >";
                        //document.getElementById("titulobusquedavanzada").innerHTML = "Busqueda Avanzada de Solicitudes (" + registro.length + " registros)";
                        //var renglones = "";
                        //if (registro.length > 0) {
                        //    for (let i = 0; i < registro.length; i++) {
                        //        renglones += "<tr><td>" + registro[i].solicitud_tipo_desc + "</td><td>" + registro[i].nombre + "</td><td>" + registro[i].empresa_desc + "</td><td>" + registro[i].empresa_anterior_desc + "</td><td>" + registro[i].fecha_legalS + "</td><td>" + registro[i].fecha_vencimientoS + "</td><td>" + registro[i].fecha_concesionS + "</td><td>" + registro[i].no_registro + "</td><td>" + registro[i].pais_desc + "</td><td>" + registro[i].clase_desc + "</td><td>" + registro[i].estatus_desc + "</td><td>" + registro[i].uso_desc + "</td><td>" + registro[i].no_solicitud + "</td><td>" + registro[i].tipo_registro_solicitud_desc + "</td><td>" + registro[i].autor_registro_desc + "</td><td>" + registro[i].despacho_desc + "</td><td>" + registro[i].corresponsal_desc + "</td><td>" + registro[i].licencia_desc + "</td><td>" + registro[i].solicitante_licencia_desc + "</td><td>" + registro[i].cesion_desc + "</td><td>" + registro[i].solicitante_cesion_desc + "</td><td>" + registro[i].fecha_requerimientoS + "</td><td>" + registro[i].fecha_instruccionesS + "</td><td>" + registro[i].fecha_registroS + "</td><td>" + registro[i].fecha_busquedaS + "</td><td>" + registro[i].fecha_resultadosS + "</td><td>" + registro[i].fecha_comprobacionS + "</td><td>" + registro[i].fecha_declaracionS + "</td></tr>";
                        //    }
                        //}
                        //document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        //document.getElementById("cTabla1_3").querySelector("tbody").innerHTML += renglones;
                        //renglones += "</tbody>";
                        //document.getElementById('cTabla1_3').innerHTML += renglones;

                        //document.getElementById('tabla01').innerHTML = "<table><thead><tr style='background-color:#254368; color: white;'><th>Tipo de solicitud</th><th>Nombre</th></tr></thead><tbody><tr><td>" + registro[0].solicitud_tipo_desc + "</td><td>" + registro[0].nombre +"</td></tr></tbody></table>";
                        /*document.getElementById('tabla01').innerHTML = "<tr><td>"+registro[0].solicitud_tipo_desc+"</td><td>"+registro[0].nombre+"</td></tr>";*/
                        //comentarios = jsonResponse.content[1];
                        //RedibujaComentarios(desabilitar);

                    } else {
                        registro = {
                            id: 0,
                            empresa: 0,
                            empresa_desc: "",
                            empresa_anterior: 0,
                            empresa_anterior_desc: "",
                            nombre: "",
                            no_registro: "",
                            titulo: "",
                            fecha_legalS: "",
                            fecha_vencimientoS: "",
                            fecha_concesionS: "",
                            clase: 0,
                            clase_desc: "",
                            tipo_registro: 0,
                            tipo_registro_desc: "",
                            pais: 0,
                            pais_desc: "",
                            estatus: 0,
                            estatus_desc: "",
                            no_solicitud: "",
                            tipo_registro_solicitud: 0,
                            tipo_registro_solicitud_desc: "",
                            autor_registro: "",
                            autor_registro_desc: "",
                            despacho: 0,
                            despacho_desc: "",
                            corresponsal: 0,
                            corresponsal_desc: "",
                            solicitante_licencia: "",
                            solicitante_licencia_desc: "",
                            licencia: 0,
                            licencia_desc: "",
                            solicitante_cesion: "",
                            solicitante_cesion_desc: "",
                            cesion: 0,
                            cesion_desc: "",
                            usuario: "",
                            usuario_desc: "",
                            activo: 0,
                            solicitud: 0,
                            solicitud_desc: "",
                            solicitud_tipo: 0,
                            solicitud_tipo_desc: "",
                            fecha_requerimientoS: "",
                            fecha_requerimiento_completoS: "",
                            fecha_instruccionesS: "",
                            fecha_instrucciones_completoS: "",
                            fecha_registroS: "",
                            fecha_registro_completoS: "",
                            fecha_busquedaS: "",
                            fecha_busqueda_completoS: "",
                            fecha_resultadosS: "",
                            fecha_resultados_completoS: "",
                            fecha_comprobacionS: "",
                            fecha_comprobacion_completoS: "",
                            fecha_vencimiento_workflowS: "",
                            fecha_vencimiento_workflow_completoS: "",
                            fecha_concesion_workflowS: "",
                            fecha_concesion_workflow_completoS: "",
                            fecha_quinquenio_anualidadS: "",
                            tipo_pago: 0,
                            tipo_pago_desc: "",
                            prioridad: "",
                            fecha_vencimiento_prioridadS: "",
                            autor: "",
                            uso: 0,
                            uso_desc: "",
                            fecha_declaracionS: "",
                            fecha_declaracion_completoS: "",
                            nueva_fecha_vencimientoS: "",
                        };
                        //document.getElementById("titulobusquedavanzada").innerHTML = "Busqueda Avanzada de Solicitudes (0 registros)";
                        //document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        //$("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-default"><i class="fa fa-undo"></i> Ok</button>');
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
}