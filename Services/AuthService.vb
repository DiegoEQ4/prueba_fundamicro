Public Class AuthService
    Implements IDisposable

    Private ReadOnly _db As New ClientesDbContext()
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                If _db IsNot Nothing Then
                    _db.Dispose()
                End If
            End If
            disposedValue = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Dispose(False)
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Function Login(usuario As String, password As String)
        Dim usuarioDB = _db.Usuarios.FirstOrDefault(Function(u) u.username = usuario AndAlso u.pass = password)

    End Function
End Class
