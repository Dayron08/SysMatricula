<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>ArcaviCloud | @ViewBag.Title</title>
    <!--Datatables-->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.2.0/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/responsive/2.3.0/css/responsive.dataTables.min.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css">
    <!-- Bootstrap -->
    @Styles.Render("~/Content/Bootstrap/css")
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/sidebar")

    <!--Jquery-->
    @Scripts.Render("~/bundles/jquery")

    <!--Mask-->
    <script src="https://unpkg.com/imask"></script>


    <!-- Swweetalert-->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- Generales-->
    @Scripts.Render("~/bundles/generales")
    @Styles.Render("~/bundles/sidebar")

</head>
<style>
    .empresaSelect {
        width: 50% !important;
    }

    #empresas {
        height: auto;
        overflow: auto;
        max-height: 130px;
    }
        /*ScroolBar*/
        #empresas::-webkit-scrollbar {
            width: 4px; /* Tamaño del scroll en vertical */
            height: 7px; /* Tamaño del scroll en vertical */
        }

        #empresas::-webkit-scrollbar-thumb {
            background: #aaa;
            border-radius: 7px;
        }

            #empresas::-webkit-scrollbar-thumb:hover {
                background: #b3b3b3;
                box-shadow: 0 0 2px 1px rgba(0, 0, 0, 0.2);
            }

            #empresas::-webkit-scrollbar-thumb:active {
                background-color: #999999;
            }

        #empresas::-webkit-scrollbar-track {
            background: #e1e1e1;
            border-radius: 4px;
        }

            #empresas::-webkit-scrollbar-track:hover,
            #empresas::-webkit-scrollbar-track:active {
                background: #d4d4d4;
            }

    #nombreEmpresa:disabled {
        background: #fff;
    }

    @@media only screen and (max-width: 600px) {
        .empresaSelect {
            width: 75% !important;
        }
    }
</style>





<body class="bg-l">
    <!-- Sidebar -->
    <div class="sidebar bg-2" id="sidebar">
        <!-- Encabezado -->
        <div class="sidebar-header bg-2 p-3 pb-1">
            <h3 class="text-white mb-0">Sistema<span class="text-4 titulo mb-0"> <br> Matr&iacute;cula <i class="fa-solid fa-square" style="font-size: 12px;"></i></span></h3>
            <hr>
        </div>
        <div class="sidebar-body">
            <ul>
                <li class="sidebar-title-header text-4">Acciones</li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "Inicio")" class="sd-lg-7">
                        @*<i class="fa-solid fa-file-lines"></i>*@
                        Inicio
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "Estudiantes")" class="sd-lg-7">
                        @*<i class="fa-solid fa-ticket"></i>*@
                        Estudiantes
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "Funcionarios")" class="sd-lg-3">
                        @*<i class="fa-solid fa-reply"></i>*@
                        Funcionarios
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "Cursos")" class="sd-lg-3">
                        @*<i class="fa-regular fa-share-from-square"></i>*@
                        Cursos
                    </a>
                </li>

                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "Carreras")" class="sd-lg-2">
                        @*<i class="fa-solid fa-money-check"></i>*@
                        Carreras
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "CursosAbiertos")">
                        @*<i class="fa-solid fa-cash-register"></i>*@
                        Cursos abiertos
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "MateriasEstudiante")">
                        @*<i class="fa-solid fa-cash-register"></i>*@
                        Materias Estudiante
                    </a>
                </li>
                <li class="sidebar-title-header text-4">Otros</li>
                <li class="sidebar-item">
                    <a href="@Url.Action("Index", "Acercade")">
                        @*<i class="fa-solid fa-cash-register"></i>*@
                        Acerca de
                    </a>
                </li>
            </ul>
        </div>
    </div>
    <div class="main p-0" id="main">
        <!--Navigation-->
        <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
            <div class="container-fluid" id="navbar-content-link">


                <button class="navbar-toggler rounded-circle" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span><i class="fa-solid fa-bars"></i></span>
                </button>

                <a class="dropdown-item" href="@Url.Action("Logout", "Login")">Cerrar Sesión <i class="fa-solid fa-arrow-right-from-bracket"></i></a>

            </div>
        </nav>
        <!-- Contenido Pagina -->
        @RenderBody()
    </div>
</body>

<!-- Bootstrap-->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>

<script type="text/javascript">
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
</script>

<!-- FontAwesome -->
<script src="https://kit.fontawesome.com/eddade569a.js" crossorigin="anonymous"></script>
<!-- Sidebar-->
@Scripts.Render("~/bundles/sidebar")

<!--Datatable-->
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/responsive/2.3.0/js/dataTables.responsive.min.js
"></script>
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
<script src="~/Scripts/Funciones/Cursos.js"></script>






</html>

























