Imports System.Web.Mvc

Namespace Controllers
    Public Class CursosAbiertosController
        Inherits Controller

        ' GET: CursosAbiertos
        Function Index() As ActionResult
            Dim sesion_ID_ROL As Integer = Convert.ToInt32(Session("Id_Rol"))

            If sesion_ID_ROL <> 1 Then
                Return RedirectToAction("Index", "Login")
            Else
                Return View()
            End If
        End Function
    End Class
End Namespace