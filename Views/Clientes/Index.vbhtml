@ModelType IEnumerable(Of prueba_fundamicro.Clientes)


<div class="container mt-4">

    @If TempData("Mensaje") IsNot Nothing Then
        @<div class="alert alert-success">@TempData("Mensaje")</div>
    End If

    @If TempData("Error") IsNot Nothing Then
        @<div class="alert alert-danger">@TempData("Error")</div>
    End If

    <div class="d-flex justify-content-end align-items-end mb-3">
        @Html.ActionLink("Cerrar Sesion", "Logout", "Auth", Nothing, New With {.class = "btn btn-danger fw-semibold"})
    </div>

    <div class="d-flex justify-content-between align-items-center mb-3">
        <h2>Clientes</h2>
        @Html.ActionLink("Agregar Nuevo Cliente", "AddView", Nothing, New With {.class = "btn btn-primary fw-semibold"})
        @Html.ActionLink("Bitacora de acciones", "Index", "Bitacora", Nothing, New With {.class = "btn btn-info text-white my-3"})
    </div>


    @If ViewBag.ErrorMessage IsNot Nothing Then
        @<div class="alert alert-danger" role="alert">
            @ViewBag.ErrorMessage
        </div>
    End If

    <div class="card shadow-sm">
        <div class="card-body p-0">
            <div class="table-responsive">
                <table class="table table-hover mb-0">
                    <thead class="table-primary">
                        <tr>
                            <th scope="col" class="px-4">ID</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Correo Electrónico</th>
                            <th scope="col" class="text-center">Direccion</th>
                            <th scope="col" class="text-center px-4">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        @If Model IsNot Nothing AndAlso Model.Any() Then
                            @For Each item In Model
                                @<tr>
                                    <td class="px-4 align-middle">@item.id</td>
                                    <td class="align-middle fw-bold">@item.nombre @item.apellido</td>
                                    <td class="align-middle">@item.email</td>
                                    <td class="align-middle">@item.direccion</td>
                                    <td class="text-center align-middle px-4">
                                        @Html.ActionLink("Editar", "EditView", New With {.id = item.id}, New With {.class = "btn btn-sm btn-warning me-1"})
                                        @Using Html.BeginForm("Remove", "Clientes", New With {.id = item.id}, FormMethod.Post, New With {.style = "display:inline;"})
                                            @<button type="submit" Class="btn btn-sm btn-danger" onclick="return confirm('¿De verdad deseas eliminar este cliente?');">
                                                Eliminar
                                            </button>
                                        End Using
                                    </td>
                                </tr>
                            Next
                        Else
                            @<tr>
                                <td colspan="5" class="text-center py-4 text-muted">
                                    No hay clientes registrados en este momento.
                                </td>
                            </tr>
                        End If
                    </tbody>
                </table>
            </div>
        </div>

    </div>
</div>