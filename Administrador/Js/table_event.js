const column = [
    { headerName: "N° Doc", field: "NroDocumento", flex: 1 },
    { headerName: "Nombres", field: "Nombres", flex: 1 },
    { headerName: "Apellidos", field: "Apellidos", flex: 1 },
    { headerName: "Email", field: "Email", flex: 1 },
    { headerName: "Username", field: "Username", flex: 1 },
    {
        headerName: "Activo",
        field: "Estado",
        flex: 1,
        cellRenderer: function (params) {
            if (params.value === "Si") {
                return `<span class="badge bg-success">Si</span>`;
            } else if (params.value === "No") {
                return `<span class="badge bg-danger">No</span>`;
            } else {
                return params.value;
            }
        }
    },
    {
        headerName: "Accion",
        field: "Accion",
        colId: "Accion",
        flex: 1,
        cellRenderer: function (params) {
            const container = document.createElement('div');
            container.classList.add('d-flex', 'align-items-center');

            const btnEditar = document.createElement('button');
            btnEditar.classList.add('btn', 'btn-primary', 'btn-sm', 'me-2');
            btnEditar.innerHTML = `<i class="fas fa-pen"></i>`;
            btnEditar.addEventListener('click', () => {
                editUser(params.data.NroDocumento); 
            });

            const btnEliminar = document.createElement('button');
            btnEliminar.classList.add('btn', 'btn-danger', 'btn-sm');
            btnEliminar.innerHTML = `<i class="fas fa-trash-alt"></i>`;
            console.log("Estado del usuario:", params.data.Estado);

            if (params.data.Estado === 'No') {
                btnEliminar.disabled = "true";
            } else {
                btnEliminar.addEventListener('click', () => {
                    deleteUser(params.data.NroDocumento);
                });
            }
            container.appendChild(btnEditar);
            container.appendChild(btnEliminar);

            return container;
        }
    }

];

const gridOptions = {
    columnDefs: column,
    rowData: null,
    pagination: true,
    defaultColDef: {
        filter: true,
        sortable: true,
    },
    onFirstDataRendered: function (params) {
        const allColumns = params.columnApi.getColumns();
        params.columnApi.autoSizeColumns(allColumns);
    },
    onGridSizeChanged: function (params) {
        const card = document.querySelector('.card');
        const cardWidth = card ? card.offsetWidth : window.innerWidth;

        params.api.sizeColumnsToFit(cardWidth);
    },
    getRowId: function (params) {
        return String(params.data.NroDocumento).trim();
    },
};

const gridDiv = document.querySelector('#myGrid');

document.addEventListener('DOMContentLoaded', function () {
    new agGrid.Grid(gridDiv, gridOptions);

    fetch('/User/ListarUsuarios', {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
            gridOptions.api.setRowData(data); 
        })
        .catch(error => console.error('Error al cargar los datos:', error));
});

function editUser(id) {
    const idUsuario = String(id);

    fetch('/User/findByDoc', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nroDoc: idUsuario })
    })  .then(response => response.json())
        .then(data => {
            showModal(data);
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Hubo un problema al procesar la solicitud.');
        })
        .finally(() => {
            //clearModal();
        });

}

function deleteUser(id) {
    let deleteId = id;
    let confirmDeleteModal = new bootstrap.Modal(document.getElementById('confirmDeleteModal'));
    let btnConfirmDelete = document.getElementById("btnConfirmDelete");

    cambiarMensajeModal(deleteId);
    confirmDeleteModal.show();

    btnConfirmDelete.removeEventListener("click", handleDelete);

    function handleDelete() {
        if (deleteId !== null) {
            fetch(`/User/Delete/${deleteId}`, { method: 'DELETE' })
                .then(response => response.json())
                .then(data => {
                    console.log("Usuario eliminado:", data);
                    confirmDeleteModal.hide();
                })
                .catch(error => console.error("Error al eliminar:", error));
        }
    }

    btnConfirmDelete.addEventListener("click", handleDelete);
}

function showModal(data) {
    let modalElement = document.getElementById('modalUsuario');
    let modal = new bootstrap.Modal(modalElement);

    showBtnUpdate(); // Asegurar que se muestra el botón correcto
    llenarFields(data);

    modal.show();
}
function cambiarMensajeModal(id) {
    let modalBody = document.querySelector('.modal-body');
    if (modalBody) {
        modalBody.innerHTML = `¿Estás seguro de que deseas eliminar al usuario con dni <strong>${id}</strong>?`;
    } else {
        console.error('No se encontró el elemento con la clase .modal-body');
    }
}


function llenarFields(data) {
    let fecha = new Date(parseInt(data.FechaNacimiento.replace(/\/Date\((.*?)\)\//, "$1")));
    let fechaFormateada = fecha.toISOString().split('T')[0];

    document.getElementById('tipoDocumento').value = data.TipoDoc.Nombre;
    document.getElementById('nmroDocumento').value = data.NroDocumento;
    document.getElementById('nombreUsuario').value = data.Nombres;
    document.getElementById('apellidoUsuario').value = data.Apellidos;
    document.getElementById('lNacimiento').value = data.LugarNacimiento;
    document.getElementById('fNacimiento').value = fechaFormateada
    document.getElementById('direccion').value = data.Direccion;
    document.getElementById('rolUsuario').value = data.Roles[0].NameRol;
    document.getElementById('email').value = data.Email;
    document.getElementById('username').value = data.Username;
    document.getElementById('password').value = data.Password;
    document.getElementById('activo').value = data.Estado;
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