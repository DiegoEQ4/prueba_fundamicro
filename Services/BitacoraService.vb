Public Class BitacoraService
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

    Public Function Create(cliente As Integer, action As String, Optional usuario As String = Nothing)

        Try
            If cliente <= 0 Then
                Return False
            End If

            Dim bitacora As Bitacora = New Bitacora()

            bitacora.cliente_id = cliente
            bitacora.action = action
            bitacora.fecha_hora = DateTime.Now
            If String.IsNullOrEmpty(usuario) Then
                Try
                    If System.Web.HttpContext.Current IsNot Nothing AndAlso System.Web.HttpContext.Current.User IsNot Nothing AndAlso System.Web.HttpContext.Current.User.Identity IsNot Nothing Then
                        usuario = System.Web.HttpContext.Current.User.Identity.Name
                    End If
                Catch
                    usuario = Nothing
                End Try
            End If

            If String.IsNullOrEmpty(usuario) Then
                usuario = "NO USUARIO"
            End If

            bitacora.usuario = usuario

            _db.Bitacora.Add(bitacora)
            _db.SaveChanges()

            Return True
        Catch ex As Exception
            Throw New Exception("Error al crear el bitacora.", ex)
        End Try
    End Function

    Public Function ListAll()
        Try
            Return _db.Bitacora.ToList()
        Catch ex As Exception
            Throw New Exception("Error al listar clientes.", ex)
        End Try
    End Function

End Class
