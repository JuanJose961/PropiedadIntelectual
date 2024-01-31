$(document).ready(function () {
    $(".ctm-header-area span").text("Módulo Contratos");
    var hoy = moment().format('DD-MM-YYYY');
    var inicioAnho = moment().startOf('year').format();
    var inicio = moment().add(-30, 'days').format();
    var fin = moment().add(30, 'days').format();

    console.log(new Date(inicio));
    console.log(new Date(fin));
    console.log(new Date());
    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });

    $('#inicio').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#fin').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $("#inicio").datepicker("update", new Date(inicio));
    $("#fin").datepicker("update", new Date(fin));


    $('#doc22').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $("#doc22").datepicker("update", new Date());
    //
    $("#in060c").hide();


    $('#modificacion').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $("#modificacion").datepicker("update", new Date(inicioAnho));

    /*$('#modificacion').daterangepicker({
        opens: 'left',
        locale:
        {
            format: 'DD-MM-YYYY'
        }
    }, function (start, end, label) {
        //PSTART_DATE = start.format('YYYY-MM-DD');
        //PEND_DATE = end.format('YYYY-MM-DD');
        //reloadDataRange();
        //console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
        //Actualizar(PSTART_DATE, PEND_DATE);
    });*/

    console.log("dentro");
    $(document).on("change", "#estatus", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#abogado", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#usuarios", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#inicio", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#fin", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#minmonto", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#maxmonto", function (event) {
        RecargaContratos();
    });
    $(document).on("keydown", "#buscar", function (event) {
        if (event.keyCode == 13) {
            RecargaContratos();
        }
    });

    $(document).on("change", "#negocio", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#tipocontrato", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#contraparte", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#folio", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#modificacion", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#prioridad", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#rfc", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#rfc", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#indefinido", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#confidenciales", function (event) {
        RecargaContratos();
    });

    if (eu_lu.role.id == "8566d71d-72f0-489d-92d4-410804d82e60" ||
        eu_lu.role.id == "e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b") {
        $("#confidencialc").show();
    } else {
        $("#confidencialc").hide();
    }

    RecargaContratos();
});


function RecargaContratos() {
    var estatus = parseInt($("#estatus option:selected").val());
    var abogado = $("#abogado option:selected").val();
    var inicio = $("#inicio").val();
    var fin = $("#fin").val();
    var buscar = $("#buscar").val();
    var min_monto = parseFloat($("#minmonto").val());
    var max_monto = parseFloat($("#maxmonto").val());

    var negocio = parseInt($("#negocio option:selected").val());
    var tipocontrato = parseInt($("#tipocontrato option:selected").val());
    var contraparte = $("#contraparte option:selected").val();
    var folio = $("#folio option:selected").val();
    var modificacion = $("#modificacion").val();
    var prioridad = parseInt($("#prioridad option:selected").val());
    var rfc = $("#rfc option:selected").val();
    var usuarios = $("#usuarios option:selected").val();

    var indefinido = 0;
    var confidencial = 0;

    if (isNaN(min_monto)) {
        min_monto = 0;
    } else if (min_monto < 0) {
        min_monto = 0;
    }

    if (isNaN(max_monto)) {
        max_monto = 99999999999;
    } else if (max_monto > 99999999999) {
        max_monto = 99999999999;
    }

    if ($("#indefinido").is(":checked")) {
        indefinido = 1;
    }
    if ($("#confidenciales").is(":checked")) {
        confidencial = 1;
    }

    $("#alertModal .close").hide();
    $("#alertModal .modal-title").text("Cargando información");
    $("#alertModal .modal-footer").empty();
    $("#alertModal .form-group").empty();
    $("#alertModal .modal-spinner").show();
    $("#alertModal").modal("show");
    var sended_url = services_url + "BuscarContratos";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({
            estatus: estatus,
            abogado: abogado,
            inicio: inicio,
            fin: fin,
            buscar: buscar,
            confidencial: confidencial,
            indefinido: indefinido,
            min_monto: min_monto,
            max_monto: max_monto,
            usuario: eu_lu.id,
            negocio: negocio,
            contraparte: contraparte,
            folio: folio,
            tipocontrato: tipocontrato,
            modificacion: modificacion,
            prioridad: prioridad,
            rfc: rfc,
            dueno: usuarios,
            pagina: pagina,
            cantidad: cantidad
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    var contratos = jsonResponse.content[0];
                    RedibujarContratos(contratos, jsonResponse.data_int);
                    $("#alertModal").modal("hide");
                    $("#alertModal .modal-title").text("Datos guardados");
                    $("#alertModal .modal-spinner").hide();
                    $("#alertModal .form-group").append("<p class=''>Se han guardados los datos correctamente</p>");
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                } else {
                    RedibujarContratos(new Array(), 0);
                    $("#alertModal .modal-spinner").hide();
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
var pagina = 1;
var cantidad = 10;
function CambiaPagina(val) {
    pagina = val;
    RecargaContratos();
}

$(document).on("change", "#cantidad", function (event) {
    cantidad = parseInt($(this).val());
    pagina = 1;
    RecargaContratos();
});

function RedibujarPaginacion(total, cantidad_a_mostrar) {
    var cantidad_maxima = pagina * cantidad;
    // 7 * 5 = 35
    // 6 * 5 = 30
    // 1 * 5 = 5
    // 1 * 1 = 1;
    var cantidad_mostrada = ((pagina - 1) * cantidad) + cantidad_a_mostrar;
    // (7 - 1) * 5 = 30 + 2 = 32
    // (6 - 1) * 5 = 25 + 5 = 30
    // (1 - 1) * 5 = 0 + 5 = 5
    // (1 - 1) * 1 = 0 + 1 = 1

    var cantidad_siguiente = cantidad_mostrada + cantidad
    // 32 + 5 = 37
    // 30 + 5 = 35
    // 5 + 5 = 10
    // 1 + 1 = 2

    var cantidad_anterior = cantidad_mostrada - cantidad
    // 32 - 5 = 37
    // 30 - 5 = 35
    // 5 - 5 = 0
    // 1 - 1 = 0

    var cantidad_paginas = parseInt(Math.ceil(total / cantidad));
    // 32 / 5 = 7
    // 8 / 1 = 8
    console.log(cantidad_anterior, cantidad_siguiente, cantidad_paginas, cantidad_maxima, total);
    $(".ctm-pagination").empty();

    if (cantidad_paginas > 0) {

        if (pagina == 1) {
            //dibuja las primeras 3
        } else {
            $(".ctm-pagination").append("<button type='button' class='btn btn-sm btn-default' onclick='CambiaPagina(" + (pagina - 1) + ")'><i class='fa fa-arrow-left'></i></button>");
        }

        $(".ctm-pagination").append("<button type='button' class='btn btn-sm btn-info' onclick=''>" + pagina + "</button>");

        if (pagina == cantidad_paginas) {
            //dibuja las ultimas 3
        } else {
            $(".ctm-pagination").append("<button type='button' class='btn btn-sm btn-default' onclick='CambiaPagina(" + (pagina + 1) + ")'><i class='fa fa-arrow-right'></i></button>");
        }
    }
    /*if (cantidad_anterior <= 0) {
        //no dibujar anterior
    } else {
        $(".ctm-pagination").append("<button type='button' class='btn btn-sm btn-default' onclick='CambiaPagina(" + (pagina - 1) + ")'><i class='fa fa-arrow-left'></i></button>");
    }*/

    //$(".ctm-pagination").append("<button type='button' class='btn btn-sm btn-info' onclick=''>" + pagina + "</button>");


    /*if (cantidad_siguiente > total) {
        //no dibujar boton siguiente
    } else {
        $(".ctm-pagination").append("<button type='button' class='btn btn-sm btn-default' onclick='CambiaPagina(" + (pagina + 1) + ")'><i class='fa fa-arrow-right'></i></button>");
    }*/
}
function RedibujarContratos(contratos, total) {
    RedibujarPaginacion(total, contratos.length);
    $("#formContrato ul").empty();
    if (contratos.length > 0) {
        for (var i = 0; i < contratos.length; i++) {
            var el = contratos[i];
            if (el.termino_indefinido == 1) {
                el.termino_contrato.ddmmyyyy = "Término de contrato indefinido";
            }
            var li_estatus = "";
            var btn_estatus = "";
            var li_estatus_validacion = "";
            var btn_estatus_validacion = "";
            switch (el.estatus_validacion) {
                case 1:
                    li_estatus = "contrato-estatus-0";
                    btn_estatus = "contrato-estatus-btn-0";
                    break;
                case 2:
                    li_estatus = "contrato-estatus-1";
                    btn_estatus = "contrato-estatus-btn-1";
                    break;
                case 3:
                    li_estatus = "contrato-estatus-2";
                    btn_estatus = "contrato-estatus-btn-2";
                    break;
                case 4:
                    li_estatus = "contrato-estatus-3";
                    btn_estatus = "contrato-estatus-btn-3";
                    break;
                case 5:
                    li_estatus = "contrato-estatus-4";
                    btn_estatus = "contrato-estatus-btn-4";
                    break;
            }
            btn_estatus_validacion = "contrato-estatus-btn-7";
            if (el.estatus == 2) {
                //li_estatus = "contrato-estatus-5";
                btn_estatus_validacion = "contrato-estatus-btn-5";
            } else if (el.estatus == 3) {
                //li_estatus = "contrato-estatus-6";
                btn_estatus_validacion = "contrato-estatus-btn-6";
            }

            var estatus_acciones = "";
            if (el.estatus == 1) {
                estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'><i class='fa fa-times'></i> Cancelar</a>" +
                    "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'><i class='fa fa-times'></i> Suspender</a>";
            } else {
                estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'><i class='fa fa-edit'></i> Activar</a>";
            }


            if (eu_lu.role.id != "8566d71d-72f0-489d-92d4-410804d82e60") {
                estatus_acciones = "";
            }
            var cajas_estatus = "<div class='col-md-12'>" +
                "<span class='contrato-estatus " + btn_estatus_validacion + "'><label>Estatus de solicicitud contrato: </label>" + el.estatus_desc + "</span>" +
                "</div>";
            if (el.estatus == 1) {
                estatus_acciones = "<div class='row'>" +
                    "<div class='col-md-6'>" +
                    "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'>Cancelar</a>" +
                    "</div>" +
                    "<div class='col-md-6'>" +
                    "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'>Suspender</a>" +
                    "</div>" +
                    "</div>";
                if (el.estatus_validacion == 4) {
                    estatus_acciones = "<div class='row'>" +
                        "<div class='col-md-6'>" +
                        "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'>Suspender</a>" +
                        "</div>" +
                        "</div>";
                }
                if (el.estatus_validacion == 5) {
                    if (eu_lu.role.id == "e9d0046c-3c62-4e91-81d5-8c8bc2a5c16b") {
                        estatus_acciones = "<div class='row'>" +
                            "<div class='col-md-6'>" +
                            "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'>Cancelar</a>" +
                            "</div>" +
                            "</div>";
                    } else {
                        estatus_acciones = "";
                    }
                }
                //-----------------------
                if (el.estatus_validacion <= 3) {
                    cajas_estatus = "<div class='col-md-6'>" +
                        "<span class='contrato-estatus " + btn_estatus + "'><label>En revisión por: </label>" + el.en_revision_por + "</span>" +
                        "</div>" +
                        "<div class='col-md-6'>" +
                        "<span class='contrato-estatus " + btn_estatus_validacion + "'><label>Estatus de solicicitud contrato: </label>" + el.estatus_desc + "</span>" +
                        "</div>";
                } else {
                    cajas_estatus = "<div class='col-md-6'>" +
                        "<span class='contrato-estatus " + btn_estatus + "'><label>Estatus de validación: </label>" + el.estatus_validacion_desc + "</span>" +
                        "</div>" +
                        "<div class='col-md-6'>" +
                        "<span class='contrato-estatus " + btn_estatus_validacion + "'><label>Estatus de solicicitud contrato: </label>" + el.estatus_desc + "</span>" +
                        "</div>";
                }
            } else if (el.estatus == 3){
                estatus_acciones = "<div class='row'>" +
                    "<div class='col-md-6'>" +
                    "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'>Reactivar</a>" +
                    "</div>" +
                    "</div>";

                //estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'><i class='fa fa-edit'></i> Activar</a>";
            } else if (el.estatus == 2) {
                estatus_acciones = "";/*"<div class='row'>" +
                    "<div class='col-md-6'>" +
                    "<span class='btn btn-danger btn-block'>Registro cancelado</span>" +
                    "</div>" +
                    "</div>";*/
            }

            var tipo_contrato_info = "";
            if (el.tipo_contrato != 4 && el.tipo_contrato != 5) {
                tipo_contrato_info = "<div class='col-md-4'>" +
                    "<p><strong>Monto: </strong> " + currencyFormatter.format(el.monto).replace('$', '') + "</p>" +
                    "</div>" +
                    "<div class='col-md-4'>" +
                    "<p><strong>Moneda: </strong> " + el.moneda_desc + "</p>" +
                    "</div>";
            }
            var row_confidencial = "";
            if (el.confidencial > 0) {
                row_confidencial = "<div class='row border-bottom'>" +
                    "<div class='col-md-12'>" +
                    "<p><strong>CONTRATO CONFIDENCIAL</strong></p>" +
                    "</div>" +
                    "</div>";
            }
            var vigencia = "<span class='contrato-estatus'><label>Vigencia: </label>" + el.vigencia + "</span>";
            var vigencia_actividad = "";
            if (el.estatus_validacion <= 3) {
                if (el.retraso_actividad == "Días restantes por atender") {
                    if (el.dias_vista == 0) {
                        vigencia = "<span class='contrato-retraso' vencido=2><label>Último día de atención: </label>" + el.dias_vista + "</span>";
                    } else {
                        vigencia = "<span class='contrato-retraso'><label>" + el.retraso_actividad + ": </label>" + el.dias_vista + "</span>";
                    }
                    //vigencia = "<span class='contrato-retraso'><label>" + el.retraso_actividad + ": </label>" + el.dias_vista + "</span>";
                } else {
                    vigencia = "<span class='contrato-retraso' vencido=1><label>" + el.retraso_actividad + ": </label>" + el.dias_vista + "</span>";
                }
            }
            else if (el.estatus_validacion == 4 && el.dias_contrato_firmado > -1) {
                console.log(el);
                if (el.retraso_actividad == "Días restantes por atender") {
                    vigencia = "<span class='contrato-retraso'><label>" + el.retraso_actividad + ": </label>" + el.dias_vista + "</span>";
                } else {
                    vigencia = "<span class='contrato-retraso' vencido=1><label>" + el.retraso_actividad + ": </label>" + el.dias_vista + "</span>";
                }
            }
            if (el.estatus == 2) {
                vigencia = "";
            }
            var li = "<li class='ctm-contrato-item " + li_estatus + "' id='#contrato_" + el.id + "'>" +
                "<div class='main-row row'>" +
                "<div class='col-md-8 contrato-item-info border-right'>" +
                "<div class='row border-bottom'>" +
                "<div class='col-md-4'>" +
                "<p><strong>Folio: </strong> " + el.folio + "</p>" +
                "</div>" +
                "<div class='col-md-8'>" +
                "<p><strong>Título: </strong> " + el.titulo + "</p>" +
                "</div>" +
                "</div>" +
                "<div class='row border-bottom'>" +
                "<div class='col-md-12'>" +
                "<p><strong>Descripción Corta: </strong> " + el.descripcion + "</p>" +
                "</div>" +
                "</div>" +
                "<div class='row border-bottom'>" +
                "<div class='col-md-4'>" +
                "<p><strong>Tipo de contrato: </strong> " + el.tipo_contrato_desc + "</p>" +
                "</div>" +
                tipo_contrato_info +
                "</div>" +
                "<div class='row border-bottom'>" +
                "<div class='col-md-6'>" +
                "<p><strong>Solicitante: </strong> " + el.usuario.name + "</p>" +
                "</div>" +
                "<div class='col-md-6'>" +
                "<p><strong>Abogado: </strong> " + el.abogado_nombre + "</p>" +
                "</div>" +
                "</div>" +
                "<div class='row border-bottom'>" +
                "<div class='col-md-6'>" +
                "<p><strong>Negocio: </strong> " + el.negocio_desc + "</p>" +
                "</div>" +
                "<div class='col-md-6'>" +
                "<p><strong>Contraparte: </strong> " + el.proveedor + " (" + el.rfc + ")" + "</p>" +
                "</div>" +
                "</div>" +
                "<div class='row border-bottom'>" +
                "<div class='col-md-6'>" +
                "<p><strong>Inicio de vigencia: </strong> " + el.inicio_vigencia.ddmmyyyy + "</p>" +
                "</div>" +
                "<div class='col-md-6'>" +
                "<p><strong>Término de vigencia: </strong> " + el.termino_contrato.ddmmyyyy + "</p>" +
                "</div>" +
                "</div>" +
                row_confidencial +
                "</div>" +
                "<div class='col-md-4 contrato-item-actions'>" +
                "<div class='row'>" +
                "<div class='col-md-6'>" +
                "<a class='btn btn-info btn-block' href='" + el.permalink + "'><i class='fa fa-eye'></i> Ver detalle</a>" +
                "</div>" +
                "<div class='col-md-6'>" +
                "<a class='btn btn-info btn-block' style='display:none;' href='javascript:void(0);' disabled><i class='fa fa-pin'></i> Fijar</a>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                cajas_estatus + 
                "</div>" +
                "<div class='row'>" +
                "<div class='col-md-12'>" +
                vigencia +
                //vigencia_actividad
                "</div>" +
                "</div>" +
                estatus_acciones +
                "</div>" +
                "</div>" +
                "" +
                "</li>";
            $("#formContrato ul").append(li);
        }
    } else {
        $("#formContrato ul").append("<li><p>No hay datos disponibles</p></li>");
    }
}
function RedibujarContratosV1(contratos) {
    $("#formContrato ul").empty();
    if (contratos.length > 0) {
        for (var i = 0; i < contratos.length; i++) {
            var el = contratos[i];
            var li_estatus = "";
            var btn_estatus = "";
            var li_estatus_validacion = "";
            var btn_estatus_validacion = "";
            switch (el.estatus_validacion) {
                case 2:
                    li_estatus = "ctm-contrato-item-warning";
                    btn_estatus = "contrato-estatus-warning";
                    break;
                case 4:
                    li_estatus = "ctm-contrato-item-success";
                    btn_estatus = "contrato-estatus-success";
                    break;
                case 4:
                    li_estatus = "ctm-contrato-item-danger";
                    btn_estatus = "contrato-estatus-danger";
                    break;
            }
            switch (el.estatus) {
                case 3:
                    li_estatus_validacion = "ctm-contrato-item-warning";
                    btn_estatus_validacion = "contrato-estatus-warning";
                    break;
                case 1:
                    li_estatus_validacion = "ctm-contrato-item-success";
                    btn_estatus_validacion = "contrato-estatus-success";
                    break;
                case 2:
                    li_estatus_validacion = "ctm-contrato-item-danger";
                    btn_estatus_validacion = "contrato-estatus-danger";
                    break;
            }
            var estatus_acciones = "";
            if (el.estatus == 1) {
                estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'><i class='fa fa-times'></i> Cancelar</a>" +
                    "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'><i class='fa fa-times'></i> Suspender</a>";
            } else if (el.estatus == 3) {
                estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'><i class='fa fa-edit'></i> Activar</a>";
            } else if (el.estatus == 2) {
                estatus_acciones = "";//"<span><i class='fa fa-ban'></i> Registro Cancelado</span>";
            }


            if (eu_lu.role.id != "8566d71d-72f0-489d-92d4-410804d82e60") {
                estatus_acciones = "";
            }
            var li = "<li class='ctm-contrato-item " + li_estatus + "' id='#contrato_" + el.id + "'>" +
                "<div class='row'>" +
                "<div class='col-md-8 contrato-col-block-main'>" +
                "<div class='row'>" +
                "<div class='col-md-4 contrato-col-block'>" +
                "<label>Folio:</label>" +
                "<p>" + el.folio + "</p>" +
                "<label>Negocio:</label>" +
                "<p>" + el.negocio_desc + "</p>" +
                "<label>Proveedor:</label>" +
                "<p>" + el.proveedor + "</p>" +
                "</div>" +
                "<div class='col-md-4 contrato-col-block'>" +
                "<label>Descripción Corta:</label>" +
                "<p>" + el.descripcion + "</p>" +
                "<label>Título:</label>" +
                "<p>" + el.titulo + "</p>" +
                "<label>Solicitante:</label>" +
                "<p>" + el.usuario.name + "</p>" +
                "<label>Abogado:</label>" +
                "<p>" + el.abogado_nombre + "</p>" +
                "</div>" +
                "<div class='col-md-4 contrato-col-block'>" +
                "<label>Tipo de contrato:</label>" +
                "<p>" + el.tipo_contrato_desc + "</p>" +
                "<label>Inicio de vigencia:</label>" +
                "<p>" + el.inicio_vigencia.ddmmyyyy + "</p>" +
                "<label>Fin de vigencia:</label>" +
                "<p>" + el.termino_contrato.ddmmyyyy + "</p>" +
                "</div>" +
                "</div>" +
                "</div>" +
                
                "<div class='col-md-2 contrato-col-block'>" +
                "<label>Monto:</label>" +
                "<p>" + currencyFormatter.format(el.monto).replace('$','') + "</p>" +
                "<label>Moneda:</label>" +
                "<p>" + el.moneda_desc + "</p>" +
                "</div>" +
                "<div class='col-md-2 contrato-col-block'>" +
                "<span class='contrato-estatus " + btn_estatus + "'><label>Estatus de validación: </label>" + el.estatus_validacion_desc + "</span>" +
                "<br>" +
                "<span class='contrato-estatus " + btn_estatus_validacion + "'><label>Estatus de contrato: </label>" + el.estatus_desc + "</span>" +
                "<br>" +
                "<span class='contrato-estatus'><label>Vigencia: </label>" + el.vigencia + "</span>" +
                "<a href='" + el.permalink + "'><i class='fa fa-eye'></i> Ver Contrato</a>" +
                estatus_acciones
                "</div>" +
                "</div>" +
                "</li>";
            $("#formContrato ul").append(li);
        }
    } else {
        $("#formContrato ul").append("<li><p>No hay datos disponibles</p></li>");
    }
}

var contrato_estatus = {
    id: 0,
    estatus: 0,
    usuario: {
        id: eu_lu.id
    }
};

function Estatus(id, estatus) {
    contrato_estatus.id = id;
    contrato_estatus.estatus = estatus;
    $("#confirmaEliminar01").modal('show');
}

function CambiarEstatus(id) {
    $("#confirmaEliminar01").modal('hide');
    setTimeout(function () {

        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Cargando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        var sended_url = services_url + "EstatusContrato";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(contrato_estatus),
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
                        $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                        $("#alertModal .modal-spinner").hide();
                        $("#alertModal").modal("show");

                        RecargaContratos();
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