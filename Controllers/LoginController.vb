Imports System.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Microsoft.Ajax.Utilities

Namespace Controllers
    Public Class LoginController
        Inherits Controller
        Private db As String = ConfigurationManager.AppSettings("DataBase")
        ' GET: Login
        Function Index() As ActionResult
            Return View()
        End Function

        Function CambioContrasena() As ActionResult
            Dim sesion_ID_ROL As Integer = Convert.ToInt32(Session("Id_Rol"))

            If sesion_ID_ROL <> 1 Then
                Return RedirectToAction("Index", "Login")
            Else
                Return View()
            End If
        End Function

#Region "metodos"
        <HttpPost>
        Public Function CambiarContrasena(correo As String, contrasena As String) As ActionResult

            Using connection As New SqlConnection(db)
                    connection.Open()

                    Dim updateQuery As String = "UPDATE Funcionarios SET Clave = @Clave WHERE Correo = @Correo"
                    Dim updateCommand As New SqlCommand(updateQuery, connection)
                    updateCommand.Parameters.AddWithValue("@Correo", correo)
                    updateCommand.Parameters.AddWithValue("@Clave", contrasena)

                    Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()
                    Session("Msj") = 0
                    Return RedirectToAction("Index", "Login")
                End Using

        End Function

        <HttpPost>
        Public Function Login(email As String, pass As String) As ActionResult
            ViewBag.Title = "Menu Principal"
            Try
                Dim tEmail As String = email.Trim()
                Dim tPass As String = pass.Trim()

                ' Encriptar contraseña

                ' Usamos la base de datos
                Using con As New SqlConnection(db)
                    con.Open()

                    Dim queryValEmail As String = "SELECT * FROM Funcionarios WHERE Correo = @Correo and Clave = @Clave"
                    Using cmdValEmail As New SqlCommand(queryValEmail, con)
                        cmdValEmail.Parameters.AddWithValue("@Correo", tEmail)
                        cmdValEmail.Parameters.AddWithValue("@Clave", tPass)
                        Dim valEmailReader As SqlDataReader = cmdValEmail.ExecuteReader()
                        If valEmailReader.HasRows Then
                            valEmailReader.Close()
                            Session("Msj") = 2
                            Session("Id_Rol") = 1
                            Return RedirectToAction("Index", "Inicio")

                        Else
                            valEmailReader.Close()
                            Session("Msj") = 0
                            Session("Alert") = 0
                            Return RedirectToAction("Index", "Inicio")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Session("Error") = ex
                Return RedirectToAction("Error", "Home")
            End Try
        End Function

        Public Function Logout() As ActionResult
            Session("Msj") = 0

            Return Redirect("Index")
        End Function

#End Region

    End Class
End Namespace