function getCategorias(empresaId) {
    var data = {
        EmpresaId: empresaId
    };
    $.ajax({
        type: "POST",
        url: "/SubCategoria/getCategoriasxEmpresa",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            $.each(data, (i, val) => {
                if ($("#selCategoria option[value=" + val.CategoriaId + "]").length == 0) {
                    $('#selCategoria').append('<option value="' + val.CategoriaId + '">' + val.Categoria + '</option> ');
                }
                if ($("#selCategoriaupd option[value=" + val.CategoriaId + "]").length == 0) {
                    $('#selCategoriaupd').append('<option value="' + val.CategoriaId + '">' + val.Categoria + '</option> ');
                }
                if ($("#selCategoriaUpd option[value=" + val.CategoriaId + "]").length == 0) {
                    $('#selCategoriaUpd').append('<option value="' + val.CategoriaId + '">' + val.Categoria + '</option> ');
                }
            })
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}
function delCategoria(categoriaId) {
    var data = {
        CategoriaId: categoriaId
    };
    $.ajax({
        type: "POST",
        url: "/Categoria/Delete",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            if (data) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: "Categor\u00eda eliminada",
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
                    timer: 1500
                })
                setInterval(() => { window.location.reload(); }, 1500);
            }
        },
        error: (error) => {
            console.log(error);
        }
    });
}
function updCategoria(categoriaId) {

    var data = {
        CategoriaId: categoriaId
    };
    $.ajax({
        type: "POST",
        url: "/Categoria/getCategoria",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            $.each(data, (i, val) => {
                $("#txtCategoriaUpd").val(val.Categoria);
                $("#txtCategoriaIdUpd").val(val.CategoriaId);
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
function updSubCategoria(subCategoriaId, empresaId) {
    getCategorias(empresaId);
    var data = {
        SubCategoriaId: subCategoriaId
    };
    $.ajax({
        type: "POST",
        url: "/SubCategoria/getSubCategoria",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            $.each(data, (i, val) => {
                $("#txtSubCategoriaSub").val(val.SubCategoria);
                $("#txtSubCategoriaSubIdUpd").val(val.SubCategoriaId);
                $("#selCategoriaupd option").removeAttr('selected');
                $("#selCategoriaupd option[value='" + val.CategoriaId + "']").attr("selected", "selected");
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
function delSubCategoria(subCategoriaId) {
    var data = {
        SubCategoriaId: subCategoriaId
    };
    $.ajax({
        type: "POST",
        url: "/SubCategoria/Delete",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            if (data) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: "Categor\u00eda eliminada",
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
                    timer: 1500
                })
                setInterval(() => { window.location.reload(); }, 1500);
            }
        },
        error: (error) => {
            console.log(error);
        }
    });
}
function getImpuestosxEmpresa() {
    $.ajax({
        type: "POST",
        url: "/Factura/getImpuestosxEmpresa",
        success: (data) => {
            $.each(data, (i, val) => {
                if ($("#Impuestos option[value=" + val.ImpuestoId + "]").length == 0) {
                    $('#Impuestos').append('<option value="' + val.ImpuestoId + '">' + val.Impuesto + '</option> ');
                }
            })
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}
function getMonedasxEmpresa() {
    $.ajax({
        type: "POST",
        url: "/Factura/getMonedasxEmpresa",
        success: (data) => {
            $.each(data, (i, val) => {
                if ($("#selMoneda option[value=" + val.MonedaId + "]").length == 0) {
                    
                    $('#selMoneda').append(`<option value="${val.MonedaId}" data-codigoMoneda = "${val.CodigoMoneda}" > ${val.DescMoneda} </option>`);

                }
            })
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}

//validaciones
function valNombreSub(NombreSub) {
    var res = validarCampos(NombreSub, 0);
    if (NombreSub.length == 0) {
        //add
        $("#lbNombreSub").text("Nombre");
        $("#lbNombreSub").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoria").addClass('invalido');
        $("#btn_AddSubCategoria").prop("disabled", true);
        //upd
        $("#lbNombreSubupd").text("Nombre");
        $("#lbNombreSubupd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoriaSub").addClass('invalido');
        $("#btn_updSub").prop("disabled", true);
        
    } else if (res) {
        //add
        $("#lbNombreSub").text("✘ No debe tener caracteres especiales");
        $("#lbNombreSub").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoria").addClass('invalido');
        $("#btn_AddSubCategoria").prop("disabled", true);
        //upd
        $("#lbNombreSubupd").text("✘ No debe tener caracteres especiales");
        $("#lbNombreSubupd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoriaSub").addClass('invalido');
        $("#btn_updSub").prop("disabled", true);
    } else {
        //add
        $("#lbNombreSub").text("✓ Nombre");
        $("#lbNombreSub").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoria").removeClass('invalido');
        $("#btn_AddSubCategoria").prop("disabled", false);
        //upd
        $("#lbNombreSubupd").text("✓ Nombre");
        $("#lbNombreSubupd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtSubCategoriaSub").removeClass('invalido');
        $("#btn_updSub").prop("disabled", false);
    }
}
function valNombreCategorias(text) {
    var res = validarCampos(text, 0);
    if (text.length == 0) {
        //add
        $("#lbNombreCat").text("Nombre");
        $("#lbNombreCat").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCategoria").addClass('invalido');
        $("#btn_addCategoria").prop("disabled", true);
        //upd
        $("#lbNombreCatupd").text("Nombre");
        $("#lbNombreCatupd").css({ "color": "black", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCategoriaUpd").addClass('invalido');
        $("#btn_updCategoria").prop("disabled", true);

    } else if (res) {
        //add
        $("#lbNombreCat").text("✘ No debe tener caracteres especiales");
        $("#lbNombreCat").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCategoria").addClass('invalido');
        $("#btn_addCategoria").prop("disabled", true);
        //upd
        $("#lbNombreCatupd").text("✘ No debe tener caracteres especiales");
        $("#lbNombreCatupd").css({ "color": "red", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCategoriaUpd").addClass('invalido');
        $("#btn_updCategoria").prop("disabled", true);
    } else {
        //add
        $("#lbNombreCat").text("✓ Nombre");
        $("#lbNombreCat").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCategoria").removeClass('invalido');
        $("#btn_addCategoria").prop("disabled", false);
        //upd
        $("#lbNombreCatupd").text("✓ Nombre");
        $("#lbNombreCatupd").css({ "color": "green", "font-family": "Times New Roman', Times, serif;" });
        $("#txtCategoriaUpd").removeClass('invalido');
        $("#btn_updCategoria").prop("disabled", false);
    }
}