<Authorize()>
Public Class BitacoraController
    Inherits System.Web.Mvc.Controller

    <HttpGet>
    Function Index() As ActionResult
        Try
            Using bitacoraService As New BitacoraService()
                Dim bitacoras = bitacoraService.ListAll()
                Return View("List", bitacoras)
            End Using
        Catch ex As Exception
            TempData("Error") = "Ocurrió un error al obtener la lista de acciones: " & ex.Message
            Return View("List", New List(Of Bitacora)())
        End Try
    End Function
End Class
