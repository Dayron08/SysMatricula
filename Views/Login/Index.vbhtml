<style>
    #row- {
        max-height: 300px;
        height: 100%;
    }

    #img-lateral {
        background-image: url("../../images/fondoLogin.png");
        background-size: cover;
    }

    #img-login {
        max-height: 60px;
        min-height: 40px;
        max-width: 140px;
        min-width: 120px;
        width: auto;
        height: auto;
    }

    body {
        background: var(--color-w);
    }
</style>

<div class="container p-5" style="height:100vh;">
    <div class="row  " id="row-login">
        <div class="col-12 som-2 col-lg-5 bg-light p-lg-5 p-4 pb-3">
            <div class="encabezado mb-4">
                <h1 class="text-1">Iniciar Sesión</h1>
                <p class="d-none d-lg-block">
                    <small>
                        Ingresa los datos que se solicitan <br>
                        para utilizar nuestro sistema
                    </small>
                </p>
                <hr class="d-lg-none" />
            </div>
            <form action="@Url.Content("~/Login/Login")" method="post">
                <label for="usuario"><i class="fa-solid fa-at"></i> Correo Electrónico</label>
                <input type="email" class="form-control" id="email" name="email" onfocusout="EnviarValidacionEmail('email','msj')" placeholder="nombre@dominio.com" required>

                <label for="contrasena"><i class="fa-solid fa-lock"></i> Contraseña</label>
                <div class="input-group p-0">
                    <input type="password" class="form-control" placeholder="Contraseña mayor a 8 caracteres" name="pass" id="pass" minlength="8" required>
                    <span class="input-group-text bg-white "><i class="fa-regular fa-eye-slash" id="passEye" onclick="EyePass('pass')"></i></span>
                </div>
                <div class="d-grid my-4">
                    <span id="msj" class=" text-small mb-3 d-none"><i class="fa-solid fa-circle-info"></i> El correo ingresado es valido </span>

                    <button type="submit" class="btn btn-outline-light bg-1 ">Ingresar</button>
                    <div class="Registro mt-3 text-center ">
                        <span class="text-a text-small d-block">¿No tienes una cuenta?<a href="@Url.Action("RegistrarUsuario","Login")" class="text-3"> Registrate aquí</a></span>
                        <span class="text-a text-small d-block"><a href="@Url.Action("CambiarContrasena","Login")" class="text-3">¿Olvidaste tu Contraseña?</a></span>

                    </div>

                </div>

            </form>
        </div>

        <div class="col-12 som-2 col-lg-7  bg-1 p-0 d-lg-block d-none" id="img-lateral">
            <div class="p-4 pb-0">
                <img src="~/images/arcavi-white.png" id="img-login" class="my-3">
                <h1 class="display-4">¡Crea una cuenta!</h1>
                <p class="mb-3">Para disfrutar de todos nuestros servicios</p>
                <a href="./Registro.html"></a>
                <a class="btn btn-outline-light px-4" href="@Url.Action("RegistrarUsuario","Login")">Registrarse</a>
            </div>


        </div>
    </div>

</div>
