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
            const idUsuario = String(params.data.NroDocumento);
            return `
                <button class="btn btn-primary btn-sm me-2" onclick="editUser(${idUsuario})">
                <i class="fas fa-pen"></i>
                </button>
                <button class="btn btn-danger btn-sm" onclick="deleteUser(${params.data.IdUsuario})">
                <i class="fas fa-trash-alt"></i>
                </button>
            `;
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

// Función para editar el usuario
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


function showModal(data) {
    let modalElement = document.getElementById('modalUsuario'); 
    let modal = new bootstrap.Modal(modalElement);

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

    modal.show();
}


function deleteUser(id) {
    const confirmacion = confirm(`¿Estás seguro de eliminar al usuario con ID: ${id}?`);
    if (confirmacion) {
        alert(`Usuario con ID ${id} eliminado.`);
        // Aquí realiza una solicitud a tu API para eliminar el usuario
    }
}
