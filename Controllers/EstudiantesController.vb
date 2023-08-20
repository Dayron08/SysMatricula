Imports System.Web.Mvc

Namespace Controllers
    Public Class EstudiantesController
        Inherits Controller

        ' GET: Estudiantes
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace