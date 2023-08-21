Imports System.Collections.Specialized.BitVector32
Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports Newtonsoft.Json.Linq

Namespace Controllers
    Public Class CarrerasController
        Inherits Controller
        Private db As String = ConfigurationManager.AppSettings("DataBase")
        ' GET: Carreras
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
        Public Function getCarreras() As ActionResult
            Dim query As New List(Of Object)()

            Using connection As New SqlConnection(db)
                connection.Open()

                Dim sql As String = "SELECT * FROM Carrera"
                Using command As New SqlCommand(sql, connection)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim item As New With {
                                .CodigoCarrera = reader("CodigoCarrera"),
                                .NombreCarrera = reader("NombreCarrera"),
                                .GradoCarrera = reader("GradoCarrera"),
                                .Estado = reader("Estado")
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