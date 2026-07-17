@ModelType prueba_fundamicro.Usuarios

<div class="text-center h-100 w-100 d-flex flex-column justify-content-center align-items-center">
    <h1>Registrar nuevo usuario</h1>
    <div class="card my-3">
        <div class="card-body">
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            <form method="post" action="Register">
                <div class="row text-start">
                    <div class="col-6">
                        <label class="form-label fw-bold fs-4">Nombre completo</label>
                        <input class="form-control" type="text" required name="nombre_completo" />
                        @Html.ValidationMessageFor(Function(m) m.nombre_completo, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-6">
                        <label class="form-label fw-bold fs-4">Usuario</label>
                        <input class="form-control" type="text" required name="username" />
                        @Html.ValidationMessageFor(Function(m) m.username, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="row text-start my-3">
                    <div class="col-12">
                        <label class="form-label fw-bold fs-4">Contrase&ntilde;a</label>
                        <input class="form-control" type="password" required name="password" />
                    </div>
                </div>

                <div class="row text-start px-4">
                    <div class="col-12">
                        <button class="btn btn-primary w-100 fw-semibold fs-4" type="submit">Registrar</button>
                        @Html.ActionLink("Cancelar", "Login", "Auth", Nothing, New With {.class = "btn btn-light w-100 fw-semibold fs-4 my-3"})
                    </div>
                </div>

            </form>
        </div>
    </div>
</div>
