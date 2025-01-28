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
        console.log("Datos cargados en la grid"); // Esto indica que los datos están listos
        const allColumns = params.columnApi.getColumns();
        params.columnApi.autoSizeColumns(allColumns);
    },
    onGridSizeChanged: function (params) {
        const card = document.querySelector('.card');
        const cardWidth = card ? card.offsetWidth : window.innerWidth;

        params.api.sizeColumnsToFit(cardWidth);
    },
    getRowId: function (params) {
        console.log("id:", params.data.NroDocumento, typeof params.data.NroDocumento);
        return String(params.data.NroDocumento).trim(); // Asegura que el id tenga 4 dígitos
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
    //console.log("id:", idUsuario, typeof idUsuario);
    //let rowNode = gridOptions.api.getRowNode(String(idUsuario));
    //if (rowNode) {
    //    let fila = rowNode.data;

    //    let modal = new bootstrap.Modal(document.getElementById('modalUsuario'));
    //    modal.show();

    //} else {

    //}
    fetch('/User/findByDoc', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ nroDoc: id })
    })  .then(response => response.json())
        .then(data => {
            showModal(data)
        })
        .catch(error => {
            console.error('Error:', error); // Manejar cualquier error
            alert('Hubo un problema al procesar la solicitud.');
        });

}


function deleteUser(id) {
    const confirmacion = confirm(`¿Estás seguro de eliminar al usuario con ID: ${id}?`);
    if (confirmacion) {
        alert(`Usuario con ID ${id} eliminado.`);
        // Aquí realiza una solicitud a tu API para eliminar el usuario
    }
}

function showModal(data) {
    let modal = new bootstrap.Modal(document.getElementById('modalUsuario'));
    //modal.getElementById('tipoDocumento') = data.
    modal.getElementById('nmroDocumento') = data.NroDocumento
    modal.getElementById('nombreUsuario') = data.Nombres
    modal.getElementById('apellidoUsuario') = data.Apellidos
    modal.getElementById('lNacimiento') = data.LugarNacimiento
    modal.getElementById('fNacimiento') = data.FechaNacimiento
    modal.getElementById('Direccion') = data.Direccion
    modal.getElementById('rolUsuario') = data.rol.nombreRol
    modal.getElementById('email') = data.Email
    modal.getElementById('username') = data.Username
    modal.getElementById('password') = data.Password
    modal.getElementById('activo') = data.Estado
    modal.show();
}
