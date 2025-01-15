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
});

var catalogo_actual = {
    id: 0,
    nombre: "",
    telefono: "",
    email: "",
    abogado: "",
    abogado_nombre: "",
    abogado_email: "",
    tipo: tipo,
    usuario: "",
    usuario_nombre: ""
};

function ModalNuevo() {
    catalogo_actual = {
        id: 0,
        nombre: "",
        telefono: "",
        email: "",
        abogado: "NA",
        abogado_nombre: "",
        abogado_email: "",
        tipo: tipo,
        usuario: "",
        usuario_nombre: ""
    };
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");
    $("#update01 .form-control").removeAttr("disabled");
    $("#update01 .modal-title").html("<span>Nuevo registro</span>");
    $("#uu_01").val(catalogo_actual.nombre);
    $("#eliminausuario").hide();

    $("#uu_02").val(catalogo_actual.telefono);
    $("#uu_03").val(catalogo_actual.email);
    $("#uu_04").val(catalogo_actual.abogado).trigger("change");
    $("#uu_05").val(catalogo_actual.abogado_nombre);
    $("#uu_06").val(catalogo_actual.abogado_email);

    $("#update01").modal("show");
}

function Editar(id) {
    catalogo_actual = {
        id: id,
        nombre: "",
        telefono: "",
        email: "",
        abogado: "",
        abogado_nombre: "",
        abogado_email: "",
        tipo: tipo,
        usuario: "",
        usuario_nombre: ""
    };
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

                $("#uu_01").val(catalogo_actual.nombre);
                $("#uu_02").val(catalogo_actual.telefono);
                $("#uu_03").val(catalogo_actual.email);
                $("#uu_04").val(catalogo_actual.abogado).trigger("change");
                $("#uu_05").val(catalogo_actual.abogado_nombre);
                $("#uu_06").val(catalogo_actual.abogado_email);

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

$(document).on("change", "#uu_04", function (event) {
    var email = $("#uu_04 option:selected").attr("data-email");
    var nombre = $("#uu_04 option:selected").text();
    var id = $("#uu_04 option:selected").val();
    if (id != "") {
        $("#uu_05").val(nombre);
        $("#uu_06").val(email);
    } else {
        $("#uu_05").val("");
        $("#uu_06").val("");
    }
});

function Confirma01() {
    if (ValidaUpdate01() != false) {
        var nombre = $("#uu_01").val();
        var telefono = $("#uu_02").val();
        var email = $("#uu_03").val();
        var abogado = $("#uu_04 option:selected").val();
        var abogado_nombre = $("#uu_05").val();
        var abogado_email = $("#uu_06").val();

        catalogo_actual.nombre = nombre;
        catalogo_actual.telefono = telefono;
        catalogo_actual.email = email;
        catalogo_actual.abogado = abogado;
        catalogo_actual.abogado_nombre = abogado_nombre;
        catalogo_actual.abogado_email = abogado_email;
        catalogo_actual.tipo = tipo;
        catalogo_actual.usuario = eu_lu.id;
        catalogo_actual.usuario_nombre = eu_lu.name;
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

    var nombres = $("#uu_01").val();
    var telefono = $("#uu_02").val();
    var email = $("#uu_03").val();
    var abogado = $("#uu_04 option:selected").val();
    var abogado_nombre = $("#uu_05").val();
    var abogado_email = $("#uu_06").val();

    var errores = 0;
    var flag = false;

    if (nombres.length <= 0) {
        $("#uu_01").addClass("control-error");
        $("#uu_01_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (email.length <= 0) {
        $("#uu_03").addClass("control-error");
        $("#uu_03_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (telefono.length <= 0) {
        $("#uu_02").addClass("control-error");
        $("#uu_02_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    //if (abogado == "NA") {
    //    $("#uu_04").addClass("control-error");
    //    $("#uu_04_c").append("<p class='form-error'>Selecciona una opción válida</p>");
    //    errores += 1;
    //}

    //if (abogado_nombre.length <= 0) {
    //    $("#uu_05").addClass("control-error");
    //    $("#uu_05_c").append("<p class='form-error'>El campo está vacío</p>");
    //    errores += 1;
    //}

    if (abogado_email.length <= 0) {
        $("#uu_06").addClass("control-error");
        $("#uu_06_c").append("<p class='form-error'>El campo está vacío</p>");
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
    catalogo_actual.usuario = eu_lu.id;
    catalogo_actual.usuario_nombre = eu_lu.name;
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
