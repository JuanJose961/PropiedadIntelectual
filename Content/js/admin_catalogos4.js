var muid = "";

$(document).ready(function () {
    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });


    $('#uu_09').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_10').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_11').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_12').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_13').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_14').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_15').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_16').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_21').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $("#contratol").hide();
    $("#solicitudl").hide();
    $("#oficiol").hide();
});

var catalogo_actual = {
    id: 0,
    cedente: 0,
    cedente_nombre: "",
    cesionario: 0,
    cesionario_nombre: "",
    solicitante: "NA",
    solicitante_nombre: "",
    nombre: "",
    numero_registro: "",
    numero_expediente: "",
    clase: 0,
    clase_nombre: "",
    pais: 0,
    pais_nombre: "",
    observaciones: "",
    despacho: 0,
    despacho_nombre: "",
    corresponsal: 0,
    corresponsal_nombre: "",
    tipo_cesion: 0,
    tipo_cesion_nombre: "",
    solicitud_filename: "",
    solicitud_size: 0,
    solicitud_nombre: "",
    solicitud_content_type: "",
    solicitud_extension: "",
    oficio_filename: "",
    oficio_size: 0,
    oficio_nombre: "",
    oficio_content_type: "",
    oficio_extension: "",
    contrato_filename: "",
    contrato_size: 0,
    contrato_nombre: "",
    contrato_content_type: "",
    contrato_extension: "",
    activo: 0,
    orden: 0,
    fecha_instruccionesS: "",
    fecha_instrucciones_completadoS: "",
    fecha_envio_documentosS: "",
    fecha_envio_documentos_completadoS: "",
    fecha_solicitudS: "",
    fecha_concesionS: "",
    fecha_legalS: "",
    fecha_vencimientoS: "",
    solicitud_fechaS: "",
    oficio_fechaS: "",
    contrato_fechaS: "",
    tipo: tipo,
    fecha_solicitud_completadoS: "",
}

function ModalNuevo() {
    catalogo_actual = {
        id: 0,
        cedente: 0,
        cedente_nombre: "",
        cesionario: 0,
        cesionario_nombre: "",
        solicitante: "NA",
        solicitante_nombre: "",
        nombre: "",
        numero_registro: "",
        numero_expediente: "",
        clase: 0,
        clase_nombre: "",
        pais: 0,
        pais_nombre: "",
        observaciones: "",
        despacho: 0,
        despacho_nombre: "",
        corresponsal: 0,
        corresponsal_nombre: "",
        tipo_cesion: 0,
        tipo_cesion_nombre: "",
        solicitud_filename: "",
        solicitud_size: 0,
        solicitud_nombre: "",
        solicitud_content_type: "",
        solicitud_extension: "",
        oficio_filename: "",
        oficio_size: 0,
        oficio_nombre: "",
        oficio_content_type: "",
        oficio_extension: "",
        contrato_filename: "",
        contrato_size: 0,
        contrato_nombre: "",
        contrato_content_type: "",
        contrato_extension: "",
        activo: 0,
        orden: 0,
        fecha_instruccionesS: "",
        fecha_instrucciones_completadoS: "",
        fecha_envio_documentosS: "",
        fecha_envio_documentos_completadoS: "",
        fecha_solicitudS: "",
        fecha_concesionS: "",
        fecha_legalS: "",
        fecha_vencimientoS: "",
        solicitud_fechaS: "",
        oficio_fechaS: "",
        contrato_fechaS: "",
        tipo: tipo,
        fecha_solicitud_completadoS: "",
    }
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");
    $("#update01 .form-control").removeAttr("disabled");
    $("#update01 .modal-title").html("<span>Nuevo registro</span>");
    $("#eliminausuario").hide();

    $("#uu_04").val(catalogo_actual.cedente).trigger("change");
    $("#uu_05").val(catalogo_actual.cesionario).trigger("change");
    //$("#uu_06").val(catalogo_actual.solicitante).trigger("change");
    $("#uu_06").val(catalogo_actual.solicitante_nombre);
    $("#uu_01").val(catalogo_actual.nombre);
    $("#uu_02").val(catalogo_actual.numero_registro);
    $("#uu_03").val(catalogo_actual.numero_expediente);
    $("#uu_07").val(catalogo_actual.clase);
    $("#uu_08").val(catalogo_actual.pais);

    $("#uu_09").val(catalogo_actual.fecha_instruccionesS);
    $("#uu_10").val(catalogo_actual.fecha_instrucciones_completadoS);
    $("#uu_11").val(catalogo_actual.fecha_envio_documentosS);
    $("#uu_12").val(catalogo_actual.fecha_envio_documentos_completadoS);
    $("#uu_13").val(catalogo_actual.fecha_solicitudS);
    $("#uu_21").val(catalogo_actual.fecha_solicitud_completadoS);
    $("#uu_14").val(catalogo_actual.fecha_concesionS);
    $("#uu_15").val(catalogo_actual.fecha_legalS);
    $("#uu_16").val(catalogo_actual.fecha_vencimientoS);

    $("#uu_09").datepicker("update", catalogo_actual.fecha_instruccionesS);
    $("#uu_10").datepicker("update", catalogo_actual.fecha_instrucciones_completadoS);
    $("#uu_11").datepicker("update", catalogo_actual.fecha_envio_documentosS);
    $("#uu_12").datepicker("update", catalogo_actual.fecha_envio_documentos_completadoS);
    $("#uu_13").datepicker("update", catalogo_actual.fecha_solicitudS);
    $("#uu_21").datepicker("update", catalogo_actual.fecha_solicitud_completadoS);
    $("#uu_14").datepicker("update", catalogo_actual.fecha_concesionS);
    $("#uu_15").datepicker("update", catalogo_actual.fecha_legalS);
    $("#uu_16").datepicker("update", catalogo_actual.fecha_vencimientoS);

    $("#uu_17").val(catalogo_actual.observaciones);
    $("#uu_18").val(catalogo_actual.despacho).trigger("change");
    $("#uu_19").val(catalogo_actual.corresponsal).trigger("change");
                //$("#uu_20").val(catalogo_actual.corresponsal).trigger("change");

    $("#solicitudl").hide();
    $("#contratol").hide();
    $("#oficiol").hide();
    $("#update01").modal("show");
};

function Editar(id) {
    catalogo_actual = {
        id: id,
        cedente: 0,
        cedente_nombre: "",
        cesionario: 0,
        cesionario_nombre: "",
        solicitante: "NA",
        solicitante_nombre: "",
        nombre: "",
        numero_registro: "",
        numero_expediente: "",
        clase: 0,
        clase_nombre: "",
        pais: 0,
        pais_nombre: "",
        observaciones: "",
        despacho: 0,
        despacho_nombre: "",
        corresponsal: 0,
        corresponsal_nombre: "",
        tipo_cesion: 0,
        tipo_cesion_nombre: "",
        solicitud_filename: "",
        solicitud_size: 0,
        solicitud_nombre: "",
        solicitud_content_type: "",
        solicitud_extension: "",
        oficio_filename: "",
        oficio_size: 0,
        oficio_nombre: "",
        oficio_content_type: "",
        oficio_extension: "",
        contrato_filename: "",
        contrato_size: 0,
        contrato_nombre: "",
        contrato_content_type: "",
        contrato_extension: "",
        activo: 0,
        orden: 0,
        fecha_instruccionesS: "",
        fecha_instrucciones_completadoS: "",
        fecha_envio_documentosS: "",
        fecha_envio_documentos_completadoS: "",
        fecha_solicitudS: "",
        fecha_concesionS: "",
        fecha_legalS: "",
        fecha_vencimientoS: "",
        solicitud_fechaS: "",
        oficio_fechaS: "",
        contrato_fechaS: "",
        tipo: tipo,
        fecha_solicitud_completadoS: "",
    }
    var sended_url = services_url + "SelectCatalogoById";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(catalogo_actual),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                catalogo_actual = jsonResponse.content[0];
                $("#update01 .form-error").remove();
                $("#update01 .form-control").removeClass("control-error");
                $("#update01 .form-control").removeAttr("disabled");
                $("#update01 .modal-title").html("<span>Editar registro</span>");

                $("#uu_04").val(catalogo_actual.cedente).trigger("change");
                $("#uu_05").val(catalogo_actual.cesionario).trigger("change");
                /*$("#uu_06").val(catalogo_actual.solicitante).trigger("change");*/
                $("#uu_06").val(catalogo_actual.solicitante_nombre);
                $("#uu_01").val(catalogo_actual.nombre);
                $("#uu_02").val(catalogo_actual.numero_registro);
                $("#uu_03").val(catalogo_actual.numero_expediente);
                $("#uu_07").val(catalogo_actual.clase);
                $("#uu_08").val(catalogo_actual.pais).trigger("change");

                $("#uu_09").val(catalogo_actual.fecha_instruccionesS);
                $("#uu_10").val(catalogo_actual.fecha_instrucciones_completadoS);
                $("#uu_11").val(catalogo_actual.fecha_envio_documentosS);
                $("#uu_12").val(catalogo_actual.fecha_envio_documentos_completadoS);
                $("#uu_13").val(catalogo_actual.fecha_solicitudS);
                $("#uu_21").val(catalogo_actual.fecha_solicitud_completadoS);
                $("#uu_14").val(catalogo_actual.fecha_concesionS);
                $("#uu_15").val(catalogo_actual.fecha_legalS);
                $("#uu_16").val(catalogo_actual.fecha_vencimientoS);

                $("#uu_09").datepicker("update",catalogo_actual.fecha_instruccionesS);
                $("#uu_10").datepicker("update",catalogo_actual.fecha_instrucciones_completadoS);
                $("#uu_11").datepicker("update",catalogo_actual.fecha_envio_documentosS);
                $("#uu_12").datepicker("update",catalogo_actual.fecha_envio_documentos_completadoS);
                $("#uu_13").datepicker("update", catalogo_actual.fecha_solicitudS);
                $("#uu_21").datepicker("update", catalogo_actual.fecha_solicitud_completadoS);
                $("#uu_14").datepicker("update",catalogo_actual.fecha_concesionS);
                $("#uu_15").datepicker("update",catalogo_actual.fecha_legalS);
                $("#uu_16").datepicker("update",catalogo_actual.fecha_vencimientoS);

                $("#uu_17").val(catalogo_actual.observaciones);
                $("#uu_18").val(catalogo_actual.despacho).trigger("change");
                $("#uu_19").val(catalogo_actual.corresponsal).trigger("change");
                $("#uu_20").val(catalogo_actual.tipo_cesion).trigger("change");

                if (catalogo_actual.contrato_permalink != "") {
                    $("#contratol").attr("href", catalogo_actual.contrato_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar documento (' + catalogo_actual.contrato_nombre_original + ')').show();
                } else {
                    $("#contratol").attr("href", "").hide();
                }
                if (catalogo_actual.solicitud_permalink != "") {
                    $("#solicitudl").attr("href", catalogo_actual.solicitud_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar documento (' + catalogo_actual.solicitud_nombre_original + ')').show();
                } else {
                    $("#solicitudl").attr("href", "").hide();
                }
                if (catalogo_actual.oficio_permalink != "") {
                    $("#oficiol").attr("href", catalogo_actual.oficio_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar documento (' + catalogo_actual.oficio_nombre_original + ')').show();
                } else {
                    $("#oficiol").attr("href", "").hide();
                }

                $("#eliminausuario").show();
                if (catalogo_actual.activo == 0) {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + catalogo_actual.activo + ")").text("Activar").addClass("btn-success").removeClass("btn-danger");
                } else {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + catalogo_actual.activo + ")").text("Inactivar").removeClass("btn-success").addClass("btn-danger");
                }
                $("#update01").modal("show");
            } else {
                //$("#btn-confirma").removeAttr("disabled");
            }
        },
        failure: function (response) {
            //$("#update01 .form-control").removeAttr("disabled");
            //$("#btn-confirma").removeAttr("disabled");
        },
        error: function (response) {
            //$("#update01 .form-control").removeAttr("disabled");
            //$("#btn-confirma").removeAttr("disabled");
        }
    });
}

function Confirma01() {
    if (ValidaUpdate01() != false) {
        $("#update01").modal("hide");
        setTimeout(function () {
            $("#alertModal .close").hide();
            $("#alertModal .modal-title").text("Guardando información");
            $("#alertModal .modal-footer").empty();
            $("#alertModal .form-group").empty();
            $("#alertModal .modal-spinner").show();
            $("#alertModal").modal("show");


            catalogo_actual.cedente = parseInt($("#uu_04 option:selected").val());
            catalogo_actual.cedente_nombre = $("#uu_04 option:selected").text();
            catalogo_actual.cesionario = parseInt($("#uu_05 option:selected").val());
            catalogo_actual.cesionario_nombre = $("#uu_05 option:selected").text();
            //catalogo_actual.solicitante = $("#uu_06 option:selected").val();
            catalogo_actual.solicitante = 0;
            //catalogo_actual.solicitante_nombre = $("#uu_06 option:selected").text();
            catalogo_actual.solicitante_nombre = $("#uu_06").val();
            catalogo_actual.nombre = $("#uu_01").val();
            catalogo_actual.numero_registro = $("#uu_02").val();
            catalogo_actual.numero_expediente = $("#uu_03").val();
            catalogo_actual.clase = parseInt($("#uu_07 option:selected").val());
            catalogo_actual.clase_nombre = $("#uu_07 option:selected").text();
            catalogo_actual.pais = parseInt($("#uu_08 option:selected").val());
            catalogo_actual.pais_nombre = $("#uu_08 option:selected").text();

            catalogo_actual.fecha_instruccionesS = $("#uu_09").val();
            catalogo_actual.fecha_instrucciones_completadoS = $("#uu_10").val();
            catalogo_actual.fecha_envio_documentosS = $("#uu_11").val();
            catalogo_actual.fecha_envio_documentos_completadoS = $("#uu_12").val();
            catalogo_actual.fecha_solicitudS = $("#uu_13").val();
            catalogo_actual.fecha_solicitud_completadoS = $("#uu_21").val();
            catalogo_actual.fecha_concesionS = $("#uu_14").val();
            catalogo_actual.fecha_legalS = $("#uu_15").val();
            catalogo_actual.fecha_vencimientoS = $("#uu_16").val();

            catalogo_actual.observaciones = $("#uu_17").val();
            catalogo_actual.despacho = parseInt($("#uu_18 option:selected").val());
            catalogo_actual.despacho_nombre = $("#uu_18 option:selected").text();
            catalogo_actual.corresponsal = parseInt($("#uu_19 option:selected").val());
            catalogo_actual.corresponsal_nombre = $("#uu_19 option:selected").text();
            catalogo_actual.tipo = tipo;
            catalogo_actual.tipo_cesion = parseInt($("#uu_20 option:selected").val());
            catalogo_actual.tipo_cesion_nombre = $("#uu_20 option:selected").text();

            var sended_url = services_url + "AddCatalogo";
            if (catalogo_actual.id > 0) {
                sended_url = services_url + "UpdateCatalogo";
            }

            $("#update01 .form-control").attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                url: sended_url,
                data: JSON.stringify(catalogo_actual),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#update01 .form-control").removeAttr("disabled");
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        catalogo_actual.id = jsonResponse.data_int;
                        $("#update01 .form-control").val("");
                        $("#tabla01").dxDataGrid("getDataSource").reload();
                        /*setTimeout(function () {
                            $("#update01").modal("hide");
                        }, 1000);*/

                        setTimeout(function () {
                            $("#alertModal .modal-title").text("Datos guardados");
                            $("#alertModal .modal-spinner").hide();
                            $("#alertModal .form-group").append("<p class=''>Se han guardados los datos correctamente</p>");
                            $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');


                            if ($('#contrato')[0].files.length > 0) {
                                uploading_contrato = true;
                                GuardarArchivo("#contrato", "contrato");
                            } else {
                                uploading_contrato = false;
                                //console.log("no hay archivos titulo");
                            }
                            if ($('#solicitud')[0].files.length > 0) {
                                uploading_solicitud = true;
                                GuardarArchivo("#solicitud", "solicitud");
                            } else {
                                uploading_solicitud = false;
                                //console.log("no hay archivos solicitud");
                            }
                            if ($('#oficio')[0].files.length > 0) {
                                uploading_oficio = true;
                                GuardarArchivo("#oficio", "oficio");
                            } else {
                                uploading_solicitud = false;
                                //console.log("no hay archivos solicitud");
                            }

                        }, 1500);
                    } else {
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#update01 .errores").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                        console.log("success");
                        console.log(jsonResponse.description);
                    }
                },
                failure: function (response) {
                    $("#update01 .form-control").removeAttr("disabled");
                    console.log("failure");
                    console.log(response);
                },
                error: function (response) {
                    $("#update01 .form-control").removeAttr("disabled");
                    console.log("error");
                    console.log(response);
                }
            });
        }, 1000);
    }
}


function ValidaUpdate01() {
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");

    var cedente = $("#uu_04 option:selected").val();
    var cesionario = $("#uu_05 option:selected").val();
    //var solicitante = $("#uu_06 option:selected").val();
    var solicitante_nombre = $("#uu_06").val();
    var pais = $("#uu_08 option:selected").val();

    console.log(cedente, cesionario, solicitante_nombre, pais);
    var errores = 0;
    var flag = false;

    if (cedente <= 0) {
        $("#uu_04").addClass("control-error");
        $("#uu_04_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }

    if (cesionario <= 0) {
        $("#uu_05").addClass("control-error");
        $("#uu_05_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }
    //if (solicitante.length <= 0 || solicitante == "NA") {
    //    $("#uu_06").addClass("control-error");
    //    $("#uu_06_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //}
    if (solicitante_nombre=="") {
        $("#uu_06").addClass("control-error");
        $("#uu_06_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (pais <= 0) {
        $("#uu_08").addClass("control-error");
        $("#uu_08_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

function eliminar01(id, val) {
    catalogo_actual.id = id;
    estatus_activo = val;
    if (val > 0) {
        $("#confirmaEliminar01 .modal-body .form-group p").text("Se necesita confirmación para desactivar los datos de este registro");
    } else {

        $("#confirmaEliminar01 .modal-body .form-group p").text("Se necesita confirmación para activar los datos de este registro");
    }
    $("#confirmaEliminar01").modal("show");
}

var estatus_activo = 0;
function ConfirmaEliminar01() {
    catalogo_actual.tipo = tipo;
    var sended_url = services_url + "UpdateCatalogoActivo";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(catalogo_actual),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                $("#tabla01").dxDataGrid("getDataSource").reload();
                
                if (estatus_activo == 0) {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + estatus_activo + ")").text("Inactivar").removeClass("btn-success").addClass("btn-danger");
                } else {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + estatus_activo + ")").text("Activar").addClass("btn-success").removeClass("btn-danger");
                }

                $("#confirmaEliminar01").modal("hide");
            } else {
                //
                $("#confirmaEliminar01 .modal-body .form-group").append("<p class='text-danger'>No se ha podido actualizar. Intentalo más tarde.</p>")
                console.log("success");
                console.log(jsonResponse.description);
            }
        },
        failure: function (response) {
            console.log("failure");
            console.log(response);
        },
        error: function (response) {
            console.log("error");
            console.log(response);
        }
    });
}


var uploading_contrato = false;
var uploading_solicitud = false;
var uploading_oficio = false;

$(document).on("change", "#solicitud", function (event) {
    readURL(this, "#solicitud", "#solicitudc");
});
$(document).on("change", "#contrato", function (event) {
    readURL(this, "#contrato", "#contratoc");
});
$(document).on("change", "#oficio", function (event) {
    readURL(this, "#oficio", "#oficioc");
});

function readURL(input, id, container) {
    if (input.files && input.files[0]) {
        var nombre = input.files[0].name;
        $(".btn-lbl[for='" + id.replace("#", "") + "']").html("<i class='fa fa-clock'></i> Archivo seleccionado (" + nombre + ")");
    }
}

function GuardarArchivo(input, tipo) {
    var formData = new FormData();
    switch (input) {
        case "#contrato":
            formData.append('file', $('#contrato')[0].files[0]);
            $("#alertModal .form-group").append("<p id='contrato_uploading'>Cargando archivos (Título) ...</p>");
            break;
        case "#solicitud":
            formData.append('file', $('#solicitud')[0].files[0]);
            $("#alertModal .form-group").append("<p id='solicitud_uploading'>Cargando archivos (Solicitud) ...</p>");
            break;
        case "#oficio":
            formData.append('file', $('#oficio')[0].files[0]);
            $("#alertModal .form-group").append("<p id='oficio_uploading'>Cargando archivos (Oficio de renovación) ...</p>");
            break;
    }
    formData.append('tipo', tipo);
    formData.append('usuario', eu_lu.id);
    formData.append('valor', catalogo_actual.id);
    $.ajax({
        url: hosturl + 'api/Archivos/CesionSaveFile',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (result) {
            $(input + "c " + input).remove();
            $(input + "c").append("<input type='file' class='form-control input-sm' id='" + input.replace("#", "") + "' style='display: none;' />");

            var jsonResponse = result;
            console.log(jsonResponse);
            if (jsonResponse.flag != false) {
                var nombre = jsonResponse.content[0];
                var permalink = jsonResponse.content[1];
                switch (input) {
                    case "#contrato":
                        uploading_contrato = false;
                        $("#contrato_uploading").text("Documento cargado correctamente (Título)");
                        $(".btn-lbl[for='contrato']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#contratol").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar documento (' + nombre + ')').show();
                        break;
                    case "#solicitud":
                        uploading_solicitud = false;
                        $("#solicitud_uploading").text("Documento cargado correctamente (Solicitud)");
                        $(".btn-lbl[for='solicitud']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#solicitudl").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar documento (' + nombre + ')').show();
                        break;
                    case "#oficio":
                        uploading_oficio = false;
                        $("#oficio_uploading").text("Documento cargado correctamente (Oficio de renovación)");
                        $(".btn-lbl[for='oficio']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#oficiol").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar documento (' + nombre + ')').show();
                        break;
                    default:
                        break;
                }
            } else {
                $(input + "c").append("<p class='form-error'>El campo está vacío</p>");
            }
            console.log("input: " + input, "tipo: " + tipo);
        },
        error: function (jqXHR) {
            switch (input) {
                case "#contrato":
                    uploading_contrato = false;
                    $(".btn-lbl[for='contrato']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#contrato_uploading").text("No se pudo cargar el archivo (Título)");
                    break;
                case "#solicitud":
                    uploading_solicitud = false;
                    $(".btn-lbl[for='solicitud']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#solicitud_uploading").text("No se pudo cargar el archivo (Solicitud)");
                    break;
                case "#oficio":
                    uploading_oficio = false;
                    $(".btn-lbl[for='oficio']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#oficio_uploading").text("No se pudo cargar el archivo (Oficio renovación)");
                    break;
                default:
                    break;
            }
        },
        complete: function (jqXHR, status) {
        }
    });

}