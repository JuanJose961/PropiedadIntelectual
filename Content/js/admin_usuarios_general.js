var muid = "";
var usuario_actual = {
    id: "",
    name: "",
    email: "",
    phone: "",
    usuariolg: "",
    usuariolg_name: "",
    cellphone: "",
    role: "USUARIO",
    roles: {
        id: "",
        descripcion: "USUARIO"
    },
    negocio: {
        id: 0,
        descripcion: ""
    },
    puesto: "USUARIO",
    imagen: hosturl + "images/default-image.png",
    password: ""
};

function ModalUsuario() {
    $("#eliminausuario").hide();
    usuario_actual = {
        id: "",
        name: "",
        email: "",
        phone: "",
        cellphone: "",
        role: "USUARIO",
        usuariolg: "",
        usuariolg_name: "",
        roles: {
            id: "",
            descripcion: "NA"
        },
        negocio: {
            id: 0,
            descripcion: ""
        },
        puesto: "USUARIO INTERNO",
        imagen: hosturl + "images/default-image.png",
        password: ""
    };
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");
    $("#update01 .form-control").removeAttr("disabled");
    $("#update01 .modal-title").html("<span>Nuevo usuario</span>");
    $("#uu_pass").hide();
    $("#uu_02_c").show();
    $("#uu_01").val(usuario_actual.name);
    $("#uu_02").val(usuario_actual.email);
    /*$("#uu_03").val(usuario_actual.phone);
    $("#uu_04").val(usuario_actual.cellphone);*/
    $("#accesos").empty();
    $("#uu_05").val(usuario_actual.roles.descripcion).trigger("change");
    //$("#uu_06").val(usuario_actual.negocio.id).trigger("change");
    for (var i = 1; i <= 200; i++) {
        $("#ng_" + i).prop("checked", false);
    }
    $("#update01").modal("show");
}

function Editar(id) {
    $("#eliminausuario").show();
    var sended_url = services_url + "SelectUsuarioByIdV2";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ id: id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                usuario_actual = jsonResponse.content[0];
                accesos = jsonResponse.content[1];
                negocios = jsonResponse.content[2];
                $("#update01 .form-error").remove();
                $("#update01 .form-control").removeClass("control-error");
                $("#update01 .form-control").removeAttr("disabled");
                $("#update01 .modal-title").html("<span>Editar usuario</span>");
                $("#uu_pass").hide();
                $("#uu_02_c").hide();
                $("#uu_01").val(usuario_actual.name);
                $("#uu_02").val(usuario_actual.email);
                /*$("#uu_03").val(usuario_actual.phone);
                $("#uu_04").val(usuario_actual.cellphone);*/
                $("#uu_05").val(usuario_actual.roles.descripcion).trigger("change");
                $("#uu_06").val(usuario_actual.negocio.id).trigger("change");
                //$("#uu_06").val(usuario_actual.negocio.id).trigger("change");


                if (usuario_actual.activo == false) {
                    $("#eliminausuario").attr("onclick", "eliminar01('" + usuario_actual.id + "', " + usuario_actual.activo + ")").text("Activar usuario").addClass("btn-success").removeClass("btn-danger");
                } else {
                    $("#eliminausuario").attr("onclick", "eliminar01('" + usuario_actual.id + "', " + usuario_actual.activo + ")").text("Inactivar usuario").removeClass("btn-success").addClass("btn-danger");
                }

                RedibujarAccesos();
                RedibujarNegocios();

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

function Confirma01() {
    if (ValidaUpdate01() != false) {
        var nombres = $("#uu_01").val();
        var correo = $("#uu_02").val();
        var telefono = "00000000000";
        var celular = "00000000000";
        var pass1 = $("#uu_07").val();
        var pass2 = $("#uu_08").val();
        var rol = $("#uu_05").val();
        var negocio = parseInt($("#uu_06 option:selected").val());
        var puesto = "USUARIO";

        usuario_actual.username = correo;
        usuario_actual.email = correo;
        usuario_actual.name = nombres;
        usuario_actual.phone = telefono;
        usuario_actual.cellphone = celular;
        usuario_actual.password = "Temporal12%";//pass1;
        usuario_actual.role = rol;
        usuario_actual.puesto = puesto;
        usuario_actual.terminos = pass1;
        usuario_actual.negocio.id = negocio;
        usuario_actual.usuariolg = eu_lu.id;
        usuario_actual.usuariolg_name = eu_lu.name;
        console.log(usuario_actual);

        var sended_url = services_url + "AddUserV2";

        $("#update01 .form-control").attr("disabled", "disabled");

        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({
                usuario: usuario_actual,
                accesos: accesos,
                negocios: negocios
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#update01 .form-control").removeAttr("disabled");
                var jsonResponse = response;
                if (jsonResponse.flag != false) {
                    $("#update01 .form-control").val("");
                    usuario_actual.id = jsonResponse.data_string;
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
    var correo = $("#uu_02").val();
    /*var telefono = $("#uu_03").val();
    var celular = $("#uu_04").val();*/
    var rol = $("#uu_05 option:selected").val();
    var negocio = $("#uu_06 option:selected").val();
    var pass1 = $("#uu_07").val();
    var pass2 = $("#uu_08").val();
    var errores = 0;
    var flag = false;

    if (nombres.length <= 0) {
        $("#uu_01").addClass("control-error");
        $("#uu_01_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }
    if (rol == "NA") {
        $("#uu_05").addClass("control-error");
        $("#uu_05_c").append("<p class='form-error'>Selecciona un rol</p>");
        errores += 1;
    } else if (rol == "Usuario Negocio" && negocio <= 0) {
        $("#uu_06").addClass("control-error");
        $("#uu_06_c").append("<p class='form-error'>Selecciona un negocio</p>");
        errores += 1;
    }

    /*if (telefono.length <= 0) {
        $("#uu_03").addClass("control-error");
        $("#uu_03_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (celular.length <= 0) {
        $("#uu_04").addClass("control-error");
        $("#uu_04_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }*/
    if (usuario_actual.id == "") {

        if (correo.length <= 0) {
            $("#uu_02").addClass("control-error");
            $("#uu_02_c").append("<p class='form-error'>El campo está vacío</p>");
            errores += 1;
        } else if (ValidateEmail(correo) != true) {
            $("#uu_02").addClass("control-error");
            $("#uu_02_c").append("<p class='form-error'>Ingresa un correo electrónico válido</p>");
            errores += 1;
        }

        /*if (pass1.length <= 0) {
            $("#uu_07").addClass("control-error");
            $("#uu_07_c").append("<p class='form-error'>El campo está vacío</p>");
            errores += 1;
        } else {
            if (pass1 != pass2) {
                $("#uu_07").addClass("control-error");
                $("#uu_08").addClass("control-error");
                $("#uu_08_c").append("<p class='form-error'>Las contraseñas no coinciden</p>");
                errores += 1;
            }
        }*/
    }
    if (errores > 0) {
        flag = false;
    } else {
        flag = true;
    }

    return flag;
}

function cambiarPassword(id) {
    usuario_actual.id = id;
    $("#cambiarPass .form-control").removeAttr("disabled");
    $("#cambiarPass .form-control").val("");
    $(".form-error").remove();
    $("#cambiarPass .form-control").removeClass("control-error");
    $("#cambiarPass").modal("show");
}
function CambiarPass() {
    if (ValidarPass() != false) {
        $("#cambiarPass .form-control").attr("disabled", "disabled");

        var p1 = $("#cp_00").val().trim();
        var p2 = $("#cp_01").val().trim();

        var sended_data = {
            id: usuario_actual.id,
            password: p1
        };
        var sended_url = services_url + "CambiarPassword";

        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify(sended_data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                //console.log(response);
                $("#cambiarPass .form-control").removeAttr("disabled");
                var jsonResponse = response;//JSON.parse(response.d);
                console.log(jsonResponse);
                if (jsonResponse.flag != false) {
                    setTimeout(function () {
                        $("#cambiarPass").modal("hide");
                    }, 1000);
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#cp_01_c").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
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
}
function ValidarPass() {
    $(".form-error").remove();
    $("#cambiarPass .form-control").removeClass("control-error");
    var p1 = $("#cp_00").val().trim();
    var p2 = $("#cp_01").val().trim();
    var flag = false;
    var errores = 0;
    //
    if (p1.length <= 0) {
        $("#cp_00").addClass("control-error");
        $("#cp_00_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (p2.length <= 0) {
        $("#cp_01").addClass("control-error");
        $("#cp_01_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }

    if (p1 != p2) {
        $("#cp_00").addClass("control-error");
        $("#cp_00_c").append("<p class='form-error'>Las contraseñas no coinciden</p>");
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
    usuario_actual.id = id;
    if (val > 0) {
        $("#confirmaEliminar01 .modal-body .form-group p").text("Se necesita confirmación para desactivar los datos de este registro");
    } else {

        $("#confirmaEliminar01 .modal-body .form-group p").text("Se necesita confirmación para activar los datos de este registro");
    }
    $("#confirmaEliminar01").modal("show");
}

function ConfirmaEliminar01() {
    var sended_url = services_url + "UpdateUsuarioActivo";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ id: usuario_actual.id, usuariolg: eu_lu.id, usuariolg_name: eu_lu.name }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
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
var accesos = new Array();
$(document).on("change", "#uu_05", function (event) {
    $("#accesos").empty();
    var val = $("#uu_05 option:selected").attr("rid");
    if (usuario_actual.id == "") {
        var sended_url = services_url + "SelectAccesoVistaByRol";
        $.ajax({
            type: "POST",
            url: sended_url,
            data: JSON.stringify({ id: val }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var jsonResponse = response;
                if (jsonResponse.flag != false) {

                    console.log("accesovistas");
                    console.log(jsonResponse.content[0]);
                    accesos = jsonResponse.content[0];
                    RedibujarAccesos();
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
    /*if (val == "Usuario Negocio") {
        $("#uu_06_c").show();
        $("#uu_06").val(0).trigger("change");
    } else {
        $("#uu_06_c").hide();
        $("#uu_06").val(0).trigger("change");
    }*/
});

function RedibujarAccesos() {
    $("#accesos").empty();
    var modulos = new Array();
    for (var i = 0; i < accesos.length; i++) {
        if (!modulos.includes(accesos[i].modulo) && accesos[i].acceso==1) {
            modulos.push(accesos[i].modulo);
        }
    }

    console.log(modulos);
    for (var i = 0; i < modulos.length; i++) {
        var arr = accesos.filter(item => item.modulo == modulos[i]);
        var opciones = "";
        for (var j = 0; j < arr.length; j++) {
            var checked = "";
            if (arr[j].acceso == 1) {
                checked = "checked";
            }
            var opcion = '<div class="col-md-6">' +
            '<div class="form-group">' +
            '<div class="custom-control custom-checkbox">' +
            '<input type="checkbox" class="custom-control-input cb_acceso_vista" id="cb_' + arr[j].pagina + '" avid="' + arr[j].pagina + '" ' + checked + '>' +
            '<label class="custom-control-label" for="cb_' + arr[j].pagina + '">' + arr[j].descripcion + '</label>' +
            '</div>' +
            '</div>' +
            '</div>';
            opciones += opcion;
        }
        var html = '<div class="row">' +
            '<div class="col-md-12">' +
            '<h6 style="font-weight: 500;">' + modulos[i] + '</h6>' +
            '</div>' +
            opciones +
            '</div>';
        $("#accesos").append(html);
    }
}

$(document).on("change", ".cb_acceso_vista", function (event) {
    var pagina = parseInt($(this).attr("avid"));
    var acceso = 0;
    if ($(this).is(":checked")) {
        acceso = 1;
    }
    for (var i = 0; i < accesos.length; i++) {
        if (accesos[i].pagina == pagina) {
            accesos[i].acceso = acceso;
            break;
        }
    }
    console.log(accesos);
});

//negocios
var negocios = new Array();

function RedibujarNegocios() {
    $(".cb_acceso_negocio").prop("checked", false);
    var activos = negocios.filter(item => item.activo == 1);
    console.log(activos);
    for (var i = 0; i < activos.length; i++) {
        $("#ng_" + activos[i].negocio).prop("checked", true);
    }
}

$(document).on("change", ".cb_acceso_negocio", function (event) {
    var negocio = parseInt($(this).attr("avid"));
    var acceso = 0;
    if ($(this).is(":checked")) {
        acceso = 1;
    }
    for (var i = 0; i < accesos.length; i++) {
        if (negocios[i].negocio == negocio) {
            negocios[i].activo = acceso;
            break;
        }
    }
    console.log(negocios);
});