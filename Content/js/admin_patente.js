var muid = "";

$(document).ready(function () {
    $("#doc00c").hide();
    $("#doc01c").hide();
    $("#tabla02 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='ModalDibujo();' id='btnDocumento'><i class='fa fa-plus'></i> Agregar documento</button>");
    $("#tabla03 .dx-toolbar-after").prepend("<button class='btn btn-info' onclick='ModalExplicacion();' id='btnDocumento'><i class='fa fa-plus'></i> Agregar documento</button>");
    $('select.select2:not(.normal)').each(function () {
        $(this).select2({
            dropdownParent: $(this).parent().parent()
        });
    });

    $(".select2").select2({
        placeholder: "Seleccionar",
        allowClear: false
    });


    $('#uu_07').datepicker({
        orientation: "bottom left",
        todayHighlight: true,
        format: 'dd/mm/yyyy'
    });

});

var catalogo_actual = {
    id: 0,
    empresa: 0,
    nombre_patente: "",
    nombre: "",
    prioridad: 0,
    pais: 0,
    explicacion: "",
    activo: 0,
    orden: 0,
    usuario: "",
    usuario_nombre: "",
    empresa_nombre: "",
    prioridad_nombre: "",
    pais_nombre: "",
    identificador: "",
    nacionalidad: "",
    domicilio: "",
    rfc: "",
    curp: "",
    lugar_nacimiento: "",
    fecha_nacimientoS: "",
    tipo_solicitud: 0,
    tipo_solicitud_nombre: ""
}
function ModalNuevo() {
    catalogo_actual = {
        id: 0,
        empresa: 0,
        nombre_patente: "",
        nombre: "",
        prioridad: 0,
        pais: 0,
        explicacion: "",
        activo: 0,
        orden: 0,
        usuario: "",
        usuario_nombre: "",
        empresa_nombre: "",
        prioridad_nombre: "",
        pais_nombre: "",
        identificador: "",
        nacionalidad: "",
        domicilio: "",
        rfc: "",
        curp: "",
        lugar_nacimiento: "",
        fecha_nacimientoS: "",
        tipo_solicitud: 0,
        tipo_solicitud_nombre: ""
    };
    $("#update01 .form-error").remove();
    $("#update01 .form-control").removeClass("control-error");
    $("#update01 .form-control").removeAttr("disabled");
    $("#update01 .modal-title").html("<span>Nuevo registro</span>");
    $("#eliminausuario").hide();

    $("#uu_04").val(catalogo_actual.empresa).trigger("change");
    $("#uu_05").val(catalogo_actual.pais).trigger("change");
    $("#uu_03").val(catalogo_actual.explicacion);
    $("#uu_01").val(catalogo_actual.nombre_patente);
    $("#uu_02").val(catalogo_actual.prioridad).trigger("change");

    $("#uu_06").val(catalogo_actual.nombre);
    $("#uu_07").datepicker("update", catalogo_actual.fecha_nacimientoS);
    $("#uu_08").val(catalogo_actual.lugar_nacimiento);
    $("#uu_09").val(catalogo_actual.nacionalidad);
    $("#uu_10").val(catalogo_actual.domicilio);
    $("#uu_11").val(catalogo_actual.rfc);
    $("#uu_12").val(catalogo_actual.curp);
    document.getElementById("uu_13_c").style.display = "none";
    document.getElementById("uu_14_c").style.display = "none";


    documentos01 = new Array();
    var dev_documentos01 = new DevExpress.data.DataSource(documentos01);
    $("#tabla02").dxDataGrid({
        dataSource: dev_documentos01,
    });
    $("#tabla02").dxDataGrid("getDataSource").reload();
    dzdocumentos01.removeAllFiles(true);
    $("#dz-documentos01 .dz-message").text("Haz click aquí o arrastra aquí para cargar el documento").show();

    documentos02 = new Array();
    var dev_documentos02 = new DevExpress.data.DataSource(documentos02);
    $("#tabla03").dxDataGrid({
        dataSource: dev_documentos02,
    });
    $("#tabla03").dxDataGrid("getDataSource").reload();
    dzdocumentos02.removeAllFiles(true);
    $("#dz-documentos02 .dz-message").text("Haz click aquí o arrastra aquí para cargar el documento").show();



    $("#update01").modal("show");

};

function Editar(id) {
    catalogo_actual = {
        id: id,
        empresa: 0,
        nombre_patente: "",
        nombre: "",
        prioridad: 0,
        pais: 0,
        explicacion: "",
        activo: 0,
        orden: 0,
        usuario: "",
        usuario_nombre: "",
        empresa_nombre: "",
        prioridad_nombre: "",
        pais_nombre: "",
        identificador: "",
        nacionalidad: "",
        domicilio: "",
        rfc: "",
        curp: "",
        lugar_nacimiento: "",
        fecha_nacimientoS: "",
        tipo_solicitud: 0,
        tipo_solicitud_nombre: ""
    };
    var sended_url = services_url + "SelectPatenteById";
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
                $("#uu_03").val(catalogo_actual.explicacion);
                $("#uu_01").val(catalogo_actual.nombre_patente);
                $("#uu_02").val(catalogo_actual.prioridad).trigger("change");

                $("#uu_06").val(catalogo_actual.nombre);
                $("#uu_07").datepicker("update", catalogo_actual.fecha_nacimientoS);
                $("#uu_08").val(catalogo_actual.lugar_nacimiento);
                $("#uu_09").val(catalogo_actual.nacionalidad);
                $("#uu_10").val(catalogo_actual.domicilio);
                $("#uu_11").val(catalogo_actual.rfc);
                $("#uu_12").val(catalogo_actual.curp);
                $("#uu_13").val(catalogo_actual.usuario_nombre);
                let date = new Date(catalogo_actual.fc)
                let day = `${(date.getDate())}`.padStart(2, '0');
                let month = `${(date.getMonth() + 1)}`.padStart(2, '0');
                let year = date.getFullYear();
                let hrs = date.getHours();
                let min = date.getMinutes();
                let seg = date.getSeconds();
                if (year > "1969") {
                    $("#uu_14").val(`${day}/${month}/${year}  ${hrs}:${min}:${seg}`);
                } else {
                    $("#uu_14").val('');
                }
                document.getElementById("uu_13_c").style.display = "block";
                document.getElementById("uu_14_c").style.display = "block";

                $("#eliminausuario").show();
                if (catalogo_actual.activo == 0) {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + catalogo_actual.activo + ")").text("Activar").addClass("btn-success").removeClass("btn-danger");
                } else {
                    $("#eliminausuario").attr("onclick", "eliminar01(" + catalogo_actual.id + ", " + catalogo_actual.activo + ")").text("Inactivar").removeClass("btn-success").addClass("btn-danger");
                }

                documentos01 = catalogo_actual.dibujo;
                var dev_documentos01 = new DevExpress.data.DataSource(documentos01);
                $("#tabla02").dxDataGrid({
                    dataSource: dev_documentos01,
                });
                $("#tabla02").dxDataGrid("getDataSource").reload();


                documentos02 = catalogo_actual._explicacion;
                var dev_documentos02 = new DevExpress.data.DataSource(documentos02);
                $("#tabla03").dxDataGrid({
                    dataSource: dev_documentos02,
                });
                $("#tabla03").dxDataGrid("getDataSource").reload();

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
            catalogo_actual.tipo_solicitud = 3;
            catalogo_actual.tipo_solicitud_nombre = "Patente";
        }
        catalogo_actual.empresa = parseInt($("#uu_04 option:selected").val());
        catalogo_actual.empresa_nombre = $("#uu_04 option:selected").text();
        catalogo_actual.pais = parseInt($("#uu_05 option:selected").val());
        catalogo_actual.pais_nombre = $("#uu_05 option:selected").text();
        catalogo_actual.prioridad = parseInt($("#uu_02 option:selected").val());
        catalogo_actual.prioridad_nombre = $("#uu_02 option:selected").text();
        catalogo_actual.nombre_patente = $("#uu_01").val();
        catalogo_actual.explicacion = $("#uu_03").val();
        catalogo_actual.nombre = $("#uu_06").val();
        catalogo_actual.fecha_nacimientoS = $("#uu_07").val();
        catalogo_actual.lugar_nacimiento = $("#uu_08").val();
        catalogo_actual.nacionalidad = $("#uu_09").val();
        catalogo_actual.domicilio = $("#uu_10").val();
        catalogo_actual.rfc = $("#uu_11").val();
        catalogo_actual.curp = $("#uu_12").val();
        catalogo_actual.usuario = eu_lu.id;
        catalogo_actual.usuario_nombre = eu_lu.name;
        var sended_url = services_url + "AddPatente";
        if (catalogo_actual.id > 0) {
            sended_url = services_url + "UpdatePatente";
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
                    dzdocumentos01.processQueue();
                    dzdocumentos02.processQueue();
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

    var empresa = $("#uu_04 option:selected").val();
    var pais = $("#uu_05 option:selected").val();
    var prioridad = $("#uu_02 option:selected").val();
    var nombre_patente = $("#uu_01").val();
    var explicacion = $("#uu_03").val();
    var nombre = $("#uu_06").val();
    var fecha_nacimiento = $("#uu_07").val();
    var lugar_nacimiento = $("#uu_08").val();
    var nacionalidad = $("#uu_09").val();
    var domicilio = $("#uu_10").val();
    var rfc = $("#uu_11").val();
    var curp = $("#uu_12").val();

    var tab = '#tab01';


    var errores = 0;
    var flag = false;


    if (documentos02.length < 1) {
        errores += 1;
        tab = '#tab04';
    }

    if (documentos01.length < 1) {
        errores += 1;
        tab = '#tab02';
    }

    if (prioridad <= 0) {
        $("#uu_02").addClass("control-error");
        $("#uu_02_c").append("<p class='form-error'>Selecciona una opción válida</p>");
        errores += 1;
    }
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
    /*if (explicacion.length <= 0) {
        $("#uu_03").addClass("control-error");
        $("#uu_03_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }*/
    if (nombre.length <= 0) {
        $("#uu_06").addClass("control-error");
        $("#uu_06_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }
    if (nombre_patente.length <= 0) {
        $("#uu_01").addClass("control-error");
        $("#uu_01_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
    }


    if (fecha_nacimiento.length <= 0) {
        $("#uu_07").addClass("control-error");
        $("#uu_07_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }
    if (lugar_nacimiento.length <= 0) {
        $("#uu_08").addClass("control-error");
        $("#uu_08_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }
    if (nacionalidad.length <= 0) {
        $("#uu_09").addClass("control-error");
        $("#uu_09_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }
    if (domicilio.length <= 0) {
        $("#uu_10").addClass("control-error");
        $("#uu_10_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }
    if (rfc.length <= 0) {
        $("#uu_11").addClass("control-error");
        $("#uu_11_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }
    if (curp.length <= 0) {
        $("#uu_12").addClass("control-error");
        $("#uu_12_c").append("<p class='form-error'>El campo está vacío</p>");
        errores += 1;
        tab = '#tab03';
    }

    if (errores > 0) {
        flag = false;
        $(".nav-link[href='" + tab + "']").click();
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
    var sended_url = services_url + "UpdatePatenteActivo";
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


//
Dropzone.autoDiscover = false;
var dp1 = false;
var dzdocumentos01 = new Dropzone("#dz-documentos01", {
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
            formData.append("tipo", "Dibujo");
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
            $("#dz-documentos01 .dz-preview").remove();
            documentos01.push({
                file_nombre: file.name,
                nombre: file.name,
                activo: 1,
                id: 0,
                cargado: 0,
                uuid: file.upload.uuid
            });
            var dev_documentos01 = new DevExpress.data.DataSource(documentos01);
            $("#tabla02").dxDataGrid({
                dataSource: dev_documentos01,
            });
            $("#tabla02").dxDataGrid("getDataSource").reload();

            $("#dz-documentos01 .dz-message").text("Haz click aquí o arrastra aquí para cargar el documento").show();

        });

        this.on("queuecomplete", function (file, responseText) {
        });
    }
});

Dropzone.autoDiscover = false;
var dzdocumentos02 = new Dropzone("#dz-documentos02", {
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
            formData.append("tipo", "Explicación");
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
            $("#dz-documentos01 .dz-preview").remove();
            documentos02.push({
                file_nombre: file.name,
                nombre: file.name,
                activo: 1,
                id: 0,
                cargado: 0,
                uuid: file.upload.uuid
            });
            var dev_documentos02 = new DevExpress.data.DataSource(documentos02);
            $("#tabla03").dxDataGrid({
                dataSource: dev_documentos02,
            });
            $("#tabla03").dxDataGrid("getDataSource").reload();

            $("#dz-documentos01 .dz-message").text("Haz click aquí o arrastra aquí para cargar el documento").show();

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
var documentos01 = new Array();
var documentos02 = new Array();

function ModalDibujo() {
    dzdocumentos01.hiddenFileInput.click();
}
function ModalExplicacion() {
    dzdocumentos02.hiddenFileInput.click();
}

function RemoverDibujo(uuid) {
    if (dzdocumentos01.files.length > 0) {
        for (var i = 0; dzdocumentos01.files.length; i++) {
            if (dzdocumentos01.files[i].upload.uuid == uuid) {
                dzdocumentos01.removeFile(dzdocumentos01.files[i]);

                var search = searchArrayByKeyProp(uuid, "uuid", documentos01)
                if (search != null) {
                    removeFromArray(search.idx, documentos01);

                    var dev_documentos = new DevExpress.data.DataSource(documentos01);
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

function RemoverExplicacion(uuid) {
    if (dzdocumentos02.files.length > 0) {
        for (var i = 0; dzdocumentos02.files.length; i++) {
            if (dzdocumentos02.files[i].upload.uuid == uuid) {
                dzdocumentos02.removeFile(dzdocumentos02.files[i]);

                var search = searchArrayByKeyProp(uuid, "uuid", documentos02);
                if (search != null) {
                    removeFromArray(search.idx, documentos02);

                    var dev_documentos = new DevExpress.data.DataSource(documentos02);
                    $("#tabla03").dxDataGrid({
                        dataSource: dev_documentos,
                    });
                    $("#tabla03").dxDataGrid("getDataSource").reload();
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