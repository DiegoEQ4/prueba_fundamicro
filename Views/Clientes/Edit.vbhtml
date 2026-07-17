@ModelType prueba_fundamicro.Clientes

<div class="text-center h-100 w-100 d-flex flex-column justify-content-center align-items-center">
    <h1>Editar Cliente</h1>
    <div class="card my-3">
        <div class="card-body">
            <form method="post" action="/Clientes/Edit">
                <div class="row text-start">
                    <div class="col-6">
                        <input class="form-control" type="text" required name="id" value="@Model.id" hidden readonly/>
                        <label class="form-label fw-bold fs-4">Nombres</label>
                        <input class="form-control" type="text" required name="nombre" value="@Model.nombre"/>
                        @Html.ValidationMessageFor(Function(m) m.Nombre, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-6">
                        <label class="form-label fw-bold fs-4">Apellidos</label>
                        <input class="form-control" type="text" required name="apellido" value="@Model.apellido" />
                        @Html.ValidationMessageFor(Function(m) m.apellido, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="row text-start my-3">
                    <div class="col-12">
                        <label class="form-label fw-bold fs-4">Correo Electronico: </label>
                        <input class="form-control" type="email" placeholder="tucorreo@email.com" name="email" value="@Model.email" required />
                        @Html.ValidationMessageFor(Function(m) m.email, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="row text-start my-3">
                    <div class="col-12">
                        <label class="form-label fw-bold fs-4">Direccion: </label>
                        <textarea class="form-control" style="resize: none;" draggable="false" rows="5" required name="direccion">@Model.direccion</textarea>
                        @Html.ValidationMessageFor(Function(m) m.Direccion, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="row text-start px-4">
                    <div class="col-12">
                        <button class="btn btn-primary w-100 fw-semibold fs-4" type="submit">Actualizar</button>
                        @Html.ActionLink("Cancelar", "Index", "Clientes", Nothing, New With {.class = "btn btn-light w-100 fw-semibold fs-4 my-3"})
                    </div>
                </div>

            </form>
        </div>
    </div>
</div>