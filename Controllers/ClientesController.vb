<Authorize()>
Public Class ClientesController
    Inherits System.Web.Mvc.Controller

    <HttpGet>
    Function Index() As ActionResult
        Try
            Using clientesService As New ClientesService()
                Dim clientes = clientesService.ListAll()
                Return View(clientes)
            End Using
        Catch ex As Exception
            TempData("Error") = "Ocurrió un error al obtener la lista de clientes: " & ex.Message
            Return View(New List(Of Clientes)())
        End Try
    End Function

    Function AddView() As ActionResult
        Return View("Add")
    End Function

    <HttpPost>
    Function Create(cliente As Clientes) As ActionResult
        If ModelState.IsValid Then
            Try
                Using clientesService As New ClientesService()
                    Dim creado = clientesService.Create(cliente)

                    If creado IsNot Nothing AndAlso creado.id > 0 Then
                        Try
                            Using bitacoraService As New BitacoraService()
                                Dim loged = bitacoraService.Create(creado.id, "CLIENTE CREADO")

                                If loged Then
                                    TempData("Mensaje") = "Cliente creado correctamente."
                                Else
                                    TempData("Mensaje") = "Cliente creado, pero no se registró en bitácora."
                                End If
                            End Using
                        Catch ex As Exception
                            TempData("Error") = "Cliente creado, pero error al guardar bitácora: " & ex.Message
                        End Try
                    End If
                End Using

                Return RedirectToAction("Index")
            Catch ex As Exception
                ModelState.AddModelError("", "Ocurrió un error al crear el cliente: " & ex.Message)
            End Try
        Else
            TempData("Error") = "Datos del formulario inválidos."
        End If

        Return View("Add", cliente)
    End Function

    <HttpPost>
    Public Function Edit(cliente As Clientes) As ActionResult
        Try
            If ModelState.IsValid Then
                Using clientesService As New ClientesService()
                    Dim editado = clientesService.Edit(cliente.id, cliente)

                    If editado Then
                        Try
                            Using bitacoraService As New BitacoraService()
                                Dim loged = bitacoraService.Create(cliente.id, "CLIENTE EDITADO")

                                If loged Then
                                    TempData("Mensaje") = "Cliente editado correctamente."
                                Else
                                    TempData("Mensaje") = "Cliente editado, pero no se registró en bitácora."
                                End If
                            End Using
                        Catch ex As Exception
                            TempData("Error") = "Cliente creado, pero error al guardar bitácora: " & ex.Message
                        End Try
                        Return RedirectToAction("Index", "Clientes")
                    Else
                        ModelState.AddModelError("", "No se encontró el cliente a modificar.")
                    End If
                End Using
            End If
        Catch ex As Exception
            ModelState.AddModelError("", "Ocurrió un error al actualizar: " & ex.Message)
        End Try

        Return View("EditView", cliente)
    End Function


    <HttpGet>
    Public Function EditView(id As Integer) As ActionResult
        Try
            Using clientesService As New ClientesService()
                Dim cliente = clientesService.FindById(id)

                If cliente IsNot Nothing Then
                    Return View("Edit", cliente)
                Else
                    TempData("Error") = "No se encontró el cliente a modificar."
                    Return RedirectToAction("Index")
                End If
            End Using

        Catch ex As Exception
            TempData("Error") = "Ocurrió un error al cargar los datos: " & ex.Message
            Return RedirectToAction("Index")
        End Try
    End Function


    <HttpPost>
    Public Function Remove(id As Integer) As ActionResult
        Try
            If id > 0 Then
                Using clientesService As New ClientesService()
                    Dim removed = clientesService.Remove(id)

                    If removed Then
                        Try
                            Using bitacoraService As New BitacoraService()
                                Dim loged = bitacoraService.Create(id, "CLIENTE ELIMINADO")

                                If loged Then
                                    TempData("Mensaje") = "Cliente eliminado correctamente."
                                Else
                                    TempData("Mensaje") = "Cliente eliminado, pero no se registró en bitácora."
                                End If
                            End Using
                        Catch ex As Exception
                            TempData("Error") = "Cliente eliminado, pero error al guardar bitácora: " & ex.Message
                        End Try
                        Return RedirectToAction("Index", "Clientes")
                    Else
                        TempData("Error") = "No se encontró el cliente a eliminar."
                        Return RedirectToAction("Index", "Clientes")
                    End If
                End Using
            End If
        Catch ex As Exception
            ModelState.AddModelError("", "Ocurrió un error al eliminar: " & ex.Message)
        End Try

        ModelState.AddModelError("", "Error desconocido.")
        Return RedirectToAction("Index", "Clientes")
    End Function
End Class
