$(document).ready(function () {
    $(".ctm-header-area span").text("Módulo Contratos");
    var hoy = moment().format('DD-MM-YYYY');
    var inicio = moment().startOf('year').add(-1,'years').format();//moment().add(-30, 'days').format();
    var fin = moment().endOf('year').format();;//moment().add(30, 'days').format();

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



    $(document).on("change", "#estatus", function (event) {
        RecargaContratos();
    });
    $(document).on("change", "#abogado", function (event) {
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

    if (eu_lu.role.id == "a78f7e2f-69af-43aa-9e41-4df768bf24b1") {
        //$("#estatus").val(997).trigger("change");
    } else {
        //$("#estatus").val(1).trigger("change");
    }

    if (eu_lu.role.id == "8566d71d-72f0-489d-92d4-410804d82e60") {
        $("#confidencialc").show();
    } else {
        $("#confidencialc").hide();
    }
    //RecargaContratos();
});

var contratos = new Array();
function RecargaContratos() {
    var estatus = parseInt($("#estatus option:selected").val());
    var abogado = $("#abogado option:selected").val();
    var inicio = $("#inicio").val();
    var fin = $("#fin").val();
    var buscar = $("#buscar").val();
    var min_monto = parseFloat($("#minmonto").val());
    var max_monto = parseFloat($("#maxmonto").val());

    var indefinido = 0;
    var confidencial = 0;

    console.log(isNaN(min_monto));
    console.log(isNaN(max_monto));
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
    if ($("#confidencial").is(":checked")) {
        confidencial = 1;
    }

    $("#alertModal .close").hide();
    $("#alertModal .modal-title").text("Cargando información");
    $("#alertModal .modal-footer").empty();
    $("#alertModal .form-group").empty();
    $("#alertModal .modal-spinner").show();
    //$("#alertModal").modal("show");
    var sended_url = services_url + "BuscarContratosDashboard";
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
            indicadores: 1
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    contratos = jsonResponse.content[0];
                    RedibujarContratos(contratos);
                    $("#alertModal .modal-title").text("Datos guardados");
                    $("#alertModal .modal-spinner").hide();
                    $("#alertModal .form-group").append("<p class=''>Se han guardados los datos corretamente</p>");
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                } else {
                    contratos = new Array();
                    RedibujarContratos(contratos);
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

function RedibujarContratos(contratos) {
    $("#formContrato ul").empty();
    if (contratos.length > 0) {
        for (var i = 0; i < contratos.length; i++) {
            var el = contratos[i];
            if (el.indefinido == 1) {
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
            } else if(el.estatus == 3) {
                //li_estatus = "contrato-estatus-6";
                btn_estatus_validacion = "contrato-estatus-btn-6";
            }
            var estatus_acciones = "";
            /*if (el.estatus == 1) {
                estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'><i class='fa fa-times'></i> Cancelar</a>" +
                    "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'><i class='fa fa-times'></i> Suspender</a>";
            } else {
                estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'><i class='fa fa-edit'></i> Activar</a>";
            }*/
            if (el.estatus == 1) {
                estatus_acciones = "<div class='row'>" +
                    "<div class='col-md-6'>" +
                    "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'>Cancelar</a>" +
                    "</div>" +
                    "<div class='col-md-6'>" +
                    "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'>Suspender</a>" +
                    "</div>" +
                    "</div>";
                /*estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",2)'><i class='fa fa-times'></i> Cancelar</a>" +
                    "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",3)'><i class='fa fa-times'></i> Suspender</a>";*/
            } else {
                estatus_acciones = "<div class='row'>" +
                    "<div class='col-md-6'>" +
                    "<a class='btn btn-info btn-block' href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'>Reactivar</a>" +
                    "</div>" +
                    "</div>";
                //estatus_acciones = "<a href='#contrato_" + el.id + "' onclick='Estatus(" + el.id + ",1)'><i class='fa fa-edit'></i> Activar</a>";
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
                    "</div>" +
                    "<div class='col-md-4 contrato-item-actions'>" +
                        "<div class='row'>" +
                            "<div class='col-md-6'>" +
                                "<a class='btn btn-info btn-block' href='" + el.permalink + "'><i class='fa fa-eye'></i> Ver detalle</a>" +
                            "</div>" +
                            "<div class='col-md-6'>" +
                                "<a class='btn btn-info btn-block' href='javascript:void(0);'><i class='fa fa-pin'></i> Fijar</a>" +
                            "</div>" +
                        "</div>" +
                        "<div class='row'>" +
                            "<div class='col-md-6'>" +
                                "<span class='contrato-estatus " + btn_estatus + "'><label>Estatus de validación: </label>" + el.estatus_validacion_desc + "</span>" +
                            "</div>" +
                            "<div class='col-md-6'>" +
                                "<span class='contrato-estatus " + btn_estatus_validacion + "'><label>Estatus de contrato: </label>" + el.estatus_desc + "</span>" +
                            "</div>" +
                        "</div>" +
                        "<div class='row'>" +
                            "<div class='col-md-12'>" +
                                "<span class='contrato-estatus'><label>Vigencia: </label>" + el.vigencia + "</span>" +
                            "</div>" +
                        "</div>" +
                        estatus_acciones +
                    "</div>" +
                "</div>" +
                "</li>";
            $("#formContrato ul").append(li);
        }
    } else {
        $("#formContrato ul").append("<li><p>No hay datos disponibles</p></li>");
    }

    location.href = "#formContrato";
}

$(document).on("click", ".ctm-graph-box", function (event) {
    /*
    var attr = $(this).attr("box");

    switch (attr) {
        case "00":
            $("#estatus").val(1).trigger("change");
            break;
        case "01":
            $("#estatus").val(2).trigger("change");
            break;
        case "02":
            $("#estatus").val(3).trigger("change");
            break;
        case "022":
            $("#estatus").val(997).trigger("change");
            break;
        case "03":
            $("#estatus").val(4).trigger("change");
            break;
        case "04":
            $("#estatus").val(5).trigger("change");
            break;
        case "05":
            $("#estatus").val(998).trigger("change");
            break;
        case "06":
            $("#estatus").val(999).trigger("change");
            break;
    }*/
});

$(document).on("click", ".filtrado", function (event) {
    var attr = $(this).attr("filtrado");
    var url = hosturl + "Admin/Contratos?filtrado=" + attr;
    location.href = url;
});

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

                        //RecargaContratos(contratos);
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