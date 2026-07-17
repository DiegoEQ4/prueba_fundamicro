Public Class ClientesService
    Implements IDisposable

    Public Sub Dispose() Implements IDisposable.Dispose
        If _db IsNot Nothing Then
            _db.Dispose()
        End If
    End Sub

    Private ReadOnly _db As New ClientesDbContext()

    Public Function ListAll()
        Try
            Return _db.Clientes.ToList()
        Catch ex As Exception
            Throw New Exception("Error al listar clientes.", ex)
        End Try
    End Function

    Public Function Create(cliente As Clientes)
        Try
            If cliente Is Nothing Then Throw New ArgumentNullException(NameOf(cliente))
            _db.Clientes.Add(cliente)
            _db.SaveChanges()

            Return cliente
        Catch ex As Exception
            Throw New Exception("Error al crear el cliente.", ex)
        End Try
    End Function

    Public Function FindById(id_cliente As Integer)
        If id_cliente <= 0 Then
            Return Nothing
        End If

        Try
            Dim clienteOriginal As Clientes = _db.Clientes.Find(id_cliente)
            Return clienteOriginal
        Catch ex As Exception
            Throw New Exception("Error al buscar el cliente por id.", ex)
        End Try

    End Function

    Public Function Edit(id_cliente As Integer, cliente As Clientes)
        If id_cliente <= 0 OrElse cliente Is Nothing Then
            Return False
        End If

        Try
            Dim clienteOriginal As Clientes = FindById(id_cliente)

            If clienteOriginal IsNot Nothing Then

                clienteOriginal.nombre = cliente.nombre
                clienteOriginal.apellido = cliente.apellido
                clienteOriginal.direccion = cliente.direccion
                clienteOriginal.email = cliente.email

                _db.SaveChanges()

                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception("Error al editar el cliente.", ex)
        End Try

    End Function

    Public Function Remove(id_cliente As Integer) As Boolean
        If id_cliente <= 0 Then
            Return False
        End If
        Try
            Dim clienteOriginal As Clientes = FindById(id_cliente)

            If clienteOriginal IsNot Nothing Then
                _db.Clientes.Remove(clienteOriginal)
                _db.SaveChanges()
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception("Error al eliminar el cliente.", ex)
        End Try
    End Function

End Class
