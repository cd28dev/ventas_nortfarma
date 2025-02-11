// grid.js
import { fetchUsers, fetchUserDetails, fetchDeleteUser, fetchSaveUser } from './apiUser.js';
import { showModal, showModalContact } from './modalUser.js';

// Definición de las columnas
export const column = [
    { headerName: "N° Doc", field: "NroDocumento", width:130 },
    { headerName: "Nombres", field: "Nombres", width: 150 },
    { headerName: "Apellidos", field: "Apellidos", width: 150 },
    { headerName: "Email", field: "Email", flex: 1 },
    { headerName: "Username", field: "Username", width: 150 },
    { headerName: "Rol", field: "Roles", valueGetter: (params) => params.data.Roles.length > 0 ? params.data.Roles[0].NameRol : "Sin rol", width: 150 },
    {
        headerName: "Activo",
        field: "Estado",
        width: 100,
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
            const btnEditar = createEditButton(params);
            const btnEliminar = createDeleteButton(params);
            const btnVer = createViewButton(params);
            container.appendChild(btnVer);
            container.appendChild(btnEditar);
            container.appendChild(btnEliminar);
            return container;
        }
    }
];

export const gridOptions = {
    columnDefs:column,
    rowData: null,
    domLayout: 'normal', // Ajusta la altura automáticamente
    pagination: true,
    paginationPageSize: 10,       // Número de filas por página
    paginationAutoPageSize: true, // Ajusta automáticamente la cantidad de filas por página
    defaultColDef: {
        filter: true,
        sortable: false,
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

export let grid = new agGrid.Grid(document.querySelector('#myGrid'), gridOptions);

export function createEditButton(params) {
    const btnEditar = document.createElement('button');
    btnEditar.classList.add('btn', 'btn-primary', 'btn-sm', 'rounded-circle', 'd-flex', 'justify-content-center', 'align-items-center', 'me-1');
    btnEditar.style.width = '30px';
    btnEditar.style.height = '30px';
    btnEditar.innerHTML = `<i class="fas fa-pen"></i>`;
    btnEditar.addEventListener('click', () => {
        editUser(params.data.NroDocumento);
    });
    return btnEditar;
}

function createDeleteButton(params) {
    const btnEliminar = document.createElement('button');
    btnEliminar.classList.add('btn', 'btn-danger', 'btn-sm', 'rounded-circle', 'd-flex', 'justify-content-center', 'align-items-center', 'me-1');
    btnEliminar.style.width = '30px';
    btnEliminar.style.height = '30px';
    btnEliminar.innerHTML = `<i class="fas fa-trash-alt"></i>`;

    if (params.data.Estado === 'No') {
        btnEliminar.disabled = true;
    } else {
        btnEliminar.addEventListener('click', () => {
            deleteUserAction(params.data.NroDocumento, btnEliminar);
        });
    }
    return btnEliminar;
}

function createViewButton(params) {
    const btnVer = document.createElement('button');
    btnVer.classList.add('btn', 'btn-info', 'btn-sm', 'rounded-circle', 'd-flex', 'justify-content-center', 'align-items-center', 'me-1');
    btnVer.style.width = '30px';
    btnVer.style.height = '30px';
    btnVer.innerHTML = `<i class="fas fa-eye"></i>`;

    btnVer.addEventListener('click', () => {
        viewUserDetails(params.data.NroDocumento);
    });

    return btnVer;
}

function editUser(id) {
    fetchUserDetails(String(id))
        .then(data => {
            showModal(data);
        });
}

function deleteUserAction(id, btnEliminar) {
    const btTodos = document.getElementById("brTodos");
    const btActivos = document.getElementById("brActivos"); 
    let deleteId = id;
    let confirmDeleteModal = new bootstrap.Modal(document.getElementById('confirmDeleteModal'));
    let btnConfirmDelete = document.getElementById("btnConfirmDelete");
    confirmDeleteModal.show();

    btnConfirmDelete.removeEventListener("click", handleDelete);

    function handleDelete() {
        if (deleteId === null) return;

        fetchDeleteUser(deleteId)
            .then(() => {
                confirmDeleteModal.hide();
                btnEliminar.disabled = true;
                let filtro = btTodos.checked ? "todos" : btActivos.checked ? "activos" : null;

                if (filtro) {
                    fetchUsers(filtro).then(data => {
                        gridOptions.api.setRowData(data);
                    });
                }
            })
            .catch(error => console.error("Error al eliminar usuario:", error));
    }


    btnConfirmDelete.addEventListener("click", handleDelete);
}

function viewUserDetails(id) {
    fetchUserDetails(String(id))
        .then(data => {
            showModalContact(data);
        });
    
}

document.addEventListener('DOMContentLoaded', function () {
    const btTodos = document.getElementById("brTodos");
    const btActivos = document.getElementById("brActivos");
    const btNoActivos = document.getElementById("brNoActivos");

    fetchUsers("todos").then(data => {
        console.log("Datos recibidos:", data);
        gridOptions.api.setRowData(data);
        btTodos.checked = true;
    });

    btTodos.addEventListener("change", function () {
        if (btTodos.checked) {
            fetchUsers("todos").then(data => {
                gridOptions.api.setRowData(data);
            });
        }
    });

    btActivos.addEventListener("change", function () {
        if (btActivos.checked) {
            fetchUsers("activos").then(data => {
                gridOptions.api.setRowData(data);
            });
        }
    });

    btNoActivos.addEventListener("change", function () {
        if (btNoActivos.checked) {
            fetchUsers("no activos").then(data => {
                gridOptions.api.setRowData(data);
            });
        }
    });
});

