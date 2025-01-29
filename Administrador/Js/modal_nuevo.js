document.addEventListener("DOMContentLoaded", function () {
    const seccionDatosPersonales = document.getElementById("seccionDatosPersonales");
    const seccionDatosUsuario = document.getElementById("seccionDatosUsuario");
    const btnSiguiente = document.getElementById("btnSiguiente");
    const btnAtras = document.getElementById("btnAtras");
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
        modal.show();
        validarCampos();
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

    btnAtras.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "block";
        seccionDatosUsuario.style.display = "none";
        btnSiguiente.style.display = "inline-block";
        btnAtras.style.display = "none";
        btnGuardar.style.display = "none";
        modalTitle.textContent = "Datos Personales";
    });

    btnGuardar.addEventListener("click", function () {
       // fetch()
    });

    // Desactivar el botón Guardar al inicio
    btnGuardar.disabled = true;

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
    }


    btnSiguiente.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "none";
        seccionDatosUsuario.style.display = "block";
        btnSiguiente.style.display = "none";
        btnAtras.style.display = "inline-block";
        btnGuardar.style.display = "inline-block";
        btnActualizar.style.display = "none"
        modalTitle.textContent = "Datos de Usuario";

        validarCampos();
    });


    
});
