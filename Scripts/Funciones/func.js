function checkBox(val) {

    $(() => {
        if (val == "0") {
            //Activo

            $('#estadoCheck-label').html("<span class='text-2'>Activo</span>")
            $('#estadoCheck').prop('checked', true);

        } else {
            //Inactivo

            $('#estadoCheck-label').html("<span class='text-secondary'>Deshabilitado</span>")
            $('#estadoCheck').prop('checked', false);


        }
        $('#estadoCheck').click(() => {
            if ($('#estadoCheck').is(':checked')) {
                $('#estadoCheck-label').html("<span class='text-2'>Activo</span>")

                $('#txtEstado').val("0");

            } else {
                $('#estadoCheck-label').html("<span class='text-secondary'>Deshabilitado</span>")
                $('#txtEstado').val("1");

            }
        })

    });
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
function validarDirecion(text, input, span) {
    $("#spanCaracteres").show();
    var max_caracteres = 300;
    if (text.length < max_caracteres) {
        caracteres = max_caracteres - text.length;
        document.getElementById(span).innerHTML = caracteres - 1
    } else {
        document.getElementById(input).value = text.substring(0, max_caracteres);
    }
    return true;
}
function getTipoCambio() {
    $.ajax({
        type: "POST",
        url: "/Factura/getTipodeCambioVenta",
        success: (data) => {
            $("#valTipoCambio").val(parseFloat(data).toFixed(2));
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}
function validarCampos(text, tipo) {
    const numerosCaracteres = "0123456789.,!@/#$%%^&*\(){}[]:;+=-'|`~_<?>";
    const Caracteres = ".,!@#$%%^&*\(/){}[]:;+=-'|`~_<?>";
    const CaracteresLetras = ".,!@#$%%^&*\(/){}[]:;+=-'|`~_<?>abcdefghijklnmñopqrstuvwxyzABCDEFGHIJKLNMÑOPQRSTUVWXYZ";
    const CaracteresLetrasSinPunto = ",!@#$%%^&*\(/){}[]:;+=-'|`~_<?>abcdefghijklnmñopqrstuvwxyzABCDEFGHIJKLNMÑOPQRSTUVWXYZ";
    var Tipo = "";
    if (tipo == 0) {
        Tipo += numerosCaracteres;
    }
    else if (tipo == 1) {
        Tipo += Caracteres;
    } else if (tipo == 2) {
        Tipo += CaracteresLetras;
    } else if (tipo == 3) {
        Tipo += CaracteresLetrasSinPunto;
    }

    for (i = 0; i < text.length; i++) {
        if (Tipo.indexOf(text.charAt(i), 0) != -1) {
            return true;
        }
    }
    return false;
}