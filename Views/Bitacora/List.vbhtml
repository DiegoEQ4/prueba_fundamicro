@ModelType IEnumerable(Of prueba_fundamicro.Bitacora)


<div class="container mt-4">
    
<div class="d-flex justify-content-between align-items-center mb-3">
    <h2>Bitacora</h2>
    @Html.ActionLink("Volver", "Index", "Clientes", Nothing, New With {.class = "btn btn-danger"})

</div>
<div class="card shadow-sm">
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table table-hover mb-0">
                <thead class="table-primary">
                    <tr>
                        <th scope="col" class="px-4">ID</th>
                        <th scope="col">Accion</th>
                        <th scope="col">Cliente</th>
                        <th scope="col" >Fecha y hora realizada</th>
                        <th scope="col">Usuario realizo</th>
                    </tr>
                </thead>
                <tbody>
                    @If Model IsNot Nothing AndAlso Model.Any() Then
                        @For Each item In Model
                            @<tr>
                                <td class="align-middle">@item.id</td>
                                <td class="align-middle fw-bold">@item.action</td>
                                <td class="align-middle">@item.cliente_id</td>
                                <td class="align-middle">@item.fecha_hora</td>
                                <td class="align-middle">
                                    @item.usuario
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