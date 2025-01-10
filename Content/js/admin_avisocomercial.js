var muid = "";

$(document).ready(function () {
    $("#doc00c").hide();
    $("#tabla02 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='ModalDocumento();' id='btnDocumento'><i class='fa fa-plus'></i> Agregar documento</button>");

    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });


    $('#uu_03').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

});

var catalogo_actual = {
    id: 0,
    empresa: 0,
    nombre: "",
    tipo: 0,
    pais: 0,
    productos: "",
    activo: 0,
    orden: 0,
    usuario: "",
    usuario_nombre: "",
    empresa_nombre: "",
    tipo_nombre: "",
    pais_nombre: "",
    identificador: "",
    fecha_usoS: "",
    tipo_solicitud: 0,
    tipo_solicitud_nombre:""
}

function ModalNuevo() {
    catalogo_actual = {
        id: 0,
        empresa: 0,
        nombre: "",
        tipo: 0,
        pais: 0,
        productos: "",
        activo: 0,
        orden: 0,
        usuario: "",
        usuario_nombre: "",
        empresa_nombre: "",
        tipo_nombre: "",
        pais_nombre: "",
        identificador: "",
        fecha_usoS: "",
        tipo_solicitud: 0,
        tipo_solicitud_nombre:""
    };
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");
    $("#update01 .form-control").removeAttr("disabled");
    $("#update01 .modal-title").html("<span>Nuevo registro</span>");
    $("#eliminausuario").hide();

    $("#uu_04").val(catalogo_actual.empresa).trigger("change");
    $("#uu_05").val(catalogo_actual.pais).trigger("change");
    $("#uu_01").val(catalogo_actual.nombre);
    $("#uu_02").val(catalogo_actual.productos);
    $("#uu_03").datepicker("update", catalogo_actual.fecha_usoS);
    document.getElementById("uu_07_c").style.display = "none";
    document.getElementById("uu_08_c").style.display = "none";


    documentos = new Array();
    var dev_documentos = new DevExpress.data.DataSource(documentos);
    $("#tabla02").dxDataGrid({
        dataSource: dev_documentos,
    });
    $("#tabla02").dxDataGrid("getDataSource").reload();


    dzdocumentos.removeAllFiles(true);
    $("#dz-documentos .dz-message").text("Haz click aquí o arrastra aquí para cargar el documento").show();

    $("#update01").modal("show");
};

function Editar(id) {
    catalogo_actual = {
        id: id,
        empresa: 0,
        nombre: "",
        tipo: 0,
        pais: 0,
        productos: "",
        activo: 0,
        orden: 0,
        usuario: "",
        usuario_nombre: "",
        empresa_nombre: "",
        tipo_nombre: "",
        pais_nombre: "",
        identificador: "",
        fecha_usoS: "",
        tipo_solicitud: 0,
        tipo_solicitud_nombre:""
    };
    var sended_url = services_url + "SelectAvisoComercialById";
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

                $("#uu_04").val(catalogo_actual.empresa).trigger("change");
                $("#uu_05").val(catalogo_actual.pais).trigger("change");
                $("#uu_01").val(catalogo_actual.nombre);
                $("#uu_02").val(catalogo_actual.productos);
                $("#uu_03").datepicker("update", catalogo_actual.fecha_usoS);
                $("#uu_06").val(catalogo_actual.tipo).trigger("change");
                $("#uu_07").val(catalogo_actual.usuario_nombre);
                let date = new Date(catalogo_actual.fc)
                let day = `${(date.getDate())}`.padStart(2, '0');
                let month = `${(date.getMonth() + 1)}`.padStart(2, '0');
                let year = date.getFullYear();
                let hrs = date.getHours();
                let min = date.getMinutes();
                let seg = date.getSeconds();
                if (year > "1969") {
                    $("#uu_08").val(`${day}/${month}/${year}  ${hrs}:${min}:${seg}`);
                } else {
                    $("#uu_08").val('');
                }
                document.getElementById("uu_07_c").style.display = "block";
                document.getElementById("uu_08_c").style.display = "block";

                $("#eliminausuario").show();
                if (catalogo_actual.activo == 0) {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + catalogo_actual.activo + ")").text("Activar").addClass("btn-success").removeClass("btn-danger");
                } else {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + catalogo_actual.activo + ")").text("Inactivar").removeClass("btn-success").addClass("btn-danger");
                }

                documentos = catalogo_actual.anexos;
                var dev_documentos = new DevExpress.data.DataSource(documentos);
                $("#tabla02").dxDataGrid({
                    dataSource: dev_documentos,
                });
                $("#tabla02").dxDataGrid("getDataSource").reload();

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
        if (catalogo_actual.id == 0) {
            catalogo_actual.tipo_solicitud = 2;
            catalogo_actual.tipo_solicitud_nombre = "Aviso Comercial";
        }
        catalogo_actual.empresa = parseInt($("#uu_04 option:selected").val());
        catalogo_actual.empresa_nombre = $("#uu_04 option:selected").text();
        catalogo_actual.pais = parseInt($("#uu_05 option:selected").val());
        catalogo_actual.pais_nombre = $("#uu_05 option:selected").text();
        catalogo_actual.nombre = $("#uu_01").val();
        catalogo_actual.productos = $("#uu_02").val();
        catalogo_actual.fecha_usoS = $("#uu_03").val();
        catalogo_actual.usuario = eu_lu.id;
        catalogo_actual.usuario_nombre = eu_lu.name;
        catalogo_actual.tipo = parseInt($("#uu_06 option:selected").val());
        catalogo_actual.tipo_nombre = $("#uu_06 option:selected").text();

        var sended_url = services_url + "AddAvisoComercial";
        if (catalogo_actual.id > 0) {
            sended_url = services_url + "UpdateAvisoComercial";
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


                    dzdocumentos.processQueue();
                } else {
                    for (var i = 0; i < jsonResponse.errors.length; i++) {
                        $("#update01 .errores").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                    }
                }
            },
            failure: function (response) {
                $("#update01 .form-control").removeAttr("disabled");
            },
            error: function (response) {
                $("#update01 .form-control").removeAttr("disabled");
            }
        });
    }
}


function ValidaUpdate01() {
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");

    var empresa = $("#uu_04 option:selected").val();
    var pais = $("#uu_05 option:selected").val();
    var nombre = $("#uu_01").val();
    var productos = $("#uu_02").val();
    var tipo = $("#uu_06 option:selected").val();

    var errores = 0;
    var flag = false;

    if (empresa <= 0) {
        $("#uu_04").addClass("control-error");
        $("#uu_04_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }

    if (pais <= 0) {
        $("#uu_05").addClass("control-error");
        $("#uu_05_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }
    if (nombre.length <= 0) {
        $("#uu_01").addClass("control-error");
        $("#uu_01_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }
    if (productos.length <= 0) {
        $("#uu_02").addClass("control-error");
        $("#uu_02_c").append("<p class='form-error'>El campo está vacio</p>");
        errores += 1;
    }
    if (tipo <= 0) {
        $("#uu_06").addClass("control-error");
        $("#uu_06_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }

    if (errores > 0) {
        flag = false;
        $(".nav-link[href='#tab01']").click();
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
    var sended_url = services_url + "UpdateAvisoComercialActivo";
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
                    estatus_activo = 1;
                } else {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + estatus_activo + ")").text("Activar").addClass("btn-success").removeClass("btn-danger");
                    estatus_activo = 0;
                }

                $("#confirmaEliminar01").modal("hide");
            } else {
                //
                $("#confirmaEliminar01 .modal-body .form-group").append("<p class='text-danger'>No se ha podido actualizar. Intentalo más tarde.</p>")

            }
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    });
}
//

Dropzone.autoDiscover = false;
var dp1 = false;
var dzdocumentos = new Dropzone("#dz-documentos", {
    url: hosturl + "api/Archivos/UploadArchivoV2",
    maxFiles: 10,
    autoProcessQueue: false,
    parallelUploads: 10,
    maxFilesize: 30,
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
            formData.append("objeto", catalogo_actual.id);
            formData.append("usuario", eu_lu.id);
            formData.append("tipo", "Anexo");
            formData.append("modelo", tipo);
        });

        this.on("success", function (file, responseText) {
            var jsonResponse = responseText;
            if (jsonResponse.flag != false) {
                try {
                } catch (ex) {
                }
            }
        });

        this.on("error", function (file, responseText) {
            //dzdocumentos.removeFile(file);
        });


        this.on("addedfile", function (file, responseText) {
            $("#dz-documentos .dz-preview").remove();
            documentos.push({
                file_nombre: file.name,
                nombre: file.name,
                activo: 1,
                id: 0,
                cargado: 0,
                uuid: file.upload.uuid
            });
            var dev_documentos = new DevExpress.data.DataSource(documentos);
            $("#tabla02").dxDataGrid({
                dataSource: dev_documentos,
            });
            $("#tabla02").dxDataGrid("getDataSource").reload();

            $("#dz-documentos .dz-message").text("Haz click aquí o arrastra aquí para cargar el documento").show();

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


function SubmitArchivos() {
}

var documentos = new Array();

function ModalDocumento() {
    dzdocumentos.hiddenFileInput.click();
}

function RemoverDropzone(uuid) {
    if (dzdocumentos.files.length > 0) {
        for (var i = 0; dzdocumentos.files.length; i++) {
            if (dzdocumentos.files[i].upload.uuid == uuid) {
                dzdocumentos.removeFile(dzdocumentos.files[i]);

                var search = searchArrayByKeyProp(uuid, "uuid", documentos);
                if (search != null) {
                    removeFromArray(search.idx, documentos);

                    var dev_documentos = new DevExpress.data.DataSource(documentos);
                    $("#tabla02").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla02").dxDataGrid("getDataSource").reload();
                }
                break;
            }
        }
    }
}

function Enviar(id,tipo) {
    var propiedad = 0;
    if (parseInt(tipo) > 0) propiedad = parseInt(tipo);
    if (propiedad > 0) {
        window.location = hosturl+'PI/RegistroMarca?propiedad=' + propiedad + '&solicitud=' + id;
    } else {
        alert("Error al direccionar, intente nuevamente");
    }
}