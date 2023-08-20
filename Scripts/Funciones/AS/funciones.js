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
function getUnidadMedidas() {
    $.ajax({
        type: "POST",
        url: "/ProductoServicio/getUnidadMedidas",
        success: (data) => {
            $.each(data, (i, val) => {
                $('#selUnidadDeMedida').append('<option value="' + val.UnidadDeMedidaId + '">' + val.DescUnidad + '</option> ');
                $('#selUnidadDeMedidaUpd').append('<option value="' + val.UnidadDeMedidaId + '">' + val.DescUnidad + '</option> ');
            });
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}
function getMarcas() {
    $.ajax({
        type: "POST",
        url: "/ProductoServicio/getMarcas",
        success: (data) => {
/*            $('#selMarca').append("<option value='' selected disabled>Seleccionar</option>");*/
            $.each(data, (i, val) => {
                $('#selMarca').append('<option value="' + val.MardaId + '">' + val.Marca + '</option> ')
                $('#selMarcaUpd').append('<option value="' + val.MardaId + '">' + val.Marca + '</option> ')
            });
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}
function getSubCategoriasAS() {
    $.ajax({
        type: "POST",
        url: "/ProductoServicio/getSubCategoriasAS",
        success: (data) => {
            //$('#selSubCategoriaAS').append("<option value='' selected disabled>Seleccionar</option>");
            $.each(data, (i, val) => {
                $('#selSubCategoriaAS').append('<option value="' + val.SubCategoriaId + '">' + val.SubCategoria + '</option> ')
                $('#selSubCategoriaUpd').append('<option value="' + val.SubCategoriaId + '">' + val.SubCategoria + '</option> ')
            });
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}
function updAS(asId, empresaId) {
    var data = {
        ASId: asId
    };
    if (!getUnidadMedidas()) {
        return false;
    }
    if (!getMarcas()) {
        return false;
    }
    if (!getCategorias(empresaId)) {
        return false;
    }
    if (!getSubCategoriasAS()) {
        return false;
    }
    $.ajax({
        type: "POST",
        url: "/ProductoServicio/getAS",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {

            $.each(data, (i, val) => {

                $("#selUnidadDeMedidaUpd  option[value='" + val.UnidadDeMedidaId + "']").attr("selected", "selected");

                $("#selMarcaUpd  option[value='" + val.MarcaId + "']").attr("selected", "selected");

                $("#selCategoriaUpd  option[value='" + val.CategoriaId + "']").attr("selected", "selected");

                $("#selSubCategoriaUpd  option[value='" + val.SubCategoriaId + "']").attr("selected", "selected");
                console.log(val.Estado)
                if (val.Estado == "0") {
                    $("#rd_tipoAS1").attr('checked', 'checked');
                } else {
                    $("#rd_tipoAS2").attr('checked', 'checked');
                }
                $("#txtEstado").val(val.Estado);
                checkBox($("#txtEstado").val());
            });
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
}
function delAS(asId) {
    var data = {
        ASId: asId
    };
    $.ajax({
        type: "POST",
        url: "/ProductoServicio/Delete",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            if (data) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: "Producto/Servicio eliminado",
                    showConfirmButton: false,
                    timer: 1500
                })
                setInterval(() => { window.location.reload(); }, 1500);
            } else {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: "Problemas al realizar la eliminaci\u00F3n",
                    showConfirmButton: false,
                    timer: 2000
                })
                setInterval(() => { window.location.reload(); }, 2000);
            }
        },
        error: (error) => {
            console.log(error);
        }
    });
}

$("#txtPrecio").focusout(() => {
    var value = $("#txtPrecio").val();
    if (value.length != 0 && value != ".") {
        var precioFloat = parseFloat(value).toFixed(2);
        $("#txtPrecio").val(precioFloat);
        $("#txtPrecioUpd").val(precioFloat);
    }
});
$("#txtPrecioUpd").focusout(() => {
    var value = $("#txtPrecioUpd").val();
    if (value.length != 0 && value != ".") {
        var precioFloat = parseFloat(value).toFixed(2);
        $("#txtPrecioUpd").val(precioFloat);
    }
});
//validaciones
function valNombreAS(text) {
    var res = validarCampos(text, 1);
    if (text.length == 0) {
        //add
        $("#lbNombreAS").text("Nombre");
        $("#lbNombreAS").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtNombre").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbNombreASupd").text("Nombre");
        $("#lbNombreASupd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtNombreudp").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);

    } else if (res) {
        //add
        $("#lbNombreAS").text("✘ No debe tener caracteres especiales");
        $("#lbNombreAS").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtNombre").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbNombreASupd").text("✘ No debe tener caracteres especiales");
        $("#lbNombreASupd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtNombreudp").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    } else {
        //add
        $("#lbNombreAS").text("✓ Nombre");
        $("#lbNombreAS").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtNombre").removeClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbNombreASupd").text("✓ Nombre");
        $("#lbNombreASupd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoriaSub").removeClass('invalido');
        $("#btn_ASupd").prop("disabled", false);
    }
}
function valSKU(text) {
    var res = validarCampos(text, 2);
    if (text.length == 0) {
        //add
        $("#lbSKU").text("SKU");
        $("#lbSKU").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKU").addClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbSKUupd").text("SKU");
        $("#lbSKUupd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKUupd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", false);

    } else if (res) {
        //add
        $("#lbSKU").text("✘ No debe tener caracteres especiales ni letras");
        $("#lbSKU").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKU").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbSKUupd").text("✘ No debe tener caracteres especiales");
        $("#lbSKUupd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKUupd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    }else if (text.length > 30) {
        //add
        $("#lbSKU").text("✘ El SKU no puede exceder 30 digitos");
        $("#lbSKU").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKU").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbSKUupd").text("✘ El SKU no puede exceder 30 digitos");
        $("#lbSKUupd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKUupd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    } else {
        //add
        $("#lbSKU").text("✓ SKU");
        $("#lbSKU").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKU").removeClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbSKUupd").text("✓ SKU");
        $("#lbSKUupd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSKUupd").removeClass('invalido');
        $("#btn_ASupd").prop("disabled", false);
    }
}
function valModeloAS(text) {
    var res = validarCampos(text, 1);
    if (text.length == 0) {
        //add
        $("#lbModeloAS").text("Modelo");
        $("#lbModeloAS").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtModelo").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbModeloASupd").text("Modelo");
        $("#lbModeloASupd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtModeloupd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);

    } else if (res) {
        //add
        $("#lbModeloAS").text("✘ No debe tener caracteres especiales");
        $("#lbModeloAS").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtModelo").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbModeloASupd").text("✘ No debe tener caracteres especiales");
        $("#lbModeloASupd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtModeloupd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    } else {
        //add
        $("#lbModeloAS").text("✓ Modelo");
        $("#lbModeloAS").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtModelo").removeClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbModeloASupd").text("✓ Modelo");
        $("#lbModeloASupd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtModeloupd").removeClass('invalido');
        $("#btn_updSub").prop("disabled", false);
    }
}
function valSelAS(text) {
    switch (text) {
        case 1:
            //add
            $("#lbUnidadDeMedida").text("✓ Unidad de Medida");
            $("#lbUnidadDeMedida").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_addAS").prop("disabled", false);
            //upd
            $("#lbUnidadDeMedidaUpd").text("✓ Unidad de Medida");
            $("#lbUnidadDeMedidaUpd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_ASupd").prop("disabled", false);
            break;
        case 2:
            //add
            $("#lbMarca").text("✓ Marca");
            $("#lbMarca").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_addAS").prop("disabled", false);
            //upd
            $("#lbMarcaUpd").text("✓ Marca");
            $("#lbMarcaUpd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_ASupd").prop("disabled", false);
            break;
        case 3:
            //add
            $("#lbCategoria").text("✓ Categor\u00eda");
            $("#lbCategoria").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_ASupd").prop("disabled", false);
            //upd
            $("#lbCategoriaUpd").text("✓ Categor\u00eda");
            $("#lbCategoriaUpd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_addAS").prop("disabled", false);
            break;
        case 4:
            //add
            $("#lbSubCategoria").text("✓ Sub Categor\u00eda");
            $("#lbSubCategoria").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_addAS").prop("disabled", false);
            //upd
            $("#lbSubCategoriaUpd").text("✓ Sub Categor\u00eda");
            $("#lbSubCategoriaUpd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
            $("#btn_ASupd").prop("disabled", false);
            break;
    }
}
function valCodCabys(text) {
    var res = validarCampos(text, 2);
    if (text.length == 0) {
        //add
        $("#lbCodCabys").text("C\u00f3digo Cabys");
        $("#lbCodCabys").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabys").addClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbCodCabysUpd").text("C\u00f3digo Cabys");
        $("#lbCodCabysUpd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabysUpd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", false);

    } else if (res) {
        //add
        $("#lbCodCabys").text("✘ No debe tener caracteres especiales ni letras");
        $("#lbCodCabys").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabys").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbCodCabysUpd").text("✘ No debe tener caracteres especiales");
        $("#lbCodCabysUpd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabysUpd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    } else if (text.length != 13) {
        //add
        $("#lbCodCabys").text("✘ Debe tener 13 digitos");
        $("#lbCodCabys").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabys").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbCodCabysUpd").text("✘ El SKU debe tener 7 digitos");
        $("#lbCodCabysUpd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabysUpd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    } else {
        //add
        $("#lbCodCabys").text("✓ C\u00f3digo Cabys");
        $("#lbCodCabys").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabys").removeClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbCodCabysUpd").text("✓ C\u00f3digo Cabys");
        $("#lbCodCabysUpd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCodCabysUpd").removeClass('invalido');
        $("#btn_ASupd").prop("disabled", false);
    }
}
function valPrecio(text) {
    var res = validarCampos(text, 3);
    if (text.length == 0) {
        //add
        $("#lbPrecio").text("Precio");
        $("#lbPrecio").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecio").addClass('invalido');
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbPrecioUpd").text("Precio");
        $("#lbPrecioUpd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecioUpd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", false);

    } else if (text == '.') {
        //add
        $("#lbPrecio").text("✘ Faltan digitos");
        $("#lbPrecio").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecio").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbPrecioUpd").text("✘ Faltan digitos");
        $("#lbPrecioUpd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecioUpd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    }
    else if (res) {
        //add
        $("#lbPrecio").text("✘ No debe tener caracteres especiales ni letras");
        $("#lbPrecio").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecio").addClass('invalido');
        $("#btn_addAS").prop("disabled", true);
        //upd
        $("#lbPrecioUpd").text("✘ No debe tener caracteres especiales");
        $("#lbPrecioUpd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecioUpd").addClass('invalido');
        $("#btn_ASupd").prop("disabled", true);
    }else {
        //add
        $("#lbPrecio").text("✓ Precio");
        $("#lbPrecio").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecio").removeClass('invalido');
        
        $("#btn_addAS").prop("disabled", false);
        //upd
        $("#lbPrecioUpd").text("✓ Precio");
        $("#lbPrecioUpd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtPrecioUpd").removeClass('invalido');
        $("#btn_ASupd").prop("disabled", false);
        
    }
}
function valAddAS() {
    valNombreAS($("#txtNombre").val());
    valSKU($("#txtSKU").val());
    valModeloAS($("#txtModelo").val());
    valCodCabys($("#txtCodCabys").val());
    valPrecio($("#txtPrecio").val());
}
function valUpdAS() {
    valNombreAS($("#txtNombreudp").val());
    valSKU($("#txtSKUupd").val());
    valModeloAS($("#txtModeloupd").val());
    valCodCabys($("#txtCodCabysUpd").val());
    valPrecio($("#txtPrecioUpd").val());
}