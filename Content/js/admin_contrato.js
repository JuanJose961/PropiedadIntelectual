var contrato = {
    id: 0,
    titulo: "",
    descripcion: "",
    inicio_vigencia: {
        yyyymmdd2: ""
    },
    termino_contrato: {
        yyyymmdd2: ""
    },
    termino_indefinido: 0,
    proveedor: "",
    identificador_proveedor: "",
    abogado: "",
    abogado_nombre: "",
    tipo_contrato: 0,
    tipo_contrato_desc: "",
    negocio: 0,
    negocio_desc: "",
    monto: 0,
    moneda: 0,
    moneda_desc: "",
    usuario: {
        yyyymmdd2: ""
    },
    folio: ""
};
var input_disabled = false;
function NotificacionContratoFirmado() {
    $("#confirmaFirmado").modal("show");
}
function ConfirmaNotificacionFirmado() {
    $("#confirmaFirmado").modal("hide");

    setTimeout(function () {
        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Cargando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        var sended_url = services_url + "EnviarNotificacionFirmado";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({ id: contrato.id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    $("#alertModal .modal-spinner").hide();
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        $("#alertModal .form-group").append("<p>Correo enviado correctamente</p>");
                        $("#alertModal .modal-footer").html('<button type="button" class="btn btn-default" data-dismiss="modal"><i class="fa fa-ban"></i> Ok</button>');
                        //$("#alertModal").modal("hide");
                    } else {
                        $("#alertModal .modal-footer").html('<button type="button" class="btn btn-default" data-dismiss="modal"><i class="fa fa-ban"></i> Ok</button>');
                        $("#guardaPrincipal").attr("disabled", "disabled");
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                }, 1500);
            },
            failure: function (response) {
                $("#alertModal .modal-spinner").hide();
            },
            error: function (response) {
                $("#alertModal .modal-spinner").hide();
            }
        });
    }, 1000);
}
var tipos_archivo = new Array();
$(document).ready(function () {
    $("#tabla011 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='ModalDocumentoCliente(7,\"Documento Cliente Manual\", \"Interno\");' id='btnDocumento'><i class='fa fa-plus'></i> Agregar documento</button>");
    $("#tabla01 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='NotificacionContratoFirmado();' id='contrato_firmado_notif'><i class='fa fa-envelope'></i> Enviar notificacion de contrato firmado</button>");

    $("#tabla02 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='ModalColaborador();' id='btnColaborador'><i class='fa fa-plus'></i> Agregar colaborador</button>");


    //$("#versionamiento .dx-toolbar-before").append("<h1 class='dx-toolbar-before-header'>Versionamiento</h1>");
    $(".ctm-header-area span").text("Módulo Contratos");
    var hoy = moment().format('YYYY-MM-DD');
    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });

    var today = new Date();
    $('#in00').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#in01').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    /*$("#in00").datepicker("update", new Date());
    $("#in01").datepicker("update", new Date());*/


    $('#doc22').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        startDate: today
    });
    $("#doc22").datepicker("update", new Date());
    //
    //$("#in060c").hide();
    $("#in060").attr("disabled","disabled");

    if (mainid > 0) {
        $("#collapseInfo").click();
        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Cargando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        var sended_url = services_url + "SelectContratoById";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({ id: mainid }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    $("#alertModal .modal-spinner").hide();
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        contrato = jsonResponse.content[0];
                        if (contrato.termino_indefinido == 1) {
                            $("#indefinido").prop("checked", true).trigger("change");
                        }
                        if (contrato.confidencial == 1) {
                            $("#confidencial").prop("checked", true).trigger("change");
                        }

                        tipo_archivo = jsonResponse.content[5];

                        var f_i = moment(contrato.inicio_vigencia.yyyymmdd2).format('DD/MM/YYYY');
                        var f_t = moment(contrato.termino_contrato.yyyymmdd2).format('DD/MM/YYYY');
                        $("#in00").val(f_i);
                        $("#in01").val(f_t);


                        $("#in00").datepicker("update", f_i);
                        $("#in01").datepicker("update", f_t);

                        $("#in02").val(contrato.negocio).trigger("change");
                        $("#in02").attr("disabled", "disabled");
                        $("#in03").val(contrato.titulo);
                        $("#in03c").show();
                        $("#in031").val(contrato.descripcion);
                        $("#in04").val(contrato.proveedor);
                        $("#in040").val(contrato.rfc);
                        //$("#in05").val(contrato.abogado).trigger("change");
                        $("#in06").val(contrato.tipo_contrato).trigger("change");
                        if (contrato.tipo_contrato == 19) {
                            $("#in060").val(contrato.tipo_contrato_desc).trigger("change");
                        }
                        $("#in07").val(contrato.monto);
                        $("#in08").val(contrato.moneda).trigger("change");
                        $("#folio").val(contrato.folio);

                        //
                        lista_documentos = jsonResponse.content[1];
                        console.log(lista_documentos);

                        ValidacionesArchivosContratos();

                        var documentacion_negocio = lista_documentos.filter(i => i.tipo_archivo.id != 6 && i.tipo_archivo.id != 7 && i.id > 0);
                        if (documentacion_negocio.length <= 0) {
                            $("#in02").removeAttr("disabled");
                        } else {
                            $("#in02").attr("disabled", "disabled");
                        }

                        var dev_documentos = new DevExpress.data.DataSource(lista_documentos);
                        $("#tabla01").dxDataGrid({
                            dataSource: dev_documentos,
                        });
                        $("#tabla01").dxDataGrid("getDataSource").reload();
                        //
                        lista_documentos_proveedor = jsonResponse.content[7];
                        var dev_documentos_cliente = new DevExpress.data.DataSource(lista_documentos_proveedor);
                        $("#tabla011").dxDataGrid({
                            dataSource: dev_documentos_cliente,
                        });
                        $("#tabla011").dxDataGrid("getDataSource").reload();
                        //
                        comentarios = jsonResponse.content[2];
                        RedibujaComentarios();
                        //
                        recordatorios = jsonResponse.content[3];
                        RedibujaRecordatorios();
                        //
                        colaboradores = jsonResponse.content[4];
                        var dev_colaboradores = new DevExpress.data.DataSource(colaboradores);
                        $("#tabla02").dxDataGrid({
                            dataSource: dev_colaboradores,
                        });
                        $("#tabla02").dxDataGrid("getDataSource").reload();

                        //$("#dueno").val(contrato.usuario.id).trigger("change");

                        CheckIfOptionExists("#dueno", contrato.usuario.id, contrato.usuario.name, true, true);
                        CheckIfOptionExists("#in05", contrato.abogado, contrato.abogado_nombre, true, true);

                        //$("#preGuardar").hide();
                        $("#extraContrato").show();
                        $("#postGuardar").show();
                        $("#in03c").show();

                        RecargaHistorialActividades();

                        $(".subheader-title span").text("Datos de contrato");

                        console.log(contrato.estatus_validacion, contrato.usuario.id, eu_lu.id);
                        switch (contrato.estatus_validacion) {
                            case 1:
                                if (contrato.usuario.id != eu_lu.id) {
                                    input_disabled = true;
                                    $(".form-control").attr("disabled", "disabled");
                                    $("input[type='checkbox']").attr("disabled", "disabled");

                                    //$("#btnRecordatorio").remove();
                                    $("#btnDocumento").remove();
                                    $(".btnDocumento").remove();
                                    //$("#btnComentario").css("visibility","hidden");
                                    $("#btnColaborador").remove();

                                    $(".contrato_acciones").remove();
                                }
                                break;
                            case 2:
                                if (contrato.abogado != eu_lu.id) {
                                    input_disabled = true;
                                    $(".form-control").attr("disabled", "disabled");
                                    $("input[type='checkbox']").attr("disabled", "disabled");

                                    //$("#btnRecordatorio").remove();
                                    $("#btnDocumento").remove();
                                    $(".btnDocumento").remove();
                                    //$("#btnComentario").css("visibility", "hidden");
                                    $("#btnColaborador").remove();

                                    $(".contrato_acciones").remove();
                                }
                                break;
                            case 3:
                                input_disabled = true;
                                $(".form-control").attr("disabled", "disabled");
                                $("input[type='checkbox']").attr("disabled", "disabled");

                                //$("#btnRecordatorio").remove();
                                $("#btnDocumento").remove();
                                $(".btnDocumento").remove();
                                //$("#btnComentario").css("visibility", "hidden");
                                $("#btnColaborador").remove();
                                $("#comentario").removeAttr("disabled");

                                //$(".contrato_acciones").remove();
                                break;
                        }

                        if (contrato.estatus_validacion == 4) {
                            input_disabled = true;
                            $(".form-control").attr("disabled", "disabled");
                            $("input[type='checkbox']").attr("disabled", "disabled");
                            //$("#preGuardar").remove();
                            //$("#postGuardar").remove();
                            //
                            //$("#doc11").removeAttr("disabled");
                            /**/
                            //$("#btnRecordatorio").remove();
                            //$("#btnDocumento").remove();
                            //$("#btnComentario").style("visibility", "hidden");
                            $("#btnColaborador").remove();
                            $("#firmado").removeAttr("disabled");
                            $("#doc01").removeAttr("disabled");
                            $("#comentario").removeAttr("disabled");
                        } else if (contrato.estatus_validacion == 5) {
                            if (contrato.abogado != eu_lu.id) {
                                input_disabled = true;
                                $(".form-control").attr("disabled", "disabled");
                                $("input[type='checkbox']").attr("disabled", "disabled");

                                //$("#btnRecordatorio").remove();
                                $("#btnDocumento").remove();
                                $(".btnDocumento").remove();
                                //$("#btnComentario").css("visibility", "hidden");
                                $("#btnColaborador").remove();
                            } else {
                                $("#doc11").removeAttr("disabled");
                                $("#doc01").removeAttr("disabled");
                                $("#comentario").removeAttr("disabled");
                            }
                        }


                        $("#comentariocolaborador").removeAttr("disabled");

                        if (eu_lu.role.id == "c696ba3f-4b65-4fb4-b31a-b2e96c9ffc99" ||
                            eu_lu.role.id == "e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b" ||
                            mainid == 0) {
                            //
                        } else {
                            /*//$(".form-control").attr("disabled", "disabled");
                            //$("input[type='checkbox']").attr("disabled", "disabled");
                            $("#preGuardar").remove();
                            //$("#postGuardar").remove();
                            $("#doc11").removeAttr("disabled");
                            $("#btnRecordatorio").remove();
                            $("#btnDocumento").remove();
                            $("#btnColaborador").remove();*/
                        }

                        if (contrato.usuario.id != eu_lu.id || contrato.estatus_validacion != 4) {
                            $("#contrato_firmado_notif").hide();
                        }
                        if (input_disabled != false) {
                            $("#preGuardar .guardaPrincipal").attr("disabled","disabled");
                        }
                        $("#comentario").removeAttr("disabled");
                        $("#doc01").removeAttr("disabled");
                        $("#doc11").removeAttr("disabled");
                        $("#doc21").removeAttr("disabled");
                        $("#doc22").removeAttr("disabled");
                        $("#doc23").removeAttr("disabled");
                        $("#colaborador").removeAttr("disabled");
                        $("#preGuardar #cancelaPrincipal").hide();
                        $("#preGuardar .guardaPrincipal").html('<i class="fa fa-save"></i> Guardar');
                        $("#collapseEstatusValidacion").text(contrato.estatus_validacion_desc).show();
                        $("#collapseEstatus").text(contrato.estatus_desc).show();
                        $("#alertModal").modal("hide");
                    } else {
                        $("#alertModal .modal-footer").html('<a href="' + hosturl + 'Admin/Contratos" class="btn btn-default"><i class="fa fa-undo"></i> Regresar a listado de contratos</a>');
                        $("#guardaPrincipal").attr("disabled", "disabled");
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                }, 1500);
            },
            failure: function (response) {
                $("#alertModal .modal-spinner").hide();
            },
            error: function (response) {
                $("#alertModal .modal-spinner").hide();
            }
        });
    } else {
        CheckIfOptionExists("#dueno", eu_lu.id, eu_lu.name, true, true);
    }

    if (eu_lu.role.id == "e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b") {
        $("#confidencialc").show();
        $("#duenoc").parent().show();
    }
});


$(document).on("change", "#in06", function () {
    var value = $(this).val();
    if (value == 19) {
        //$("#in060c").show();
        $("#in060").removeAttr("disabled");
        //$("#in060").val("");
    } else {
        $("#in060").attr("disabled","disabled");
        //$("#in060").val("");
    }

    if (value == 5 || value == 4) {
        $("#in060").val("");
        $("#in07").val(0);
        $("#in08").val(0).trigger("change");
        console.log("tacos");
        $("#in07").attr("disabled", "disabled");
        //$("#in08").val(1).trigger("change");
        $("#in08").attr("disabled", "disabled");
    } else {
        //$("#in08").val(0).trigger("change");
        $("#in07").removeAttr("disabled");
        $("#in08").removeAttr("disabled");
    }
});

$(document).on("change", "#indefinido", function () {
    if ($(this).is(":checked")) {
        $("#in01").attr("disabled", "disabled");
        $("#in01c").hide();
    } else {
        $("#in01").removeAttr("disabled");
        $("#in01c").show();
    }
});


$(document).on("change", "#in07", function () {
    $("#in07c .form-error").remove();

    $("#formContrato .form-control").removeClass("control-error");
    var val = $("#in07").val();
    if (val < 0) {
        $("#in07c").append("<p class='form-error'>El valor debe ser mayor o igual a 0</p>");
    }
});

function Confirma01(enviar) {
    $("#confirmaEstatus").modal("hide");
    if (Validar01() != false) {
        var indefinido = 0;
        var confidencial = 0;
        var comentario = $("#comentario").val();
        var inicio_vigencia = $("#in00").val();
        var termino_contrato = $("#in01").val();
        var negocio = parseInt($("#in02 option:selected").val());
        var negocio_desc = $("#in02 option:selected").text();
        var titulo = $("#in03").val();
        var descripcion = $("#in031").val();
        var proveedor = $("#in04").val();
        var rfc = $("#in040").val();
        var abogado = $("#in05 option:selected").val();
        var abogado_nombre = $("#in05 option:selected").text();
        var tipo_contrato = parseInt($("#in06 option:selected").val());
        var tipo_contrato_desc = $("#in06 option:selected").text();
        var monto = parseFloat($("#in07").val());
        var moneda = parseInt($("#in08 option:selected").val());
        var moneda_desc = $("#in08 option:selected").text();
        if ($("#indefinido").is(":checked")) {
            indefinido = 1;
        }
        if ($("#confidencial").is(":checked")) {
            confidencial = 1;
        }
        if (tipo_contrato == 19) {
            tipo_contrato_desc = $("#in060").val();
        }
        var dueno = $("#dueno option:selected").val();

        if (dueno == "NA") {
            contrato.usuario.id = eu_lu.id;
        } else {
            contrato.usuario.id = dueno;
        }

        if (contrato.abogado != abogado) {
            contrato.cambio_abogado = 1;
        } else {
            contrato.cambio_abogado = 0;
        }
        if (contrato.rfc != rfc) {
            contrato.cambio_rfc = 1;
        } else {
            contrato.cambio_rfc = 0;
        }
        contrato.comentario = comentario;
        contrato.termino_indefinido = indefinido;
        contrato.confidencial = confidencial;
        contrato.inicio_vigencia.yyyymmdd2 = inicio_vigencia;
        contrato.termino_contrato.yyyymmdd2 = termino_contrato;
        contrato.negocio = negocio;
        contrato.negocio_desc = negocio_desc;
        contrato.titulo = titulo;
        contrato.descripcion = descripcion;
        contrato.proveedor = proveedor;
        contrato.abogado = abogado;
        contrato.abogado_nombre = abogado_nombre;
        contrato.tipo_contrato = tipo_contrato;
        contrato.tipo_contrato_desc = tipo_contrato_desc;
        contrato.monto = monto;
        contrato.moneda = moneda;
        contrato.moneda_desc = moneda_desc;
        contrato.rfc = rfc;
        //contrato.usuario.id = eu_lu.id;
        $(".form-control").attr("disabled", "disabled");
        $("#guardaPrincipal").attr("disabled", "disabled");

        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Cargando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        var sended_url = services_url + "UpdateObjContrato";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({
                contrato: contrato,
                documentos: lista_documentos,
                documentos_cliente: new Array(), //lista_documentos_proveedor,
                comentarios: comentarios,
                recordatorios: recordatorios,
                colaboradores: colaboradores,
                enviar: enviar,
                usuario: eu_lu.id
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    if (input_disabled != true) {
                        $(".form-control").removeAttr("disabled");
                    }
                    $("#guardaPrincipal").removeAttr("disabled");
                    $("#guardaPrincipal").removeAttr("disabled");
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        if (contrato.id == 0) {
                            RecargaDocumentos(jsonResponse.data_int, contrato.rfc);
                            $("#preGuardar #cancelaPrincipal").hide();
                            $("#preGuardar .guardaPrincipal").html('<i class="fa fa-save"></i> Guardar');
                            $("#collapseEstatusValidacion").text("Solicitud en curso").show();
                            $("#collapseEstatus").text("Activo").show();
                        }
                        contrato.id = jsonResponse.data_int;
                        contrato.folio = jsonResponse.data_string;

                        for (var i = 0; i < lista_documentos_proveedor.length; i++) {
                            lista_documentos_proveedor[i].cargado = 1;
                        }

                        $("#folio").val(contrato.folio);

                        if (enviar == 1) {
                            $("#alertModal .modal-title").text("Datos guardados");
                            $("#alertModal .modal-spinner").hide();
                            $("#alertModal .form-group").append("<p class=''>Se han guardados los datos correctamente y se le ha enviado el contrato a el o los usuarios involucrados.</p>");
                            $("#alertModal .modal-footer").html('<a href="' + hosturl + 'Admin/Contratos" class="btn btn-info"><i class="fa fa-check"></i> Ver mis contratos</button>');
                        } else {
                            $("#alertModal .modal-title").text("Datos guardados");
                            $("#alertModal .modal-spinner").hide();
                            $("#alertModal .form-group").append("<p class=''>Se han guardados los datos correctamente</p>");
                            $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                        }

                        actualizaTitulo();
                        //$("#preGuardar").hide();
                        $(".subheader-title span").text("Datos de contrato");
                        $("#extraContrato").show();
                        $("#postGuardar").show();
                        $("#in03c").show();
                        $("#folio").attr("disabled", "disabled");
                        $("#in03").attr("disabled", "disabled");
                        //$("#in02").attr("disabled", "disabled");
                        $("#in06").trigger("change");


                    } else {
                        $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-default"><i class="fa fa-undo"></i> Ok</button>');
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                    RecargaHistorialActividades();
                }, 1500);
            },
            failure: function (response) {
                $(".form-control").removeAttr("disabled");
                $("#guardaPrincipal").removeAttr("disabled");
            },
            error: function (response) {
                $(".form-control").removeAttr("disabled");
                $("#guardaPrincipal").removeAttr("disabled");
            }
        });
    }
}

function Validar01() {
    $("#formContrato .form-error").remove();
    $("#formContrato .form-control").removeClass("control-error");
    $("#formContrato .select2.select2-container .select2-selection").removeClass("control-error");

    var indefinido = 0;
    var inicio_vigencia = $("#in00").val();
    var termino_contrato = $("#in01").val();
    var negocio = parseInt($("#in02 option:selected").val());
    var titulo = $("#in03").val();
    var descripcion = $("#in031").val();
    var proveedor = $("#in04").val();
    var abogado = $("#in05 option:selected").val();
    var tipo_contrato = parseInt($("#in06 option:selected").val());
    var tipo_contrato_desc = $("#in060").val();
    var monto = parseFloat($("#in07").val());
    var moneda = parseInt($("#in08 option:selected").val());
    var moment_inicioO = moment(inicio_vigencia, "DD/MM/YYYY");
    var moment_finO = moment(termino_contrato, "DD/MM/YYYY");
    var moment_inicio = moment_inicioO.toDate();
    var moment_fin = moment_finO.toDate();
    var errores = 0;
    var flag = false;

    if ($("#indefinido").is(":checked")) {
        indefinido = 1;
    }

    if (inicio_vigencia.length <= 0) {
        $("#in00").addClass("control-error");
        $("#in00c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (termino_contrato.length <= 0 && indefinido == 0) {
        $("#in01").addClass("control-error");
        $("#in01c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    } else if (moment(moment_inicio).isAfter(moment_fin) && indefinido == 0) {
        $("#in01").addClass("control-error");
        $("#in01c").append("<p class='form-error'>La fecha de término de contrato no puede ser menor a la fecha de inicio de vigencia</p>");
        errores += 1;
    }

    if (negocio <= 0) {
        $("#in02c .select2.select2-container .select2-selection").addClass("control-error");
        $("#in02c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }

    /*if (titulo.length <= 0) {
        $("#in03").addClass("control-error");
        $("#in03c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }*/

    if (proveedor.length <= 0) {
        $("#in04").addClass("control-error");
        $("#in04c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (abogado == "NA") {
        $("#in05c .select2.select2-container .select2-selection").addClass("control-error");
        $("#in05c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }

    if (tipo_contrato <= 0) {
        $("#in06c .select2.select2-container .select2-selection").addClass("control-error");
        $("#in06c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    } else if (tipo_contrato == 19 && tipo_contrato_desc.length <= 0) {
        $("#in060").addClass("control-error");
        $("#in060c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    } else if (tipo_contrato != 4 && tipo_contrato != 5) {


        if (moneda <= 0) {
            $("#in08c .select2.select2-container .select2-selection").addClass("control-error");
            $("#in08c").append("<p class='form-error'>Selecciona una opción válida</p>");
            errores += 1;
        }
    }

    if (monto < 0 || isNaN(monto)) {
        $("#in07").addClass("control-error");
        $("#in07c").append("<p class='form-error'>El valor debe ser mayor o igual a 0</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

function ModalDocumento(tipo, nombre) {
    documento = {
        id: 0,
        contrato: 0,
        comentario: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        },
        tipo: "default",
        tipo_archivo: {
            id: tipo,
            nombre: nombre
        }
    };
    $("#doc01").val("");

    $("#firmado").prop("checked", false).trigger("change");
    $("#dz-documentos .dz-message").text("Haz click aquí o arrastra aquí para cargar los archivos").show();
    $("#dz-documentos .dz-preview").remove();
    $("#dz-documentos").parent().find("label").show();
    $("#archivoModal .modal-spinner").hide();
    $("#archivoModal .form-error").remove();
    $("#archivoModal .modal-title").text("Adjuntar " + nombre);
    $("#archivoModal").modal("show");
}

function ModalDocumentoCliente(tipo, nombre, type) {
    documento = {
        id: 0,
        contrato: 0,
        comentario: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        },
        tipo: type,
        tipo_archivo: {
            id: tipo,
            nombre: nombre
        }
    };
    $("#doc01").val("");
    console.log("aaaaa", documento);
    $("#firmado").prop("checked", false).trigger("change");
    $("#dz-documentos .dz-message").text("Haz click aquí o arrastra aquí para cargar los archivos").show();
    $("#dz-documentos .dz-preview").remove();
    $("#dz-documentos").parent().find("label").show();
    $("#archivoModal .modal-spinner").hide();
    $("#archivoModal .form-error").remove();
    $("#archivoModal .modal-title").text("Adjuntar " + nombre);
    $("#archivoModal").modal("show");
}

var ultimo_versionamiento = 0;
function Ver(id) {
    documento = {
        id: id,
        contrato: 0,
        comentario: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        }
    };
    $("#da00").text("");
    $("#da01").text("");
    $("#da02").text("");
    $("#da03").text("");
    $("#detalleArchivoModal .modal-spinner").show();
    $("#detalleArchivoModal .modal-title").text("Cargando datos ...");
    $("#detalleArchivoModal").modal("show");
    $("#versionamiento").dxDataGrid({
        dataSource: new Array(),
    });
    $("#versionamiento").dxDataGrid("getDataSource").reload();
    var sended_url = services_url + "SelectDocumentoById";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(documento),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#detalleArchivoModal .modal-spinner").hide();
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    documento = jsonResponse.content[0];
                    ultimo_versionamiento = documento.id;
                    $("#detalleArchivoModal .modal-title").text("Versionamiento de " + documento.tipo_archivo.nombre);
                    $("#da00").text(documento.file_nombre);
                    $("#da01").text(moment(documento.fc).format("DD/MM/YYYY"));
                    $("#da02").text(documento.usuario.nombre);
                    $("#da03").text(documento.comentario);
                    $("#da05").text(documento.tipo_archivo.nombre);
                    $("#da06").text(documento.nombre_original);
                    $("#da04").attr("href", hosturl + "Admin/DescargarDocumento?id=" + documento.id + "&usuario=" + eu_lu.id);
                    if (documento.tipo == "firmado") {
                        $("#firmado").prop("checked", true);
                    } else {
                        $("#firmado").prop("checked", false);
                    }
                    if (contrato.estatus_validacion == 4 && documento.tipo_archivo.nombre == "Contrato Firmado") {
                        $("#firmadoc").show();
                    }
                    var dev_documentos = new DevExpress.data.DataSource(jsonResponse.content[2]);
                    $("#versionamiento").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#versionamiento").dxDataGrid("getDataSource").reload();
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#detalleArchivoModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }
            }, 1500);
        },
        failure: function (response) {
            $("#detalleArchivoModal .modal-spinner").hide();
        },
        error: function (response) {
            $("#detalleArchivoModal .modal-spinner").hide();
        }
    });
}

function RecargaDocumentos(id, rfc) {
    var sended_url = services_url + "SelectDocumentosFromContrato";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ id: id, rfc: rfc }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                lista_documentos = jsonResponse.content[0];

                var documentacion_negocio = lista_documentos.filter(i => i.tipo_archivo.id != 6 && i.tipo_archivo.id != 7 && i.id > 0);
                if (documentacion_negocio.length <= 0) {
                    $("#in02").removeAttr("disabled");
                } else {
                    $("#in02").attr("disabled", "disabled");
                }

                ValidacionesArchivosContratos();

                var dev_documentos = new DevExpress.data.DataSource(lista_documentos);
                $("#tabla01").dxDataGrid({
                    dataSource: dev_documentos,
                });
                $("#tabla01").dxDataGrid("getDataSource").reload();
                //
                lista_documentos_proveedor = jsonResponse.content[3];
                var dev_documentos_cliente = new DevExpress.data.DataSource(lista_documentos_proveedor);
                $("#tabla011").dxDataGrid({
                    dataSource: dev_documentos_cliente,
                });
                $("#tabla011").dxDataGrid("getDataSource").reload();
            } else {
                lista_documentos = new Array();

                ValidacionesArchivosContratos();

                var documentacion_negocio = lista_documentos.filter(i => i.tipo_archivo.id != 6 && i.tipo_archivo.id != 7 && i.id > 0);
                if (documentacion_negocio.length <= 0) {
                    $("#in02").removeAttr("disabled");
                } else {
                    $("#in02").attr("disabled", "disabled");
                }

                var dev_documentos = new DevExpress.data.DataSource(lista_documentos);
                $("#tabla01").dxDataGrid({
                    dataSource: dev_documentos,
                });
                $("#tabla01").dxDataGrid("getDataSource").reload();
                //
                lista_documentos_proveedor = new Array();
                var dev_documentos_cliente = new DevExpress.data.DataSource(lista_documentos_proveedor);
                $("#tabla011").dxDataGrid({
                    dataSource: dev_documentos_cliente,
                });
                $("#tabla011").dxDataGrid("getDataSource").reload();
            }
            //
        },
        failure: function (response) {
            $("#detalleArchivoModal .modal-spinner").hide();
        },
        error: function (response) {
            $("#detalleArchivoModal .modal-spinner").hide();
        }
    });
}

function Eliminar(id) {
    documento = {
        id: id,
        contrato: 0,
        comentario: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        }
    };
    $("#eliminarArchivoModal .modal-spinner").hide();
    $("#eliminarArchivoModal .form-error").remove();
    $("#eliminarArchivoModal").modal("show");
}

function EliminarDocCliente(id) {
    documento = {
        id: id,
        contrato: 0,
        comentario: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        }
    };
    $("#eliminarArchivoClienteModal .modal-spinner").hide();
    $("#eliminarArchivoClienteModal .form-error").remove();
    $("#eliminarArchivoClienteModal").modal("show");
}

function EliminarVersion(id, tipo_archivo) {
    documento = {
        id: id,
        contrato: 0,
        comentario: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        }
    };
    $("#detalleArchivoModal").modal("hide");
    setTimeout(function () {
        $("#eliminarArchivoVersionModal .modal-spinner").hide();
        $("#eliminarArchivoVersionModal .form-error").remove();
        $("#eliminarArchivoVersionModal").modal("show");
    }, 1000);
}

function CancelaEliminarDocumentoVersion() {
    $("#eliminarArchivoVersionModal").modal("hide");
    setTimeout(function () {
        $("#detalleArchivoModal").modal("show");
    }, 1000);
}

function ConfirmaEliminarDocumento() {
    $("#eliminarArchivoModal .modal-spinner").show();
    $("#eliminarArchivoModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "EliminarDocumento";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(documento),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#eliminarArchivoModal .modal-spinner").hide();
                $("#eliminarArchivoModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    var item = jsonResponse.content[0];
                    var search = searchArrayByKeyProp(documento.id, "id", lista_documentos);
                    if (item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual") {
                        search = searchArrayByKeyProp(documento.id, "id", lista_documentos_proveedor);
                    }
                    if (search != null) {
                        if (item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo") {
                            removeFromArray(search.idx, lista_documentos);
                        }
                        if (item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual") {
                            removeFromArray(search.idx, lista_documentos_proveedor);
                        } else {
                            var index = lista_documentos.findIndex(i => i.tipo_archivo.id == item.tipo_archivo.id);
                            if (index != null) {
                                lista_documentos[index] = item;
                            }
                        }
                    }

                    ValidacionesArchivosContratos();

                    var dev_documentos = new DevExpress.data.DataSource(lista_documentos);
                    $("#tabla01").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla01").dxDataGrid("getDataSource").reload();


                    var dev_documentos_dev = new DevExpress.data.DataSource(lista_documentos_proveedor.filter(i => i.cargado > -1));
                    $("#tabla011").dxDataGrid({
                        dataSource: dev_documentos_dev,
                    });
                    $("#tabla011").dxDataGrid("getDataSource").reload();

                    $("#eliminarArchivoModal").modal("hide");

                    //
                    var documentacion_negocio = lista_documentos.filter(i => i.tipo_archivo.id != 6 && i.tipo_archivo.id != 7 && i.id > 0);
                    if (documentacion_negocio.length <= 0) {
                        $("#in02").removeAttr("disabled");
                    } else {
                        $("#in02").attr("disabled", "disabled");
                    }
                    RecargaHistorialActividades();
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#eliminarArchivoModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }

            }, 1500);
        },
        failure: function (response) {
            $("#eliminarArchivoModal .modal-spinner").hide();
            $("#eliminarArchivoModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#eliminarArchivoModal .modal-spinner").hide();
            $("#eliminarArchivoModal .btn-info").removeAttr("disabled");
        }
    });
}

function ConfirmaEliminarDocCliente() {
    $("#eliminarArchivoClienteModal .modal-spinner").show();
    $("#eliminarArchivoClienteModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "EliminarDocumentoCliente";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(documento),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#eliminarArchivoClienteModal .modal-spinner").hide();
                $("#eliminarArchivoClienteModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    $("#eliminarArchivoClienteModal").modal("hide");
                    setTimeout(function () {
                        var search = searchArrayByKeyProp(documento.id, "id", lista_documentos_proveedor);
                        if (search != null) {
                            lista_documentos_proveedor[search.idx].activo = 0;
                        }
                        var dev_documentos_dev = new DevExpress.data.DataSource(lista_documentos_proveedor.filter(i => i.cargado > -1));
                        $("#tabla011").dxDataGrid({
                            dataSource: dev_documentos_dev,
                        });
                        $("#tabla011").dxDataGrid("getDataSource").reload();
                    }, 1000);
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#eliminarArchivoClienteModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }

            }, 1500);
        },
        failure: function (response) {
            $("#eliminarArchivoClienteModal .modal-spinner").hide();
            $("#eliminarArchivoClienteModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#eliminarArchivoClienteModal .modal-spinner").hide();
            $("#eliminarArchivoClienteModal .btn-info").removeAttr("disabled");
        }
    });
}

function ConfirmaEliminarDocumentoVersion() {
    $("#eliminarArchivoVersionModal .modal-spinner").show();
    $("#eliminarArchivoVersionModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "EliminarDocumento";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(documento),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#eliminarArchivoVersionModal .modal-spinner").hide();
                $("#eliminarArchivoVersionModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    $("#eliminarArchivoVersionModal").modal("hide");
                    setTimeout(function () {
                        //
                        var item = jsonResponse.content[0];
                        var search = searchArrayByKeyProp(documento.id, "id", lista_documentos);
                        if (item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual") {
                            search = searchArrayByKeyProp(documento.id, "id", lista_documentos_proveedor);
                        }
                        if (search != null) {
                            if (item.tipo_archivo.id == 3 || item.tipo_archivo.nombre == "Anexo") {
                                removeFromArray(search.idx, lista_documentos);
                            }
                            if (item.tipo_archivo.id == 7 || item.tipo_archivo.nombre == "Documento Cliente Manual") {
                                removeFromArray(search.idx, lista_documentos_proveedor);
                            } else {
                                var index = lista_documentos.findIndex(i => i.tipo_archivo.id == item.tipo_archivo.id);
                                if (index != null) {
                                    lista_documentos[index] = item;
                                }
                            }
                        }


                        ValidacionesArchivosContratos();

                        var dev_documentos = new DevExpress.data.DataSource(lista_documentos);
                        $("#tabla01").dxDataGrid({
                            dataSource: dev_documentos,
                        });
                        $("#tabla01").dxDataGrid("getDataSource").reload();


                        var dev_documentos_dev = new DevExpress.data.DataSource(lista_documentos_proveedor.filter(i => i.cargado > -1));
                        $("#tabla011").dxDataGrid({
                            dataSource: dev_documentos_dev,
                        });
                        $("#tabla011").dxDataGrid("getDataSource").reload();

                        $("#eliminarArchivoModal").modal("hide");

                        //
                        var documentacion_negocio = lista_documentos.filter(i => i.tipo_archivo.id != 6 && i.tipo_archivo.id != 7 && i.id > 0);
                        if (documentacion_negocio.length <= 0) {
                            $("#in02").removeAttr("disabled");
                        } else {
                            $("#in02").attr("disabled", "disabled");
                        }
                        RecargaHistorialActividades();
                        //
                        Ver(ultimo_versionamiento);
                    }, 1000);
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#eliminarArchivoVersionModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }

            }, 1500);
        },
        failure: function (response) {
            $("#eliminarArchivoVersionModal .modal-spinner").hide();
            $("#eliminarArchivoVersionModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#eliminarArchivoVersionModal .modal-spinner").hide();
            $("#eliminarArchivoVersionModal .btn-info").removeAttr("disabled");
        }
    });
}

var documento = {
    id: 0,
    contrato: 0,
    comentario: "",
    file_nombre: "",
    usuario: {
        id: eu_lu.id
    }
};

Dropzone.autoDiscover = false;
Dropzone.prototype.defaultOptions.dictFileTooBig = "El archivo es muy pesado ({{filesize}} MB). El máximo permitido es {{maxFilesize}} MB."
var dp1 = false;
var documentos01 = new Array();
var dzdocumentos = new Dropzone("#dz-documentos", {
    url: hosturl + "api/Archivos/ArchivoContrato",
    maxFiles: 1,
    autoProcessQueue: false,
    parallelUploads: 1,
    maxFilesize: 120,
    previewTemplate: previewTemplate(),
    timeout: 180000,
    accept: function (file, done) {
        if (file.size == 0) {
            done("Empty files will not be uploaded.");
            $("#dzAlert").modal("show");
        }
        else {
            done();
        }
    },
    uploadprogress: function (file, progress, bytesSent) {
        if (file.previewElement) {
            var progressElement = file.previewElement.querySelector("[data-dz-uploadprogress]");
            progressElement.style.width = progress + "%";
            progressElement.querySelector(".progress-text").textContent = progress + "%";
        }
    },
    init: function () {
        this.on("sending", function (file, xhr, formData) {
            console.log(documento);
            formData.append("contrato", contrato.id);
            formData.append("usuario", eu_lu.id);
            var tipo = "default";
            if (documento.tipo != "") {
                tipo = documento.tipo;
            }
            if ($("#firmado").is(":checked")) {
                tipo = "firmado";
            }
            formData.append("tipo", tipo);
            formData.append("tipo_archivo", documento.tipo_archivo.id);
            formData.append("modelo", "Contrato");
        });

        this.on("success", function (file, responseText) {
            var jsonResponse = responseText;
            if (jsonResponse.flag != false) {
                try {
                    documentos01.push(jsonResponse.content[0]);
                    console.log(documentos01);

                    documento.id = jsonResponse.content[0].id;
                    documento.contrato = contrato.id;
                    documento.usuario.id = eu_lu.id;
                    documento.file_nombre = jsonResponse.content[0].file_nombre;

                    Confirma02();
                    /*
                    var dev_documentos = new DevExpress.data.DataSource(documentos01);
                    $("#tabla01").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla01").dxDataGrid("getDataSource").reload();*/
                } catch (ex) {
                    console.log(ex);
                }
            }
            /*var jsonResponse = responseText;
            if (jsonResponse.flag != false) {
                try {
                    documento.id = jsonResponse.data_int;
                    documento.contrato = contrato.id;
                    documento.usuario.id = eu_lu.id;
                    documento.file_nombre = jsonResponse.data_string;

                    $("#dz-documentos .dz-preview").remove();
                    $("#dz-documentos .dz-message").text("Ya hay archivos").hide();
                    var item = getFileItem(jsonResponse.data_string);
                    $("#dz-documentos").append(item);
                    $("#dz-documentos").parent().find("label").show();

                    $("#doc00c .form-error").remove();
                    dp1 = true;
                } catch (ex) {
                }
            }*/
        });

        this.on("error", function (file, responseText) {
            dzdocumentos.removeFile(file);
            console.log(file, responseText);

            /*$("#archivoModal .form-error").remove();
            $("#archivoModal .errores").append("<p class='form-error'>" + responseText + "</p>");*/
        });


        this.on("addedfile", function (file, responseText) {
            $("#archivoModal .form-error").remove();
            dp1 = true;
            $("#dz-documentos .dz-message").hide();
            if (dzdocumentos.files.length > 1) {
                dzdocumentos.removeFile(dzdocumentos.files[0]);
            }
            console.log(file, responseText);
        });

        this.on("queuecomplete", function (file, responseText) {
        });
    }
});

function getFileItem(filename) {
    var imageurl = hosturl + "Content/images/default-dz-file.png";
    return '<div class="dz-preview dz-image-preview dz-processing dz-success dz-complete">' +
        '<div class="dz-image">' +
        '   <img data-dz-thumbnail="" alt="' + filename + '" src="' + imageurl + '">' +
        '</div > ' +
        '<div class="dz-details">' +
        '<div class="dz-filename"><span data-dz-name="">' + filename + '</span></div>' +
        '</div> ' +
        '</div>';
}

function previewTemplate() {
    var imageurl = hosturl + "Content/images/default-dz-file.png";
    return '<div class="dz-preview dz-image-preview dz-processing dz-success dz-complete">' +
        '<div class="dz-image">' +
        '   <img data-dz-thumbnail="" alt="uploading" src="' + imageurl + '">' +
        '</div > ' +
        '<div class="dz-details">' +
        '<div class="dz-progress"><span class="dz-upload" data-dz-uploadprogress><span class="progress-text"></span></span></div>' +
        '<div class="dz-filename"><span data-dz-name="">Cargando archivo ...</span></div>' +
        '</div> ' +
        '</div>';
}

function ConfirmaUploadArchivo() {
    if (Validar02() != false) {

        $("#archivoModal .modal-spinner").show();
        $("#archivoModal .form-control").attr("disabled", "disabled");
        $("#archivoModal .btn-info").attr("disabled", "disabled");
        $("#archivoModal .modal-spinner").show();

        //dzdocumentos.hiddenFileInput.click();
        dzdocumentos.processQueue();
    }
}

function Confirma02() {
    if (Validar02() != false) {
        var tipo = "default";
        if ($("#firmado").is(":checked")) {
            tipo = "firmado";
        }
        documento.comentario = $("#doc01").val();
        documento.tipo = tipo;

        /*$("#archivoModal .modal-spinner").show();
        $("#archivoModal .form-control").attr("disabled", "disabled");
        $("#archivoModal .btn-info").attr("disabled", "disabled");
        $("#archivoModal .modal-spinner").show();*/

        var sended_url = services_url + "AddDocumentoContrato";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(documento),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    $("#archivoModal .form-control").removeAttr("disabled");
                    $("#archivoModal .btn-info").removeAttr("disabled");
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        $("#archivoModal .modal-spinner").hide();
                        if (jsonResponse.content.length > 0) {
                            //lista_documentos.push(jsonResponse.content[0]);
                            //
                            if (documento.tipo_archivo.id == 3) {
                                var cantidad = lista_documentos.filter(i => i.tipo_archivo.id == documento.tipo_archivo.id);
                                if (cantidad.length > 0) {
                                    lista_documentos.push(jsonResponse.content[0]);
                                } else {
                                    var index = lista_documentos.findIndex(i => i.tipo_archivo.id == documento.tipo_archivo.id);
                                    if (index != null) {
                                        lista_documentos[index] = jsonResponse.content[0];
                                    }
                                }
                            }
                            else if (documento.tipo_archivo.id == 7) {
                                lista_documentos_proveedor.push(jsonResponse.content[0]);
                            }
                            else {
                                var index = lista_documentos.findIndex(i => i.tipo_archivo.id == documento.tipo_archivo.id);
                                if (index != null) {
                                    lista_documentos[index] = jsonResponse.content[0];
                                }
                            }
                        }


                        ValidacionesArchivosContratos();

                        var documentacion_negocio = lista_documentos.filter(i => i.tipo_archivo.id != 6 && i.tipo_archivo.id != 7 && i.id > 0);
                        if (documentacion_negocio.length <= 0) {
                            $("#in02").removeAttr("disabled");
                        } else {
                            $("#in02").attr("disabled", "disabled");
                        }

                        var dev_documentos = new DevExpress.data.DataSource(lista_documentos);
                        $("#tabla01").dxDataGrid({
                            dataSource: dev_documentos,
                        });
                        $("#tabla01").dxDataGrid("getDataSource").reload();

                        $("#archivoModal").modal("hide");

                        //-------------------------------

                        var dev_documentos_dev = new DevExpress.data.DataSource(lista_documentos_proveedor.filter(i => i.cargado > -1));
                        $("#tabla011").dxDataGrid({
                            dataSource: dev_documentos_dev,
                        });
                        $("#tabla011").dxDataGrid("getDataSource").reload();

                        RecargaHistorialActividades();
                    } else {
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#archivoModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                }, 1500);
            },
            failure: function (response) {
                $("#archivoModal .form-control").removeAttr("disabled");
                $("#archivoModal .btn-info").removeAttr("disabled");
            },
            error: function (response) {
                $("#archivoModal .form-control").removeAttr("disabled");
                $("#archivoModal .btn-info").removeAttr("disabled");
            }
        });
    }
}

function Validar02() {
    $("#archivoModal .form-error").remove();
    $("#archivoModal .form-control").removeClass("control-error");
    $("#archivoModal .select2.select2-container .select2-selection").removeClass("control-error");

    var descripcion = $("#doc01").val();

    var errores = 0;
    var flag = false;

    if (dp1 == false) {
        $("#doc00").addClass("control-error");
        $("#doc00c").append("<p class='form-error'>No se ha cargado ningun documento</p>");
        errores += 1;
    }

    /*if (descripcion.length <= 0) {
        $("#doc01").addClass("control-error");
        $("#doc01c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }*/

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

//documentos

var lista_documentos_proveedor = new Array();

var comentario = {
    id: 0,
    contrato: 0,
    descripcion: "",
    usuario: {
        id: eu_lu.id
    }
};
function ModalComentario() {
    comentario = {
        id: 0,
        contrato: 0,
        descripcion: "",
        file_nombre: "",
        usuario: {
            id: eu_lu.id
        }
    };
    $("#doc11").val("");
    $("#comentarioModal .modal-spinner").hide();
    $("#comentarioModal .form-error").remove();
    $("#comentarioModal").modal("show");
}


function Confirma03() {
    if (Validar03() != false) {
        comentario.descripcion = $("#doc11").val();
        comentario.contrato = contrato.id;

        $("#comentarioModal .modal-spinner").show();
        $("#comentarioModal .form-control").attr("disabled", "disabled");
        $("#comentarioModal .btn-info").attr("disabled", "disabled");
        $("#comentarioModal .modal-spinner").show();

        var sended_url = services_url + "AddComentarioContrato";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(comentario),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    $("#comentarioModal .form-control").removeAttr("disabled");
                    $("#comentarioModal .btn-info").removeAttr("disabled");
                    $("#comentarioModal .modal-spinner").hide();
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        if (jsonResponse.content.length > 0) {
                            comentarios.unshift(jsonResponse.content[0]);
                        }
                        RedibujaComentarios();
                        $("#comentarioModal").modal("hide");
                        RecargaHistorialActividades();
                    } else {
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#comentarioModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                }, 1500);
            },
            failure: function (response) {
                $("#comentarioModal .form-control").removeAttr("disabled");
                $("#comentarioModal .btn-info").removeAttr("disabled");
            },
            error: function (response) {
                $("#comentarioModal .form-control").removeAttr("disabled");
                $("#comentarioModal .btn-info").removeAttr("disabled");
            }
        });
    }
}

function Validar03() {
    $("#comentarioModal .form-error").remove();
    $("#comentarioModal .form-control").removeClass("control-error");
    $("#comentarioModal .select2.select2-container .select2-selection").removeClass("control-error");

    var descripcion = $("#doc11").val();

    var errores = 0;
    var flag = false;

    if (descripcion.length <= 0) {
        $("#doc11").addClass("control-error");
        $("#doc11c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

var comentarios = new Array();
function RedibujaComentarios() {
    $("#comentarios").empty();
    if (comentarios.length > 0) {
        for (var i = 0; i < comentarios.length; i++) {
            var el = comentarios[i];
            var acciones = '<span onclick="EliminarComentario(' + el.id + ')"><i class="fa fa-times"></i></span>';
            if (el.usuario.id != eu_lu.id) {
                acciones = "";
            }

            var li = '<li class="ctm-comentario">' +
                '<div class="ctm-comentario-header">' +
                '<h4>' + el.usuario.nombre + '</h4>' +
                acciones +
                '</div>' +
                '<div class="ctm-comentario-body">' +
                '<p>' + el.descripcion + '</p>' +
                '</div>' +
                '<div class="ctm-comentario-footer">' +
                '<span>' + el.FC_d + '</span>' +
                '</div>' +
                '</li>';
            $("#comentarios").append(li);
        }
    } else {
        var li = '<li class="ctm-comentario">' +
            '<div class="ctm-comentario-body">' +
            '<p>No hay comentarios aún</p>' +
            '</div>'
            '</li>';
        $("#comentarios").append(li);
    }
}

//---------------------------
var recordatorio = {
    id: 0,
    contrato: 0,
    descripcion: "",
    usuario: {
        id: ""
    },
    asignado: {
        id: ""
    },
    autor: {
        id: ""
    },
    FR_d: ""
};
function ModalRecordatorio() {
    recordatorio = {
        id: 0,
        contrato: 0,
        descripcion: "",
        usuario: {
            id: eu_lu.id
        },
        autor: {
            id: ""
        },
        asignado: {
            id: ""
        },
        FR_d: ""
    };
    $("#doc21").val("");
    $("#doc22").datepicker("update", new Date());

    $("#colaborador").prop("checked", false);
    $("#colaborador").removeAttr("disabled");

    $("#doc23").val(eu_lu.id).trigger("change");


    $("#recordatorioModal .modal-spinner").hide();
    $("#recordatorioModal .form-error").remove();
    $("#recordatorioModal").modal("show");
}


function Confirma04() {
    if (Validar04() != false) {
        if ($("#colaborador").is(":checked")) {
            recordatorio.colaborador = 1;
        } else {
            recordatorio.colaborador = 0;
        }
        recordatorio.descripcion = $("#doc21").val();
        recordatorio.FR_d = $("#doc22").val();
        recordatorio.asignado.id = $("#doc23").val();
        recordatorio.asignado.nombre = $("#doc23 option:selected").text();
        recordatorio.contrato = contrato.id;

        recordatorio.autor.id = eu_lu.id;
        recordatorio.autor.nombre = eu_lu.name;

        $("#recordatorioModal .modal-spinner").show();
        $("#recordatorioModal .form-control").attr("disabled", "disabled");
        $("#recordatorioModal .btn-info").attr("disabled", "disabled");
        $("#recordatorioModal .modal-spinner").show();

        var sended_url = services_url + "AddRecordatorioContrato";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(recordatorio),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    $("#recordatorioModal .form-control").removeAttr("disabled");
                    $("#recordatorioModal .btn-info").removeAttr("disabled");
                    $("#recordatorioModal .modal-spinner").hide();
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        if (jsonResponse.content.length > 0) {
                            recordatorios.unshift(jsonResponse.content[0]);
                        }
                        RedibujaRecordatorios();
                        $("#recordatorioModal").modal("hide");
                        RecargaHistorialActividades();

                        if (jsonResponse.content.length > 1) {
                            colaboradores.push(jsonResponse.content[1]);
                            var dev_colaboradores = new DevExpress.data.DataSource(colaboradores);
                            $("#tabla02").dxDataGrid({
                                dataSource: dev_colaboradores,
                            });
                            $("#tabla02").dxDataGrid("getDataSource").reload();
                        }
                    } else {
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#recordatorioModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                }, 1500);
            },
            failure: function (response) {
                $("#recordatorioModal .form-control").removeAttr("disabled");
                $("#recordatorioModal .btn-info").removeAttr("disabled");
            },
            error: function (response) {
                $("#recordatorioModal .form-control").removeAttr("disabled");
                $("#recordatorioModal .btn-info").removeAttr("disabled");
            }
        });
    }
}

function Validar04() {
    $("#recordatorioModal .form-error").remove();
    $("#recordatorioModal .form-control").removeClass("control-error");
    $("#recordatorioModal .select2.select2-container .select2-selection").removeClass("control-error");

    var descripcion = $("#doc21").val();
    var fecha = $("#doc22").val();
    var asignado = $("#doc23").val();

    var errores = 0;
    var flag = false;

    if (descripcion.length <= 0) {
        $("#doc21").addClass("control-error");
        $("#doc21c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }
    if (fecha.length <= 0) {
        $("#doc22").addClass("control-error");
        $("#doc22c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }
    if (asignado == "NA") {
        $("#doc23").addClass("control-error");
        $("#doc23c").append("<p class='form-error'>Selecciona un usuario</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

var recordatorios = new Array();
function RedibujaRecordatorios() {
    $("#recordatorios").empty();
    if (recordatorios.length > 0) {
        for (var i = 0; i < recordatorios.length; i++) {
            var el = recordatorios[i];

            var acciones = '<span onclick="EliminarRecordatorio(' + el.id + ')"><i class="fa fa-times"></i></span>';
            if (el.usuario.id != eu_lu.id) {
                acciones = "";
            }
            var li = '<li class="ctm-comentario">' +
                '<div class="ctm-comentario-header">' +
                '<h4>Recordatorio con fecha: ' + el.FR_d + ' para el usuario: ' + el.asignado.nombre + '</h4>' +
                acciones +
                '</div>' +
                '<div class="ctm-comentario-body">' +
                '<p>' + el.descripcion + '</p>' +
                '</div>' +
                '<div class="ctm-comentario-footer">' +
                '<span>' + el.FC_d + '</span>' +
                '</div>' +
                '</li>';
            $("#recordatorios").append(li);
        }
    } else {
        var li = '<li class="ctm-comentario">' +
            '<div class="ctm-comentario-body">' +
            '<p>No hay comentarios aún</p>' +
            '</div>'
        '</li>';
        $("#recordatorios").append(li);
    }
}

//--------------------------

var colaboradores = new Array();
var colaborador = {
    id: 0,
    contrato: 0,
    usuario: {
        id: eu_lu.id
    },
    autor: {
        id: eu_lu.id
    }
};
function ModalColaborador() {
    colaborador = {
        id: 0,
        contrato: 0,
        usuario: {
            id: eu_lu.id
        },
        autor: {
            id: eu_lu.id
        }
    };
    $("#doc31").val("NA").trigger("change");
    $("#colaboradorModal .modal-spinner").hide();
    $("#colaboradorModal .form-error").remove();
    $("#colaboradorModal").modal("show");
}
function EditarColaborador(id, usuario) {
    colaborador = {
        id: id,
        contrato: 0,
        usuario: {
            id: usuario
        },
        autor: {
            id: eu_lu.id
        }
    };
    $("#doc31").val(usuario).trigger("change");
    $("#colaboradorModal .modal-spinner").hide();
    $("#colaboradorModal .form-error").remove();
    $("#colaboradorModal").modal("show");
}

$(document).on("change", "#doc23", function (event) {
    var val = $(this).val();
    var abogado = $("#in05").val();
    if (val == abogado) {
        $("#colaborador").prop("checked", false);
        $("#colaborador").attr("disabled", "disabled");
    } else {
        $("#colaborador").removeAttr("disabled");
    }
});
function Confirma05() {
    if (Validar05() != false) {
        colaborador.usuario.id = $("#doc31").val();
        colaborador.usuario.nombre = $("#doc31 option:selected").text();
        colaborador.autor.id = eu_lu.id;
        colaborador.autor.nombre = eu_lu.name;
        colaborador.contrato = contrato.id;

        $("#colaboradorModal .modal-spinner").show();
        $("#colaboradorModal .form-control").attr("disabled", "disabled");
        $("#colaboradorModal .btn-info").attr("disabled", "disabled");
        $("#colaboradorModal .modal-spinner").show();

        var sended_url = services_url + "AddColaboradorContrato";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(colaborador),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    $("#colaboradorModal .form-control").removeAttr("disabled");
                    $("#colaboradorModal .btn-info").removeAttr("disabled");
                    $("#colaboradorModal .modal-spinner").hide();
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {
                        if (colaborador.id == 0) {
                            if (jsonResponse.content.length > 0) {
                                colaboradores.push(jsonResponse.content[0]);
                            }
                        } else {
                            var search = searchArrayByKeyProp(colaborador.id, "id", colaboradores);
                            if (search != null) {
                                colaboradores[search.idx] = jsonResponse.content[0];
                            }
                        }
                        var dev_colaboradores = new DevExpress.data.DataSource(colaboradores);
                        $("#tabla02").dxDataGrid({
                            dataSource: dev_colaboradores,
                        });
                        $("#tabla02").dxDataGrid("getDataSource").reload();

                        $("#colaboradorModal").modal("hide");
                        RecargaHistorialActividades();
                    } else {
                        for (var i = 0; i < jsonResponse.errors.length; i++) {
                            $("#colaboradorModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                        }
                    }
                }, 1500);
            },
            failure: function (response) {
                $("#colaboradorModal .form-control").removeAttr("disabled");
                $("#colaboradorModal .btn-info").removeAttr("disabled");
            },
            error: function (response) {
                $("#colaboradorModal .form-control").removeAttr("disabled");
                $("#colaboradorModal .btn-info").removeAttr("disabled");
            }
        });
    }
}

function Validar05() {
    $("#colaboradorModal .form-error").remove();
    $("#colaboradorModal .form-control").removeClass("control-error");
    $("#colaboradorModal .select2.select2-container .select2-selection").removeClass("control-error");

    var asignado = $("#doc31").val();

    var abogado = $("#in05").val();

    var errores = 0;
    var flag = false;

    if (asignado == "NA") {
        $("#doc31").addClass("control-error");
        $("#doc31c").append("<p class='form-error'>Selecciona un usuario</p>");
        errores += 1;
    } else if (abogado == asignado) {
        $("#doc31").addClass("control-error");
        $("#doc31c").append("<p class='form-error'>Este usuario ya se encuentra asignado como abogado</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

function EliminarColaborador(id) {
    colaborador = {
        id: id,
        contrato: 0,
        usuario: {
            id: eu_lu.id
        },
        autor: {
            id: eu_lu.id
        }
    };
    $("#eliminarColaboradorModal .modal-spinner").hide();
    $("#eliminarColaboradorModal .form-error").remove();
    $("#eliminarColaboradorModal").modal("show");
}

function ConfirmaEliminarColaborador() {
    $("#eliminarColaboradorModal .modal-spinner").show();
    $("#eliminarColaboradorModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "EliminarColaborador";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(colaborador),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#eliminarColaboradorModal .modal-spinner").hide();
                $("#eliminarColaboradorModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    var search = searchArrayByKeyProp(colaborador.id, "id", colaboradores);
                    if (search != null) {
                        removeFromArray(search.idx, colaboradores);
                    }
                    var dev_colaboradores = new DevExpress.data.DataSource(colaboradores);
                    $("#tabla02").dxDataGrid({
                        dataSource: dev_colaboradores,
                    });
                    $("#tabla02").dxDataGrid("getDataSource").reload();

                    $("#eliminarColaboradorModal").modal("hide");
                    RecargaHistorialActividades();
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#eliminarColaboradorModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }
            }, 1500);
        },
        failure: function (response) {
            $("#eliminarColaboradorModal .modal-spinner").hide();
            $("#eliminarColaboradorModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#eliminarColaboradorModal .modal-spinner").hide();
            $("#eliminarColaboradorModal .btn-info").removeAttr("disabled");
        }
    });
}

//
function EliminarComentario(id) {
    comentario = {
        id: id,
        contrato: 0,
        usuario: {
            id: eu_lu.id
        }
    };
    $("#eliminarComentarioModal .modal-spinner").hide();
    $("#eliminarComentarioModal .form-error").remove();
    $("#eliminarComentarioModal").modal("show");
}

function ConfirmaEliminarComentario() {
    $("#eliminarComentarioModal .modal-spinner").show();
    $("#eliminarComentarioModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "EliminarComentario";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(comentario),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#eliminarComentarioModal .modal-spinner").hide();
                $("#eliminarComentarioModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    var search = searchArrayByKeyProp(comentario.id, "id", comentarios);
                    if (search != null) {
                        removeFromArray(search.idx, comentarios);
                    }

                    RedibujaComentarios();

                    $("#eliminarComentarioModal").modal("hide");
                    RecargaHistorialActividades();
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#eliminarComentarioModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }
            }, 1500);
        },
        failure: function (response) {
            $("#eliminarComentarioModal .modal-spinner").hide();
            $("#eliminarComentarioModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#eliminarComentarioModal .modal-spinner").hide();
            $("#eliminarComentarioModal .btn-info").removeAttr("disabled");
        }
    });
}
//
function EliminarRecordatorio(id) {
    recordatorio = {
        id: id,
        contrato: 0,
        descripcion: "",
        usuario: {
            id: eu_lu.id
        },
        asignado: {
            id: ""
        },
        autor: {
            id: ""
        },
        FR_d: ""
    };
    $("#eliminarRecordatorioModal .modal-spinner").hide();
    $("#eliminarRecordatorioModal .form-error").remove();
    $("#eliminarRecordatorioModal").modal("show");
}

function ConfirmaEliminarRecordatorio() {
    $("#eliminarRecordatorioModal .modal-spinner").show();
    $("#eliminarRecordatorioModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "EliminarRecordatorio";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(recordatorio),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#eliminarRecordatorioModal .modal-spinner").hide();
                $("#eliminarRecordatorioModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    var search = searchArrayByKeyProp(recordatorio.id, "id", recordatorios);
                    if (search != null) {
                        removeFromArray(search.idx, recordatorios);
                    }

                    RedibujaRecordatorios();

                    $("#eliminarRecordatorioModal").modal("hide");
                    RecargaHistorialActividades();
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#eliminarRecordatorioModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }
            }, 1500);
        },
        failure: function (response) {
            $("#eliminarRecordatorioModal .modal-spinner").hide();
            $("#eliminarRecordatorioModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#eliminarRecordatorioModal .modal-spinner").hide();
            $("#eliminarRecordatorioModal .btn-info").removeAttr("disabled");
        }
    });
}

//-----
$(document).on("change", "#in02", function (event) {
    actualizaTitulo();
});
$(document).on("change", "#in04", function (event) {
    actualizaTitulo();
});
$(document).on("change", "#in06", function (event) {
    actualizaTitulo();
});

function actualizaTitulo() {
    var negocio = $("#in02 option:selected").text();
    var proveedor = $("#in04").val();
    var tipo_contrato = $("#in06").val();

    var titulo = contrato.folio +
        //"_" +
        //negocio.replace(/\s/g, '_') +
        "_" +
        proveedor.replace(/\s/g, '_');
        /*"_" +
        tipo_contrato.replace(/\s/g, '_');*/

    $("#in03").val(titulo).trigger("change");
}

var estatus_pre = 0;
function CambiarEstatus(id) {
    $("#confirmaEstatus .modal-spinner").hide();
    $("#confirmaEstatus .errores").empty();
    if (id == 3) {
        $("#confirmaEstatus .form-group p").html("Se enviarán notificaciones a los colaboradores con los comentarios asignados.<br>¿Estás seguro de querer cambiar el estatus del contrato?");
        $(".detalleColaboradores").show();
    } else {
        var texto_modal = "¿Estás seguro de querer cambiar el estatus del contrato?";
        switch (id) {
            case 1:
                texto_modal = "¿Estás seguro de querer enviar la solicitud al usuario?";
                break;
            case 2:
                texto_modal = "¿Estás seguro de querer enviar la solicitud al abogado?";
                break;
            case 3:
                texto_modal = "¿Estás seguro de querer cambiar el estatus del contrato?";
                break;
            case 4:
                texto_modal = "¿Estás seguro de querer cambiar el estatus del contrato?";
                break;
            case 5:
                texto_modal = "¿Estás seguro de querer cambiar el estatus del contrato?";
                break;
        }
        $("#confirmaEstatus .form-group p").html(texto_modal);
        $(".detalleColaboradores").hide();
    }
    estatus_pre = id;
    $("#confirmaEstatus").modal("show");
}
function VerColaboradores() {
    $(".nav-link[href='#tab03']").click();
    $("#confirmaEstatus").modal("hide");
}
function ConfirmaEstatus() {
    if (estatus_pre == 3 && colaboradores.length <= 0) {
        $("#confirmaEstatus .errores").empty();
        $("#confirmaEstatus .errores").append("<p class='form-error'>No se han asignado colaboradores</p>");
    } else {
        $("#confirmaEstatus").modal("hide");
        setTimeout(function () {
            var comentario = $("#comentario").val();
            $("#alertModal .close").hide();
            $("#alertModal .modal-title").text("Cargando información");
            $("#alertModal .modal-footer").empty();
            $("#alertModal .form-group").empty();
            $("#alertModal .modal-spinner").show();
            $("#alertModal").modal("show");
            var sended_url = services_url + "EstatusValidacionContrato";
            $.ajax({
                type: "POST",
                url: sended_url,
                data: JSON.stringify({ id: contrato.id, estatus_validacion: estatus_pre, comentario: comentario, usuario: { id: eu_lu.id } }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    setTimeout(function () {
                        var jsonResponse = response;
                        if (jsonResponse.flag != false) {

                            $("#alertModal .close").hide();
                            $("#alertModal .modal-title").text("Estatus actualizado correctamente");
                            $("#alertModal .modal-footer").empty();
                            $("#alertModal .form-group").empty();
                            $("#alertModal .form-group").append("<p>Se ha actualizado el estatus del contrato.</p>");
                            //$("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                            $("#alertModal .modal-footer").html('<a href="' + hosturl + 'Admin/Contratos" class="btn btn-info"><i class="fa fa-check"></i> Ver mis contratos</button>');
                            $("#alertModal .modal-spinner").hide();
                            $("#alertModal").modal("show");
                            RecargaHistorialActividades();
                        } else {
                            $("#alertModal .close").hide();
                            $("#alertModal .modal-title").text("Error");
                            $("#alertModal .modal-footer").empty();
                            $("#alertModal .form-group").empty();
                            $("#alertModal .form-group").append("<p>No se pudo actualizar el estatus del contrato.</p>");
                            $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                            $("#alertModal .modal-spinner").hide();
                            $("#alertModal").modal("show");
                        }
                    }, 1500);
                },
                failure: function (response) {
                },
                error: function (response) {
                }
            });
        }, 1000);
    }
}

var revision_id = 0;
var revision_estatus = 0;
var revision_comentario = "";
function AprobacionColaborador(id, estatus) {
    revision_id = id;
    revision_estatus = estatus;
    revision_comentario = "";
    $("#comentariocolaborador").val("");
    $("#confirmaColaborador").modal("show");
}
function ConfirmaEstatusRevision() {
    $("#confirmaColaborador").modal("hide");
    setTimeout(function () {
        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Enviando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        revision_comentario = $("#comentariocolaborador").val();
        var sended_url = services_url + "EstatusColaborador";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({ id: revision_id, descripcion: revision_comentario, aprobado: revision_estatus, usuario: { id: eu_lu.id } }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                setTimeout(function () {
                    var jsonResponse = response;
                    if (jsonResponse.flag != false) {

                        $("#alertModal .close").hide();
                        $("#alertModal .modal-title").text("Estatus actualizado correctamente");
                        $("#alertModal .modal-footer").empty();
                        $("#alertModal .form-group").empty();
                        $("#alertModal .form-group").append("<p>Se ha actualizado el estatus del contrato.</p>");
                        $("#alertModal .modal-footer").html('<a href="' + hosturl + 'Admin/Contratos" class="btn btn-info"><i class="fa fa-check"></i> Ver mis contratos</button>');
                        //$("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                        $("#alertModal .modal-spinner").hide();
                        $("#alertModal").modal("show");
                    } else {
                        $("#alertModal .close").hide();
                        $("#alertModal .modal-title").text("Error");
                        $("#alertModal .modal-footer").empty();
                        $("#alertModal .form-group").empty();
                        $("#alertModal .form-group").append("<p>No se pudo actualizar el estatus del contrato.</p>");
                        $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                        $("#alertModal .modal-spinner").hide();
                        $("#alertModal").modal("show");
                    }
                }, 1500);
            },
            failure: function (response) {
            },
            error: function (response) {
            }
        });
    }, 1000);
}

$(document).on("keydown", "#in040", function (event) {
    if (event.keyCode == 13) {
        var rfc = $("#in040").val();
        BuscarCliente(rfc);
        //BuscarClienteDocumentos(rfc);
    }
});

function BuscarCliente(rfc) {
    $("#alertModal .close").hide();
    $("#alertModal .modal-title").text("Buscando cliente");
    $("#alertModal .modal-footer").empty();
    $("#alertModal .form-group").empty();
    $("#alertModal .modal-spinner").show();
    $("#alertModal").modal("show");
    var sended_url = services_url + "BuscarCliente";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ P_RFC: rfc, contrato: contrato.id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    if (contrato.rfc != rfc) {
                        $("#in04").val(jsonResponse.data_string);
                        var documentosManuales = lista_documentos_proveedor.filter(i => i.tipo_archivo.id == 7 || i.tipo_archivo.nombre == "Documento Cliente Manual");
                        var documentosPrecargados = lista_documentos_proveedor.filter(i => i.tipo_archivo.id == 6 || i.tipo_archivo.nombre == "Documento Cliente");
                        var docServicio = jsonResponse.content[0];
                        if (documentosPrecargados.length > 0) {
                            for (var i = 0; i < documentosPrecargados.length; i++) {
                                documentosPrecargados[i].cargado = -1;
                            }
                        }

                        lista_documentos_proveedor = docServicio.concat(documentosPrecargados, documentosManuales);//jsonResponse.content[0];

                        var dev_documentos = new DevExpress.data.DataSource(lista_documentos_proveedor.filter(i => i.cargado > -1));
                        $("#tabla011").dxDataGrid({
                            dataSource: dev_documentos,
                        });
                        $("#tabla011").dxDataGrid("getDataSource").reload();
                    } else {
                    }
                    $("#alertModal .close").hide();
                    $("#alertModal .modal-title").text("Correcto");
                    $("#alertModal .modal-footer").empty();
                    $("#alertModal .form-group").empty();
                    $("#alertModal .form-group").append("<p>Se ha cargado el nombre del cliente.</p>");
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                    $("#alertModal .modal-spinner").hide();
                    $("#alertModal").modal("show");
                } else {
                    $("#in040").val(contrato.rfc);
                    $("#in04").val(contrato.proveedor);
                    $("#alertModal .close").hide();
                    $("#alertModal .modal-title").text("Error");
                    $("#alertModal .modal-footer").empty();
                    $("#alertModal .form-group").empty();
                    $("#alertModal .form-group").append("<p>No se encontró ningún cliente con este RFC.</p>");
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                    $("#alertModal .modal-spinner").hide();
                    $("#alertModal").modal("show");
                }
            }, 1500);
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    });
}

var registroActividad = new Array();
function RecargaHistorialActividades() {
    /*$("#alertModal .close").hide();
    $("#alertModal .modal-title").text("Buscando cliente");
    $("#alertModal .modal-footer").empty();
    $("#alertModal .form-group").empty();
    $("#alertModal .modal-spinner").show();
    $("#alertModal").modal("show");*/
    var sended_url = services_url + "RegistroActividadContrato";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ id: contrato.id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    registroActividad = jsonResponse.content[0];
                    var dev_historial = new DevExpress.data.DataSource(registroActividad);
                    $("#tabla012").dxDataGrid({
                        dataSource: dev_historial,
                    });
                    $("#tabla012").dxDataGrid("getDataSource").reload();

                } else {
                    registroActividad = new Array();
                    var dev_historial = new DevExpress.data.DataSource(registroActividad);
                    $("#tabla012").dxDataGrid({
                        dataSource: dev_historial,
                    });
                    $("#tabla012").dxDataGrid("getDataSource").reload();
                }
            }, 1500);
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    });
}
/*
function BuscarClienteDocumentos(rfc) {
    var sended_url = services_url + "BuscarClienteDocumentos";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ P_RFC: rfc }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    lista_documentos_proveedor = jsonResponse.content[0];
                    var dev_documentos = new DevExpress.data.DataSource(lista_documentos_proveedor);
                    $("#tabla011").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla011").dxDataGrid("getDataSource").reload();

                } else {
                    lista_documentos_proveedor = new Array();
                    var dev_documentos = new DevExpress.data.DataSource(lista_documentos_proveedor);
                    $("#tabla011").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla011").dxDataGrid("getDataSource").reload();
                }
            }, 1500);
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    });
}
*/
function DescargaDocumentoProveedor(idx) {
    console.log(idx);
    var doc = lista_documentos_proveedor[idx];
    console.log(doc);
    var file = new Blob([blob], { type: doc.file_content_type });
    var fileUrl = URL.createObjectURL(file);
    var win = window.open();
    win.document.write('<iframe src="' + fileUrl + '" framework="0" style="border:0px; top: 0px; left: 0px; bottom:0; right: 0px; width:100%; height:100%; allowfullscreen"></iframe>');
}

function download(filename, text, type) {
    var el = document.createElement("a");
    el.setAttribute("href", "data:" + type + ";charset=utf-8;base64," + encodeURIComponent(text));
    el.setAttribute("download", filename);

    el.style.display = "none";
    document.body.appendChild(el);
    el.click();

    document.body.removeChild(el);
}

function ValidacionesArchivosContratos() {
    console.log(contrato.estatus_validacion);
    if (contrato.estatus_validacion < 4) {
        var contrato_liberado = lista_documentos.filter(i => i.tipo_archivo.id == 4 && i.id > 0);
        if (contrato_liberado.length <= 0) {
            $("#aprobado_firmas").attr("disabled", "disabled");
        } else {
            $("#aprobado_firmas").removeAttr("disabled");
        }
    }
    else if (contrato.estatus_validacion == 4) {
        var contrato_firmado = lista_documentos.filter(i => i.tipo_archivo.id == 5 && i.id > 0);
        if (contrato_firmado.length <= 0) {
            $("#contrato_firmado_notif").attr("disabled", "disabled");
            $("#contrato_firmado").attr("disabled", "disabled");
        } else {
            $("#contrato_firmado_notif").removeAttr("disabled");
            $("#contrato_firmado").removeAttr("disabled");
        }
    }
}