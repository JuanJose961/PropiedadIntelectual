//var hosturl = "https://proveedor.gis.com.mx/pr/";
const currencyFormatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2
});
function getFromArrayByValue(value, nameKey, myArray) {
    var arr = new Array();
    for (var i = 0; i < myArray.length; i++) {
        if (myArray[i][nameKey] === value) {
            var tmpobj = myArray[i];
            tmpobj.idx = i;
            arr.push(tmpobj);
        }
    }
    return arr;
}

function searchArrayByKeyProp(value, nameKey, myArray) {
    var tmp = new Array();
    console.log(value, nameKey, myArray);
    for (var i = 0; i < myArray.length; i++) {
        if (myArray[i][nameKey] === value) {
            tmp = myArray[i];
            tmp.idx = i;
            return tmp;
        }
    }
}

function isInArray(value, array) {
    return array.indexOf(value) > -1;
}
function removeFromArray(index, arr) {
    arr.splice(index, 1);
}

$(document).on("keypress", 'input[type="number"]', function (event) {
    //console.log("event.keyCode: ", event.keyCode);
    if (event.keyCode == 69 || event.keyCode == 101) {
        event.preventDefault();
    }
});

function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true)
    }
    //alert("You have entered an invalid email address!")
    return (false)
}

function CheckIfOptionExists(parent, value, text, defaultSelected, selected) {
    if ($(parent).find("option[value='" + value + "']").length) {
        $(parent).val(value).trigger("change");
    } else {
        var newOption = new Option(text, value, defaultSelected, selected);
        $(parent).append(newOption).trigger("change");
    }
}

function Exportar(e, nombre, flag, id) {
    var workbook = new ExcelJS.Workbook();
    var worksheet = workbook.addWorksheet('Main sheet');
    DevExpress.excelExporter.exportDataGrid({
        worksheet: worksheet,
        component: e.component,
        customizeCell: function (options) {
            var excelCell = options;
            excelCell.font = { name: 'Arial', size: 12 };
            excelCell.alignment = { horizontal: 'left' };
        }
    }).then(function () {
        workbook.xlsx.writeBuffer().then(function (buffer) {
            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), nombre.replace(" ", "") + '.xlsx');
        });
        InsReporteActividad(flag, id)
    });
    e.cancel = true;
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}


function InsReporteActividad(tipo, id) {
    var sended_url = services_url + "InsReporteActividad";
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ data_int: id, data_string: tipo, data_string2: eu_lu.id }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            RecargaHistorialActividades();
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    });
}
// Write your Javascript code.asdasasdasdda
/*

function validatePhone(val, tipo) {
    var flag = false;
    switch (tipo) {
        case 0:
            if (val.length == 10) {
                flag = true;
            }
            break;
        case 1:
            if (val.length == 8) {
                flag = true;
            }
            break;
    }
    return flag;
}

function getFromArrayByValue(value, nameKey, myArray) {
    var arr = new Array();
    for (var i = 0; i < myArray.length; i++) {
        if (myArray[i][nameKey] === value) {
            var tmpobj = myArray[i];
            tmpobj.idx = i;
            arr.push(tmpobj);
        }
    }
    return arr;
}

function searchArrayByKeyProp(value, nameKey, myArray) {
    var tmp = new Array();
    for (var i = 0; i < myArray.length; i++) {
        if (myArray[i][nameKey] === value) {
            tmp = myArray[i];
            tmp.idx = i;
            return tmp;
        }
    }
}



$(document).ready(function (event) {
    $('.modal').on('shown', function (e) {
        // var target = $(e.target).attr("href"); // activated tab
        // alert (target);
        console.log("recargando?")
        $($.fn.dataTable.tables(true)).css('width', '100%');
        $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
    });
});


function modalErrorText(modal, arr) {
    console.log(arr);
    $("#" + modal + " .modal-error-c").empty();
    if (arr.length > 0) {
        $("#" + modal + " .modal-error-c").show();
        for (var i = 0; i < arr.length; i++) {
            $("#" + modal + " .modal-error-c").append("<p><i class='fa fa-exclamation'></i>" + arr[i].toUpperCase() + "</p>");
        }
        $("#" + modal + " .modal-error-c").focus();
    } else {
        $("#" + modal + " .modal-error-c").hide();
    }
}

function mainModalError(arr) {
    $("#mainModalError .modal-body").empty();
    if (arr.length > 0) {
        for (var i = 0; i < arr.length; i++) {
            $("#mainModalError .modal-body").append("<p><i class='fa fa-exclamation' style='margin-right:5px;'></i>" + arr[i].toUpperCase() + "</p>");
        }

        $("#mainModalError").modal("show");
    }
}
var prev_ver_imagen = "";
function VerImagen(url, modal) {
    $("#" + modal).modal("hide");
    prev_ver_imagen = modal;
    setTimeout(function () {
        $("#verImagen img").attr("src", url);
        $("#verImagen").modal("show");
    }, 500);
}

function CerrarVerImagen() {
    $("#verImagen").modal("hide");
    setTimeout(function () {
        $("#" + prev_ver_imagen).modal("show");
    }, 500);
}


function DibujarDropdown(class_name, actions) {
    var acciones = "";
    
    for (var i = 0; i < actions.length; i++) {
        var el = actions[i];
        acciones += el;
    }
    var button = "<div class='dropdown'>" +
        "<button class='btn btn-xs " + class_name + " dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false'>Acciones " +
        "<span class='caret'></span></button>" +
        "<ul class='dropdown-menu test' role='menu'>" +
        acciones +
        "</ul>" +
        "</div>";

    return button;
}

function LabelVacias(items) {
    $(items).each(function (index) {
        var t = $(this).text();
        if (t.length <= 0) {
            $(this).text("SIN ESPECIFICAR");
        }
    });
}

$("#datatable_fixed_column").on('processing.dt', function (e, settings, processing) {
    if (processing) {
		if(!$(".ctm-processing").is(":visible")){
			$("#datatable_fixed_column_wrapper").prepend("<div class='ctm-processing'><p><img src='/images/spinner2.gif' style='width: 100px;'></p></div>");
		}
    } else {
        $(".ctm-processing").remove();
    }
    $('#datatable_fixed_column_processing').css('display', 'none');
});

$("#datatable_fixed_column1").on('processing.dt', function (e, settings, processing) {
    if (processing) {
		if(!$(".ctm-processing").is(":visible")){
			$("#datatable_fixed_column1_wrapper").prepend("<div class='ctm-processing'><p><img src='/images/spinner2.gif' style='width: 100px;'></p></div>");
		}
    } else {
        $(".ctm-processing").remove();
    }
    $('#datatable_fixed_column1_processing').css('display', 'none');
});

$("#datatable_fixed_column2").on('processing.dt', function (e, settings, processing) {
    if (processing) {
        if (!$(".ctm-processing").is(":visible")) {
            $("#datatable_fixed_column2_wrapper").prepend("<div class='ctm-processing'><p><img src='/images/spinner2.gif' style='width: 100px;'></p></div>");
        }
    } else {
        $(".ctm-processing").remove();
    }
    $('#datatable_fixed_column2_processing').css('display', 'none');
});



function removeFromArray(index, array) {
    array.splice(index, 1);
}



function isInArray(value, array) {
    return array.indexOf(value) > -1;
}

function removeFromArray(index, arr) {
    arr.splice(index, 1);
}


function modalCorreo() {

    $("#un01").val("");
    $("#un02").val("");
    $("#un03").val("");
    $("#un04").val("VENTAS");
    $("#un06").val("");
    $("#un07").val("");
    $("#un08").val("");
    $("#un09").val("PREFIERO NO DECIRLO");
    $("#unetenos").modal("show");
}

function EnviarCorreo() {
    var email = {
        nombre: $("#un01").val(),
        email: $("#un02").val(),
        telefono: $("#un03").val(),
        puesto: $("#un04").val(),
        mensaje: $("#un06").val(),
        domicilio: $("#un07").val(),
        fecha_nacimiento: $("#un08").val(),
        sexo: $("#un09").val()
    };

    var formData = new FormData();
    formData.append('file', $('#un05')[0].files[0]); // myFile is the input type="file" control
    formData.append('nombre', email.nombre);
    formData.append('email', email.email);
    formData.append('telefono', email.telefono);
    formData.append('puesto', email.puesto);
    formData.append('mensaje', email.mensaje);
    formData.append('domicilio', email.domicilio);
    formData.append('fecha_nacimiento', email.fecha_nacimiento);
    formData.append('sexo', email.sexo);
    $.ajax({
        url: '/Archivos/CorreoUnetenos',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (result) {
            $("#sc_file").empty().append("<label class='btn btn-success btn-sm' for='archivo'>Seleccionar imagen</label><input type='file' id='archivo' name='archivo' class='form-control input-sm' style='display:none;' />");
            var jsonResponse = JSON.parse(result);
            if (jsonResponse.flag != false) {
                SelectImagenFromInventario(inventario_actual.inventario.id);
                SelectInventario();
            }
        },
        error: function (jqXHR) {
        },
        complete: function (jqXHR, status) {
        }
    });
}

function EnviarCorreoInfo() {
    var email = {
        nombre: $("#sc_01").val(),
        email: $("#sc_03").val(),
        telefono: $("#sc_03").val(),
        mensaje: $("#sc_04").val()
    };

    var formData = new FormData();
    formData.append('nombre', email.nombre);
    formData.append('email', email.email);
    formData.append('telefono', email.telefono);
    formData.append('mensaje', email.mensaje);
    $.ajax({
        url: '/Archivos/CorreoInformacion',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (result) {
            $("#sc_file").empty().append("<label class='btn btn-success btn-sm' for='archivo'>Seleccionar imagen</label><input type='file' id='archivo' name='archivo' class='form-control input-sm' style='display:none;' />");
            var jsonResponse = JSON.parse(result);
            if (jsonResponse.flag != false) {
                SelectImagenFromInventario(inventario_actual.inventario.id);
                SelectInventario();
            }
        },
        error: function (jqXHR) {
        },
        complete: function (jqXHR, status) {
        }
    });
}

function EnviarCorreoContacto() {
    var email = {
        nombre: $("#co01").val(),
        email: $("#co02").val(),
        telefono: $("#co03").val(),
        tema: $("#co04").val(),
        mensaje: $("#co06").val(),
        auto: $("#co05").val()
    };

    var formData = new FormData();
    formData.append('nombre', email.nombre);
    formData.append('email', email.email);
    formData.append('telefono', email.telefono);
    formData.append('tema', email.tema);
    formData.append('mensaje', email.mensaje);
    formData.append('auto', email.auto);
    $.ajax({
        url: '/Archivos/CorreoContacto',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (result) {
            $("#sc_file").empty().append("<label class='btn btn-success btn-sm' for='archivo'>Seleccionar imagen</label><input type='file' id='archivo' name='archivo' class='form-control input-sm' style='display:none;' />");
            var jsonResponse = JSON.parse(result);
            if (jsonResponse.flag != false) {
                SelectImagenFromInventario(inventario_actual.inventario.id);
                SelectInventario();
            }
        },
        error: function (jqXHR) {
        },
        complete: function (jqXHR, status) {
        }
    });
}

function EnviarCorreoCompra() {
    var email = {
        nombre: $("#dp_01").val(),
        email: $("#dp_02").val(),
        telefono: $("#dp_03").val(),
        marca: $("#dp_04").val(),
        version: $("#dp_05").val(),
        anho: $("#dp_06").val(),
        mensaje: $("#dp_07").val(),
        calendario: $("#dp_08").val()
    };

    var formData = new FormData();
    //formData.append('file', $('#un05')[0].files[0]); // myFile is the input type="file" control
    formData.append('nombre', email.nombre);
    formData.append('email', email.email);
    formData.append('telefono', email.telefono);
    formData.append('marca', email.marca);
    formData.append('version', email.version);
    formData.append('anho', email.anho);
    formData.append('mensaje', email.mensaje);
    formData.append('calendario', email.calendario);
    $.ajax({
        url: '/Archivos/CorreoCompra',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (result) {
            $("#sc_file").empty().append("<label class='btn btn-success btn-sm' for='archivo'>Seleccionar imagen</label><input type='file' id='archivo' name='archivo' class='form-control input-sm' style='display:none;' />");
            var jsonResponse = JSON.parse(result);
            if (jsonResponse.flag != false) {
                SelectImagenFromInventario(inventario_actual.inventario.id);
                SelectInventario();
            }
        },
        error: function (jqXHR) {
        },
        complete: function (jqXHR, status) {
        }
    });
}

$(document).on("click", "body", function (event) {
    console.log("body");
});

$(document).on("click", "#mySidebar", function (event) {
    //closeNav();
    console.log("sidebar");
});

$(window).click(function (e) {
    var idName = e.target.id;
    var className = e.target.className;

    var ids = ["mySidebar", "burgerFlop", "burgerFlopLi", "burgerFlopI"];

    if (!ids.includes(idName)) {
        closeNav();
    }
});
*/


function openNav() {
    console.log('abrir');
    document.getElementById("mobileNav").style.display = "block";
    $("#burgerFlop").attr("onclick", "closeNav()");
}

function closeNav() {
    console.log('cerrar');
    document.getElementById("mobileNav").style.display = "none";
    $("#burgerFlop").attr("onclick", "openNav()");
}

$(document).ready(function (event) {
    $('#sucursales-carousel').carousel(0);
});

/*
function Exportar(e, nombre) {
    var workbook = new ExcelJS.Workbook();
    var worksheet = workbook.addWorksheet('Main sheet');
    DevExpress.excelExporter.exportDataGrid({
        worksheet: worksheet,
        component: e.component,
        customizeCell: function (options) {
            var excelCell = options;
            excelCell.font = { name: 'Arial', size: 12 };
            excelCell.alignment = { horizontal: 'left' };
        }
    }).then(function () {
        workbook.xlsx.writeBuffer().then(function (buffer) {
            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), nombre.replace(" ", "") + '.xlsx');
        });
    });
    e.cancel = true;
}*/