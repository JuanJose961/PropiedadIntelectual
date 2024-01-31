$(document).ready(function () {
    $(".ctm-header-area span").text("Módulo Propiedad Intelectual");
    
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
