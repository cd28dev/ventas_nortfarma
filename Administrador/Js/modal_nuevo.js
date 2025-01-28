
    document.addEventListener("DOMContentLoaded", function () {
        const seccionDatosPersonales = document.getElementById("seccionDatosPersonales");
        const seccionDatosUsuario = document.getElementById("seccionDatosUsuario");
        const btnSiguiente = document.getElementById("btnSiguiente");
        const btnAtras = document.getElementById("btnAtras");
        const btnGuardar = document.getElementById("btnGuardar");
        const modalTitle = document.getElementById("modalUsuarioLabel");

        // Todos los inputs de ambas secciones
        const inputsDatosPersonales = seccionDatosPersonales.querySelectorAll("input, select");
        const inputsDatosUsuario = seccionDatosUsuario.querySelectorAll("input, select");

    // Función para verificar si todos los campos están completos
    function validarCampos() {
            const todosLlenos = [...inputsDatosPersonales, ...inputsDatosUsuario].every(input => input.value.trim() !== "");
    btnGuardar.disabled = !todosLlenos;
        }

        // Agregar evento 'input' para validar mientras el usuario escribe
        [...inputsDatosPersonales, ...inputsDatosUsuario].forEach(input => {
        input.addEventListener("input", validarCampos);
        });

    btnSiguiente.addEventListener("click", function () {
        seccionDatosPersonales.style.display = "none";
        seccionDatosUsuario.style.display = "block";
        btnSiguiente.style.display = "none";
        btnAtras.style.display = "inline-block";
        btnGuardar.style.display = "inline-block";
        modalTitle.textContent = "Datos de Usuario";

        // Verificar si el botón Guardar debe activarse
        validarCampos();
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
        alert("Usuario guardado correctamente!");
            // Aquí puedes agregar la lógica para guardar los datos
        });

    // Desactivar el botón Guardar al inicio
    btnGuardar.disabled = true;
    });

