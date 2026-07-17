Imports System.Web.Security

Public Class AuthController
    Inherits System.Web.Mvc.Controller

    <HttpGet>
    <AllowAnonymous()>
    Function Login() As ActionResult
        ViewBag.loged = False

        Return View()
    End Function

    <HttpPost>
    <AllowAnonymous()>
    Public Function ActionLogin(username As String, pass As String) As ActionResult
        Try
            Using service As New UsuariosService()
                If service.ValidateCredentials(username, pass) Then
                    FormsAuthentication.SetAuthCookie(username, False)
                    Return RedirectToAction("Index", "Clientes")
                Else
                    TempData("Mensaje") = "Usuario o contraseña inválidos."
                    ModelState.AddModelError("", "")
                    Return View("Login")
                End If
            End Using
        Catch ex As Exception
            ModelState.AddModelError("", "Error al autenticar: " & ex.Message)
            Return View("Login")
        End Try
    End Function

    <HttpGet>
    <AllowAnonymous()>
    Public Function Register() As ActionResult
        Return View()
    End Function

    <HttpPost>
    <AllowAnonymous()>
    Public Function Register(user As Usuarios, password As String) As ActionResult
        If ModelState.IsValid Then
            Try
                Using service As New UsuariosService()
                    Dim creado = service.Create(user, password)
                    FormsAuthentication.SetAuthCookie(user.username, False)
                    Return RedirectToAction("Index", "Clientes")
                End Using
            Catch ex As Exception
                ModelState.AddModelError("", "Error al registrar: " & ex.Message)
            End Try
        End If
        Return View("Register", user)
    End Function

    Public Function Logout() As ActionResult
        FormsAuthentication.SignOut()
        Return RedirectToAction("Login")
    End Function

End Class
