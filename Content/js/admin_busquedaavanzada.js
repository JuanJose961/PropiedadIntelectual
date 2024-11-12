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
        var cktodo=document.getElementById("chektodo");
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
        var no_registro = $("#uu_03").val();
        var no_solicitud = $("#uu_11").val();
        var fecha_legalS = $("#uu_04").val();
        var fecha_vencimientoS = $("#uu_05").val();
        var fecha_concesionS = $("#uu_06").val();
        var fecha_quinquenio_anualidadS = $("#uu_37").val();
        var fecha_requerimientoS = $("#uu_21").val();
        var fecha_instruccionesS = $("#uu_22").val();
        var fecha_registroS = $("#uu_23").val();
        var fecha_busquedaS = $("#uu_24").val();
        var fecha_resultadosS = $("#uu_25").val();
        var fecha_comprobacionS = $("#uu_26").val();
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
                nombre: nombre,
                no_registro: no_registro,
                no_solicitud: no_solicitud,
                fecha_legalS: fecha_legalS,
                fecha_vencimientoS: fecha_vencimientoS,
                fecha_concesionS: fecha_concesionS,
                fecha_quinquenio_anualidadS: fecha_quinquenio_anualidadS,
                fecha_requerimientoS: fecha_requerimientoS,
                fecha_instruccionesS: fecha_instruccionesS,
                fecha_registroS: fecha_registroS,
                fecha_busquedaS: fecha_busquedaS,
                fecha_resultadosS: fecha_resultadosS,
                fecha_comprobacionS: fecha_comprobacionS,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        registro = jsonResponse.content[0];
                        var today = new Date();
                        var now = today.toLocaleString();
                        $('#cTabla1_3').remove();
                        document.getElementById("titulobusquedavanzada").innerHTML = "Busqueda Avanzada de Solicitudes (" + registro.length + " registros)";
                        //document.getElementById("cTabla1_3").querySelector("thead").innerHTML = "";
                        //document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        //var encabezados = "";
                        //var renglones = "";
                        //if (cktodo.checked == true) {
                        //    encabezados = "<tr style='background-color:#254368; color: white;' align='center'><th> Tipo de Solicitud</th><th>Nombre</th><th>Empresa Propietaria</th><th>Enpresa Anterior</th><th>Fecha Legal</th><th>Fecha de Vencimiento</th><th>Fecha de Concesion</th><th>No. Registro</th><th>Pais</th><th>Clase</th><th>Estatus</th><th>Uso</th><th>No. Solicitud</th><th>Tipo de Registro</th><th>Persona que Solicito Registro</th><th>Despacho</th><th>Corresponsal</th><th>Licencia</th><th>Persona que Solicito Licencia</th><th>Cesion</th><th>Persona que Solicito Cesion</th><th>Fecha de Requerimiento del Negocio</th><th>Fecha de Instrucciones al Corresponsal</th><th>Fecha de Registro Ante la Autoridad Competente</th><th>Fecha de Solicitud de Busqueda</th><th>Fecha de Informacion de Resultados al Negocio</th><th>Fecha Comprobacion de Uso</th><th>Fecha Declaracion de Uso</th></tr >";
                        //    document.getElementById("cTabla1_3").querySelector("thead").innerHTML += encabezados;
                        //    if (registro.length > 0) {
                        //        for (let i = 0; i < registro.length; i++) {
                        //            renglones += "<tr><td>" + registro[i].solicitud_tipo_desc + "</td><td>" + registro[i].nombre + "</td><td>" + registro[i].empresa_desc + "</td><td>" + registro[i].empresa_anterior_desc + "</td><td>" + registro[i].fecha_legalS + "</td><td>" + registro[i].fecha_vencimientoS + "</td><td>" + registro[i].fecha_concesionS + "</td><td>" + registro[i].no_registro + "</td><td>" + registro[i].pais_desc + "</td><td>" + registro[i].clase_desc + "</td><td>" + registro[i].estatus_desc + "</td><td>" + registro[i].uso_desc + "</td><td>" + registro[i].no_solicitud + "</td><td>" + registro[i].tipo_registro_solicitud_desc + "</td><td>" + registro[i].autor_registro_desc + "</td><td>" + registro[i].despacho_desc + "</td><td>" + registro[i].corresponsal_desc + "</td><td>" + registro[i].licencia_desc + "</td><td>" + registro[i].solicitante_licencia_desc + "</td><td>" + registro[i].cesion_desc + "</td><td>" + registro[i].solicitante_cesion_desc + "</td><td>" + registro[i].fecha_requerimientoS + "</td><td>" + registro[i].fecha_instruccionesS + "</td><td>" + registro[i].fecha_registroS + "</td><td>" + registro[i].fecha_busquedaS + "</td><td>" + registro[i].fecha_resultadosS + "</td><td>" + registro[i].fecha_comprobacionS + "</td><td>" + registro[i].fecha_declaracionS + "</td></tr>";
                        //        }
                        //    }
                        //    document.getElementById("cTabla1_3").querySelector("tbody").innerHTML += renglones;
                        //} else {
                        //    encabezados = "<tr style='background-color:#254368; color: white;' align='center'><th> Tipo de Solicitud</th><th>Nombre</th><th>Empresa Propietaria</th><th>Enpresa Anterior</th><th>Fecha Legal</th><th>Fecha de Vencimiento</th><th>Fecha de Concesion</th><th>No. Registro</th><th>Pais</th><th>Clase</th><th>Estatus</th><th>Uso</th><th>No. Solicitud</th><th>Tipo de Registro</th><th>Persona que Solicito Registro</th><th>Despacho</th><th>Corresponsal</th><th>Licencia</th><th>Persona que Solicito Licencia</th><th>Cesion</th><th>Persona que Solicito Cesion</th></tr >";
                        //    document.getElementById("cTabla1_3").querySelector("thead").innerHTML += encabezados;
                        //    if (registro.length > 0) {
                        //        for (let i = 0; i < registro.length; i++) {
                        //            renglones += "<tr><td>" + registro[i].solicitud_tipo_desc + "</td><td>" + registro[i].nombre + "</td><td>" + registro[i].empresa_desc + "</td><td>" + registro[i].empresa_anterior_desc + "</td><td>" + registro[i].fecha_legalS + "</td><td>" + registro[i].fecha_vencimientoS + "</td><td>" + registro[i].fecha_concesionS + "</td><td>" + registro[i].no_registro + "</td><td>" + registro[i].pais_desc + "</td><td>" + registro[i].clase_desc + "</td><td>" + registro[i].estatus_desc + "</td><td>" + registro[i].uso_desc + "</td><td>" + registro[i].no_solicitud + "</td><td>" + registro[i].tipo_registro_solicitud_desc + "</td><td>" + registro[i].autor_registro_desc + "</td><td>" + registro[i].despacho_desc + "</td><td>" + registro[i].corresponsal_desc + "</td><td>" + registro[i].licencia_desc + "</td><td>" + registro[i].solicitante_licencia_desc + "</td><td>" + registro[i].cesion_desc + "</td><td>" + registro[i].solicitante_cesion_desc + "</td></tr>";
                        //        }
                        //    }
                        //    document.getElementById("cTabla1_3").querySelector("tbody").innerHTML += renglones;
                        //}
                        var tablecontent;
                        var encabezados = "";
                        var renglones = "";
                        if (cktodo.checked == false) {
                            encabezados = "<th style='background-color:#024775; color:white;' align='center;'>Tipo de Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Nombre</th><th style='background-color:#024775; color:white;' align='center;'>Empresa Propietaria</th><th style='background-color:#024775; color:white;' align='center;'>Enpresa Anterior</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Legal</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Vencimiento</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Concesion</th><th style='background-color:#024775; color:white;' align='center;'>No. Registro</th><th style='background-color:#024775; color:white;' align='center;'>Pais</th><th style='background-color:#024775; color:white;' align='center;'>Clase</th><th style='background-color:#024775; color:white;' align='center;'>Estatus</th><th style='background-color:#024775; color:white;' align='center;'>Fecha a Pagar Quinquenios o Anualidades</th><th style='background-color:#024775; color:white;' align='center;'>TipoPago</th><th style='background-color:#024775; color:white;' align='center;'>Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Vencimiento Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Uso</th><th style='background-color:#024775; color:white;' align='center;'>No. Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Tipo de Registro</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Registro</th><th style='background-color:#024775; color:white;' align='center;'>Despacho</th><th style='background-color:#024775; color:white;' align='center;'>Corresponsal</th><th style='background-color:#024775; color:white;' align='center;'>Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Cesion</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Cesion</th>";
                            if (registro.length > 0) {
                                for (let i = 0; i < registro.length; i++) {
                                    renglones += "<tr><td>" + registro[i].solicitud_tipo_desc + "</td><td>" + registro[i].nombre + "</td><td>" + registro[i].empresa_desc + "</td><td>" + registro[i].empresa_anterior_desc + "</td><td>" + registro[i].fecha_legalS + "</td><td>" + registro[i].fecha_vencimientoS + "</td><td>" + registro[i].fecha_concesionS + "</td><td>" + registro[i].no_registro + "</td><td>" + registro[i].pais_desc + "</td><td>" + registro[i].clase_desc + "</td><td>" + registro[i].estatus_desc + "</td><td>" + registro[i].fecha_quinquenio_anualidadS + "</td><td>" + registro[i].tipo_pago_desc + "</td><td>" + registro[i].prioridad + "</td><td>" + registro[i].fecha_vencimiento_prioridadS + "</td><td>" + registro[i].uso_desc + "</td><td>" + registro[i].no_solicitud + "</td><td>" + registro[i].tipo_registro_solicitud_desc + "</td><td>" + registro[i].autor_registro_desc + "</td><td>" + registro[i].despacho_desc + "</td><td>" + registro[i].corresponsal_desc + "</td><td>" + registro[i].licencia_desc + "</td><td>" + registro[i].solicitante_licencia_desc + "</td><td>" + registro[i].cesion_desc + "</td><td>" + registro[i].solicitante_cesion_desc + "</td></tr>";
                                }
                            }
                        } else {
                            encabezados = "<th style='background-color:#024775; color:white;' align='center;'>Tipo de Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Nombre</th><th style='background-color:#024775; color:white;' align='center;'>Empresa Propietaria</th><th style='background-color:#024775; color:white;' align='center;'>Enpresa Anterior</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Legal</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Vencimiento</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Concesion</th><th style='background-color:#024775; color:white;' align='center;'>No. Registro</th><th style='background-color:#024775; color:white;' align='center;'>Pais</th><th style='background-color:#024775; color:white;' align='center;'>Clase</th><th style='background-color:#024775; color:white;' align='center;'>Estatus</th><th style='background-color:#024775; color:white;' align='center;'>Fecha a Pagar Quinquenios o Anualidades</th><th style='background-color:#024775; color:white;' align='center;'>TipoPago</th><th style='background-color:#024775; color:white;' align='center;'>Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Vencimiento Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Uso</th><th style='background-color:#024775; color:white;' align='center;'>No. Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Tipo de Registro</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Registro</th><th style='background-color:#024775; color:white;' align='center;'>Despacho</th><th style='background-color:#024775; color:white;' align='center;'>Corresponsal</th><th style='background-color:#024775; color:white;' align='center;'>Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Cesion</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Cesion</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Requerimiento del Negocio</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Instrucciones al Corresponsal</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Registro Ante la Autoridad Competente</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Solicitud de Busqueda</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Informacion de Resultados al Negocio</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Comprobacion de Uso</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Declaracion de Uso</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th>";
                            if (registro.length > 0) {
                                for (let i = 0; i < registro.length; i++) {
                                    renglones += "<tr><td>" + registro[i].solicitud_tipo_desc + "</td><td>" + registro[i].nombre + "</td><td>" + registro[i].empresa_desc + "</td><td>" + registro[i].empresa_anterior_desc + "</td><td>" + registro[i].fecha_legalS + "</td><td>" + registro[i].fecha_vencimientoS + "</td><td>" + registro[i].fecha_concesionS + "</td><td>" + registro[i].no_registro + "</td><td>" + registro[i].pais_desc + "</td><td>" + registro[i].clase_desc + "</td><td>" + registro[i].estatus_desc + "</td><td>" + registro[i].fecha_quinquenio_anualidadS + "</td><td>" + registro[i].tipo_pago_desc + "</td><td>" + registro[i].prioridad + "</td><td>" + registro[i].fecha_vencimiento_prioridadS + "</td><td>" + registro[i].uso_desc + "</td><td>" + registro[i].no_solicitud + "</td><td>" + registro[i].tipo_registro_solicitud_desc + "</td><td>" + registro[i].autor_registro_desc + "</td><td>" + registro[i].despacho_desc + "</td><td>" + registro[i].corresponsal_desc + "</td><td>" + registro[i].licencia_desc + "</td><td>" + registro[i].solicitante_licencia_desc + "</td><td>" + registro[i].cesion_desc + "</td><td>" + registro[i].solicitante_cesion_desc + "</td><td>" + registro[i].fecha_requerimientoS + "</td><td>" + registro[i].fecha_requerimiento_completoS + "</td><td>" + registro[i].fecha_instruccionesS + "</td><td>" + registro[i].fecha_instrucciones_completoS + "</td><td>" + registro[i].fecha_registroS + "</td><td>" + registro[i].fecha_registro_completoS + "</td><td>" + registro[i].fecha_busquedaS + "</td><td>" + registro[i].fecha_busqueda_completoS + "</td><td>" + registro[i].fecha_resultadosS + "</td><td>" + registro[i].fecha_resultados_completoS + "</td><td>" + registro[i].fecha_comprobacionS + "</td><td>" + registro[i].fecha_comprobacion_completoS + "</td><td>" + registro[i].fecha_declaracionS + "</td><td>" + registro[i].fecha_declaracion_completoS + "</td></tr>";
                                }
                            }
                        }
                        //class='table table-bordered table-striped display nowrap" style = "width:100%'
                        //class='table table-bordered table-hover table-striped w-100'
                        tablecontent = "<table id='cTabla1_3' class='table-striped table-bordered table-hover display'><thead><tr>" + encabezados + "</tr></thead><tbody></tbody></table>";
                        /*tablecontent = "<table id='cTabla1_3'><thead><tr style='background-color: #161DEE; color: white;' align='center'>" + encabezados + "</tr></thead><tbody></tbody></table>";*/
                        $("#cTabla").html(tablecontent);
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML += renglones;
                        
                        $('#cTabla1_3').DataTable(
                            {
                                clear: true,
                                destroy: true,
                                scrollY: 700,
                                scrollX: true,
                                scrollCollapse: true,
                                autoWidth: false,
                                pageLength: 25,
                                paging: true,
                                lengthMenu: [[10, 25, 50, 100, 100000], [10, 25, 50, 100, "All"]],
                                autoFill: false,
                                //dom:
                                //    "<'row mb-3'<'col-sm-12 col-md-3 d-flex align-items-center justify-content-start'f><'col-sm-12 col-md-9 d-flex align-items-center justify-content-end'B>>" +
                                //                "<'row'<'col-sm-12'tr>>" +
                                //                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
                                //dom: 'Bfrtip',
                                //buttons: [
                                //    {
                                //        extend: 'copyHtml5',
                                //        exportOptions: { orthogonal: 'export' }
                                //    },
                                //    {
                                //        extend: 'excelHtml5',
                                //        exportOptions: { orthogonal: 'export' }
                                //    },
                                //    {
                                //        extend: 'pdfHtml5',
                                //        exportOptions: { orthogonal: 'export' }
                                //    }
                                //],
                                //layout: {
                                //    topStart: {
                                //        buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
                                //    }
                                //},
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay información",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Ultimo",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },
                                
                            });

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
                        $('#cTabla1_3').remove();
                        var tablecontent;
                        var encabezados = "";
                        var renglones = "";
                        if (cktodo.checked == false) {
                            encabezados = "<th style='background-color:#024775; color:white;' align='center;'>Tipo de Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Nombre</th><th style='background-color:#024775; color:white;' align='center;'>Empresa Propietaria</th><th style='background-color:#024775; color:white;' align='center;'>Enpresa Anterior</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Legal</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Vencimiento</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Concesion</th><th style='background-color:#024775; color:white;' align='center;'>No. Registro</th><th style='background-color:#024775; color:white;' align='center;'>Pais</th><th style='background-color:#024775; color:white;' align='center;'>Clase</th><th style='background-color:#024775; color:white;' align='center;'>Estatus</th><th style='background-color:#024775; color:white;' align='center;'>Fecha a Pagar Quinquenios o Anualidades</th><th style='background-color:#024775; color:white;' align='center;'>TipoPago</th><th style='background-color:#024775; color:white;' align='center;'>Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Vencimiento Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Uso</th><th style='background-color:#024775; color:white;' align='center;'>No. Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Tipo de Registro</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Registro</th><th style='background-color:#024775; color:white;' align='center;'>Despacho</th><th style='background-color:#024775; color:white;' align='center;'>Corresponsal</th><th style='background-color:#024775; color:white;' align='center;'>Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Cesion</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Cesion</th>";
                        } else {
                            encabezados = "<th style='background-color:#024775; color:white;' align='center;'>Tipo de Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Nombre</th><th style='background-color:#024775; color:white;' align='center;'>Empresa Propietaria</th><th style='background-color:#024775; color:white;' align='center;'>Enpresa Anterior</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Legal</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Vencimiento</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Concesion</th><th style='background-color:#024775; color:white;' align='center;'>No. Registro</th><th style='background-color:#024775; color:white;' align='center;'>Pais</th><th style='background-color:#024775; color:white;' align='center;'>Clase</th><th style='background-color:#024775; color:white;' align='center;'>Estatus</th><th style='background-color:#024775; color:white;' align='center;'>Fecha a Pagar Quinquenios o Anualidades</th><th style='background-color:#024775; color:white;' align='center;'>TipoPago</th><th style='background-color:#024775; color:white;' align='center;'>Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Vencimiento Prioridad</th><th style='background-color:#024775; color:white;' align='center;'>Uso</th><th style='background-color:#024775; color:white;' align='center;'>No. Solicitud</th><th style='background-color:#024775; color:white;' align='center;'>Tipo de Registro</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Registro</th><th style='background-color:#024775; color:white;' align='center;'>Despacho</th><th style='background-color:#024775; color:white;' align='center;'>Corresponsal</th><th style='background-color:#024775; color:white;' align='center;'>Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Licencia</th><th style='background-color:#024775; color:white;' align='center;'>Cesion</th><th style='background-color:#024775; color:white;' align='center;'>Persona que Solicito Cesion</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Requerimiento del Negocio</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Instrucciones al Corresponsal</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Registro Ante la Autoridad Competente</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Solicitud de Busqueda</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha de Informacion de Resultados al Negocio</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Comprobacion de Uso</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th><th style='background-color:#024775; color:white;' align='center;'>Fecha Declaracion de Uso</th><th style='background-color:#024775; color:white;' align='center;'>Completo</th>";
                        }
                        tablecontent = "<table id='cTabla1_3' class='table-striped table-bordered table-hover display'><thead><tr>" + encabezados + "</tr></thead><tbody></tbody></table>";
                        /*tablecontent = "<table id='cTabla1_3'><thead><tr style='background-color: #161DEE; color: white;' align='center'>" + encabezados + "</tr></thead><tbody></tbody></table>";*/
                        $("#cTabla").html(tablecontent);
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML = "";
                        document.getElementById("cTabla1_3").querySelector("tbody").innerHTML += renglones;

                        $('#cTabla1_3').DataTable(
                            {
                                clear: true,
                                destroy: true,
                                scrollY: 700,
                                scrollX: true,
                                scrollCollapse: true,
                                autoWidth: false,
                                pageLength: 25,
                                paging: true,
                                lengthMenu: [[10, 25, 50, 100, 100000], [10, 25, 50, 100, "All"]],
                                autoFill: false,
                                language: {
                                    "decimal": "",
                                    "emptyTable": "No hay informacion",
                                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                                    "infoPostFix": "",
                                    "thousands": ",",
                                    "lengthMenu": "Mostrar _MENU_ Entradas",
                                    "loadingRecords": "Cargando...",
                                    "processing": "Procesando...",
                                    "search": "Buscar:",
                                    "zeroRecords": "Sin resultados encontrados",
                                    "paginate": {
                                        "first": "Primero",
                                        "last": "Ultimo",
                                        "next": "Siguiente",
                                        "previous": "Anterior"
                                    }
                                },

                            });
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
        var cktodo = document.getElementById("chektodo");
        var ctodo = 0;
        if (cktodo.checked == true) ctodo = 1;
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
        var no_registro = $("#uu_03").val();
        var no_solicitud = $("#uu_11").val();
        var fecha_legalS = $("#uu_04").val();
        var fecha_vencimientoS = $("#uu_05").val();
        var fecha_concesionS = $("#uu_06").val();
        var fecha_quinquenio_anualidadS = $("#uu_37").val();
        var fecha_requerimientoS = $("#uu_21").val();
        var fecha_instruccionesS = $("#uu_22").val();
        var fecha_registroS = $("#uu_23").val();
        var fecha_busquedaS = $("#uu_24").val();
        var fecha_resultadosS = $("#uu_25").val();
        var fecha_comprobacionS = $("#uu_26").val();
        var sended_url = services_url + "ExcelRegistroMarca";
        //location.href = hosturl + "Admin/DescargarExcelRegistroMarca";
        //location.href = hosturl + "PI/BusquedaAvanzada";
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
                nombre: nombre,
                no_registro: no_registro,
                no_solicitud: no_solicitud,
                fecha_legalS: fecha_legalS,
                fecha_vencimientoS: fecha_vencimientoS,
                fecha_concesionS: fecha_concesionS,
                fecha_quinquenio_anualidadS: fecha_quinquenio_anualidadS,
                fecha_requerimientoS: fecha_requerimientoS,
                fecha_instruccionesS: fecha_instruccionesS,
                fecha_registroS: fecha_registroS,
                fecha_busquedaS: fecha_busquedaS,
                fecha_resultadosS: fecha_resultadosS,
                fecha_comprobacionS: fecha_comprobacionS,
                cktodo: ctodo
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
                        var rutaDocumento = hosturl + 'Content/PI/' + jsonResponse.info;
                        window.open(rutaDocumento, 'Download');
                        console.log("success");
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