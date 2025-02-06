document.addEventListener("DOMContentLoaded", function () {
    const seccionDatosPersonales = document.getElementById("seccionDatosPersonales");
    const seccionDatosUsuario = document.getElementById("seccionDatosUsuario");
    const btnSiguiente1 = document.getElementById("btnSiguiente1");
    const btnSiguiente2 = document.getElementById("btnSiguiente2");
    const btnAtras1 = document.getElementById("btnAtras1");
    const btnAtras2 = document.getElementById("btnAtras2");
    const btnGuardar = document.getElementById("btnGuardar");
    const btnActualizar = document.getElementById('btnActualizar');
    const nuevoBtn = document.getElementById('nuevoBtn');
    const closeModalBtn = document.querySelector('.btn-close');
    const modalTitle = document.getElementById("modalUsuarioLabel");
    const inputsDatosPersonales = seccionDatosPersonales.querySelectorAll("input, select");
    const inputsDatosUsuario = seccionDatosUsuario.querySelectorAll("input, select");

    let modalElement = document.getElementById('modalUsuario');
    let modal = new bootstrap.Modal(modalElement);
    

    nuevoBtn.addEventListener('click', function () {
        limpiarCamposModal();
        modalTitle.textContent = "Datos Personales"; // Restablecer título del modal
        btnGuardar.style.display = "none";  // Mostrar botón Guardar
        btnActualizar.style.display = "none";       // Ocultar botón Actualizar
        btnSiguiente1.style.display = "inline-block";
        btnSiguiente2.style.display = "none";
        btnAtras1.style.display = "none";
        btnAtras2.style.display = "none";
        seccionDatosPersonales.style.display = "block";
        seccionDatosUsuario.style.display = "none";
        modal.show();
    });


    
    closeModalBtn.addEventListener('click', function () {
        modal.hide();
    });

    function validarCampos() {
        const todosLlenos = [...inputsDatosPersonales, ...inputsDatosUsuario].every(input => input.value.trim() !== "");
        btnGuardar.disabled = !todosLlenos;
    }

    [...inputsDatosPersonales, ...inputsDatosUsuario].forEach(input => {
        input.addEventListener("input", validarCampos);
    });

    btnAtras1.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "block";
        seccionDatosUsuario.style.display = "none";

        btnSiguiente1.style.display = "inline-block";
        btnSiguiente2.style.display = "none";
        btnAtras1.style.display = "none";
        btnAtras2.style.display = "none";
        btnGuardar.style.display = "none";
        btnActualizar.style.display = "none";

        modalTitle.textContent = "Datos Personales";
    });

    btnAtras2.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "block";
        seccionDatosUsuario.style.display = "none";

        btnSiguiente1.style.display = "none";
        btnSiguiente2.style.display = "inline-block";
        btnAtras1.style.display = "none";
        btnAtras2.style.display = "none";
        btnGuardar.style.display = "none";
        btnActualizar.style.display = "none";

        modalTitle.textContent = "Datos Personales";
    });

    btnGuardar.addEventListener("click", function () {
        const usuario = {
            Username: document.getElementById("username").value,
            Password: document.getElementById("password").value,
            Estado: document.getElementById("activo").value === "Si" ? "1" : "0",
            Email: document.getElementById("email").value,
            Nombres: document.getElementById("nombreUsuario").value,
            Apellidos: document.getElementById("apellidoUsuario").value,
            NroDocumento: document.getElementById("nmroDocumento").value,
            Telefono: document.getElementById("telefono").value,
            FechaNacimiento: document.getElementById("fNacimiento").value,
            LugarNacimiento: document.getElementById("lNacimiento").value,
            Direccion: document.getElementById("direccion").value,
            TipoDoc: {
                IdTipoDoc: document.getElementById("tipoDocumento").value
            },
            Roles: [{
                IdRol: document.getElementById("rolUsuario").value
            }]

        };

        fetch('/User/SaveUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(usuario)
        })
            .then(response => response.json())
            .then(data => {
                if (data) {
                    showSuccessModal();
                    $('#modalUsuario').modal('hide');
                    fetch('/User/ListarUsuarios', {
                        method: 'GET',
                    })
                        .then(response => response.json())
                        .then(data => {
                            gridOptions.api.setRowData(data);
                        })
                        .catch(error => console.error('Error al cargar los datos:', error));
                } else {
                    alert("Error al guardar el usuario");
                }
            })

            .catch(error => console.error('Error:', error));

       
    });



    // Desactivar el botón Guardar al inicio
    btnGuardar.disabled = true;
    btnActualizar.disabled = true;

    // Función para limpiar los campos del modal
    function limpiarCamposModal() {
        document.getElementById('tipoDocumento').value = "";
        document.getElementById('nmroDocumento').value = "";
        document.getElementById('nombreUsuario').value = "";
        document.getElementById('apellidoUsuario').value = "";
        document.getElementById('lNacimiento').value = "";
        document.getElementById('fNacimiento').value = "";
        document.getElementById('direccion').value = "";
        document.getElementById('rolUsuario').value = "";
        document.getElementById('email').value = "";
        document.getElementById('username').value = "";
        document.getElementById('password').value = "";
        document.getElementById('activo').value = "";
        btnGuardar.style.display = "none";  // Mostrar botón Guardar
        btnActualizar.style.display = "none";       // Ocultar botón Actualizar
    }


    btnSiguiente1.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "none";
        seccionDatosUsuario.style.display = "block";

        btnSiguiente1.style.display = "none";
        btnSiguiente2.style.display = "none";
        btnAtras1.style.display = "inline-block";
        btnAtras2.style.display = "none";
        btnGuardar.style.display = "inline-block";
        btnActualizar.style.display = "none";

        modalTitle.textContent = "Datos de Usuario";

        validarCampos();
    });

    btnSiguiente2.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "none";
        seccionDatosUsuario.style.display = "block";

        btnSiguiente1.style.display = "none";
        btnSiguiente2.style.display = "none";
        btnAtras1.style.display = "none";
        btnAtras2.style.display = "inline-block";
        btnGuardar.style.display = "none";
        btnActualizar.style.display = "inline-block";

        modalTitle.textContent = "Datos de Usuario";

        validarCampos();
    });

    function showSuccessModal() {
        var myModal = new bootstrap.Modal(document.getElementById('successModal'));
        myModal.show();
    }
    
});
