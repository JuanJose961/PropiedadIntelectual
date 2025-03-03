﻿var muid = "";
var registro = {
    id: 0,
    empresa: 0,
    empresa_desc: "",
    empresa_anterior: 0,
    empresa_anterior_desc: "",
    nombre: "",
    no_registro: "",
    titulo: "",
    //fecha_legal: DateTime.Parse("1969-01-01"),
    //fecha_vencimiento: DateTime.Parse("1969-01-01"),
    //fecha_concesion: DateTime.Parse("1969-01-01"),
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
    //solicitud_nombre: "",
    //solicitud_data: new Array(),
    //solicitud_content_type: "",
    //solicitud_size: 0,
    //solicitud_extension: "",
    //solicitud_nombre_original: "",
    //solicitud_url: "",
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
    //fecha_requerimiento: DateTime.Parse("1969-01-01"),
    //fecha_requerimiento_completo: DateTime.Parse("1969-01-01"),
    //fecha_instrucciones: DateTime.Parse("1969-01-01"),
    //fecha_instrucciones_completo: DateTime.Parse("1969-01-01"),
    //fecha_registro: DateTime.Parse("1969-01-01"),
    //fecha_registro_completo: DateTime.Parse("1969-01-01"),
    //fecha_busqueda: DateTime.Parse("1969-01-01"),
    //fecha_busqueda_completo: DateTime.Parse("1969-01-01"),
    //fecha_resultados: DateTime.Parse("1969-01-01"),
    //fecha_resultados_completo: DateTime.Parse("1969-01-01"),
    //fecha_comprobacion: DateTime.Parse("1969-01-01"),
    //fecha_comprobacion_completo: DateTime.Parse("1969-01-01"),
    //fecha_vencimiento_workflow: DateTime.Parse("1969-01-01"),
    //fecha_vencimiento_workflow_completo: DateTime.Parse("1969-01-01"),
    //fecha_concesion_workflow: DateTime.Parse("1969-01-01"),
    //fecha_concesion_workflow_completo: DateTime.Parse("1969-01-01"),
    //fc: DateTime.Parse("1969-01-01"),
    //fu: DateTime.Parse("1969-01-01"),
    usuario: "",
    usuario_desc: "",
    activo: 0,
    //titulo_nombre: "",
    //titulo_data: new Array(),
    //titulo_content_type: "",
    //titulo_size: 0,
    //titulo_extension: "",
    //titulo_nombre_original: "",
    //titulo_url: "",
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
    nombre: "",
    nueva_fecha_vencimientoS: "",
};
$(document).ready(function () {
    var url = new URL(location.href); //Mediante esta propiedad accedemos a la dirección URL completa de la página mostrada en una ventana
    var propiedad = JSON.parse(url.searchParams.get('propiedad')); //Capturar el valor
    var solicitud = JSON.parse(url.searchParams.get('solicitud')); //Capturar el valor
    var desabilitar = JSON.parse(url.searchParams.get('desabilita')); //Capturar el valor
    //alert(desabilitar);
    var solicitud_select = "";
    var solicitudes_disponibles = null;
    var tipo_descrip = "Marca";
    if (propiedad == null) {
       //opiedad = 1;
        //alert(propiedad);
        var tipo_registro = parseInt(JSON.parse(url.searchParams.get('tipo'))); //Capturar el valor
        //ert(tipo_registro);
        if (tipo_registro == 0) {
            propiedad = 1;
        } else {
            switch (tipo_registro) {
                case 1: propiedad = 1; tipo_descrip = "Marca"; break;
                case 2: propiedad = 2; tipo_descrip = "Aviso Comercial"; break;
                case 3: propiedad = 3; tipo_descrip = "Patente"; break;
                case 4: propiedad = 4; tipo_descrip = "Diseño Industrial"; break;
                case 5: propiedad = 5; tipo_descrip = "Modelo Utilidad"; break;
                case 6: propiedad = 6; tipo_descrip = "Modelo Industrial"; break;
                case 7: propiedad = 7; tipo_descrip = "Obra Artística"; break;
                case 8: propiedad = 8; tipo_descrip = "Obra Visual"; break;
                case 9: propiedad = 9; tipo_descrip = "Obra Literaria"; break;
                case 10: propiedad = 10; tipo_descrip = "Obra Auditiva"; break;
                case 11: propiedad = 11; tipo_descrip = "Obra Gráfica"; break;
                case 12: propiedad = 12; tipo_descrip = "Obra Tecnológica"; break;
                default: propiedad = 1; tipo_descrip = "Marca"; break;
            }
        }
        document.getElementById("tipo_registromarca").value = tipo_registro;
        solicitudes_disponibles = solicitudes.filter(i => i.tipo_solicitud == propiedad & i.activo==1 & i.atendido==0);
        $("#uu_021 option[value!=0]").remove();
        for (var i = 0; i < solicitudes_disponibles.length; i++) {
            $("#uu_021").append("<option value='" + solicitudes_disponibles[i].id + "' tipo='" + solicitudes_disponibles[i].tipo + "'>" + solicitudes_disponibles[i].nombre + "</option>");
        }

        setTimeout(function () {
              CheckIfOptionExists("#uu_02", tipo_registro, tipo_descrip, true, true);
        }, 500);
    } else {
        document.getElementById("tipo_registromarca").value = propiedad;
        solicitud_select = solicitudes.filter(i => i.tipo_solicitud == propiedad & i.id == solicitud & i.activo == 1 & i.atendido==0);
        //alert(solicitud_select[0].nombre);
        solicitudes_disponibles = solicitudes.filter(i => i.tipo_solicitud == propiedad & i.activo == 1 & i.atendido==0);
        $("#uu_021 option[value!=0]").remove();
        for (var i = 0; i < solicitudes_disponibles.length; i++) {
            $("#uu_021").append("<option value='" + solicitudes_disponibles[i].id + "' tipo='" + solicitudes_disponibles[i].tipo + "'>" + solicitudes_disponibles[i].nombre + "</option>");
        }
        document.getElementById("uu_02").value = propiedad;
        //$("#uu_02").val(propiedad).trigger("change");
        //alert(solicitud_select[0].tipo_registro);
        setTimeout(function () {
            
            //$("#uu_021").val(solicitud).trigger("change");
            if (solicitud_select[0] != undefined) {
                CheckIfOptionExists("#uu_021", solicitud_select[0].id, solicitud_select[0].nombre, true, true);
                document.getElementById("uu_022").value = solicitud_select[0].nombre;
                CheckIfOptionExists("#uu_10", 1, 'En búsqueda', true, true);
                //ya funciona empresa,pais, tipo_registro, persona que registro el formato
                CheckIfOptionExists("#uu_00", solicitud_select[0].empresa, true);
                if (propiedad >= 1 && propiedad <= 6) {
                    CheckIfOptionExists("#uu_09", solicitud_select[0].pais, true);
                }
                if (propiedad == 1 || propiedad == 2) { 
                    CheckIfOptionExists("#uu_12", solicitud_select[0].tipo_registro, true);
                }
                CheckIfOptionExists("#uu_13", solicitud_select[0].usuario, true);
            }
        }, 500);
    }

    if (propiedad == 1 || propiedad == 2) {
        document.getElementById("uu_07_a").style.display = "block";//clase
        document.getElementById("uu_12_a").style.display = "block";//tipo registro(pestaña en registro)
        document.getElementById("uu_26_a").style.display = "block";//fecha comprobacion uso
        document.getElementById("uu_260_a").style.display = "block";//completo fecha comprobacion uso
        document.getElementById("uu_39_a").style.display = "block";//uso
    } else {
        document.getElementById("uu_07_a").style.display = "none";
        document.getElementById("uu_12_a").style.display = "none";
        document.getElementById("uu_26_a").style.display = "none";
        document.getElementById("uu_260_a").style.display = "none";
        document.getElementById("uu_39_a").style.display = "none";
    }

    if (propiedad == 3 || propiedad == 4 || propiedad == 5 || propiedad == 6) {
        document.getElementById("uu_34_a").style.display = "block";//tipo pago
        document.getElementById("uu_35_a").style.display = "block";//prioridad
        document.getElementById("uu_36_a").style.display = "block";//fecha vencimiento prioridad
        document.getElementById("uu_37_a").style.display = "block";//fecha quinquenio anualidad
        document.getElementById("contrato_a").style.display = "block";//contrato archivo
        document.getElementById("reivindicacion_a").style.display = "block";//reivindicacion archivo
    } else {
        document.getElementById("uu_34_a").style.display = "none";
        document.getElementById("uu_35_a").style.display = "none";
        document.getElementById("uu_36_a").style.display = "none";
        document.getElementById("uu_37_a").style.display = "none";
        document.getElementById("contrato_a").style.display = "none";
        document.getElementById("reivindicacion_a").style.display = "none";
    }

    if (propiedad == 1 || propiedad == 2 || propiedad == 3 || propiedad == 4 || propiedad == 5 || propiedad == 6) {
        document.getElementById("uu_05_a").style.display = "block";//fecha vencimiento
        document.getElementById("uu_09_a").style.display = "block";//pais
        document.getElementById("uu_24_a").style.display = "block";//fecha solicitud de busqueda
        document.getElementById("uu_240_a").style.display = "block";//completo fecha solicitud de busqueda
        document.getElementById("uu_25_a").style.display = "block";//fecha informacion de resultados al negocio
        document.getElementById("uu_250_a").style.display = "block";//completo fecha informacion de resultados al negocio
    } else {
        document.getElementById("uu_05_a").style.display = "none";
        document.getElementById("uu_09_a").style.display = "none";
        document.getElementById("uu_24_a").style.display = "none";
        document.getElementById("uu_240_a").style.display = "none";
        document.getElementById("uu_25_a").style.display = "none";
        document.getElementById("uu_250_a").style.display = "none";
    }

    if (propiedad == 7 || propiedad == 8 || propiedad == 9 || propiedad == 10 || propiedad == 11 || propiedad == 12) {
        document.getElementById("uu_38_a").style.display = "block";//autor
        document.getElementById("carta_a").style.display = "block";//carta archivo
    } else {
        document.getElementById("uu_38_a").style.display = "none";
        document.getElementById("carta_a").style.display = "none";
    }

    if (propiedad == 1 || propiedad == 2) {
        document.getElementById("uu_25_l").innerHTML = "Información de resultados al negocio";
    } else {
        document.getElementById("uu_25_l").innerHTML = "Información de resultados de la busqueda";
    }

    /*if (propiedad == 1 || propiedad == 2 || propiedad == 3 || propiedad == 4) {
        const contentString = "*";
        document.getElementById("uu_16_l").innerHTML = "Persona que solicitó la licencia " + contentString.fontcolor("red");//persona que solicito la licencia
    } else {
        document.getElementById("uu_16_l").innerHTML = "Persona que solicitó la licencia";
    }*/

    if (propiedad == 1 || propiedad == 2 || propiedad == 3 || propiedad == 4 || propiedad == 5 || propiedad == 6 || propiedad == 7 || propiedad == 8 || propiedad == 9 || propiedad == 10) {
        const contentString = "*";
        document.getElementById("uu_21_l").innerHTML = "Requerimiento del negocio " + contentString.fontcolor("red");//fecha de requerimiento del negocio
    } else {
        document.getElementById("uu_21_l").innerHTML = "Requerimiento del negocio";
    }

    if (eu_lu.role.id == "4c8ed3da-531b-4e4d-8b0f-2fb89e09119d") {//usuario de negocio
        $("#tab01 .form-control").attr("disabled", "disabled");
        $("#tab02 .form-control").attr("disabled", "disabled");
        $("#tab03 .form-control").attr("disabled", "disabled");
        $("#tab04 .form-control").attr("disabled", "disabled");
        $("#tab05 .form-control").attr("disabled", "disabled");
        $("#tab07 .form-control").attr("disabled", "disabled");
        $("#btnGuardar").attr("disabled", "disabled").remove();
        $(".nav-link[href='#tab05']").attr("disabled", "disabled").hide();
        $(".nav-link[href='#tab07']").attr("disabled", "disabled").hide();
        $("label[for='titulo']").attr("disabled", "disabled").remove();
        $("label[for='solicitud']").attr("disabled", "disabled").remove();
        $("label[for='contrato']").attr("disabled", "disabled").remove();
        $("label[for='reivindicacion']").attr("disabled", "disabled").remove();
        $("label[for='carta']").attr("disabled", "disabled").remove();
        $("Comentarios1").attr("disabled", "disabled").remove();
        $("Comentarios2").attr("disabled", "disabled").remove();
    } else {
        $(".nav-link[href='#tab06']").attr("disabled", "disabled").hide();
        $(".nav-link[href='#tab07']").attr("disabled", "disabled").hide();
        $(".nav-link[href='#tab08']").attr("disabled", "disabled").hide();
        $("#notificacion_titulo").attr("disabled", "disabled").parent().hide();
        $("#notificacion_vencimiento").attr("disabled", "disabled").parent().hide();
        $("#notificacion_estatus").attr("disabled", "disabled").parent().hide();

        $("#vobo").attr("disabled", "disabled");
        $("#btnGuardarVoBo").attr("disabled", "disabled").remove();
        $("Comentarios3").attr("disabled", "disabled").remove();
    }
    
    $("#doc00c").hide();
    $("#tabla01 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='ModalDocumento();' id='btnDocumento'><i class='fa fa-plus'></i> Agregar documento</button>");
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
    //
    $('#uu_21').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_210').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_22').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_220').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_23').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_230').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_24').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_240').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_25').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_250').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_26').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_260').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_27').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_270').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_28').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_280').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

    $('#uu_29').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });
    $('#uu_290').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });

    $('#uu_30').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });
    $('#uu_300').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });

    $('#uu_31').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });
    $('#uu_310').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });

    $('#uu_32').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });
    $('#uu_320').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });

    $('#uu_33').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });

    $('#uu_36').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        numberOfMonths: 2
    });
    $('#uu_37').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        numberOfMonths: 2
    });

    $('#uu_40').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_400').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_41').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy',
        //startDate: '-6m',
        //endDate: '+6m'
    });
    //

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });

    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $("#titulol").hide();
    $("#solicitudl").hide();
    $("#oficiol").hide();
    $("#contratol").hide();
    $("#reivindicacionl").hide();
    $("#cartal").hide();
    $("#licencial").hide();
    $("#cesionl").hide();
    
    if (mainid > 0) {
        if (propiedad >= 1 && propiedad <= 6 && desabilitar == 0) {
            if (desabilitar == 0) {
                document.getElementById("tituloregistromarca").innerHTML = "Edición de " + tipo_descrip;//titulo registro marca
            } else {
                document.getElementById("tituloregistromarca").innerHTML = "Información de " + tipo_descrip;//titulo registro marca
            }
        } else {
            if (desabilitar == 0) {
                document.getElementById("tituloregistromarca").innerHTML = "Edición de " + tipo_descrip;//titulo registro marca
            } else {
                document.getElementById("tituloregistromarca").innerHTML = "Información de " + tipo_descrip;//titulo registro marca
            }
        }
        if (propiedad == 1 || propiedad == 2) {
            document.getElementById("pestaña_renovacion").innerHTML = "Renovación";// pestaña renovacion
            document.getElementById("renovacion_l").innerHTML = "Crear renovación";//renovacion
            document.getElementById("uu_29_l").innerHTML = "Solicita a la empresa instrucciones para renovar";//fecha empresa
            document.getElementById("uu_33_l").innerHTML = "Fecha de oficio de renovación";//fecha oficio
            document.getElementById("uu_41_l").innerHTML = "Nueva fecha de vencimiento";//nueva fecha renovacion
            document.getElementById("oficio_l").innerHTML = "Oficio de renovación";//oficio renovacion
        } else if (propiedad == 3 || propiedad == 4 || propiedad == 5 || propiedad == 6) {
            document.getElementById("pestaña_renovacion").innerHTML = "Mantenimiento";// pestaña renovacion
            document.getElementById("renovacion_l").innerHTML = "Crear mantenimiento";//quinquenio
            document.getElementById("uu_29_l").innerHTML = "Solicita a la empresa instrucciones para mantenimiento";//fecha empresa
            document.getElementById("uu_33_l").innerHTML = "Fecha oficio de mantenimiento";//fecha oficio
            document.getElementById("uu_41_l").innerHTML = "Nueva fecha de pago de quinquenio o anualidad";//nueva fecha quinquenio
            document.getElementById("oficio_l").innerHTML = "Oficio de mantenimiento";//oficio quinquenio
        }
        SelectRegistroMarca(mainid,desabilitar);
    } else {
        if (propiedad >= 1 && propiedad <= 6) {
            document.getElementById("tituloregistromarca").innerHTML = "Registro de Propiedad Industrial " + tipo_descrip;//titulo registro marca
        } else {
            document.getElementById("tituloregistromarca").innerHTML = "Registro de Propiedad Intelectual " + tipo_descrip;//titulo registro marca
        }
    }
});

$(document).on("change", "#uu_02", function (event) { //tipo_solicitud
    var val = parseInt($(this).val());
    //var columna = parseInt(val);
    console.log(val);
    //if (val > 7) { val = 7; }
    //var solicitudes_disponibles = solicitudes.filter(i => i.tipo == val);
    var solicitudes_disponibles = solicitudes.filter(i => i.tipo_solicitud == val & i.activo == 1 & i.atendido==0);
    console.log(solicitudes_disponibles);

    $("#uu_021").select2("destroy");
    $("#uu_021 option[value!=0]").remove();
    for (var i = 0; i < solicitudes_disponibles.length; i++) {
        $("#uu_021").append("<option value='" + solicitudes_disponibles[i].id + "' tipo='" + solicitudes_disponibles[i].tipo + "'>" + solicitudes_disponibles[i].nombre + "</option>");
    }
    $("#uu_021").select2({
        placeholder: "Seleccionar",
        allowClear: false,
        dropdownParent: $("#uu_021").parent().parent()
    });
    $("#uu_021").val(0).trigger("change");


    //mostrar u ocultar campos
    if (val == 1 || val == 2) {
        document.getElementById("uu_07_a").style.display = "block";//clase
        $('#uu_07').prop("required", true);
        document.getElementById("uu_12_a").style.display = "block";//tipo registro(pestaña en registro)
        $('#uu_12').prop("required", true);
        document.getElementById("uu_26_a").style.display = "block";//fecha comprobacion uso
        $('#uu_26').prop("required", true);
        document.getElementById("uu_260_a").style.display = "block";//completo fecha comprobacion uso
        $('#uu_260').prop("required", true);
        document.getElementById("uu_39_a").style.display = "block";//uso
        $('#uu_39').prop("required", true);
    } else {
        document.getElementById("uu_07_a").style.display = "none";
        $('#uu_07').prop("required", false);
        document.getElementById("uu_12_a").style.display = "none";
        $('#uu_12').prop("required", false);
        document.getElementById("uu_26_a").style.display = "none";
        $('#uu_26').prop("required", false);
        document.getElementById("uu_260_a").style.display = "none";
        $('#uu_260').prop("required", false);
        document.getElementById("uu_39_a").style.display = "none";
        $('#uu_39').prop("required", false);
    }

    if (val==3 || val==4 || val==5 || val==6) {
        //document.getElementById("uu_06_l").innerHTML = "Fecha para pagar los quinquenios o anualidades";//fecha concesion
        document.getElementById("uu_34_a").style.display = "block";//tipo pago
        $('#uu_34').prop("required", true);
        document.getElementById("uu_35_a").style.display = "block";//prioridad
        $('#uu_35').prop("required", true);
        document.getElementById("uu_36_a").style.display = "block";//fecha vencimiento prioridad
        $('#uu_36').prop("required", true);
        document.getElementById("uu_37_a").style.display = "block";//fecha quinquenio anualidad
        $('#uu_37').prop("required", true);
        //document.getElementById("uu_06_a").style.display = "none"//fecha concesion
        //$('#uu_06').prop("required", false);
        document.getElementById("contrato_a").style.display = "block"//contrato archivo
        document.getElementById("reivindicacion_a").style.display = "block"//reivindicacion archivo
    } else {
        //document.getElementById("uu_06_l").innerHTML = "Fecha de concesión";
        document.getElementById("uu_34_a").style.display = "none";
        $('#uu_34').prop("required", false);
        document.getElementById("uu_35_a").style.display = "none";
        $('#uu_35').prop("required", false);
        document.getElementById("uu_36_a").style.display = "none";
        $('#uu_36').prop("required", false);
        document.getElementById("uu_37_a").style.display = "none";
        $('#uu_37').prop("required", false);
        //document.getElementById("uu_06_a").style.display = "block"
        //$('#uu_06').prop("required", true);
        document.getElementById("contrato_a").style.display = "none";
        document.getElementById("reivindicacion_a").style.display = "none";
    }

    if (val == 1 || val == 2 || val == 3 || val == 4 || val == 5 || val == 6) {
        document.getElementById("uu_05_a").style.display = "block";//fecha vencimiento
        $('#uu_05').prop("required", true);
        document.getElementById("uu_09_a").style.display = "block";//pais
        $('#uu_09').prop("required", true);
        document.getElementById("uu_24_a").style.display = "block";//fecha solicitud de busqueda
        $('#uu_24').prop("required", true);
        document.getElementById("uu_240_a").style.display = "block";//completo fecha solicitud de busqueda
        $('#uu_240').prop("required", true);
        document.getElementById("uu_25_a").style.display = "block";//fecha informacion de resultados al negocio
        $('#uu_25').prop("required", true);
        document.getElementById("uu_250_a").style.display = "block";//completo fecha informacion de resultados al negocio
        $('#uu_250').prop("required", true);
    } else {
        document.getElementById("uu_05_a").style.display = "none";
        $('#uu_05').prop("required", false);
        document.getElementById("uu_09_a").style.display = "none";
        $('#uu_09').prop("required", false);
        document.getElementById("uu_24_a").style.display = "none";
        $('#uu_24').prop("required", false);
        document.getElementById("uu_240_a").style.display = "none";
        $('#uu_240').prop("required", false);
        document.getElementById("uu_25_a").style.display = "none";
        $('#uu_25').prop("required", false);
        document.getElementById("uu_250_a").style.display = "none";
        $('#uu_250').prop("required", false);
    }

    if (val == 7 || val == 8 || val == 9 || val == 10 || val == 11 || val == 12) {
        document.getElementById("uu_38_a").style.display = "block";//autor
        $('#uu_38').prop("required", true);
        document.getElementById("carta_a").style.display = "block";//carta archivo
    } else {
        document.getElementById("uu_38_a").style.display = "none";
        $('#uu_38').prop("required", false);
        document.getElementById("carta_a").style.display = "none";
    }

    if (val == 1 || val == 2) {
        document.getElementById("uu_25_l").innerHTML = "Información de resultados al negocio";
    } else {
        document.getElementById("uu_25_l").innerHTML = "Información de resultados de la busqueda";
    } 

    /*if (val == 1 || val == 2 || val == 3 || val == 4) {
        const contentString = "*";
        document.getElementById("uu_16_l").innerHTML = "Persona que solicitó la licencia " + contentString.fontcolor("red");//persona que solicito la licencia
    } else {
        document.getElementById("uu_16_l").innerHTML = "Persona que solicitó la licencia";
    }*/

    if (val == 1 || val == 2 || val == 3 || val == 4 || val == 5 || val == 6 || val == 7 || val == 8 || val == 9 || val == 10) {
        const contentString = "*";
        document.getElementById("uu_21_l").innerHTML = "Requerimiento del negocio " + contentString.fontcolor("red");//fecha de requerimiento del negocio
    } else {
        document.getElementById("uu_21_l").innerHTML = "Requerimiento del negocio";
    }

    //if (val >7) {
    //    document.getElementById("btnGuardar").disabled = true;
    //} else {
    //    document.getElementById("btnGuardar").disabled = false;
    //}
    /*$("#uu_021 option").removeAttr("disabled")
        .removeAttr("hidden");
    if (val == 0) {
        $("#uu_021 option").removeAttr("disabled")
            .removeAttr("hidden");
    } else {
        $("#uu_021 option[tipo!='" + val + "']").attr("disabled","disabled")
            .attr("hidden","hidden");
    }
    $("#uu_021 option[value=0]").removeAttr("disabled")
        .removeAttr("hidden");
    $("#uu_021").select2("destroy");
    $("#uu_021").select2({
        placeholder: "Seleccionar",
        allowClear: false,
        dropdownParent: $("#uu_021").parent().parent()
    });
    $("#uu_021").val(0).trigger("change");*/
});

$(document).on("change", "#renovacion", function (event) {
    if ($(this).is(":checked")) {
        //$("#renovacion_check").hide();
        $("#renovacion_info").show();
    } else {
        //$("#renovacion_check").show();
        $("#renovacion_info").hide();
        if (registro.renovacion == 0) {
            $("#uu_29").val("");
            $("#uu_290").val("");
            $("#uu_30").val("");
            $("#uu_300").val("");
            $("#uu_31").val("");
            $("#uu_310").val("");
            $("#uu_32").val("");
            $("#uu_320").val("");
            $("#uu_33").val("");
            $("#oficio").remove();
            $("#oficioc").append("<input type='file' class='form-control input-sm' id='oficio' style='display: none;' />");
            $(".btn-lbl[for='oficio']").html("<i class='fa fa-upload'></i> Seleccionar documento");
        }
    }
});

$(document).on("change", "#uu_021", function (event) { //solicitud
    var val = parseInt($(this).val());
    var id = $("#id_registro").val();
    if (val > 0) {
        var tipo = parseInt($("#uu_02 option:selected").val());
        //var solicitud = solicitudes.filter(i => i.tipo == tipo & i.id == val);
        var solicitud = solicitudes.filter(i => i.solicitud_tipo == tipo & i.id == val);
        //document.getElementById("uu_022").value = solicitud[0].nombre; //nombre ya no aplica, se oculto select
        if (solicitud.length > 0) {
            var empresa = solicitud[0].empresa;
            var pais = solicitud[0].pais;
            var usuario = solicitud[0].usuario;

            console.log(empresa, pais, usuario);

            var existe_empresa = $('#uu_00 option[value=' + empresa + ']').length;
            var existe_pais = $('#uu_09 option[value=' + pais + ']').length;
            var existe_usuario = $('#uu_13 option[value=' + usuario + ']').length;

            var errores = new Array();
            //if (existe_empresa > 0) {
            //    if (id == 0) $("#uu_00").val(empresa).trigger("change");
            //} else {
            //    $("#uu_00").val(0).trigger("change");
            //    errores.push("No se encontró la empresa");
            //}
            //if (existe_pais > 0) {
            //    if (id == 0) $("#uu_09").val(pais).trigger("change"); 
            //} else {
            //    $("#uu_09").val(0).trigger("change");
            //    errores.push("No se encontró el país");
            //}
            //if (existe_usuario > 0) {
            //    if (id == 0) $("#uu_13").val(usuario).trigger("change");
            //} else {
            //    $("#uu_13").val(0).trigger("change");
            //    errores.push("No se encontró al usuario");
            //}

            if (errores.length > 0) {
                alert(errores.join("\n"));
            }
        } else {
            //$("#uu_00").val(0).trigger("change");
            //$("#uu_09").val(0).trigger("change");
            //$("#uu_13").val(0).trigger("change");
        }
    } else {
        //$("#uu_00").val(0).trigger("change");
        //$("#uu_09").val(0).trigger("change");
        //$("#uu_13").val(0).trigger("change");
    }

});

function Validar() {
    $(".form-error").remove();
    $(".form-control").removeClass("control-error");
    $(".select2-selection").removeClass("control-error");
    var tab = '#tab01';

    var errores = 0;
    var flag = false;

    var solicitud_tipo = $("#uu_02 option:selected").val();
    var solicitud_tipo_desc = $("#uu_02 option:selected").text();

    var fecha_renovarS = $("#uu_29").val();
    var fecha_renovar_completoS = $("#uu_290").val();
    var fecha_instruccion_corresponsalS = $("#uu_30").val();
    var fecha_instruccion_corresponsal_completoS = $("#uu_300").val();
    var fecha_solicitud_empresaS = $("#uu_31").val();
    var fecha_solicitud_empresa_completoS = $("#uu_310").val();
    var fecha_despachoS = $("#uu_32").val();
    var fecha_despacho_completoS = $("#uu_320").val();
    var oficio_completoS = $("#uu_33").val();

    var fecha_declaracion_completoS = $("#uu_260").val();
    var fecha_declaracionS = $("#uu_26").val();
    var fecha_concesion_workflow_completoS = $("#uu_280").val();
    var fecha_concesion_workflowS = $("#uu_28").val();
    var fecha_vencimiento_workflow_completoS = $("#uu_270").val();
    var fecha_vencimiento_workflowS = $("#uu_27").val();
    var fecha_comprobacion_completoS = $("#uu_260").val();
    var fecha_comprobacionS = $("#uu_26").val();
    var fecha_resultados_completoS = $("#uu_250").val();
    var fecha_resultadosS = $("#uu_25").val();
    var fecha_busqueda_completoS = $("#uu_240").val();
    var fecha_busquedaS = $("#uu_24").val();
    var fecha_registro_completoS = $("#uu_230").val();
    var fecha_registroS = $("#uu_23").val();
    var fecha_instrucciones_completoS = $("#uu_220").val();
    var fecha_instruccionesS = $("#uu_22").val();
    var fecha_requerimiento_completoS = $("#uu_210").val();
    var fecha_requerimientoS = $("#uu_21").val();
    if (fecha_requerimientoS == "" && (solicitud_tipo == 1 || solicitud_tipo == 2 || solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6 || solicitud_tipo == 7 || solicitud_tipo == 8 || solicitud_tipo == 9 || solicitud_tipo == 10)) {
        //$("#uu_06").addClass("control-error");
        $("#uu_21_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab05';
    }

    var cesion = $("#uu_19 option:selected").val();
    var cesion_desc = $("#uu_19 option:selected").text();
    var solicitante_cesion = $("#uu_18").val();
    var solicitante_cesion_desc = $("#uu_18").val();
    //if(cesion <= 0) {
    //    //$("#uu_19_c .select2-selection").addClass("control-error");
    //    $("#uu_19_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab04';
    //}

    //if (solicitante_cesion == "") {
    //    //$("#uu_18").addClass("control-error");
    //    $("#uu_18_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab04';
    //}

    var licencia = $("#uu_17 option:selected").val();
    var licencia_desc = $("#uu_17 option:selected").text();
    var solicitante_licencia = $("#uu_16").val();
    var solicitante_licencia_desc = $("#uu_16").val();
    //if (licencia <= 0) {
    //    //$("#uu_17_c .select2-selection").addClass("control-error");
    //    $("#uu_17_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab03';
    //}

    //if (solicitante_licencia == "" && (solicitud_tipo == 1 || solicitud_tipo == 2 || solicitud_tipo == 3 || solicitud_tipo == 4)) {
    //    //$("#uu_16").addClass("control-error");
    //    $("#uu_16_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab03';
    //}

    //var corresponsal = $("#uu_15 option:selected").val();
    var corresponsal_desc = $("#uu_15 option:selected").text();
    var despacho = $("#uu_14 option:selected").val();
    var despacho_desc = $("#uu_14 option:selected").text();
    var autor_registro = $("#uu_13 option:selected").val();
    var autor_registro_desc = $("#uu_13 option:selected").text();
    var tipo_registro_solicitud = $("#uu_12 option:selected").val();
    var tipo_registro_solicitud_desc = $("#uu_12 option:selected").text();
    var no_solicitud = $("#uu_11").val();
    //if (corresponsal <= 0) {
    //    //$("#uu_15_c .select2-selection").addClass("control-error");
    //    $("#uu_15_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab02';
    //}
    //if (despacho <= 0) {
    //    //$("#uu_14_c .select2-selection").addClass("control-error");
    //    $("#uu_14_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab02';
    //}
    //if (autor_registro == "NA") {
    if (autor_registro <=0) {
        //$("#uu_13_c .select2-selection").addClass("control-error");
        $("#uu_13_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab02';
    }
    if (tipo_registro_solicitud <= 0 && (solicitud_tipo == 1 || solicitud_tipo == 2)) {
        //$("#uu_12_c .select2-selection").addClass("control-error");
        $("#uu_12_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab02';
    }
    //if (no_solicitud == "") {
    //    //$("#uu_11").addClass("control-error");
    //    $("#uu_11_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab02';
    //}   

    var uso = $("#uu_39 option:selected").val();
    var estatus = $("#uu_10 option:selected").val();
    var estatus_desc = $("#uu_10 option:selected").text();
    var pais = $("#uu_09 option:selected").val();
    var pais_desc = $("#uu_09 option:selected").text();
    //var tipo_registro = $("#uu_08 option:selected").val();
    //var tipo_registro_desc = $("#uu_08 option:selected").text();
    var tipo_registro = 0;
    var tipo_registro_desc = "";
    var clase = $("#uu_07 option:selected").val();
    var clase_desc = $("#uu_07 option:selected").text();
    var fecha_concesionS = $("#uu_06").val();
    var fecha_vencimientoS = $("#uu_05").val();
    var fecha_legalS = $("#uu_04").val();
    var no_registro = $("#uu_03").val();
    var empresa_anterior = $("#uu_01 option:selected").val();
    var empresa_anterior_desc = $("#uu_01 option:selected").text();
    var empresa = $("#uu_00 option:selected").val();
    var empresa_desc = $("#uu_00 option:selected").text();
    var solicitud = $("#uu_021 option:selected").val();
    var solicitud_desc = $("#uu_021 option:selected").text();
    var nombre = $("#uu_022").val();
    var nueva_fecha_vencimientoS = $("#uu_41").val();

    //if (uso <= 0 && (solicitud_tipo == 1 || solicitud_tipo == 2)) {
    //    //$("#uu_09_c .select2-selection").addClass("control-error");
    //    $("#uu_39_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    if (estatus <= 0) {
        //$("#uu_10_c .select2-selection").addClass("control-error");
        $("#uu_10_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab01';
    }
    if (pais <= 0 && (solicitud_tipo == 1 || solicitud_tipo == 2 || solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6)) {
        //$("#uu_09_c .select2-selection").addClass("control-error");
        $("#uu_09_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab01';
    }
    if (tipo_registro <= 0 && tipo_registro!=0) {
        //$("#uu_08_c .select2-selection").addClass("control-error");
        $("#uu_08_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab01';
    }
    if (clase <= 0 && (solicitud_tipo==1 || solicitud_tipo==2)) {
        //$("#uu_07_c .select2-selection").addClass("control-error");
        $("#uu_07_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab01';
    }
    //if (fecha_concesionS == "" && (solicitud_tipo == 1 || solicitud_tipo == 2 || solicitud_tipo == 7 || solicitud_tipo == 8 || solicitud_tipo == 9 || solicitud_tipo == 10 || solicitud_tipo == 11 || solicitud_tipo == 12)) {
    //if (fecha_concesionS == "") {
    //    //$("#uu_06").addClass("control-error");
    //    $("#uu_06_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (fecha_vencimientoS == "" && solicitud_tipo <= 6) {
    //    //$("#uu_05").addClass("control-error");
    //    $("#uu_05_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (fecha_legalS == "") {
    //    //$("#uu_04").addClass("control-error");
    //    $("#uu_04_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (no_registro == "") {
    //    //$("#uu_03").addClass("control-error");
    //    $("#uu_03_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (empresa_anterior <= 0) {
    //    //$("#uu_01_c .select2-selection").addClass("control-error");
    //    $("#uu_01_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    if (empresa <= 0) {
        //$("#uu_00_c .select2-selection").addClass("control-error");
        $("#uu_00_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
        tab = '#tab01';
    }
    if (solicitud_tipo <= 0) {
        //$("#uu_02_c .select2-selection").addClass("control-error");
        $("#uu_02_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab01';
    }
    //if (solicitud <= 0) {
    //    //$("#uu_021_c .select2-selection").addClass("control-error");
    //    $("#uu_021_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    if (nombre == "") {
        //$("#uu_04").addClass("control-error");
        $("#uu_022_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab01';
    }

    var fecha_quinquenio_anualidadS = $("#uu_37").val();
    var tipo_pago = $("#uu_34 option:selected").val();
    var tipo_pago_desc = $("#uu_34 option:selected").text();
    //var prioridad = $("#uu_35").val();
    //var fecha_vencimiento_prioridadS = $("#uu_36").val();
    //if (fecha_quinquenio_anualidadS == "" && (solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6)) {
    //    $("#uu_37_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (tipo_pago <= 0 && (solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6)) {
    //    $("#uu_34_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (prioridad=="" && (solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6)) {
    //    $("#uu_35_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}
    //if (fecha_vencimiento_prioridadS=="" && (solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6)) {
    //    $("#uu_36_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //    tab = '#tab01';
    //}

    var autor = $("#uu_38").val();
    if (autor == "" && solicitud_tipo>=7) {
        $("#uu_38_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab01';
    }

    var renovacion = $("#renovacion").val();
    var oficiold = $("#oficiol").attr("href");
    var fecha_oficio_renovacionS = $("#uu_33").val();
    var oficio_renovacion = $("#oficio").val();
    var id = $("#id_registro").val();
    var oficio_renovacion_old = $("#oficiol").text();

    if ((id > 0 && fecha_oficio_renovacionS == "" && oficio_renovacion != "") || (id > 0 && fecha_oficio_renovacionS == "" && nueva_fecha_vencimientoS != "")) {
        $("#uu_33_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab01';
    }

    if ((id > 0 && oficio_renovacion == "" && fecha_oficio_renovacionS != "" && renovacion == 'on' && oficiold == "") || (id > 0 && oficio_renovacion == "" && nueva_fecha_vencimientoS != "" && renovacion == 'on' && oficiold == "")) {
        $("#oficioc").append("<p class='form-error'>Seleccione el archivo</p>");
        errores += 1;
        tab = '#tab01';
    }

    if (id > 0 && fecha_oficio_renovacionS != "" && oficio_renovacion != "" && nueva_fecha_vencimientoS=="") {
        $("#uu_41_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab01';
    }


    if (errores > 0) {
        flag = false;
        $(".nav-link[href='" + tab + "']").click();
    } else {
        flag = true;
    }

    return flag;
}

function Guardar() {
    if (Validar() != false) {
        var fecha_declaracion_completoS = $("#uu_400").val();
        var fecha_declaracionS = $("#uu_40").val();
        var fecha_concesion_workflow_completoS = $("#uu_280").val();
        var fecha_concesion_workflowS = $("#uu_28").val();
        var fecha_vencimiento_workflow_completoS = $("#uu_270").val();
        var fecha_vencimiento_workflowS = $("#uu_27").val();
        var fecha_comprobacion_completoS = $("#uu_260").val();
        var fecha_comprobacionS = $("#uu_26").val();
        var fecha_resultados_completoS = $("#uu_250").val();
        var fecha_resultadosS = $("#uu_25").val();
        var fecha_busqueda_completoS = $("#uu_240").val();
        var fecha_busquedaS = $("#uu_24").val();
        var fecha_registro_completoS = $("#uu_230").val();
        var fecha_registroS = $("#uu_23").val();
        var fecha_instrucciones_completoS = $("#uu_220").val();
        var fecha_instruccionesS = $("#uu_22").val();
        var fecha_requerimiento_completoS = $("#uu_210").val();
        var fecha_requerimientoS = $("#uu_21").val();

        var cesion = 0;
        var cesion_desc = "";
        if (parseInt($("#uu_19 option:selected").val()) > 0) {
            cesion = $("#uu_19 option:selected").val();
            cesion_desc = $("#uu_19 option:selected").text();
        }
        var solicitante_cesion = $("#uu_18").val();
        var solicitante_cesion_desc = $("#uu_18").val();

        var licencia = 0;
        var licencia_desc = "";
        if (parseInt($("#uu_17 option:selected").val()) > 0) {
            licencia = $("#uu_17 option:selected").val();
            licencia_desc = $("#uu_17 option:selected").text();
        }
        var solicitante_licencia = $("#uu_16").val();
        var solicitante_licencia_desc = $("#uu_16").val();

        var solicitud_tipo = $("#uu_02 option:selected").val();
        var solicitud_tipo_desc = $("#uu_02 option:selected").text();

        var corresponsal = 0;
        var corresponsal_desc = "";
        if (parseInt($("#uu_15 option:selected").val()) > 0) {
            corresponsal = $("#uu_15 option:selected").val();
            corresponsal_desc = $("#uu_15 option:selected").text();
        }
        var despacho =0;
        var despacho_desc = "";
        if (parseInt($("#uu_14 option:selected").val()) > 0) {
            despacho = $("#uu_14 option:selected").val();
            despacho_desc = $("#uu_14 option:selected").text();
        }
        var autor_registro = $("#uu_13 option:selected").val();
        var autor_registro_desc = $("#uu_13 option:selected").text();
        var tipo_registro_solicitud = 0;
        var tipo_registro_solicitud_desc = "";
        if (solicitud_tipo == 1 || solicitud_tipo == 2) {
            tipo_registro_solicitud = $("#uu_12 option:selected").val();
            tipo_registro_solicitud_desc = $("#uu_12 option:selected").text();
        }
        var no_solicitud = $("#uu_11").val()
        var uso = 0;
        var uso_desc = "";
        if (parseInt($("#uu_39 option:selected").val()) > 0 && (solicitud_tipo == 1 || solicitud_tipo == 2)) {
            uso = $("#uu_39 option:selected").val();
            uso_desc = $("#uu_39 option:selected").text();
        }
        var estatus = $("#uu_10 option:selected").val();
        var estatus_desc = $("#uu_10 option:selected").text();
        var pais = 0;
        var pais_desc = "N/A";
        if (solicitud_tipo == 1 || solicitud_tipo == 2 || solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6) {
            pais = $("#uu_09 option:selected").val();
            pais_desc = $("#uu_09 option:selected").text();
        }
        //var tipo_registro = $("#uu_08 option:selected").val();
        //var tipo_registro_desc = $("#uu_08 option:selected").text();
        var tipo_registro = 0;
        var tipo_registro_desc = "";
        var clase = 0;
        var clase_desc = "N/A";
        if (solicitud_tipo == 1 || solicitud_tipo == 2) {
            clase = $("#uu_07 option:selected").val();
            clase_desc = $("#uu_07 option:selected").text();
        }
        //var fecha_concesionS = "";
        //if (solicitud_tipo == 1 || solicitud_tipo == 2 || solicitud_tipo == 7 || solicitud_tipo == 8 || solicitud_tipo == 9 || solicitud_tipo == 10 || solicitud_tipo == 11 || solicitud_tipo == 12) {
        //    fecha_concesionS = $("#uu_06").val();
        //} 
        var fecha_concesionS = $("#uu_06").val();
        var fecha_vencimientoS = $("#uu_05").val();
        var fecha_legalS = $("#uu_04").val();
        var no_registro = $("#uu_03").val();
        var empresa_anterior = 0;
        var empresa_anterior_desc = "";
        if (parseInt($("#uu_01 option:selected").val()) > 0) {
            empresa_anterior = $("#uu_01 option:selected").val();
            empresa_anterior_desc = $("#uu_01 option:selected").text();
        }
        var empresa = $("#uu_00 option:selected").val();
        var empresa_desc = $("#uu_00 option:selected").text();
        var solicitud = $("#uu_021 option:selected").val();
        var solicitud_desc = $("#uu_021 option:selected").text();
        var nombre = $("#uu_022").val();
        var notificacion_titulo = $("#notificacion_titulo").val();
        var notificacion_vencimiento = $("#notificacion_vencimiento").val();
        var notificacion_estatus = $("#notificacion_estatus").val();

        var fecha_quinquenio_anualidadS = "";
        if (solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6) {
            fecha_quinquenio_anualidadS = $("#uu_37").val();
        }
        var tipo_pago = 0;
        var tipo_pago_desc = "";
        if (parseInt($("#uu_34 option:selected").val()) > 0 && (solicitud_tipo == 3 || solicitud_tipo == 4 || solicitud_tipo == 5 || solicitud_tipo == 6)) {
            tipo_pago = $("#uu_34 option:selected").val();
            tipo_pago_desc = $("#uu_34 option:selected").text();
        }
        var prioridad = $("#uu_35").val();
        var fecha_vencimiento_prioridadS = $("#uu_36").val();

        var autor = "";
        if (solicitud_tipo == 7 || solicitud_tipo == 8 || solicitud_tipo == 9 || solicitud_tipo == 10 || solicitud_tipo == 11 || solicitud_tipo == 12) {
            autor = $("#uu_38").val();
        }
        //----
        var fecha_renovarS = $("#uu_29").val();
        var fecha_renovar_completoS = $("#uu_290").val();
        var fecha_instruccion_corresponsalS = $("#uu_30").val();
        var fecha_instruccion_corresponsal_completoS = $("#uu_300").val();
        var fecha_solicitud_empresaS = $("#uu_31").val();
        var fecha_solicitud_empresa_completoS = $("#uu_310").val();
        var fecha_despachoS = $("#uu_32").val();
        var fecha_despacho_completoS = $("#uu_320").val();
        var oficio_completoS = $("#uu_33").val();
        var nueva_fecha_vencimientoS = $("#uu_41").val();

        registro.fecha_renovarS = fecha_renovarS;
        registro.fecha_renovar_completoS = fecha_renovar_completoS;
        registro.fecha_instruccion_corresponsalS = fecha_instruccion_corresponsalS;
        registro.fecha_instruccion_corresponsal_completoS = fecha_instruccion_corresponsal_completoS;
        registro.fecha_solicitud_empresaS = fecha_solicitud_empresaS;
        registro.fecha_solicitud_empresa_completoS = fecha_solicitud_empresa_completoS;
        registro.fecha_despachoS = fecha_despachoS;
        registro.fecha_despacho_completoS = fecha_despacho_completoS;
        registro.oficio_completoS = oficio_completoS;
        //----

        registro.nombre = nombre;
        registro.empresa = empresa;
        registro.empresa_desc = empresa_desc;
        registro.empresa_anterior = empresa_anterior;
        registro.empresa_anterior_desc = empresa_anterior_desc;
        //registro.nombre = nombre;
        registro.no_registro = no_registro;
        //registro.titulo = titulo;
        registro.fecha_legalS = fecha_legalS;
        registro.fecha_vencimientoS = fecha_vencimientoS;
        registro.fecha_concesionS = fecha_concesionS;
        registro.clase = clase;
        registro.clase_desc = clase_desc;
        registro.tipo_registro = tipo_registro;
        registro.tipo_registro_desc = tipo_registro_desc;
        registro.pais = pais;
        registro.pais_desc = pais_desc;
        registro.estatus = estatus;
        registro.estatus_desc = estatus_desc;
        registro.uso = uso;
        registro.uso_desc = uso_desc;
        registro.no_solicitud = no_solicitud;
        registro.tipo_registro_solicitud = tipo_registro_solicitud;
        registro.tipo_registro_solicitud_desc = tipo_registro_solicitud_desc;
        registro.autor_registro = autor_registro;
        registro.autor_registro_desc = autor_registro_desc;
        registro.despacho = despacho;
        registro.despacho_desc = despacho_desc;
        registro.corresponsal = corresponsal;
        registro.corresponsal_desc = corresponsal_desc;
        registro.solicitante_licencia = solicitante_licencia;
        registro.solicitante_licencia_desc = solicitante_licencia_desc;
        registro.licencia = licencia;
        registro.licencia_desc = licencia_desc;
        registro.solicitante_cesion = solicitante_cesion;
        registro.solicitante_cesion_desc = solicitante_cesion_desc;
        registro.cesion = cesion;
        registro.cesion_desc = cesion_desc;
        registro.usuario = eu_lu.id;
        registro.usuario_desc = eu_lu.name;
        //registro.activo = resutlado;
        registro.solicitud = solicitud;
        registro.solicitud_desc = solicitud_desc;
        registro.solicitud_tipo = solicitud_tipo;
        registro.solicitud_tipo_desc = solicitud_tipo_desc;
        registro.fecha_requerimientoS = fecha_requerimientoS;
        registro.fecha_requerimiento_completoS = fecha_requerimiento_completoS;
        registro.fecha_instruccionesS = fecha_instruccionesS;
        registro.fecha_instrucciones_completoS = fecha_instrucciones_completoS;
        registro.fecha_registroS = fecha_registroS;
        registro.fecha_registro_completoS = fecha_registro_completoS;
        registro.fecha_busquedaS = fecha_busquedaS;
        registro.fecha_busqueda_completoS = fecha_busqueda_completoS;
        registro.fecha_resultadosS = fecha_resultadosS;
        registro.fecha_resultados_completoS = fecha_resultados_completoS;
        registro.fecha_comprobacionS = fecha_comprobacionS;
        registro.fecha_comprobacion_completoS = fecha_comprobacion_completoS;
        registro.fecha_vencimiento_workflowS = fecha_vencimiento_workflowS;
        registro.fecha_vencimiento_workflow_completoS = fecha_vencimiento_workflow_completoS;
        registro.fecha_concesion_workflowS = fecha_concesion_workflowS;
        registro.fecha_concesion_workflow_completoS = fecha_concesion_workflow_completoS;
        registro.fecha_declaracionS = fecha_declaracionS;
        registro.fecha_declaracion_completoS = fecha_declaracion_completoS;

        registro.notificacion_titulo = notificacion_titulo;
        registro.notificacion_vencimiento = notificacion_vencimiento;
        registro.notificacion_estatus = notificacion_estatus;

        registro.fecha_quinquenio_anualidadS = fecha_quinquenio_anualidadS;
        registro.tipo_pago = tipo_pago;
        registro.tipo_pago_desc = tipo_pago_desc;
        registro.prioridad = prioridad;
        registro.fecha_vencimiento_prioridadS = fecha_vencimiento_prioridadS;
        registro.autor = autor;
        registro.nueva_fecha_vencimientoS = nueva_fecha_vencimientoS;
        //--
        var renovacion = 0;
        if ($("#renovacion").is(":checked")) {
            renovacion = 1;
        }
        registro.renovacion = renovacion;
        //--

        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Cargando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        var sended_url = services_url + "UpdateOBJRegistroMarca";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({
                registro: registro
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    if (registro.id == 0) {
                        registro.id = jsonResponse.data_int;
                    }
                    /*if (contrato.id == 0) {
                        RecargaDocumentos(jsonResponse.data_int);
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
                    $("#preGuardar").hide();
                    $(".subheader-title span").text("Datos de contrato");
                    $("#extraContrato").show();
                    $("#postGuardar").show();
                    $("#in03c").show();
                    $("#folio").attr("disabled", "disabled");
                    $("#in03").attr("disabled", "disabled");
                    //$("#in02").attr("disabled", "disabled");
                    $("#in06").trigger("change");*/
                    $("#btnRemover").show();

                    setTimeout(function () {
                        $("#alertModal .modal-title").text("Datos guardados");
                        $("#alertModal .modal-spinner").hide();
                        $("#alertModal .form-group").append("<p class=''>Se han guardados los datos correctamente</p>");
                        $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');


                        if ($('#titulo')[0].files.length > 0) {
                            uploading_titulo = true;
                            GuardarArchivo("#titulo", "titulo");
                        } else {
                            uploading_titulo = false;
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
                            uploading_oficio = false;
                            //console.log("no hay archivos solicitud");
                        }
                        if ($('#contrato')[0].files.length > 0) {
                            uploading_contrato = true;
                            GuardarArchivo("#contrato", "contrato");
                        } else {
                            uploading_contrato = false;
                            //console.log("no hay archivos solicitud");
                        }
                        if ($('#reivindicacion')[0].files.length > 0) {
                            uploading_reivindicacion = true;
                            GuardarArchivo("#reivindicacion", "reivindicacion");
                        } else {
                            uploading_reivindicacion = false;
                            //console.log("no hay archivos solicitud");
                        }
                        if ($('#carta')[0].files.length > 0) {
                            uploading_carta = true;
                            GuardarArchivo("#carta", "carta");
                        } else {
                            uploading_carta = false;
                            //console.log("no hay archivos solicitud");
                        }
                        var tipourl = parseInt($("#tipo_registromarca").val());
                        if (tipourl == 0) tipourl = 1;
                        setTimeout(function () {
                            window.location = hosturl+'PI/RegistroMarcas?tipo=' + tipourl;
                        }, 2800);
                    }, 1500);
                } else {
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-default"><i class="fa fa-undo"></i> Ok</button>');
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
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
}
function ValidarVoBo() {
    return true;
}
function GuardarVoBo() {
    if (ValidarVoBo() != false) {
        var vobo = 0;
        if ($("#vobo").is(":checked")) {
            vobo = 1;
        }
        $("#alertModal .close").hide();
        $("#alertModal .modal-title").text("Cargando información");
        $("#alertModal .modal-footer").empty();
        $("#alertModal .form-group").empty();
        $("#alertModal .modal-spinner").show();
        $("#alertModal").modal("show");
        var sended_url = services_url + "UpdateRegistroMarcaVoBo";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({
                id: registro.id,
                vobo: vobo
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    setTimeout(function () {
                        $("#alertModal .modal-title").text("Datos guardados");
                        $("#alertModal .modal-spinner").hide();
                        $("#alertModal .form-group").append("<p class=''>Se han guardados los datos correctamente</p>");
                        $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                        var tipourl = parseInt($("#tipo_registromarca").val());
                        if (tipourl == 0) tipourl = 1;
                        setTimeout(function () {
                            window.location = hosturl+'PI/RegistroMarcas?tipo='+tipourl;
                        }, 2800);
                    }, 1500);
                } else {
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-default"><i class="fa fa-undo"></i> Ok</button>');
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
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
}

$(document).on("change", "#solicitud", function (event) {
    readURL(this, "#solicitud", "#solicitudc");
});
$(document).on("change", "#titulo", function (event) {
    readURL(this, "#titulo", "#tituloc");
});
$(document).on("change", "#oficio", function (event) {
    readURL(this, "#oficio", "#oficioc");
});
$(document).on("change", "#contrato", function (event) {
    readURL(this, "#contrato", "#contratoc");
});
$(document).on("change", "#reivindicacion", function (event) {
    readURL(this, "#reivindicacion", "#reivindicacionc");
});
$(document).on("change", "#carta", function (event) {
    readURL(this, "#carta", "#cartac");
});
function readURL(input, id, container) {
    if (input.files && input.files[0]) {
        var nombre = input.files[0].name;
        $(".btn-lbl[for='" + id.replace("#", "") + "']").html("<i class='fa fa-clock'></i> Archivo seleccionado (" + nombre + ")");
    }
}

function SelectRegistroMarca(id, desabilitar) {
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
                    comentarios = jsonResponse.content[1];
                    RedibujaComentarios(desabilitar);
                    //
                    //--------------------
                    if (registro.licencia>=1) {
                        document.getElementById("lic_0_c").style.display = "block";//licencia
                        //document.getElementById("licencia_a").style.display = "block";//licencia
                        document.getElementById("lic_2_c").style.display = "block";//licencia
                        document.getElementById("lic_3_c").style.display = "block";//licencia
                    } else {
                        document.getElementById("lic_0_c").style.display = "none";//licencia
                        //document.getElementById("licencia_a").style.display = "none";//licencia
                        document.getElementById("lic_2_c").style.display = "none";//licencia
                        document.getElementById("lic_3_c").style.display = "none";//licencia
                    }
                    if (registro.cesion >= 1) {
                        document.getElementById("ces_0_c").style.display = "block";//cesion
                        //document.getElementById("cesion_a").style.display = "block";//cesion
                        //document.getElementById("ces_2_c").style.display = "block";//cesion
                        document.getElementById("ces_3_c").style.display = "block";//cesion
                        document.getElementById("ces_4_c").style.display = "block";//cesion
                    } else {
                        document.getElementById("ces_0_c").style.display = "none";//cesion
                        //document.getElementById("cesion_a").style.display = "none";//cesion
                        //document.getElementById("ces_2_c").style.display = "none";//cesion
                        document.getElementById("ces_3_c").style.display = "none";//cesion
                        document.getElementById("ces_4_c").style.display = "none";//cesion
                    }
                    $("#uu_022").val(registro.nombre);
                    var solicitud = solicitudes.filter(i => i.tipo == registro.solicitud_tipo & i.id == registro.solicitud);
                    if (solicitud.length < 1) {
                        solicitudes.push({
                            id: registro.solicitud,
                            nombre: registro.nombre,
                            empresa: registro.empresa,
                            pais: registro.pais,
                            tipo: registro.solicitud_tipo,
                            usuario: registro.usuario
                        });
                    }
                    CheckIfOptionExists("#uu_02", registro.solicitud_tipo, registro.solicitud_tipo_desc, true, true);

                    setTimeout(function () {
                        document.getElementById("id_registro").value = registro.id;
                        var solicitud_select = solicitudes.filter(i => i.tipo == registro.solicitud_tipo & i.id == registro.solicitud);
                        //alert(solicitud_select[0].id);
                        if (solicitud_select[0].id >0) CheckIfOptionExists("#uu_021", registro.solicitud, registro.solicitud_desc, true, true);
                    }, 500);
                    //--------------------
                    CheckIfOptionExists("#uu_00", registro.empresa, registro.empresa_desc, true, true);
                    CheckIfOptionExists("#uu_01", registro.empresa_anterior, registro.empresa_anterior_desc, true, true);
                    $("#uu_03").val(registro.no_registro);
                    $("#uu_04").val(registro.fecha_legalS);
                    $("#uu_04").datepicker("update", registro.fecha_legalS);
                    $("#uu_05").val(registro.fecha_vencimientoS);
                    $("#uu_05").datepicker("update", registro.fecha_vencimientoS);
                    $("#uu_06").val(registro.fecha_concesionS);
                    $("#uu_06").datepicker("update", registro.fecha_concesionS);
                    CheckIfOptionExists("#uu_07", registro.clase, registro.clase_desc, true, true);
                    CheckIfOptionExists("#uu_08", registro.tipo_registro, registro.tipo_registro_desc, true, true);
                    CheckIfOptionExists("#uu_09", registro.pais, registro.pais_desc, true, true);
                    CheckIfOptionExists("#uu_10", registro.estatus, registro.estatus_desc, true, true);

                    $("#uu_11").val(registro.no_solicitud);
                    CheckIfOptionExists("#uu_12", registro.tipo_registro_solicitud, registro.tipo_registro_solicitud_desc, true, true);
                    CheckIfOptionExists("#uu_13", registro.autor_registro, registro.autor_registro_desc, true, true);
                    CheckIfOptionExists("#uu_14", registro.despacho, registro.despacho_desc, true, true);
                    CheckIfOptionExists("#uu_15", registro.corresponsal, registro.corresponsal_desc, true, true);


                    $("#uu_16").val(registro.solicitante_licencia);
                    CheckIfOptionExists("#uu_17", registro.licencia, registro.licencia_desc, true, true);


                    $("#uu_18").val(registro.solicitante_cesion);
                    CheckIfOptionExists("#uu_19", registro.cesion, registro.cesion_desc, true, true);


                    $("#uu_21").val(registro.fecha_requerimientoS);
                    $("#uu_21").datepicker("update", registro.fecha_requerimientoS);
                    $("#uu_210").val(registro.fecha_requerimiento_completoS);
                    $("#uu_210").datepicker("update", registro.fecha_requerimiento_completoS);

                    $("#uu_22").val(registro.fecha_instruccionesS);
                    $("#uu_22").datepicker("update", registro.fecha_instruccionesS);
                    $("#uu_220").val(registro.fecha_instrucciones_completoS);
                    $("#uu_220").datepicker("update", registro.fecha_instrucciones_completoS);

                    $("#uu_23").val(registro.fecha_registroS);
                    $("#uu_23").datepicker("update", registro.fecha_registroS);
                    $("#uu_230").val(registro.fecha_registro_completoS);
                    $("#uu_230").datepicker("update", registro.fecha_registro_completoS);

                    $("#uu_24").val(registro.fecha_busquedaS);
                    $("#uu_24").datepicker("update", registro.fecha_busquedaS);
                    $("#uu_240").val(registro.fecha_busqueda_completoS);
                    $("#uu_240").datepicker("update", registro.fecha_busqueda_completoS);

                    $("#uu_25").val(registro.fecha_resultadosS);
                    $("#uu_25").datepicker("update", registro.fecha_resultadosS);
                    $("#uu_250").val(registro.fecha_resultados_completoS);
                    $("#uu_250").datepicker("update", registro.fecha_resultados_completoS);

                    $("#uu_26").val(registro.fecha_comprobacionS);
                    $("#uu_26").datepicker("update", registro.fecha_comprobacionS);
                    $("#uu_260").val(registro.fecha_comprobacion_completoS);
                    $("#uu_260").datepicker("update", registro.fecha_comprobacion_completoS);

                    $("#uu_27").val(registro.fecha_vencimiento_workflowS);
                    $("#uu_27").datepicker("update", registro.fecha_vencimiento_workflowS);
                    $("#uu_270").val(registro.fecha_vencimiento_workflow_completoS);
                    $("#uu_270").datepicker("update", registro.fecha_vencimiento_workflow_completoS);

                    $("#uu_28").val(registro.fecha_concesion_workflowS);
                    $("#uu_28").datepicker("update", registro.fecha_concesion_workflowS);
                    $("#uu_280").val(registro.fecha_concesion_workflow_completoS);
                    $("#uu_280").datepicker("update", registro.fecha_concesion_workflow_completoS);

                    //--
                    $("#uu_29").val(registro.fecha_renovarS);
                    $("#uu_29").datepicker("update", registro.fecha_renovarS);
                    $("#uu_290").val(registro.fecha_renovar_completoS);
                    $("#uu_290").datepicker("update", registro.fecha_renovar_completoS);

                    $("#uu_30").val(registro.fecha_instruccion_corresponsalS);
                    $("#uu_30").datepicker("update", registro.fecha_instruccion_corresponsalS);
                    $("#uu_300").val(registro.fecha_instruccion_corresponsal_completoS);
                    $("#uu_300").datepicker("update", registro.fecha_instruccion_corresponsal_completoS);

                    $("#uu_31").val(registro.fecha_solicitud_empresaS);
                    $("#uu_31").datepicker("update", registro.fecha_solicitud_empresaS);
                    $("#uu_310").val(registro.fecha_solicitud_empresa_completoS);
                    $("#uu_310").datepicker("update", registro.fecha_solicitud_empresa_completoS);

                    $("#uu_32").val(registro.fecha_despachoS);
                    $("#uu_32").datepicker("update", registro.fecha_despachoS);
                    $("#uu_320").val(registro.fecha_despacho_completoS);
                    $("#uu_320").datepicker("update", registro.fecha_despacho_completoS);

                    $("#uu_33").val(registro.oficio_completoS);
                    $("#uu_33").datepicker("update", registro.oficio_completoS);

                    $("#uu_37").datepicker("update", registro.fecha_quinquenio_anualidadS);
                    CheckIfOptionExists("#uu_34", registro.tipo_pago, registro.tipo_pago_desc, true, true);
                    $("#uu_35").val(registro.prioridad);
                    $("#uu_36").datepicker("update", registro.fecha_vencimiento_prioridadS);
                    $("#uu_38").val(registro.autor);
                    CheckIfOptionExists("#uu_39", registro.uso, registro.uso_desc, true, true);
                    $("#uu_40").val(registro.fecha_declaracionS);
                    $("#uu_40").datepicker("update", registro.fecha_declaracionS);
                    $("#uu_400").val(registro.fecha_declaracion_completoS);
                    $("#uu_400").datepicker("update", registro.fecha_declaracion_completoS);
                    $("#uu_41").val(registro.nueva_fecha_vencimientoS);
                    $("#uu_41").datepicker("update", registro.nueva_fecha_vencimientoS);;
                    //--



                    if (registro.titulo_permalink != "") {
                        $("#titulol").attr("href", registro.titulo_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar (' + registro.titulo_nombre_original + ')').show();
                    } else {
                        $("#titulol").attr("href", "").hide();
                    }
                    if (registro.solicitud_permalink != "") {
                        $("#solicitudl").attr("href", registro.solicitud_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar (' + registro.solicitud_nombre_original + ')').show();
                    } else {
                        $("#solicitudl").attr("href", "").hide();
                    }
                    if (registro.oficio_permalink != "") {
                        $("#oficiol").attr("href", registro.oficio_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar (' + registro.oficio_nombre_original + ')').show();
                    } else {
                        $("#oficiol").attr("href", "").hide();
                    }
                    if (registro.contrato_permalink != "") {
                        $("#contratol").attr("href", registro.contrato_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar (' + registro.contrato_nombre_original + ')').show();
                    } else {
                        $("#contratol").attr("href", "").hide();
                    }
                    if (registro.reivindicacion_permalink != "") {
                        $("#reivindicacionl").attr("href", registro.reivindicacion_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar (' + registro.reivindicacion_nombre_original + ')').show();
                    } else {
                        $("#reivindicacionl").attr("href", "").hide();
                    }
                    if (registro.carta_permalink != "") {
                        $("#cartal").attr("href", registro.carta_permalink + "&us=" + eu_lu.id).html('<i class="fa fa-download"></i> Descargar (' + registro.carta_nombre_original + ')').show();
                    } else {
                        $("#cartal").attr("href", "").hide();
                    }


                    if (registro.vobo == 1) {
                        $("#vobo").prop("checked", true);
                    } else {
                        $("#vobo").prop("checked", false);
                    }

                    $("#notificacion_titulo").val(registro.notificacion_titulo);
                    $("#notificacion_vencimiento").val(registro.notificacion_vencimiento);
                    $("#notificacion_estatus").val(registro.notificacion_estatus);

                    documentos01 = jsonResponse.content[2];
                    var dev_documentos01 = new DevExpress.data.DataSource(documentos01);
                    $("#tabla01").dxDataGrid({
                        dataSource: dev_documentos01,
                    });
                    $("#tabla01").dxDataGrid("getDataSource").reload();

                    //

                    $("#btnRemover").show();

                    if (registro.activo == 0) {
                        $("#btnRemover").removeClass("btn-danger")
                            .addClass("btn-success").html('<i class="fa fa-check"></i> Activar');
                    } else {
                        $("#btnRemover").removeClass("btn-success")
                            .addClass("btn-danger").html('<i class=""></i> Inactivar');
                    }

                    if (registro.renovacion == 1) {
                        $("#renovacion").prop("checked", true).attr("disabled","disabled");
                        //$("#renovacion_check").hide();
                        $("#renovacion_info").show();
                    } else {
                        $("#renovacion").prop("checked", false);
                        //$("#renovacion_check").show();
                        $("#renovacion_info").hide();
                    }



                    if (registro.estatus_desc == "En registro") {
                        $(".nav-link[href='#tab06']").removeAttr("disabled").show();
                        $("#notificacion_titulo").removeAttr("disabled").parent().show();
                        $("#notificacion_vencimiento").removeAttr("disabled").parent().show();
                        $("#notificacion_estatus").removeAttr("disabled").parent().show();
                    }

                    const hoy = new Date(Date.now());
                    let day = `${(hoy.getDate())}`.padStart(2, '0');
                    let month = `${(hoy.getMonth() + 1)}`.padStart(2, '0');
                    let year = hoy.getFullYear();
                    let fechaAct = year + '-' + month + '-' + day + 'T00:00:00';

                    //let yearAtras = year;
                    //let monthAtras = month - 6;
                    //if (monthAtras <= 0) {
                    //    monthAtras = monthAtras + 12;
                    //    yearAtras = year - 1;
                    //}
                    //let fecAtras = yearAtras + '-' + monthAtras + '-' + day + 'T00:00:00';

                    //const fecVen = new Date(registro.fecha_vencimiento);
                    //let dayVen = `${(fecVen.getDate())}`.padStart(2, '0');
                    //let monthVen = `${(fecVen.getMonth() + 1)}`.padStart(2, '0');
                    //let yearVen = fecVen.getFullYear();
                    //let fechaVen = yearVen + '-' + monthVen + '-' + dayVen + 'T00:00:00';
                    //alert(fechaVen);
                    //if (registro.estatus_desc == "Registrada") {
                    //if (((registro.fecha_vencimiento < fechaAct && fechaVen > fecAtras) || (registro.fecha_vencimiento < fechaAct && fechaVen > fecAtras))&& registro.estatus > 2) {
                    if ((registro.fecha_vencimiento < fechaAct || registro.fecha_vencimiento >= fechaAct) && registro.estatus > 2) {
                        $("#notificacion_titulo").removeAttr("disabled").show();
                        $("#notificacion_vencimiento").removeAttr("disabled").show();
                        $("#notificacion_estatus").removeAttr("disabled").show();
                        $(".nav-link[href='#tab07']").removeAttr("disabled").show();
                        if (registro.solicitud_tipo >= 1 && registro.solicitud_tipo <= 2) {
                            $(".nav-link[href='#tab08']").removeAttr("disabled").show();
                        }else if (registro.solicitud_tipo >= 3 && registro.solicitud_tipo <= 6 && registro.fecha_quinquenio_anualidad != "1969-01-01T00:00:00" && registro.fecha_quinquenio_anualidad >= fechaAct) {
                            $(".nav-link[href='#tab08']").removeAttr("disabled").show();
                        }
                        //$("#valor").removeAttr("readonly")
                        //$("#uu_29").removeAttr("disabled");
                        //$("#uu_290").removeAttr("disabled");
                        //$("#uu_30").removeAttr("disabled");
                        //$("#uu_300").removeAttr("disabled");
                        //$("#uu_31").removeAttr("disabled");
                        //$("#uu_310").removeAttr("disabled");
                        //$("#uu_32").removeAttr("disabled");
                        //$("#uu_320").removeAttr("disabled");
                        //$("#uu_33").removeAttr("disabled");
                        //$("#uu_41").removeAttr("disabled");
                        //$("#oficio").removeAttr("disabled");
                    } //else if (registro.fecha_vencimiento >= fechaAct && registro.estatus > 2) {
                    //    $("#notificacion_titulo").removeAttr("disabled").show();
                    //    $("#notificacion_vencimiento").removeAttr("disabled").show();
                    //    $(".nav-link[href='#tab07']").removeAttr("disabled").show();
                    //    if (registro.solicitud_tipo == 1 || registro.solicitud_tipo == 2) {
                    //        $(".nav-link[href='#tab08']").removeAttr("disabled").show();
                    //    }
                    //    $("#uu_29").attr("disabled", "disabled");
                    //    $("#uu_290").attr("disabled", "disabled");
                    //    $("#uu_30").attr("disabled", "disabled");
                    //    $("#uu_300").attr("disabled", "disabled");
                    //    $("#uu_31").attr("disabled", "disabled");
                    //    $("#uu_310").attr("disabled", "disabled");
                    //    $("#uu_32").attr("disabled", "disabled");
                    //    $("#uu_320").attr("disabled", "disabled");
                    //    $("#uu_33").attr("disabled", "disabled");
                    //    $("#uu_41").attr("disabled", "disabled");
                    //    $("#oficio").attr("disabled", "disabled");
                    //    //$("#oficio").remove();
                    //    //var elemento = document.getElementById('oficio');
                    //    //elemento.style.display = "none";
                    //    //$("#oficio").hide();
                    //    //$("#oficio").hide();
                    //    //$("#oficio").style.display="none";
                    //    //document.getElementById("oficio").disabled = false;
                    //}

                    $("#alertModal .modal-title").text("Datos guardados");
                    $("#alertModal .modal-spinner").hide();
                    $("#alertModal .form-group").append("<p class=''>Se han guardados los datos corretamente</p>");
                    $("#alertModal .modal-footer").html('<button type="button" data-dismiss="modal" class="btn btn-info"><i class="fa fa-check"></i> Ok</button>');
                    
                    //licencia_select = licencias.filter(i => i.id == registro.licencia);
                    //if (licencia_select[0] != undefined) {
                    //    let date = new Date(licencia_select[0].fecha_vencimiento)
                    //    let day = `${(date.getDate())}`.padStart(2, '0');
                    //    let month = `${(date.getMonth() + 1)}`.padStart(2, '0');
                    //    let year = date.getFullYear();
                    //    //$("#lic_02").val(new Date(licencia_select[0].fecha_vencimiento).toLocaleDateString('en-us', { weekday: 'long', year: 'numeric', month: 'short', day: 'numeric' }));
                    //    $("#lic_02").val(`${day}/${month}/${year}`);
                    //    $("#lic_03").val(licencia_select[0].observaciones);
                    //    //alert(registro.idlic)
                    //    alert(registro.licencia_fecha_vencimiento)
                    //    if (registro.licencia_permalink != "") {
                    //        $("#licencial").attr("href", registro.licencia_permalink + "&us="+registro.idlic).html('<i class="fa fa-download"></i> Descargar (' + registro.licencia_nombre_original + ')').show();
                    //    } else {
                    //        $("#licencial").attr("href", "").hide();
                    //    }
                    //} else {
                    //    $("#lic_02").val('');
                    //    $("#lic_03").val('');
                    //    $("#licencial").attr("href", "").hide();
                    //}

                    //licencia_select = licencias.filter(i => i.id == registro.licencia);
                    if (registro.idlic >= 1) {
                        let date = new Date(registro.licencia_fecha_vencimiento)
                        let day = `${(date.getDate())}`.padStart(2, '0');
                        let month = `${(date.getMonth() + 1)}`.padStart(2, '0');
                        let year = date.getFullYear();
                        if (year > "1969") {
                            //$("#lic_02").val(new Date(licencia_select[0].fecha_vencimiento).toLocaleDateString('en-us', { weekday: 'long', year: 'numeric', month: 'short', day: 'numeric' }));
                            $("#lic_02").val(`${day}/${month}/${year}`);
                        } else {
                            $("#lic_02").val('');
                        }
                        $("#lic_03").val(registro.licencia_observaciones);
                        //alert(registro.idlic)
                        //alert(registro.licencia_nombre_original)
                        //if (registro.licencia_permalink != "") {
                        //    $("#licencial").attr("href", registro.licencia_permalink + "&us=" + registro.idlic).html('<i class="fa fa-download"></i> Descargar (' + registro.licencia_nombre_original + ')').show();
                        //} else {
                        //    $("#licencial").attr("href", "").hide();
                        //}
                        if (registro.licencia_permalink != "") {
                            document.getElementById("licencia_a").style.display = "block";//licencia
                            $("#licencial").attr("href", registro.licencia_permalink + "&us=" + registro.idlic).html('<i class="fa fa-download"></i> Descargar (' + registro.licencia_nombre_original + ')').show();
                        } else {
                            document.getElementById("licencia_a").style.display = "none";//licencia
                            $("#licencial").attr("href", "").hide();
                        }
                    } else {
                        document.getElementById("licencia_a").style.display = "none";//licencia
                        $("#lic_02").val('');
                        $("#lic_03").val('');
                        $("#licencial").attr("href", "").hide();
                    }

                    if (registro.idces >= 1) {
                        /*let date = new Date(registro.cesion_fecha_vencimiento)
                        let day = `${(date.getDate())}`.padStart(2, '0');
                        let month = `${(date.getMonth() + 1)}`.padStart(2, '0');
                        let year = date.getFullYear();
                        if (year > "1969") {
                            $("#ces_02").val(`${day}/${month}/${year}`);
                        } else {
                            $("#ces_02").val('');
                        }*/
                        $("#ces_03").val(registro.cesion_observaciones);
                        if (registro.cesion_registro != "") {
                            $("#ces_04").val(registro.cesion_cedente + ' - ' + registro.cesion_cesionario + ' - ' + registro.cesion_nombre + ' - ' + registro.cesion_registro + ' - ' + registro.cesion_clase + ' - ' +registro.cesion_pais);
                        } else {
                            $("#ces_04").val(registro.cesion_cedente + ' - ' + registro.cesion_cesionario + ' - ' + registro.cesion_nombre + ' - ' + registro.cesion_expediente + ' - ' + registro.cesion_clase + ' - ' + registro.cesion_pais);
                        }

                        if (registro.cesion_permalink != "") {
                            document.getElementById("cesion_a").style.display = "block";//licencia
                            $("#cesionl").attr("href", registro.cesion_permalink + "&us=" + registro.idces).html('<i class="fa fa-download"></i> Descargar (' + registro.cesion_nombre_original + ')').show();
                        } else {
                            document.getElementById("cesion_a").style.display = "none";//licencia
                            $("#cesionl").attr("href", "").hide();
                        }
                    } else {
                        document.getElementById("cesion_a").style.display = "none";//licencia
                        $("#ces_02").val('');
                        $("#ces_03").val('');
                        $("#ces_04").val('');
                        $("#cesionl").attr("href", "").hide();
                    }

                    $("#alertModal").modal("hide");

                    //VISTAS
                    if (eu_lu.role.id == "8566d71d-72f0-489d-92d4-410804d82e60") {//super admin
                        document.getElementById("comentarios_a").style.display = "block";
                        document.getElementById("uu_14_a").style.display = "block";//despacho, lo utiliza todos
                        document.getElementById("uu_15_a").style.display = "block";//corresponsal, lo utiliza todos
                        document.getElementById("comentarios_b").style.display = "block";
                        //clase se muestra para propiedad 1,2, pero ya se oculta o muestra arriba
                        document.getElementById("contrato_a").style.display = "block";
                        //tipo registro se muestra para propiedad 1,2, pero ya se oculta o muestra arriba
                        //document.getElementById("renovacion_check").style.display = "block";
                        //document.getElementById("renovacion_a").style.display = "block";
                        //document.getElementById("tab05").style.display = "block";
                    } else {
                        document.getElementById("comentarios_a").style.display = "none";
                        document.getElementById("uu_14_a").style.display = "none";//despacho, lo utiliza todos
                        document.getElementById("uu_15_a").style.display = "none";//corresponsal, lo utiliza todos
                        document.getElementById("notificacion_titulo_a").style.display = "none";//notificacion titulo
                        document.getElementById("notificacion_vencimiento_a").style.display = "none";//notificacion vencimiento
                        document.getElementById("notificacion_estatus_a").style.display = "none";//notificacion estatus
                        document.getElementById("comentarios_b").style.display = "none";
                        //clase se oculta para propiedad 3,4,5,6,7,8,9,10,11,12, pero ya se oculta o muestra arriba
                        document.getElementById("contrato_a").style.display = "none";
                        //tipo registro se oculta para propiedad 3,4,5,6,7,8,9,10,11,12, pero ya se oculta o muestra arriba
                        document.getElementById("renovacion_check").style.display = "none";
                        document.getElementById("renovacion_a").style.display = "none";
                        document.getElementById("tabActividades").style.display = "none";
                        if (eu_lu.role.id == "c696ba3f-4b65-4fb4-b31a-b2e96c9ffc99" || eu_lu.role.id == "e4aacdfd-3425-42de-9ac5-7e0bcdf177c3") { //auditor y director
                            document.getElementById("uu_35_a").style.display = "none";//prioridad lo utiliza admin y usuario
                            document.getElementById("uu_36_a").style.display = "none";//fecha vencimineto prioridad lo utiliza admin y usuario
                            document.getElementById("uu_39_a").style.display = "none";//uso lo utiliza admin y usuario
                            if (registro.solicitud_tipo >= 1 && registro.solicitud_tipo <= 6) {
                                document.getElementById("solicitud_a").style.display = "none";
                            }
                            if (registro.solicitud_tipo >= 7 && registro.solicitud_tipo <= 12) {
                                document.getElementById("carta_a").style.display = "none";
                            }

                        }
                        
                    }

                    if (desabilitar == 0) {
                        $("#btnGuardar").show();
                        $("#btnRemover").show();
                        $("#tituloa").show();
                        $("#titulo").removeAttr('disabled');
                        $("#Comentarios1").show();
                        //document.getElementById("btnGuardar").disabled = false;
                        $("#uu_022").removeAttr('disabled');
                        $("#uu_38").removeAttr('disabled');
                        $("#uu_00").removeAttr('disabled');
                        $("#uu_01").removeAttr('disabled');
                        $("#uu_03").removeAttr('disabled');
                        $("#uu_04").removeAttr('disabled');
                        $("#uu_05").removeAttr('disabled');
                        $("#uu_06").removeAttr('disabled');
                        $("#uu_07").removeAttr('disabled');
                        $("#uu_09").removeAttr('disabled');
                        $("#uu_10").removeAttr('disabled');
                        $("#uu_37").removeAttr('disabled');
                        $("#uu_34").removeAttr('disabled');
                        $("#uu_35").removeAttr('disabled');
                        $("#uu_36").removeAttr('disabled');
                        $("#uu_39").removeAttr('disabled');
                        $("#notificacion_titulo").removeAttr('disabled');
                        $("#notificacion_vencimiento").removeAttr('disabled');
                        $("#notificacion_estatus").removeAttr('disabled');
                        //en registro
                        $("#solicituda").show();
                        //$("#solicitud").removeAttr('disabled');
                        $("#contratoa").show();
                        //$("#contrato").removeAttr('disabled');
                        $("#reivindicaciona").show();
                        //$("#reivindicacion").removeAttr('disabled');
                        $("#cartaa").show();
                        //$("#carta").removeAttr('disabled');
                        $("#Comentarios2").show();
                        $("#uu_11").removeAttr('disabled');
                        $("#uu_12").removeAttr('disabled');
                        $("#uu_13").removeAttr('disabled');
                        $("#uu_14").removeAttr('disabled');
                        $("#uu_15").removeAttr('disabled');
                        //licencia
                        $("#uu_16").removeAttr('disabled');
                        $("#uu_17").removeAttr('disabled');
                        //cesion
                        $("#uu_18").removeAttr('disabled');
                        $("#uu_19").removeAttr('disabled');
                        //actividades
                        $("#uu_21").removeAttr('disabled');
                        $("#uu_210").removeAttr('disabled');
                        $("#uu_22").removeAttr('disabled');
                        $("#uu_220").removeAttr('disabled');
                        $("#uu_23").removeAttr('disabled');
                        $("#uu_230").removeAttr('disabled');
                        $("#uu_24").removeAttr('disabled');
                        $("#uu_240").removeAttr('disabled');
                        $("#uu_25").removeAttr('disabled');
                        $("#uu_250").removeAttr('disabled');
                        $("#uu_26").removeAttr('disabled');
                        $("#uu_260").removeAttr('disabled');
                        $("#uu_40").removeAttr('disabled');
                        $("#uu_400").removeAttr('disabled');
                        //oficios
                        $("#btnDocumento").show();
                        //renovacion
                        $("#oficioa").show();
                        //$("#oficio").removeAttr('disabled');
                        $("#renovacion_1").attr('disabled', 'disabled');//chek
                        $("#uu_29").removeAttr('disabled');
                        $("#uu_290").removeAttr('disabled');
                        $("#uu_30").removeAttr('disabled');
                        $("#uu_300").removeAttr('disabled');
                        $("#uu_31").removeAttr('disabled');
                        $("#uu_310").removeAttr('disabled');
                        $("#uu_32").removeAttr('disabled');
                        $("#uu_320").removeAttr('disabled');
                        $("#uu_33").removeAttr('disabled');
                        $("#uu_41").removeAttr('disabled');
                    } else {
                        //general
                        $("#btnGuardar").hide();
                        $("#btnRemover").hide();
                        $("#tituloa").hide();//archivo titulo
                        //$("#titulo").attr('disabled', 'disabled');
                        $("#Comentarios1").hide();
                        //document.getElementById("btnGuardar").disabled = true;
                        $("#uu_022").attr('disabled', 'disabled');//nombre
                        $("#uu_38").attr('disabled', 'disabled');//autor
                        $("#uu_00").attr('disabled', 'disabled');//empresa
                        $("#uu_01").attr('disabled', 'disabled');//antigua empresa
                        $("#uu_03").attr('disabled', 'disabled');//no registro
                        $("#uu_04").attr('disabled', 'disabled');//fecha_legal
                        $("#uu_05").attr('disabled', 'disabled');//fecha vencimiento
                        $("#uu_06").attr('disabled', 'disabled');//fecha concesion
                        $("#uu_07").attr('disabled', 'disabled');//clase
                        $("#uu_09").attr('disabled', 'disabled');//pais
                        $("#uu_10").attr('disabled', 'disabled');//estatus
                        $("#uu_37").attr('disabled', 'disabled');//fecha quinquenio
                        $("#uu_34").attr('disabled', 'disabled');//tipo pago
                        $("#uu_35").attr('disabled', 'disabled');//prioridad
                        $("#uu_36").attr('disabled', 'disabled');//fecha prioridad
                        $("#uu_39").attr('disabled', 'disabled');//uso
                        $("#notificacion_titulo").attr('disabled', 'disabled');//notificacion titulo
                        $("#notificacion_vencimiento").attr('disabled', 'disabled');//notificacion vencimiento
                        $("#notificacion_estatus").attr('disabled', 'disabled');//notificacion estatus
                        //en registro
                        $("#solicituda").hide();//archivo solicitud
                        //$("#solicitud").attr('disabled', 'disabled');
                        $("#contratoa").hide();//archivo contrato
                        //$("#contrato").attr('disabled', 'disabled');
                        $("#reivindicaciona").hide();//archivo reivindicacion
                        //$("#reivindicacion").attr('disabled', 'disabled');
                        $("#cartaa").hide();//archivo carta
                        //$("#carta").attr('disabled', 'disabled');
                        $("#Comentarios2").hide();
                        $("#uu_11").attr('disabled', 'disabled');//no solicitud
                        $("#uu_12").attr('disabled', 'disabled');//tipo registro
                        $("#uu_13").attr('disabled', 'disabled');//persona pidio registro
                        $("#uu_14").attr('disabled', 'disabled');//despacho
                        $("#uu_15").attr('disabled', 'disabled');//corresponsal
                        //licencia
                        $("#uu_16").attr('disabled', 'disabled');//persona que solicita licencia
                        $("#uu_17").attr('disabled', 'disabled');//licencia
                        //cesion
                        $("#uu_18").attr('disabled', 'disabled');//persona que solicita cesion
                        $("#uu_19").attr('disabled', 'disabled');//cesion
                        //actividades
                        $("#uu_21").attr('disabled', 'disabled');//requerimiento del negocio
                        $("#uu_210").attr('disabled', 'disabled');//completo
                        $("#uu_22").attr('disabled', 'disabled');//instrucciones al corresponsal
                        $("#uu_220").attr('disabled', 'disabled');//completo
                        $("#uu_23").attr('disabled', 'disabled');//registro ante la autoridad
                        $("#uu_230").attr('disabled', 'disabled');//completo
                        $("#uu_24").attr('disabled', 'disabled');//solicitud busqueda
                        $("#uu_240").attr('disabled', 'disabled');//completo
                        $("#uu_25").attr('disabled', 'disabled');//resultados al negocio
                        $("#uu_250").attr('disabled', 'disabled');//completo
                        $("#uu_26").attr('disabled', 'disabled');//comprobacion de uso
                        $("#uu_260").attr('disabled', 'disabled');//completo
                        $("#uu_40").attr('disabled', 'disabled');//declaracion de uso
                        $("#uu_400").attr('disabled', 'disabled');//completo
                        //oficios
                        $("#btnDocumento").hide();
                        //renovacion
                        $("#oficioa").hide();//archivo oficio
                        //$("#oficio").attr('disabled', 'disabled');
                        $("#renovacion_1").attr('disabled', 'disabled');//chek
                        $("#uu_29").attr('disabled', 'disabled');//enpresa instrucciones
                        $("#uu_290").attr('disabled', 'disabled');//completo
                        $("#uu_30").attr('disabled', 'disabled');//instrucciones corresponsal
                        $("#uu_300").attr('disabled', 'disabled');//completo
                        $("#uu_31").attr('disabled', 'disabled');//solicitud de informacion
                        $("#uu_310").attr('disabled', 'disabled');//completo
                        $("#uu_32").attr('disabled', 'disabled');//envio informacion despacho
                        $("#uu_320").attr('disabled', 'disabled');//completo
                        $("#uu_33").attr('disabled', 'disabled');//oficio de renovacion
                        $("#uu_41").attr('disabled', 'disabled');//new fecha vencimiento

                        $(".nav-link[href='#tab06']").attr("disabled", "disabled").hide();
                    }
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
                        //fecha_legal: DateTime.Parse("1969-01-01"),
                        //fecha_vencimiento: DateTime.Parse("1969-01-01"),
                        //fecha_concesion: DateTime.Parse("1969-01-01"),
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
                        //solicitud_nombre: "",
                        //solicitud_data: new Array(),
                        //solicitud_content_type: "",
                        //solicitud_size: 0,
                        //solicitud_extension: "",
                        //solicitud_nombre_original: "",
                        //solicitud_url: "",
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
                        //fecha_requerimiento: DateTime.Parse("1969-01-01"),
                        //fecha_requerimiento_completo: DateTime.Parse("1969-01-01"),
                        //fecha_instrucciones: DateTime.Parse("1969-01-01"),
                        //fecha_instrucciones_completo: DateTime.Parse("1969-01-01"),
                        //fecha_registro: DateTime.Parse("1969-01-01"),
                        //fecha_registro_completo: DateTime.Parse("1969-01-01"),
                        //fecha_busqueda: DateTime.Parse("1969-01-01"),
                        //fecha_busqueda_completo: DateTime.Parse("1969-01-01"),
                        //fecha_resultados: DateTime.Parse("1969-01-01"),
                        //fecha_resultados_completo: DateTime.Parse("1969-01-01"),
                        //fecha_comprobacion: DateTime.Parse("1969-01-01"),
                        //fecha_comprobacion_completo: DateTime.Parse("1969-01-01"),
                        //fecha_vencimiento_workflow: DateTime.Parse("1969-01-01"),
                        //fecha_vencimiento_workflow_completo: DateTime.Parse("1969-01-01"),
                        //fecha_concesion_workflow: DateTime.Parse("1969-01-01"),
                        //fecha_concesion_workflow_completo: DateTime.Parse("1969-01-01"),
                        //fc: DateTime.Parse("1969-01-01"),
                        //fu: DateTime.Parse("1969-01-01"),
                        usuario: "",
                        usuario_desc: "",
                        activo: 0,
                        //titulo_nombre: "",
                        //titulo_data: new Array(),
                        //titulo_content_type: "",
                        //titulo_size: 0,
                        //titulo_extension: "",
                        //titulo_nombre_original: "",
                        //titulo_url: "",
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
                        //contrato_nombre: "",
                        //contrato_data: new Array(),
                        //contrato_content_type: "",
                        //contrato_size: 0,
                        //contrato_extension: "",
                        //contrato_nombre_original: "",
                        //contrato_url: "",

                        //reivindicacion_nombre: "",
                        //reivindicacion_data: new Array(),
                        //reivindicacion_content_type: "",
                        //reivindicacion_size: 0,
                        //reivindicacion_extension: "",
                        //reivindicacion_nombre_original: "",
                        //reivindicacion_url: "",
                        autor: "",
                        //carta_nombre: "",
                        //carta_data: new Array(),
                        //carta_content_type: "",
                        //carta_size: 0,
                        //carta_extension: "",
                        //carta_nombre_original: "",
                        //carta_url: "",
                        uso: 0,
                        uso_desc: "",
                        fecha_declaracionS: "",
                        fecha_declaracion_completoS: "",
                        nueva_fecha_vencimientoS: "",
                    };

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

var uploading_titulo = false;
var uploading_solicitud = false;
var uploading_oficio = false;
var uploading_contrato = false;
var uploading_reivindicacion = false;
var uploading_carta = false;

function submitarchivos() {
    if ($('#titulo')[0].files.length > 0) {
        uploading_titulo = true;
        GuardarArchivo("#titulo", "titulo");
    } else {
        uploading_titulo = false;
        //console.log("no hay archivos titulo");
    }
    if ($('#solicitud')[0].files.length > 0) {
        uploading_solicitud = true;
        GuardarArchivo("#solicitud", "solicitud");
    } else {
        uploading_solicitud = false;
        //console.log("no hay archivos solicitud");
    }
    if ($('#contrato')[0].files.length > 0) {
        uploading_contrato = true;
        GuardarArchivo("#contrato", "contrato");
    } else {
        uploading_contrato = false;
        //console.log("no hay archivos solicitud");
    }
    if ($('#reivindicacion')[0].files.length > 0) {
        uploading_reivindicacion = true;
        GuardarArchivo("#reivindicacion", "reivindicacion");
    } else {
        uploading_reivindicacion = false;
        //console.log("no hay archivos solicitud");
    }
    if ($('#carta')[0].files.length > 0) {
        uploading_carta = true;
        GuardarArchivo("#carta", "carta");
    } else {
        uploading_carta = false;
        //console.log("no hay archivos solicitud");
    }
}

function GuardarArchivo(input, tipo) {
    var formData = new FormData();
    switch (input) {
        case "#titulo":
            formData.append('file', $('#titulo')[0].files[0]);
            $("#alertModal .form-group").append("<p id='titulo_uploading'>Cargando archivos (Título) ...</p>");
            break;
        case "#solicitud":
            formData.append('file', $('#solicitud')[0].files[0]);
            $("#alertModal .form-group").append("<p id='solicitud_uploading'>Cargando archivos (Solicitud) ...</p>");
            break;
        case "#oficio":
            formData.append('file', $('#oficio')[0].files[0]);
            $("#alertModal .form-group").append("<p id='oficio_uploading'>Cargando archivos (Oficio de renovación) ...</p>");
            break;
        case "#contrato":
            formData.append('file', $('#contrato')[0].files[0]);
            $("#alertModal .form-group").append("<p id='contrato_uploading'>Cargando archivos (Contrato de cesión del inventor) ...</p>");
            break;
        case "#reivindicacion":
            formData.append('file', $('#reivindicacion')[0].files[0]);
            $("#alertModal .form-group").append("<p id='reivindicacion_uploading'>Cargando archivos (Reivindicaciones) ...</p>");
            break;
        case "#carta":
            formData.append('file', $('#carta')[0].files[0]);
            $("#alertModal .form-group").append("<p id='carta_uploading'>Cargando archivos (Carta colaboración renumerada) ...</p>");
            break;
    }
    formData.append('tipo', tipo);
    formData.append('usuario', eu_lu.id);
    formData.append('valor', registro.id);
    $.ajax({
        url: hosturl + 'api/Archivos/RegistroMarcaSaveFile',
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
                    case "#titulo":
                        uploading_titulo = false;
                        $("#titulo_uploading").text("Documento cargado correctamente (Título)");
                        $(".btn-lbl[for='titulo']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#titulol").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar (' + nombre + ')').show();
                        break;
                    case "#solicitud":
                        uploading_solicitud = false;
                        $("#solicitud_uploading").text("Documento cargado correctamente (Solicitud)");
                        $(".btn-lbl[for='solicitud']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#solicitudl").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar (' + nombre + ')').show();
                        break;
                    case "#oficio":
                        uploading_oficio = false;
                        $("#oficio_uploading").text("Documento cargado correctamente (Oficio de renovación)");
                        $(".btn-lbl[for='oficio']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#oficiol").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar (' + nombre + ')').show();
                        break;
                    case "#contrato":
                        uploading_contrato = false;
                        $("#contrato_uploading").text("Documento cargado correctamente (Contrato de cesión del inventor)");
                        $(".btn-lbl[for='contrato']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#contratol").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar (' + nombre + ')').show();
                        break;
                    case "#reivindicacion":
                        uploading_reivindicacion = false;
                        $("#reivindicacion_uploading").text("Documento cargado correctamente (Reivindicaciones)");
                        $(".btn-lbl[for='reivindicacion']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#reivindicacionl").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar (' + nombre + ')').show();
                        break;
                    case "#carta":
                        uploading_carta = false;
                        $("#carta_uploading").text("Documento cargado correctamente (Carta colaboración renumerada)");
                        $(".btn-lbl[for='carta']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                        $("#cartal").attr("href", permalink).html('<i class="fa fa-download"></i> Descargar (' + nombre + ')').show();
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
                case "#titulo":
                    uploading_titulo = false;
                    $(".btn-lbl[for='titulo']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#titulo_uploading").text("No se pudo cargar el archivo (Título)");
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
                case "#contrato":
                    uploading_contrato = false;
                    $(".btn-lbl[for='contrato']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#contrato_uploading").text("No se pudo cargar el archivo (Contrato de cesión del inventor)");
                    break;
                case "#reivindicacion":
                    uploading_reivindicacion = false;
                    $(".btn-lbl[for='reivindicacion']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#reivindicacion_uploading").text("No se pudo cargar el archivo (Reivindicaciones)");
                    break;
                case "#carta":
                    uploading_carta = false;
                    $(".btn-lbl[for='carta']").html("<i class='fa fa-upload'></i> Seleccionar documento");
                    $("#carta_uploading").text("No se pudo cargar el archivo (Carta colaboración renumerada)");
                    break;
                default:
                    break;
            }
        },
        complete: function (jqXHR, status) {
        }
    });

}

var comentario = {
    id: 0,
    tipo_comentario: 0,
    registro_marca: 0,
    descripcion: "",
    usuario: {
        id: eu_lu.id
    }
};
function ValidarComentario() {
    $("#comentarioModal .form-error").remove();
    $("#comentarioModal .form-control").removeClass("control-error");
    $("#comentarioModal .select2.select2-container .select2-selection").removeClass("control-error");

    var descripcion = $("#comentario").val();

    var errores = 0;
    var flag = false;

    if (descripcion.length <= 0) {
        $("#comentario").addClass("control-error");
        $("#comentarioc").append("<p class='form-error'>El campo está vacío</p>");
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

function ConfirmaComentario() {
    if (ValidarComentario() != false) {
        comentario.descripcion = $("#comentario").val();
        comentario.registro_marca = registro.id;

        $("#comentarioModal .modal-spinner").show();
        $("#comentarioModal .form-control").attr("disabled", "disabled");
        $("#comentarioModal .btn-info").attr("disabled", "disabled");
        $("#comentarioModal .modal-spinner").show();

        var sended_url = services_url + "AddRegistroMarcaComentario";
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
                        RedibujaComentarios(0);
                        $("#comentarioModal").modal("hide");
                        //RecargaHistorialActividades();
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

function RedibujaComentarios(desabilitar) {
    $("#general").empty();
    $("#registro").empty();
    $("#revision").empty();
    var general = comentarios.filter(i => i.tipo_comentario == 1);
    var registro = comentarios.filter(i => i.tipo_comentario == 2);
    var revision = comentarios.filter(i => i.tipo_comentario == 3);
    //console.log(eu_lu.id, general, registro, revision);
    //----------

    if (general.length > 0) {
        for (var i = 0; i < general.length; i++) {
            var el = general[i];
            var acciones = '';
            if (desabilitar == 0) { acciones = '<span onclick="EliminarComentario(' + el.id + ')"><i class="fa fa-times"></i></span>'; }
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
            $("#general").append(li);
        }
    } else {
        var li = '<li class="ctm-comentario">' +
            '<div class="ctm-comentario-body">' +
            '<p>No hay comentarios aún</p>' +
            '</div>'
        '</li>';
        $("#general").append(li);
    }

    //----------

    if (registro.length > 0) {
        for (var i = 0; i < registro.length; i++) {
            var el = registro[i];
            var acciones = '';
            if (desabilitar == 0) { acciones = '<span onclick="EliminarComentario(' + el.id + ')"><i class="fa fa-times"></i></span>'; }
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
            $("#registro").append(li);
        }
    } else {
        var li = '<li class="ctm-comentario">' +
            '<div class="ctm-comentario-body">' +
            '<p>No hay comentarios aún</p>' +
            '</div>'
        '</li>';
        $("#registro").append(li);
    }

    if (revision.length > 0) {
        for (var i = 0; i < revision.length; i++) {
            var el = revision[i];
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
            $("#revision").append(li);
        }
    } else {
        var li = '<li class="ctm-comentario">' +
            '<div class="ctm-comentario-body">' +
            '<p>No hay comentarios aún</p>' +
            '</div>'
        '</li>';
        $("#revision").append(li);
    }
}


function ModalComentario(tipo) {
    comentario = {
        id: 0,
        tipo_comentario: tipo,
        registro_marca: registro.id,
        descripcion: "",
        usuario: {
            id: eu_lu.id
        }
    };
    $("#comentario").val("");
    $("#comentarioModal .modal-spinner").hide();
    $("#comentarioModal .form-error").remove();
    $("#comentarioModal").modal("show");
}


function EliminarComentario(id) {
    comentario = {
        id: id,
        registro_marca: registro.id,
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
    var sended_url = services_url + "EliminarRegistroMarcaComentario";
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

                    RedibujaComentarios(0);

                    $("#eliminarComentarioModal").modal("hide");
                    //RecargaHistorialActividades();
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

//---------------------------
//
Dropzone.autoDiscover = false;
var dp1 = false;
var documentos01 = new Array();
var dzdocumentos01 = new Dropzone("#dz-documentos01", {
    url: hosturl + "api/Archivos/UploadArchivoV2",
    maxFiles: 1,
    autoProcessQueue: true,
    parallelUploads: 1,
    maxFilesize: 100,
    accept: function (file, done) {
        if (file.size == 0) {
            done("Empty files will not be uploaded.");
            $("#dzAlert").modal("show");
        }
        else {
            done();
        }
    },
    init: function () {
        this.on("sending", function (file, xhr, formData) {
            formData.append("objeto", registro.id);
            formData.append("usuario", eu_lu.id);
            formData.append("tipo", "oficio");
            formData.append("modelo", "RegistroMarca");
        });

        this.on("success", function (file, responseText) {
            var jsonResponse = responseText;
            if (jsonResponse.flag != false) {
                try {
                    documentos01.push(jsonResponse.content[0]);
                    var dev_documentos = new DevExpress.data.DataSource(documentos01);
                    $("#tabla01").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla01").dxDataGrid("getDataSource").reload();
                } catch (ex) {
                }
            }
        });


        this.on("error", function (file, responseText) {
            dzdocumentos01.removeFile(file);
            console.log(file, responseText);
        });


        this.on("addedfile", function (file, responseText) {
            if (dzdocumentos01.files.length > 1) {
                dzdocumentos01.removeFile(dzdocumentos01.files[0]);
            }
            console.log(file, responseText);
        });

        this.on("queuecomplete", function (file, responseText) {
        });
    }
});

function ModalDocumento() {
    dzdocumentos01.hiddenFileInput.click();
}

function RemoverDocumento(uuid) {
    if (dzdocumentos01.files.length > 0) {
        for (var i = 0; dzdocumentos01.files.length; i++) {
            if (dzdocumentos01.files[i].upload.uuid == uuid) {
                dzdocumentos01.removeFile(dzdocumentos01.files[i]);

                var search = searchArrayByKeyProp(uuid, "uuid", documentos01)
                if (search != null) {
                    removeFromArray(search.idx, documentos01);

                    var dev_documentos = new DevExpress.data.DataSource(documentos01);
                    $("#tabla01").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla01").dxDataGrid("getDataSource").reload();
                }
                break;
            }
        }
    }
}

//-----------------
function Remover() {
    $("#removerModal .modal-spinner").hide();
    $("#removerModal .form-error").remove();
    $("#removerModal").modal("show");
}

function ConfirmaRemoverRegistro() {
    $("#removerModal .modal-spinner").show();
    $("#removerModal .btn-info").attr("disabled", "disabled");
    var sended_url = services_url + "UpdateRegistroMarcaActivo";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ id: registro.id, usuario: eu_lu.id, usuario_desc: eu_lu.name }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setTimeout(function () {
                $("#removerModal .modal-spinner").hide();
                $("#removerModal .btn-info").removeAttr("disabled");
                var jsonResponse = response;
                var tipourl = parseInt($("#tipo_registromarca").val());
                if (tipourl == 0) tipourl = 1;
                if (jsonResponse.flag != false) {
                    location.href = hosturl + "PI/RegistroMarcas?tipo="+tipourl;
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#removerModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }
            }, 1500);
        },
        failure: function (response) {
            $("#removerModal .modal-spinner").hide();
            $("#removerModal .btn-info").removeAttr("disabled");
        },
        error: function (response) {
            $("#removerModal .modal-spinner").hide();
            $("#removerModal .btn-info").removeAttr("disabled");
        }
    });
}

function Cancelar() {
    var tipourl = parseInt($("#tipo_registromarca").val());
    if (tipourl == 0) tipourl = 1;
    location.href = hosturl + "PI/RegistroMarcas?tipo=" + tipourl;
}