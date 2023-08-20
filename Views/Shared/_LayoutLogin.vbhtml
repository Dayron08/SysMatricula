<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>@ViewBag.Title</title>
    <!-- Bootstrap -->
    @Styles.Render("~/Content/Bootstrap/css")
    @Styles.Render("~/Content/css")
    <!--Jquery-->
    @Scripts.Render("~/bundles/jquery")
    <!-- Swweetalert-->
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- Generales-->
    @Scripts.Render("~/bundles/generales")

    <!--Mask-->
    <script src="https://unpkg.com/imask"></script>
</head>

<body class="bg-l">
    @RenderBody()

</body>
<!-- Bootstrap-->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>

<script type="text/javascript">
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
</script>
<!-- FontAwesome -->
<script src="https://kit.fontawesome.com/eddade569a.js" crossorigin="anonymous"></script>




</html>
