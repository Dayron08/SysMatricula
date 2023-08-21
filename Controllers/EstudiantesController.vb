Imports System.Data.SqlClient

Namespace Controllers
    Public Class EstudiantesController
        Inherits Controller
        Private db As String = ConfigurationManager.AppSettings("DataBase")

        ' GET: Estudiantes
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
        Public Function getEstudiantes() As ActionResult
            Dim query As New List(Of Object)()

            Using connection As New SqlConnection(db)
                connection.Open()

                Dim sql As String = "SELECT e.Identificacion
      ,e.Carnet
      ,e.Nombre
      ,e.Apellidos
      ,e.Telefono
      ,e.Correo
      ,e.FechaNac
      ,e.Beca
      ,e.Direccion
      ,e.Estado
	  ,ca.NombreCarrera
FROM dbo.Estudiantes e
INNER JOIN dbo.Matricula m ON e.Identificacion = m.Identificacion
INNER JOIN dbo.CursosMatricula cm ON cm.IdMatricula = m.IdMatricula
INNER JOIN dbo.Cursos c ON cm.CodigoCurso = c.CodigoCurso
INNER JOIN dbo.Carrera ca ON c.CodigoCarrera = ca.CodigoCarrera"
                Using command As New SqlCommand(sql, connection)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim item As New With {
                                .Identificacion = reader("Identificacion"),
                                .Carnet = reader("Carnet"),
                                .Nombre = reader("Nombre"),
                                .Apellidos = reader("Apellidos"),
                                .Telefono = reader("Telefono"),
                                .Correo = reader("Correo"),
                                .FechaNac = reader("FechaNac"),
                                .Beca = reader("Beca"),
                                .Direccion = reader("Direccion"),
                                .Estado = reader("Estado"),
                                .NombreCarrera = reader("NombreCarrera")
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
        Public Function Create(txtIdentificacion As String, txtCarnet As String, txtNombre As String, txtapellidos As String, NumTelefono As String, txtCorreo As String, FchNacimiento As Date, Float_Beca As Decimal, selCarrera As String, txtDireccion As String) As ActionResult
            Try
                Dim response As Integer = 0
                Using connection As New SqlConnection(db)
                    connection.Open()

                    Dim sql As String = "INSERT INTO Estudiantes VALUES (@Identificacion, @Carnet, @Nombre, @Apellidos, @Telefono, @Correo, @FechaNac, @Beca, @Direccion, @Estado)"
                    Dim insertCommand As New SqlCommand(sql, connection)
                    insertCommand.Parameters.AddWithValue("@Identificacion", txtIdentificacion)
                    insertCommand.Parameters.AddWithValue("@Carnet", txtCarnet)
                    insertCommand.Parameters.AddWithValue("@Nombre", txtNombre)
                    insertCommand.Parameters.AddWithValue("@Apellidos", txtapellidos)
                    insertCommand.Parameters.AddWithValue("@Telefono", NumTelefono)
                    insertCommand.Parameters.AddWithValue("@Correo", txtCorreo)
                    insertCommand.Parameters.AddWithValue("@FechaNac", FchNacimiento)
                    insertCommand.Parameters.AddWithValue("@Beca", Float_Beca)
                    insertCommand.Parameters.AddWithValue("@Direccion", txtDireccion)
                    insertCommand.Parameters.AddWithValue("@Estado", 0)

                    If 1 > 0 Then
                        Session("Msj") = 1
                    Else
                        Session("Msj") = 2
                    End If
                End Using

                Return Redirect("Index")
            Catch ex As Exception
                Session("Error") = ex
                Return RedirectToAction("Error", "Home")
            End Try
        End Function



#End Region
    End Class
End Namespace