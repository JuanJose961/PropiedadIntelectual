var muid = "";
$(document).ready(function () {
    $(".ctm-header-area span").text("Módulo PI");

    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });

    $('#uu_02').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
    $('#uu_06').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });
});

$(document).on("change", "#uu_08", function (event) { //tipo recordatorio
    var val = parseInt($(this).val());
    if (val == 1) {
        document.getElementById("uu_03_a").style.display = "block";//dias antes vencimiento
        //document.getElementById("uu_10_c").style.display = "block";//fecha validacion
        //document.getElementById("uu_04_c").style.display = "block";//dias del mes
    } else { 
        document.getElementById("uu_03_a").style.display = "none";//dias antes vencimiento
        //document.getElementById("uu_10_c").style.display = "none";//fecha validacion
        //document.getElementById("uu_04_c").style.display = "block";//dias del mes
    }
});

var catalogo_actual = {
    id: 0,
    usuario: "",
    asignado: "",
    fecha_recordatorioS: "",
    fecha_finS: "",
    descripcion: "",
    dias_vencimiento: 0,
    dias_frecuencia: "",
    estatus: 1
};

function ModalNuevo() {
    catalogo_actual = {
        id: 0,
        usuario: eu_lu.id,
        asignado: "NA",
        fecha_recordatorioS: "",
        fecha_finS: "",
        descripcion: "",
        dias_vencimiento: 0,
        dias_frecuencia: "",
        estatus: 1,
        tipo: 1,
        aux1: 0,
        tipo_desc: ""
    };
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");
    $("#update01 .form-control").removeAttr("disabled");
    $("#update01 .modal-title").html("<span>Nuevo registro</span>");
    $("#eliminausuario").hide();

    $("#uu_01").val(catalogo_actual.asignado).trigger("change");
    $("#uu_02").val("");
    $("#uu_06").val("");
    $("#uu_03").val(0);
    $("#uu_04").val("0");
    $("#uu_05").val("");
    $("#uu_07").val("");
    $("#uu_08").removeAttr('disabled');
    $("#uu_09").val("");
    $("#update01").modal("show");
}

function Editar(id) {
    catalogo_actual = {
        id: id,
        usuario: eu_lu.id,
        asignado: "",
        fecha_recordatorioS: "",
        fecha_finS: "",
        descripcion: "",
        dias_vencimiento: 0,
        dias_frecuencia: "",
        estatus: 1
    };
    var sended_url = services_url + "SelectRecordatorioPI";
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

                $("#uu_10").val(catalogo_actual.fecha_validacion).trigger("change");
                $("#uu_09").val(catalogo_actual.mensaje);
                $("#uu_08").val(catalogo_actual.tipo).trigger("change");
                $("#uu_08").attr('disabled', 'disabled');//tipo
                $("#uu_01").val(catalogo_actual.asignado).trigger("change");

                $("#uu_02").val(catalogo_actual.fecha_recordatorioS);
                $("#uu_02").datepicker("update", catalogo_actual.fecha_recordatorioS);


                $("#uu_06").val(catalogo_actual.fecha_finS);
                $("#uu_06").datepicker("update", catalogo_actual.fecha_finS);

                $("#uu_03").val(catalogo_actual.dias_vencimiento);
                $("#uu_04").val(catalogo_actual.dias_frecuencia);
                $("#uu_05").val(catalogo_actual.descripcion);
                $("#uu_07").val(catalogo_actual.nombre);

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
        var asignado = $("#uu_01 option:selected").val();
        var fecha_recordatorio = $("#uu_02").val();
        var fecha_fin = $("#uu_06").val();
        var dias_vencimiento = parseInt($("#uu_03").val());
        //var frecuencia = parseInt($("#uu_04").val());
        var descripcion = $("#uu_05").val();
        var nombre = $("#uu_07").val();
        var tipo = $("#uu_08 option:selected").val();
        var tipo_desc = $("#uu_08 option:selected").text();
        var dias_frecuencia = $("#uu_04").val();;
        //if (tipo == 2) dias_frecuencia = $("#uu_04").val();
        var mensaje = $("#uu_09").val();
        var fecha_validacion = 0;
        var fecha_validacion_desc = "";
        if (tipo == 1) {
            fecha_validacion = $("#uu_10 option:selected").val();
            fecha_validacion_desc = $("#uu_10 option:selected").text();
        }
        
        

        catalogo_actual.asignado = asignado;
        catalogo_actual.fecha_recordatorioS = fecha_recordatorio;
        catalogo_actual.fecha_finS = fecha_fin;
        catalogo_actual.dias_vencimiento = dias_vencimiento;
        catalogo_actual.dias_frecuencia = dias_frecuencia;
        catalogo_actual.descripcion = descripcion;
        catalogo_actual.nombre = nombre;
        catalogo_actual.tipo = tipo;
        catalogo_actual.tipo_desc = tipo_desc;
        catalogo_actual.mensaje = mensaje;
        catalogo_actual.fecha_validacion = fecha_validacion;
        catalogo_actual.fecha_validacion_desc = fecha_validacion_desc;

        var sended_url = services_url + "AddRecordatorioPI";
        if (catalogo_actual.id > 0) {
            sended_url = services_url + "UpdateRecordatorioPI";
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
                    setTimeout(function () {
                        $("#update01").modal("hide");
                    }, 1000);
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
    }
}


function ValidaUpdate01() {
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");

    var asignado = $("#uu_01 option:selected").val();
    var fecha_recordatorio = $("#uu_02").val();
    var fecha_fin = $("#uu_06").val();
    //var dias_vencimiento = parseInt($("#uu_03").val());
    var dias_vencimiento = $("#uu_03").val();
    //var frecuencia = parseInt($("#uu_04").val());
    var dias_frecuencia = $("#uu_04").val();
    var descripcion = $("#uu_05").val();
    var nombre = $("#uu_07").val();
    var tipo = $("#uu_08 option:selected").val();
    var mensaje = $("#uu_09").val();
    var fecha_validacion = $("#uu_10 option:selected").val();
    
    var errores = 0;
    var flag = false;

    if (fecha_validacion == 0) {
        $("#uu_10").addClass("control-error");
        $("#uu_10_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }
    //alert(nombre);
    //if (mensaje.length == "") {
    //    $("#uu_09").addClass("control-error");
    //    $("#uu_09_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //}
    if (tipo == 0) {
        $("#uu_08").addClass("control-error");
        $("#uu_08_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }
    /*if (asignado == "NA") {
        $("#uu_01").addClass("control-error");
        $("#uu_01_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }*/

    /*if (fecha_recordatorio.length == "") {
        $("#uu_02").addClass("control-error");
        $("#uu_02_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (fecha_fin.length == "") {
        $("#uu_06").addClass("control-error");
        $("#uu_06_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }*/
    if ((parseInt(dias_vencimiento) == 0 || dias_vencimiento =="") && tipo==1) {
        $("#uu_03").addClass("control-error");
        $("#uu_03_c").append("<p class='form-error'>Ingresa un valor válido</p>");
        errores += 1;
    }
    
    //if (frecuencia.length < 0) {
    if (dias_frecuencia.length =="") {
        $("#uu_04").addClass("control-error");
        $("#uu_04_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }
    //alert(descripcion.length);
    if (descripcion.length == "") {
        $("#uu_05").addClass("control-error");
        $("#uu_05_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }
    if (nombre.length == "") {
        $("#uu_07").addClass("control-error");
        $("#uu_07_c").append("<p class='form-error'>El campo está vacío</p>");
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
    var sended_url = services_url + "UpdateRegistroPIActivo";
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
