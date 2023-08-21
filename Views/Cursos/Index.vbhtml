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
                                        <th scope="col">Nombre</th>
                                        <th scope="col">Creditos</th>
                                        <th scope="col">NotaMinima</th>
                                        <th scope="col">CantidadMin</th>
                                        <th scope="col">CantidadMax</th>
                                        <th scope="col">Grado</th>
                                        <th scope="col">Costo</th>
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
        $.ajax({
            type: "POST",
            url: "/Cursos/getCursos",
            success: (data) => {
                //alert(JSON.stringify(data))

                $.each(data, (i, val) => {
                    $('#listCursos').append("<tr>" +
                        "<td> " + val.Nombre + "</td>" +
                        "<td> " + val.CantidadCreditos + "</td>" +
                        "<td> " + val.NotaMinima + "</td>" +
                        "<td> " + val.CantidadMinima + "</td>" +
                        "<td> " + val.CantidadMaxima + "</td>" +
                        "<td> " + val.Grado + "</td>" +
                        "<td> " + val.Costo + "</td>" +
                        "<td> " + val.Estado + "</td>" +
                        "<td>"+
                        "<a href=\"#\" class=\"btn btn - warning\">"+
                                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"bi bi-pencil-fill\" viewBox=\"0 0 16 16\">"+
                                    "<path d=\"M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z\" />"+
                                "</svg>"+
                            "</a><a href=\"#\" class=\"btn btn-danger\">"+
                                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"bi bi-trash-fill\" viewBox=\"0 0 16 16\">"+
                                    "<path d=\"M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z\" />"+
                        "</svg>" +
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

        if (!getCursos()) {
            return false
        }
    });

</script>