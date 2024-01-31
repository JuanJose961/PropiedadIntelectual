var markup = politicas.data_string;

function formatOutput(value, valueType) {
    const formattedValue = valueType === 'html' ? prettierFormat(value) : value;
    $('.value-content').text(formattedValue);
}

function valueChanged({ component, value }) {
    formatOutput(value, component.option('valueType'));
}

function selectionChanged(e) {
    var editorInstance = $("#html-editor").dxHtmlEditor("instance");

    var valueType = e.addedItems[0].text.toLowerCase();
    editorInstance.option({ valueType });
    var value = editorInstance.option("value");

    formatOutput(value, valueType);
}

function prettierFormat(markup) {
    return prettier.format(markup, {
        parser: "html",
        plugins: prettierPlugins
    })
}

function guardaPoliticas() {
    $("#guardar").attr("disabled", "disabled");
    $("#alertModal .close").hide();
    $("#alertModal .modal-title").text("Cargando información");
    $("#alertModal .modal-footer").empty();
    $("#alertModal .form-group").empty();
    $("#alertModal .modal-spinner").show();
    $("#alertModal").modal("show");
    var sended_url = services_url + "UpdateAdministracion";
    var html = $("#htmlContent").text();
    $.ajax({
        type: "POST",
        url: sended_url,
        data: JSON.stringify({ data_string: "politicas", data_string1: html }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#alertModal .modal-spinner").hide();
            $("#guardar").removeAttr("disabled");
            var jsonResponse = response;
            if (jsonResponse.flag != false) {
                $("#alertModal .form-group").append("<p>Guardado correctamente</p>");
                $("#alertModal .modal-footer").html('<button type="button" class="btn btn-default" data-dismiss="modal"><i class="fa fa-ban"></i> Ok</button>');
                //$("#alertModal").modal("hide");
            } else {
                $("#alertModal .modal-footer").html('<button type="button" class="btn btn-default" data-dismiss="modal"><i class="fa fa-ban"></i> Ok</button>');
                for (var i = 0; i < jsonResponse.errors.length; i++) {
                    $("#alertModal .form-group").append("<p class='form-error'>" + jsonResponse.errors[i] + "</p>");
                }
            }
        },
        failure: function (response) {
            $("#alertModal .modal-spinner").hide();
            $("#guardar").removeAttr("disabled");
        },
        error: function (response) {
            $("#alertModal .modal-spinner").hide();
            $("#guardar").removeAttr("disabled");
        }
    });
}