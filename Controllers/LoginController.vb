Imports System.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        ' GET: Login
        Function Index() As ActionResult
            Return View()
        End Function

        Function CambioContrasena() As ActionResult
            Return View()
        End Function
    End Class
End Namespace