Imports System.Web.Mvc

Namespace Controllers
    Public Class MateriasEstudianteController
        Inherits Controller

        ' GET: MateriasEstudiante
        Function Index() As ActionResult 'funcio de vistas
            Dim sesion_ID_ROL As Integer = Convert.ToInt32(Session("Id_Rol"))

            If sesion_ID_ROL <> 1 Then
                Return RedirectToAction("Index", "Login")
            Else
                Return View()
            End If
        End Function
    End Class
End Namespace