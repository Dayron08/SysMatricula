Imports System.Web.Optimization

Public Module BundleConfig
    ' Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(bundles As BundleCollection)
        ' Scripts
        ' Jquery
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-3.6.1.min.js"))
        ' Generales
        bundles.Add(New ScriptBundle("~/bundles/generales").Include(
                    "~/Scripts/Utilities/alertsw.js", "~/Scripts/Utilities/validaciones.js", "~/Scripts/Utilities/maskInput.js"))

        bundles.Add(New ScriptBundle("~/bundles/sidebar").Include("~/Scripts/Utilities/sidebar.js"))

        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        ' Estilos
        ' Bootstrap
        bundles.Add(New StyleBundle("~/Content/Bootstrap/css").Include(
                      "~/Content/Bootstrap/bootstrap.min.css"))
        ' Generales
        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/Site.css"))

        bundles.Add(New StyleBundle("~/Content/sidebar").Include(
                  "~/Content/paginaPrincipal.css", "~/Content/sidebar.css", "~/Content/configDatatable.css"))
    End Sub

End Module

