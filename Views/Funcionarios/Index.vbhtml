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
                                        <th>Primer Apellido</th>
                                        <th>Segundo Apeliido</th>
                                        <th>Correo</th>
                                        <th>Clave</th>
                                        <th>Usuario</th>
                                        <th>Estado</th>
                                        <th>Opciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>125616</td>
                                        <td>Margarito</td>
                                        <td>Vensacar</td>
                                        <td>Piedras</td>
                                        <td>correosilencio</td>
                                        <td>65464</td>
                                        <th>Loba</th>
                                        <td style="color:blue">Activo</td>
                                        <td>
                                            <a href="#" class="btn btn-warning">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                                                    <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                                                </svg>
                                            </a><a href="#" class="btn btn-danger">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                                </svg>
                                            </a>
                                    </tr>
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