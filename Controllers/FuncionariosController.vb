Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports Microsoft.Ajax.Utilities

Namespace Views
    Public Class FuncionariosController
        Inherits Controller
        Private db As String = ConfigurationManager.AppSettings("DataBase")
        ' GET: Funcionarios
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
        Public Function getFuncionarios() As ActionResult
            Dim query As New List(Of Object)()

            Using connection As New SqlConnection(db)
                connection.Open()

                Dim sql As String = "SELECT * FROM Funcionarios"
                Using command As New SqlCommand(sql, connection)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim item As New With {
                                .Identificacion = reader("Identificacion"),
                                .Nombre = reader("Nombre"),
                                .Apellido1 = reader("Apellido1"),
                                .Apellido2 = reader("Apellido2"),
                                .Correo = reader("Correo"),
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


        <HttpPost>
        Public Function Delete(data As Funcionarios) As Integer
            Dim blbandera As Integer = 0
            Try
                Dim response As Integer = 0
                Using connection As New SqlConnection(db)
                    connection.Open()

                    Dim sql As String = "DELETE FROM Funcionarios WHERE Identificacion = @Identificacion"
                    Dim deleteCommand As New SqlCommand(sql, connection)
                    deleteCommand.Parameters.AddWithValue("@Identificacion", data.Identificacion)
                    Dim rowsAffected As Integer = deleteCommand.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        blbandera = 1
                    Else
                        blbandera = 0
                    End If
                End Using
            Catch ex As Exception
                blbandera = 0
            End Try
            Return blbandera
        End Function




#End Region
    End Class
End Namespace