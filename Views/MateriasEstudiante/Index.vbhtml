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
                        <h1>Matricula Estudiante</h1>
                        <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#mod-new">
                            Nuevo
                        </button>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Curso</th>
                                        <th>Codigo del curso</th>
                                        <th>Cantidad minima</th>
                                        <th>Cantidad maxima</th>
                                        <th>Estado</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Matematicas</td>
                                        <td>TI-114</td>
                                        <td>5</td>
                                        <td>25</td>
                                        <td style="color:blue">Activo</td>
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
                <h1 class="modal-title fs-5" id="">Nuevo Estudiante</h1>
                <button type="button" class="" data-bs-dismiss="modal" aria-label="Close">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
                        <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                    </svg>
                </button>
            </div>
            <div class="modal-body">
                @*<%-- informacion par aingresar al boton busacar--%>*@
                <form class="row g-3">

                    @*<%--txtIdentificacion--%>*@
                    <div class="col-md-6">
                        <label for="txtIdentificacion" class="form-label">Identificacion</label>
                        <input type="text" class="form-control" id="txtIdentificacion" required>
                    </div>

                    @*<%--txtCarnet--%>*@
                    <div class="col-md-6">
                        <label for="txtCarnet" class="form-label">Carnet</label>
                        <input type="text" class="form-control" id="txtCarnet" required>
                    </div>
                    @*<%--txtnombre--%>*@
                    <div class="col-md-6">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <input type="text" class="form-control" id="txtNombre" required>
                    </div>
                    @*<%--txtapellido--%>*@
                    <div class="col-md-6">
                        <label for="txtapellidos" class="form-label">Apellidos</label>
                        <input type="text" class="form-control" id="txtapellidos" required>

                    </div> @*<%--NumTelefono--%>*@
                    <div class="col-md-6">
                        <label for="NumTelefono" class="form-label">Telefono</label>
                        <input type="Number" class="form-control" id="NumTelefono" required>
                    </div>
                    @*<%--txtCorreo--%>*@
                    <div class="col-md-6">
                        <label for="txtCorreo" class="form-label">Correo</label>
                        <input type="email" class="form-control" id="txtCorreo" required>

                    </div>

                    @*<%--FchNacimiento--%>*@
                    <div class="col-md-6">
                        <label for="FchNacimiento" class="form-label">Fecha Nacimiento</label>
                        <input type="date" class="form-control" id="FchNacimiento" required>

                    </div>

                    @*<%--Float_Beca--%>*@
                    <div class="col-md-6">
                        <label for="Float_Beca" class="form-label">Beca</label>
                        <input type="Number" class="form-control" id="Float_Beca" required>

                    </div>

                    @*<%--txtCarrerasMatriculadas--%>*@
                    <div class="col-md-6">
                        <label for="selCarrera" class="form-label">Carreras Matriculads</label>
                        <select class="form-control" id="selCarrera">
                            <option value="01">RRHH</option>
                            <option value="opcion2">Opción 2</option>
                            <option value="opcion3">Opción 3</option>
                            <option value="opcion4">Opción 4</option>
                        </select>
                    </div>

                    @*<%--txtDireccion--%>*@
                    <div class="col-md-6">
                        <label for="txtDireccion" class="form-label">Direccion exacta</label>
                        <input type="text" class="form-control" id="txtDireccion" required>

                    </div>

                    @*<%--Checkbox--%>*@
                    <div class="col-md-6">
                        <label for="txtDireccion" class="form-label">Direccion exacta</label>
                        <input type="checkbox">
                    </div>
                    <div class="col-md-6">
                        <label for="txtDireccion" class="form-label">Direccion exacta</label>
                        <input type="checkbox">
                    </div>
                    <div class="col-md-6">
                        <label for="txtDireccion" class="form-label">Direccion exacta</label>
                        <input type="checkbox" >
                    </div>
                    <div class="col-md-4">
                        <label for="txtDireccion" class="form-label">Direccion exacta</label>
                        <input type="checkbox">
                    </div>


                    @*<%--Boton cerrar--%>*@
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