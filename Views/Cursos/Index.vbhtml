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
                        <h1>Cursos</h1>
                        <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#mod-new">
                            Nuevo
                        </button>
                    </div>
                    <div class="card-body">
                        <div class="col-12">
                            <table class="table table-bordered bg-white " id="tabla">
                                <thead>
                                    <tr>
                                        <th scope="col">NombreCompleto</th>
                                        <th scope="col">Identificación</th>
                                        <th scope="col">Telefono</th>
                                        <th scope="col">Email</th>
                                        <th scope="col">Estado</th>
                                        <th scope="col">Acciones</th>
                                    </tr>
                                </thead>
                                <tbody id="listCursos">
                                   
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
        <footer Class="sticky-footer bg-white">
            <div Class="container my-auto">
                <div Class="copyright text-center my-auto">
                    <span> Copyright &copy; Your Website 2020</span>
                </div>
            </div>
        </footer>
        <!-- End of Footer -->

    </div>
    <!-- End of Content Wrapper -->

</div>
<!-- End of Page Wrapper -->
<!-- Modal -->
<div Class="modal fade" id="mod-new" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div Class="modal-dialog">
        <div Class="modal-content">
            <div Class="modal-header">
                <h1 Class="modal-title fs-5" id="">Nuevo Curso</h1>
                <button type = "button" Class="fa fa-times" data-bs-dismiss="modal" aria-label="Close">
                </button>
            </div>
            <div Class="modal-body">
                <form Class="row g-3">

                    @*<%--txtCodigoCurso--%>*@
                    <div Class="col-md-6">
                        <label for="txtCodigoCurso" class="form-label">Codigo Curso</label>
                        <input type = "text" Class="form-control" id="txtIdentiftxtCodigoCursoicacion" required>

                    </div>

                    @*<%--txtnombre--%>*@
                    <div Class="col-md-6">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <input type = "text" Class="form-control" id="txtNombre" required>

                    </div>



                    @*<%--IntCantCreditos--%>*@
                    <div Class="col-md-6">
                        <label for="IntCantCreditos" class="form-label">Creditos</label>
                        <input type = "Number" Class="form-control" id="IntCantCreditos" required>

                    </div>

                    @*<%--IntNotaMinima--%>*@
                    <div Class="col-md-6">
                        <label for="IntNotaMinima" class="form-label">Nota Minima</label>
                        <input type = "Number" Class="form-control" id="IntNotaMinima" required>

                    </div>

                    @*<%--IntCantidadMinima--%>*@
                    <div Class="col-md-6">
                        <label for="IntCantidadMinima" class="form-label">Cantidad Minima</label>
                        <input type = "Number" Class="form-control" id="IntCantidadMinima" required>

                    </div>

                    @*<%--IntCantidadMaxi--%>*@
                    <div Class="col-md-6">
                        <label for="IntCantidadMaxi" class="form-label">Cantidad Maxima</label>
                        <input type = "Number" Class="form-control" id="IntCantidadMaxi" required>

                    </div>

                    @*<%--TxtGrado--%>*@
                    <div Class="col-md-6">
                        <label for="TxtGrado" class="form-label">Grado</label>
                        <input type = "text" Class="form-control" id="TxtGrado" required>

                    </div>

                    @*<%--IntEstado--%>*@
                    <div Class="col-md-6">
                        <label for="IntEstado" class="form-label">Estado</label>
                        <input type = "Number" Class="form-control" id="IntEstado" required>

                    </div>

                    @*<%--IntCosto--%>*@
                    <div Class="col-md-6">
                        <label for="IntCosto" class="form-label">Costo</label>
                        <input type = "Number" Class="form-control" id="IntCosto" required>

                    </div>




                    <div Class="modal-footer">
                        <button type = "button" Class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <button type = "submit" Class="btn btn-primary">
                            Guardar
                        </button>
                    </div>
                </form>
            </div>

        </div>
    </div>
</div>


<!-- Logout Modal-->
<div Class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div Class="modal-dialog" role="document">
        <div Class="modal-content">
            <div Class="modal-header">
                <h5 Class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                <button Class="close" type="button" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
            </div>
            <div Class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
            <div Class="modal-footer">
                <button Class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                <a Class="btn btn-primary" href="login.html">Logout</a>
            </div>
        </div>
    </div>
</div>

<script>
    $(document).ready(() => {
        if (!getCursos()) {
            return false
        }
    });

</script>