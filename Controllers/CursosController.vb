Imports System.Collections.Specialized.BitVector32
Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports Newtonsoft.Json.Linq


Namespace Controllers
    Public Class CursosController
        Inherits Controller

        Private db As String = ConfigurationManager.AppSettings("DataBase")


        ' GET: Cursos
        Function Index() As ActionResult
            Dim sesion_ID_ROL As Integer = Convert.ToInt32(Session("Id_Rol"))

            If sesion_ID_ROL <> 1 Then
                Return RedirectToAction("Index", "Login")
            Else
                Return View()
            End If
        End Function


#Region "metodos"
        <HttpPost>
        Public Function getCursos() As ActionResult
            Dim query As New List(Of Object)()

            Using connection As New SqlConnection(db)
                connection.Open()

                Dim sql As String = "SELECT * FROM Cursos"
                Using command As New SqlCommand(sql, connection)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim item As New With {
                            .CodigoCurso = reader("CodigoCurso"),
                            .Nombre = reader("Nombre"),
                            .CantidadCreditos = reader("CantidadCreditos"),
                            .NotaMinima = reader("NotaMinima"),
                            .CantidadMinima = reader("CantidadMinima"),
                            .CantidadMaxima = reader("CantidadMaxima"),
                            .Grado = reader("Grado"),
                            .Estado = reader("Estado"),
                            .Costo = reader("Costo"),
                            .CodigoCarrera = reader("CodigoCarrera")
                        }
                            query.Add(item)
                        End While
                    End Using
                End Using
            End Using

            Return New JsonResult With {
            .Data = query,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }

        End Function


#End Region


    End Class
End Namespace