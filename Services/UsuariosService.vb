Imports System
Imports System.Linq

Public Class UsuariosService
    Implements IDisposable

    Private ReadOnly _db As New ClientesDbContext()

    Public Sub Dispose() Implements IDisposable.Dispose
        If _db IsNot Nothing Then
            _db.Dispose()
        End If
    End Sub

    Public Function Create(usuario As Usuarios, plainPassword As String) As Usuarios
        Try
            If usuario Is Nothing Then Throw New ArgumentNullException(NameOf(usuario))
            If String.IsNullOrEmpty(plainPassword) Then Throw New ArgumentNullException(NameOf(plainPassword))

            Dim existing = _db.Usuarios.FirstOrDefault(Function(u) u.username = usuario.username)
            If existing IsNot Nothing Then
                Throw New Exception("El nombre de usuario ya existe.")
            End If

            usuario.pass = PasswordHelper.HashPassword(plainPassword)
            _db.Usuarios.Add(usuario)
            _db.SaveChanges()

            Return usuario
        Catch ex As Exception
            Throw New Exception("Error al crear usuario.", ex)
        End Try
    End Function

    Public Function FindByUsername(username As String) As Usuarios
        Try
            If String.IsNullOrEmpty(username) Then Return Nothing
            Return _db.Usuarios.FirstOrDefault(Function(u) u.username = username)
        Catch ex As Exception
            Throw New Exception("Error al buscar usuario.", ex)
        End Try
    End Function

    Public Function ValidateCredentials(username As String, password As String) As Boolean
        Try
            Dim user = FindByUsername(username)
            If user Is Nothing Then Return False
            Return PasswordHelper.VerifyPassword(user.pass, password)
        Catch ex As Exception
            Throw New Exception("Error al validar credenciales.", ex)
        End Try
    End Function

End Class
