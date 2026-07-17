<div class="d-flex h-100 d-flex justify-content-center align-items-center">
    <div class="card w-50">
        <div class="card-header text-center text-white bg bg-primary">
            <h2>Inicia sesion</h2>
        </div>
        <div class="card-body">

            @If TempData("Mensaje") IsNot Nothing Then
                @<div class="alert alert-danger">@TempData("Mensaje")</div>
            End If
            <form action="/Auth/ActionLogin" method="POST">
                <div class="p-2">
                    <label class="form-label" for="username">Nombre de usuario:</label>
                    <input class="w-100 form-control" type="text" name="username" id="username" />
                </div>
                <div class="p-2">
                    <label class="form-label" for="pass">Contrase&ntilde;a:</label>
                    <input class="form-control" type="password" id="pass" name="pass" />
                </div>
                <div class="p-2 d-flex justify-content-center">
                    <button class="btn btn-primary w-100" type="submit">Ingresar</button>
                </div>
                <div class="p-1 text-center">
                    @Html.ActionLink("Registrarse", "Register", "Auth", Nothing, New With {.class = "small text-decoration-underline"})
                </div>
            </form>
        </div>
    </div>
</div>