 <!-- Page Wrapper -->
<div id="wrapper">


    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

        <!-- Main Content -->
        <div id="content">


            <!-- Begin Page Content -->
            <div class="container-fluid">

                <!-- Page Heading -->
                <!-- DataTales Example -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h1>Funcionarios</h1>
                        <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#mod-new">
                            Nuevo
                        </button>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Identificacion</th>
                                        <th>Nombre</th>
                                        <th>Correo</th>
                                        <th>Estado</th>
                                        <th>Opciones</th>
                                    </tr>
                                </thead>
                                <tbody id="listFuncionarios">
                                   
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- End of Main Content -->
        <!-- Footer -->
        <footer class="sticky-footer bg-white">
            <div class="container my-auto">
                <div class="copyright text-center my-auto">
                    <span>Copyright &copy; Your Website 2020</span>
                </div>
            </div>
        </footer>
        <!-- End of Footer -->

    </div>
    <!-- End of Content Wrapper -->

</div>
<!-- End of Page Wrapper -->
<!-- Modal -->
<div class="modal fade" id="mod-new" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="">Nuevo Funcionario</h1>
                <button type="button" class="fa fa-times" data-bs-dismiss="modal" aria-label="Close">
                </button>
            </div>
            <div class="modal-body">
                <form class="row g-3">

                    @*<%--txtIdentificacion--%>*@
                    <div class="col-md-6">
                        <label for="txtIdentificacion" class="form-label">Identificacion</label>
                        <input type="text" class="form-control" id="txtIdentificacion" required>

                    </div>

                    @*<%--txtnombre--%>*@
                    <div class="col-md-6">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <input type="text" class="form-control" id="txtNombre" required>

                    </div>

                    @*<%--txtPriApellido--%>*@
                    <div class="col-md-6">
                        <label for="txtPriApellido" class="form-label">1 Apellidos</label>
                        <input type="text" class="form-control" id="txtPriApellido" required>

                    </div>

                    @*<%--txtSegApellido--%>*@
                    <div class="col-md-6">
                        <label for="txtSegApellido" class="form-label">2 Apellidos</label>
                        <input type="text" class="form-control" id="txtSegApellido" required>

                    </div>
                    @*<%--txtClave--%>*@
                    <div class="col-md-6">
                        <label for="txtClave" class="form-label">Clave</label>
                        <input type="text" class="form-control" id="txtClave" required>

                    </div>


                    @*<%--txtUsuario--%>*@
                    <div class="col-md-6">
                        <label for="txtUsuario" class="form-label">Usuario</label>
                        <input type="text" class="form-control" id="txtUsuario" required>

                    </div>


                    @*<%--IntEstado--%>*@
                    <div class="col-md-6">
                        <label for="IntEstado" class="form-label">Estado</label>
                        <input type="Number" class="form-control" id="IntEstado" required>

                    </div>
                    @*<%--txtCorreo--%>*@
                    <div class="col-md-6">
                        <label for="txtCorreo" class="form-label">Correo</label>
                        <input type="email" class="form-control" id="txtCorreo" required>

                    </div>


                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-primary">
                            Guardar
                        </button>
                    </div>
                </form>
            </div>

        </div>
    </div>
</div>


<!-- Logout Modal-->
<div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
            </div>
            <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                <a class="btn btn-primary" href="login.html">Logout</a>
            </div>
        </div>
    </div>
</div>

<script>


    $(document).ready(() => {
        $.ajax({
            type: "POST",
            url: "/Funcionarios/getFuncionarios",
            success: (data) => {
                //alert(JSON.stringify(data))
                $.each(data, (i, val) => {
                    $('#listFuncionarios').append("<tr>" +
                        "<td> " + val.Identificacion + "</td>" +
                        "<td> " + val.Nombre + " " + val.Apellido1 + " " + val.Apellido2 + "</td>" +
                        "<td> " + val.Correo + "</td>" +
                        "<td> " + val.Estado + "</td>" +
                        "<td>"+
                        "<a href=\"#\" class=\"btn btn-warning\" onclick=\"updFuncionario(" + val.Identificacion +")\">"+
                        "<i class=\"fa-solid fa-pencil\"></i>" +
                        "</a><a href=\"#\" class=\"btn btn-danger\" onclick=\"delFuncionario(" + val.Identificacion + ")\">"+
                        "<i class=\"fa-solid fa-trash\"></i>" +
                        "</a>" +
                        "</td>" +
                        "</tr >"

                    );
                });
            },
            error: (error) => {
                console.log(error);
                return false;
            }
        });
        return true;

    });

    function delFuncionario(ideFucionario) {
        //alert('si')
        var data = {
            Identificacion: ideFucionario
        };
        $.ajax({
            type: "POST",
            url: "/Funcionarios/Delete",
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: (data) => {
 //alert('si'**********************************************************************************)
                //alert(JSON.stringify(data))
                if (data==1) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: "Funcionario eliminado",
                        showConfirmButton: false,
                        timer: 1500
                    })
                    setInterval(() => { window.location.reload(); }, 1500);
                } else {
                    Swal.fire({
                        position: 'center',
                        icon: 'error',
                        title: "Funcionario no eliminado",
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

</script>