var obj = {
    id: "",
    descripcion: "",
    activo: 1
};
function Nuevo() {
    obj = {
        id: "",
        descripcion: "",
        activo: 1
    };
    $("#elimina_obj").hide();
    $("#update01 h4.modal-title").text("Nuevo registro");
    $("#update01 .form-control").val("");
    $("#update01").modal("show");
}
function Editar(id) {
    obj.id = id;
    $("#elimina_obj").show();
    var sended_url = services_url + "SelectRolById";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                obj = jsonResponse.content[0];
                $("#update01 .form-error").remove();
                $("#update01 .form-control").removeClass("control-error");
                $("#update01 .form-control").removeAttr("disabled");
                $("#update01 .modal-title").html("<span>Editar registro</span>");

                $("#uu_01").val(obj.descripcion);

                if (obj.activo == 0) {
                    $("#elimina_obj").attr("onclick", "eliminar01('" + obj.id + "', " + obj.activo + ")").text("Activar registro en catalogo").addClass("btn-success").removeClass("btn-danger");
                } else {
                    $("#elimina_obj").attr("onclick", "eliminar01('" + obj.id + "', " + obj.activo + ")").text("Inactivar registro en catalogo").removeClass("btn-success").addClass("btn-danger");
                }

                $("#update01").modal("show");
            } else {
                console.log("success");
                console.log(jsonResponse.description);
                //$("#btn-confirma").removeAttr("disabled");
            }
        },
        failure: function (response) {
            //$("#update01 .form-control").removeAttr("disabled");
            console.log("failure");
            console.log(response);
            //$("#btn-confirma").removeAttr("disabled");
        },
        error: function (response) {
            //$("#update01 .form-control").removeAttr("disabled");
            console.log("error");
            console.log(response);
            //$("#btn-confirma").removeAttr("disabled");
        }
    });
}
function ValidaUpdate01() {
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");

    var descripcion = $("#uu_01").val();
    var errores = 0;
    var flag = false;

    if (descripcion.length <= 0) {
        $("#uu_01").addClass("control-error");
        $("#uu_01_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}
function Confirma01() {
    if (ValidaUpdate01() != false) {
        var descripcion = $("#uu_01").val();

        obj.descripcion = descripcion;
        $("#update01 .form-control").attr("disabled", "disabled");

        var sended_url = services_url + "ActualizarRol";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#update01 .form-control").removeAttr("disabled");
                $("#update01 .fa-save").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    $("#update01 .form-control").val("");
                    obj.id = jsonResponse.data_int;

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
                $("#update01 .fa-save").removeAttr("disabled");
            },
            error: function (response) {
                $("#update01 .form-control").removeAttr("disabled");
                console.log("error");
                console.log(response);
                $("#update01 .fa-save").removeAttr("disabled");
            }
        });
    }
}

function eliminar01(id, val) {
    obj.id = id;
    obj.activo = val;
    if (val > 0) {
        $("#confirmaEliminar01 .modal-body .form-group p").text("Se necesita confirmación para desactivar los datos de este registro");
    } else {

        $("#confirmaEliminar01 .modal-body .form-group p").text("Se necesita confirmación para activar los datos de este registro");
    }
    $("#confirmaEliminar01").modal("show");
}

function ConfirmaEliminar01() {
    var sended_url = services_url + "ActualizarRolActivo";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                if (obj.activo == 0) {
                    obj.activo = 1;
                } else {
                    obj.activo = 0;
                }

                if (obj.activo == 0) {
                    $("#elimina_obj").attr("onclick", "eliminar01('" + obj.id + "', " + obj.activo + ")").text("Activar registro en catalogo").addClass("btn-success").removeClass("btn-danger");
                } else {
                    $("#elimina_obj").attr("onclick", "eliminar01('" + obj.id + "', " + obj.activo + ")").text("Inactivar registro en catalogo").removeClass("btn-success").addClass("btn-danger");
                }
                $("#tabla01").dxDataGrid("getDataSource").reload();
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