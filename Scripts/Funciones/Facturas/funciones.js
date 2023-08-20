function getDataTable() {
    var DetalleAS = [];
    var resume_table = document.getElementById("BodyPd");

    for (var i = 0, row; row = resume_table.rows[i]; i++) {
        var LineaDetalle = [];
        for (var j = 0, col; col = row.cells[j]; j++) {

            LineaDetalle.push(col.innerText);
        }
        DetalleAS[i] = LineaDetalle;
    }
    return DetalleAS;
}
function addFactura() {
    //Validaciones de espacios Información Factura
    if ($('#condicionVenta').val() != "00" && $('#selMoneda option:selected').val() != "00") 
    {
        //Validaciones datos Receptor 
        if ($('#dataCliente').val() != "" && $('#ClienteTipoIdentificacion').val() != "00" && $("#tpId").val() != "" &&
            $("#ClienteIdentificacion").val() != "" && $("#ClienteEmail").val() != "" && $("#ClienteNombre").val() != "")
        {
            var children = $("#BodyPd")[0].children;
            if (children.length != 0)
            {
                Swal.fire({
                    title: 'Información de Factura',
                    html: `<div class="text-start p-2 p-2 border border-opacity-25 rounded-3">` +
                        `<br><span class="text-3"> Fecha de creación:</span> ${$('#datenow').val()}` +
                        `<br><span class="text-3"> Condición de Venta:</span> ${$('#condicionVenta option:selected').data()['condicion']}` +
                        `<br><span class="text-3"> Tipo de Pago:</span> ${$('#selTipoPago option:selected').data()['tipopago']}` +
                        `<br><span class="text-3"> Nombre Cliente:</span> ${$('#ClienteNombre').val()}` +
                        `<br><span class="text-3"> Identificación:</span> ${$('#ClienteIdentificacion').val()}` +
                        `<hr><span class="text-3"> SubTotal:</span> ${$('#total_venta_neta').val()}` +
                        `<br><span class="text-3"> Total Impuesto:</span> ${$('#total_impuesto').val()}` +
                        `<br><span class="text-3"> Total Descuento:</span> ${$('#total_descuento').val()}` +
                        `<br><span class="text-3"> Total:</span> ${$('#total_detalle_factura').val()}` +
                        `</div>`,
                    icon: 'question',
                    showCancelButton: true,
                    confirmButtonColor: '#164872',
                    cancelButtonColor: '#6f9dd1',
                    confirmButtonText: 'Crear Factura',
                    cancelButtonText: 'Cancelar'

                }).then((result) => {
                    if (result.isConfirmed)
                    {
                        var DetalleAS = getDataTable();
                        var data = {
                            //informacion de factura
                            CondicionVenta: $("#condicionVenta").val(),
                            MedioPago: $("#selTipoPago").val(),
                            CantidadDias: $("#txtdiasCredito").val(),
                            TipodeCambio: $("#txtTipoCambio").val(),
                            //Datos del receptor
                            ClienteId: $("#ClienteId").val(),
                            TipoIdentificacion: $("#ClienteTipoIdentificacion").val(),
                            Identificacion: $("#ClienteIdentificacion").val(),
                            Telefono: $("#ClienteTelefono").val(),
                            Nombre: $("#ClienteNombre").val(),
                            Correo: $("#ClienteEmail").val(),
                            //Detalles del AS
                            DetalleServicio: DetalleAS,
                            //Resumen de factura
                            Descuento: $("#txtDescuento").val(),
                            NaturalezaDescuento: $("#NaturalezaDescuento").val(),
                            CodigoMoneda: $("#selMoneda").val(),
                            TotalServGravados: $("#total_serv_grav").val(),
                            TotalServExentos: $("#total_serv_exent").val(),
                            TotalServExonerado: $("#total_serv_exoner").val(),
                            TotalMercanciasGravadas: $("#total_merc_grav").val(),
                            TotalMercanciasExentas: $("#total_merc_exent").val(),
                            TotalMercExonerada: $("#total_merc_exoner").val(),
                            TotalGravado: $("#total_grav").val(),
                            TotalExento: $("#total_exent").val(),
                            TotalExonerado: $("#total_exoner").val(),
                            TotalVenta: $("#total_venta").val(),
                            TotalDescuentos: $("#total_descuento").val(),
                            TotalVentaNeta: $("#total_venta_neta").val(),
                            TotalImpuesto: $("#total_impuesto").val(),
                            TotalIVADevuelto: $("#total_iva_devuelto").val(),
                            TotalOtrosCargos: $("#total_otros_cargos").val(),
                            TotalComprobante: $("#total_detalle_factura").val(),
                            //Personalizados
                            Observaciones: $("#Observaciones").val()
                        };
                        //console.log(DetalleAS)

                        $.ajax({
                            type: "POST",
                            url: "/Factura/Create",
                            data: JSON.stringify(data),
                            contentType: 'application/json',
                            success: (data) => {

                                if (data) {
                                    Swal.fire({
                                        position: 'center',
                                        icon: 'success',
                                        title: "Factura Registrada",
                                        showConfirmButton: false,
                                        timer: 1500
                                    })
                                    setInterval(() => { window.location.href = "Index"; }, 1500);
                                } else {
                                    Swal.fire({
                                        position: 'center',
                                        icon: 'error',
                                        title: "Problemas al realizar la inserci\u00F3n",
                                        showConfirmButton: false,
                                        timer: 2000
                                    })
                                    setInterval(() => { window.location.reload(); }, 2000);
                                }

                            },
                            error: (error) => {
                                console.log(error);
                                return false;
                            }
                        });
                    }
                })

               
            } else Alertsw('warning', 'Aviso', 'No has agregado ningún producto', 4000)
        } else Alertsw('error', 'No has seleccionado un cliente', 'Debes seleccionar un cliente para completar la creación', 4000)

    }else Alertsw('warning','Completa todos los espacios','Asegurate de haber completado toda la información para la creación de la factura',4000)
   
}
function EliminarProductoTabla(trId) {
    document.getElementById(trId).remove();
    valEtiqueta();
}
function valEtiqueta() {
    if ($("#BodyPd").find("tr").length != 0) {
        $("#pExistenciaProductos").hide();
    } else {
        $("#pExistenciaProductos").show();
    }
}
function TotalesLoad() {
    setTimeout(() => {
        //TotalServGravados
        var TotalServGravados = 0;
        //TotalMercanciasGravadas
        var TotalMercanciasGravadas = 0;
        //TotalGravado
        var TotalGravado = 0;
        //TotalVenta
        var TotalVenta = 0;
        //TotalDescuentos
        var TotalDescuentos = 0;
        //TotalVentaNeta
        var TotalVentaNeta = 0;
        //TotalImpuesto
        var TotalImpuesto = 0;
        //TotalComprobante
        var TotalComprobante = 0;

        var DetalleAS = getDataTable();
        for (var i = 0; i < DetalleAS.length; i++) {
            if (DetalleAS[i][1] == "Servicio") {
                TotalServGravados += parseFloat(DetalleAS[i][3]) * parseInt(DetalleAS[i][4]);
            }
            else if (DetalleAS[i][1] == "Artículo") {
                TotalMercanciasGravadas += parseFloat(DetalleAS[i][3]) * parseInt(DetalleAS[i][4]);
            }
            TotalDescuentos += parseFloat(DetalleAS[i][10]);
            TotalImpuesto += parseFloat(DetalleAS[i][9]);
            TotalComprobante += parseFloat(DetalleAS[i][11]);
        }
        TotalVenta = TotalServGravados + TotalMercanciasGravadas;
        TotalVentaNeta = parseFloat(TotalVenta - TotalDescuentos);
        //console.log(TotalVenta)
        //console.log(TotalDescuentos)
        //console.log(TotalVentaNeta)
        TotalGravado = TotalServGravados + TotalMercanciasGravadas;
        //Detalle Factura
        $("#total_serv_grav").val(parseFloat(TotalServGravados).toFixed(2));
        $("#total_merc_grav").val(parseFloat(TotalMercanciasGravadas).toFixed(2));
        $("#total_grav").val(parseFloat(TotalGravado).toFixed(2));
        $("#total_venta").val(parseFloat(TotalVenta).toFixed(2));
        $("#total_descuento").val(parseFloat(TotalDescuentos).toFixed(2));
        $("#total_venta_neta").val(parseFloat(TotalVentaNeta).toFixed(2));
        $("#total_impuesto").val(parseFloat(TotalImpuesto).toFixed(2));
        $("#total_detalle_factura").val(parseFloat(TotalComprobante).toFixed(2));
    }, 1000);
    return true;
}
function cerrarDetalles() {
    $("#panelsStayOpen-collapseFour").removeClass();
    $("#panelsStayOpen-collapseFour").addClass("accordion-collapse collapse");
}
function valFactura() {
    setTimeout(() => {
        if ($("#cantidadPd").val() == 0) {
            $("#agregar_Pd").prop("disabled", true);
        }
        else if ($("#Impuestos option:selected").val() == "0") {
            $("#agregar_Pd").prop("disabled", true);
        }
        else if ($("#dataPd").val().length == 0) {
            $("#agregar_Pd").prop("disabled", true);
        }
        else {
            $("#agregar_Pd").prop("disabled", false);
            $("#agregar_Pd").prop("disabled", null);

        }
    },1000);
    return true;
}