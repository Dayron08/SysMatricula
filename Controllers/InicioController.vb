Imports System.Web.Mvc

Namespace Controllers
    Public Class InicioController
        Inherits Controller

        ' GET: Inicio
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace