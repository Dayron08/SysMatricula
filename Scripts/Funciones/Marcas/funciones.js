function getMarca(marcaId) {
    var data = {
        MarcaId: marcaId
    };
    $.ajax({
        type: "POST",
        url: "/Marcas/getMarca",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            $.each(data, (i, val) => {
                $("#txtMarcaupd").val(val.Marca);
                $("#txtMarcaId").val(val.MarcaId);
                $("#txtEstado").val(val.Estado);
                $("#txtMarcaIdupd").val(val.MarcaId);
                checkBox($("#txtEstado").val());
            });
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
}
function delMarca(marcaId) {
    var data = {
        MarcaId: marcaId
    };
    $.ajax({
        type: "POST",
        url: "/Marcas/Delete",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: (data) => {
            if (data) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: "Marca eliminada",
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