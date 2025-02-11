import { fetchUsers, fetchUserDetails, fetchDeleteUser,fetchSaveUser, fetchUpdateUser,fetchListRoles, fetchListTd } from './apiUser.js';
import { grid, gridOptions } from './gridUser.js';

// modal.js
export function showModal(data) {
    let modalElement = document.getElementById('modalUsuario');
    let modal = new bootstrap.Modal(modalElement);
    fetchListRoles()
        .then(d => {
            let select = document.getElementById("rolUsuario");
            select.innerHTML = '<option value=""></option>';
            d.forEach(rol => {
                let option = document.createElement("option");
                option.value = rol.IdRol;
                option.textContent = rol.NameRol;
                select.appendChild(option);
            });

            select.value = data.Roles[0].IdRol;
        })

    fetchListTd()
        .then(d => {
            let select = document.getElementById("tipoDocumento");
            select.innerHTML = '<option value=""></option>';
            d.forEach(td => {
                let option = document.createElement("option");
                option.value = td.IdTipoDoc;
                option.textContent = td.Nombre;
                select.appendChild(option);
            });
            console.log(data.TipoDoc.IdTipoDoc);
            select.value = data.TipoDoc.IdTipoDoc;
        })


    showBtnUpdate();
    llenarFields(data);
    modal.show();
}

export function showModalContact(data) {
    let modalElement = document.getElementById('userModal');
    let modal = new bootstrap.Modal(modalElement);
    let fecha = new Date(parseInt(data.FechaNacimiento.replace(/\/Date\((.*?)\)\//, "$1")));
    let fechaFormateada = fecha.toISOString().split('T')[0];

    document.getElementById("userName").textContent = data.Nombres + " " +data.Apellidos;
    document.getElementById("userGender").textContent = data.Sexo === 'F' ? 'Femenino' : 'Masculino';
    document.getElementById("userTipoDocumento").textContent = data.TipoDoc.Nombre;
    document.getElementById("userNumeroDocumento").textContent = data.NroDocumento;
    document.getElementById("userEmail").textContent = data.Email;
    document.getElementById("userPhone").textContent = data.Telefono;
    document.getElementById("userDireccion").textContent = data.Direccion;
    document.getElementById("userLnacimiento").textContent = data.LugarNacimiento;
    document.getElementById("userFnacimiento").textContent = fechaFormateada;

    // Icono dinámico según género
    let icono = document.getElementById("userIcon");

    // Asegurar que el icono es un elemento válido
    if (icono) {
        if (data.Sexo === 'M') {
            icono.setAttribute("class", "fas fa-male text-primary fa-6x"); // Azul para hombres
        } else if (data.Sexo === 'F') {
            icono.setAttribute("class", "fas fa-female text-danger fa-6x"); // Rojo para mujeres
        } else {
            icono.setAttribute("class", "fas fa-user-circle fa-6x"); // Default
        }
    }

    modal.show();
}

export function llenarFields(data) {
    let fecha = new Date(parseInt(data.FechaNacimiento.replace(/\/Date\((.*?)\)\//, "$1")));
    let fechaFormateada = fecha.toISOString().split('T')[0];

    document.getElementById('hiddenPersonId').value = data.IdPersona
    document.getElementById('hiddenUserId').value = data.IdUsuario
    /*document.getElementById('tipoDocumento').value = data.TipoDoc.IdTipoDoc;*/
    document.getElementById('sexo').value = data.Sexo;
    document.getElementById('nmroDocumento').value = data.NroDocumento;
    document.getElementById('nombreUsuario').value = data.Nombres;
    document.getElementById('apellidoUsuario').value = data.Apellidos;
    document.getElementById('lNacimiento').value = data.LugarNacimiento;
    document.getElementById('fNacimiento').value = fechaFormateada;
    document.getElementById('direccion').value = data.Direccion;
    document.getElementById('email').value = data.Email;
    document.getElementById('username').value = data.Username;
    document.getElementById('activo').value = data.Estado;
    document.getElementById('telefono').value = data.Telefono;
    
}

export function cambiarMensajeModal(id) {
    let modalBody = document.querySelector('.modal-body');
    if (modalBody) {
        modalBody.innerHTML = `¿Estás seguro de que deseas eliminar al usuario con dni <strong>${id}</strong>?`;
    }
}

function showBtnUpdate() {
    const seccionDatosPersonales = document.getElementById("seccionDatosPersonales");
    const seccionDatosUsuario = document.getElementById("seccionDatosUsuario");
    const btnSave = document.getElementById('btnGuardar');
    const btnUpdate = document.getElementById('btnActualizar');
    const btnSiguiente2 = document.getElementById("btnSiguiente2");
    const btnSiguiente1 = document.getElementById("btnSiguiente1");
    const btnAtras2 = document.getElementById("btnAtras2");
    const btnAtras1 = document.getElementById("btnAtras1");
    const modalTitle = document.getElementById("modalUsuarioLabel");

    seccionDatosPersonales.style.display = "block";
    seccionDatosUsuario.style.display = "none";

    btnSiguiente2.style.display = "inline-block";
    btnSiguiente1.style.display = "none";
    btnAtras2.style.display = "none";
    btnAtras1.style.display = "none";

    btnSave.style.display = "none";
    btnUpdate.style.display = "none";

    modalTitle.textContent = "Datos Personales"; // Restablecer título
}

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
    document.getElementById('activo').value = "";
    btnGuardar.style.display = "none";  // Mostrar botón Guardar
    btnActualizar.style.display = "none";       // Ocultar botón Actualizar
}

document.addEventListener('DOMContentLoaded', function () {
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
    const gridDiv = document.querySelector('#myGrid');
    let modalElement1 = document.getElementById('modalUsuario');
    let modal = new bootstrap.Modal(modalElement1);
    let modalElement2 = document.getElementById('successModal');
    let modalSuccess = new bootstrap.Modal(modalElement2);
    let modalElement3 = document.getElementById('confirmDeleteModal');
    let modalDelete = new bootstrap.Modal(modalElement3);

    // Desactivar el botón Guardar al inicio
    btnGuardar.disabled = false;
    btnActualizar.disabled = false;

    // Botón Nuevo: Abre el modal
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

        fetchListRoles()
            .then(data => {
                console.log("Datos recibidos:", data); // Depuración
                let select = document.getElementById("rolUsuario");
                select.innerHTML = '<option value=""></option>';
                data.forEach(rol => {
                    console.log("Procesando rol:", rol); // Verifica cada objeto de la lista

                    let option = document.createElement("option");
                    option.value = rol.IdRol;
                    option.textContent = rol.NameRol;
                    select.appendChild(option);
                });
            })

        fetchListTd()
            .then(d => {
                let select = document.getElementById("tipoDocumento");
                select.innerHTML = '<option value=""></option>';
                d.forEach(td => {
                    let option = document.createElement("option");
                    option.value = td.IdTipoDoc;
                    option.textContent = td.Nombre;
                    select.appendChild(option);
                });
            })

        modal.show();
    });

    closeModalBtn.addEventListener('click', function () {
        modal.hide();
    });

    // Control de navegación entre secciones en el modal
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

    // Botón Guardar
    btnGuardar.addEventListener('click', function () {
        const btTodos = document.getElementById("brTodos");
        const btActivos = document.getElementById("brActivos");
        const btNoActivos = document.getElementById("brNoActivos"); 
        const usuario = {
            Username: document.getElementById("username").value,
            /*Password: document.getElementById("password").value,*/
            Estado: document.getElementById("activo").value === "Si" ? "1" : "0",
            Email: document.getElementById("email").value,
            Sexo: document.getElementById("sexo").value,
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
        fetchSaveUser(usuario)
            .then(data => {
                modal.hide();
                modalSuccess.show();
                let filtro = btTodos.checked ? "todos" : btActivos.checked ? "activos" : btNoActivos.checked ? "no activos" : null;
                if (filtro) {
                    fetchUsers(filtro).then(data => {
                        gridOptions.api.setRowData(data);
                    });
                }
            })
    });

    btnActualizar.addEventListener('click', function () {
        const btTodos = document.getElementById("brTodos");
        const btActivos = document.getElementById("brActivos");
        const btNoActivos = document.getElementById("brNoActivos");
        const usuario = {
            IdPersona: document.getElementById('hiddenPersonId').value,
            IdUsuario: document.getElementById('hiddenUserId').value,
            Username: document.getElementById("username").value,
            Password: document.getElementById("password").value,
            Estado: document.getElementById("activo").value === "Si" ? "1" : "0",
            Email: document.getElementById("email").value,
            Sexo: document.getElementById("sexo").value,
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

        let filtro = btTodos.checked ? "todos" : btActivos.checked ? "activos" : btNoActivos.checked ? "no activos" : null;
        fetchUpdateUser(usuario)
            .then(data => {
                modalElement1.classList.remove("show");
                modalElement1.style.display = "none";
                document.body.classList.remove("modal-open");

                let backdrop = document.querySelector(".modal-backdrop");
                if (backdrop) {
                    backdrop.remove();
                }
                modalSuccess.show();
                if (filtro) {
                    fetchUsers(filtro).then(data => {
                        gridOptions.api.setRowData(data);
                    });
                }
            });

    });



    function validarCampos() {
        let camposVacios = [];

        const todosLlenos = [...inputsDatosPersonales, ...inputsDatosUsuario].every(input => {
            if (input.type !== "hidden" && input.value.trim() === "") {
                camposVacios.push(input.id); // Guardar los campos vacíos
                return false;
            }
            return true;
        });
        btnGuardar.disabled = !todosLlenos;
    }

    // Agregar evento a todos los inputs
    [...inputsDatosPersonales, ...inputsDatosUsuario].forEach(input => {
        input.addEventListener("input", validarCampos);
    });

});
