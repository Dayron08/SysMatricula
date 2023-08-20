@Code
    'codigo que al iniciar el programa permite el acceso solamente y depende del estado del login da acceso'
    Dim sesion_ID_ROL As Integer = Convert.ToInt32(Session("Id_ROL"))
    Select Case sesion_ID_ROL
        Case 1
            'Aun no tiene acceso
            Layout = "~/Views/Shared/_Layout.vbhtml"
        Case 2
            'Usuario Admin
            Layout = "~/Views/Shared/_LayoutAdmin.vbhtml"
        Case 3
            'Usuario
            Layout = "~/Views/Shared/_LayoutLogin.vbhtml"
        Case Else
            'Usuario no logueado
            Layout = "~/Views/Shared/_Layout.vbhtml"
    End Select
End Code
