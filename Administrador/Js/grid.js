// grid.js
import { fetchUsers, fetchUserDetails, fetchDeleteUser, fetchSaveUser } from './api.js';
import { showModal } from './modal.js';

// Definición de las columnas
export const column = [
    { headerName: "N° Doc", field: "NroDocumento", flex: 1 },
    { headerName: "Nombres", field: "Nombres", flex: 1 },
    { headerName: "Apellidos", field: "Apellidos", flex: 1 },
    { headerName: "Email", field: "Email", flex: 1 },
    { headerName: "Username", field: "Username", flex: 1 },
    { headerName: "Rol", field: "Roles", valueGetter: (params) => params.data.Roles.length > 0 ? params.data.Roles[0].NameRol : "Sin rol", flex: 1 },
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
            const btnEditar = createEditButton(params);
            const btnEliminar = createDeleteButton(params);
            container.appendChild(btnEditar);
            container.appendChild(btnEliminar);
            return container;
        }
    }
];

export const gridOptions = {
    columnDefs:column,
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

export let grid = new agGrid.Grid(document.querySelector('#myGrid'), gridOptions);

export function createEditButton(params) {
    const btnEditar = document.createElement('button');
    btnEditar.classList.add('btn', 'btn-primary', 'btn-sm', 'me-2');
    btnEditar.innerHTML = `<i class="fas fa-pen"></i>`;
    btnEditar.addEventListener('click', () => {
        editUser(params.data.NroDocumento);
    });
    return btnEditar;
}

function createDeleteButton(params) {
    const btnEliminar = document.createElement('button');
    btnEliminar.classList.add('btn', 'btn-danger', 'btn-sm');
    btnEliminar.innerHTML = `<i class="fas fa-trash-alt"></i>`;
    if (params.data.Estado === 'No') {
        btnEliminar.disabled = "true";
    } else {
        btnEliminar.addEventListener('click', () => {
            deleteUserAction(params.data.NroDocumento, btnEliminar);
        });
    }
    return btnEliminar;
}

function editUser(id) {
    fetchUserDetails(String(id))
        .then(data => {
            showModal(data);
        });
}

function deleteUserAction(id, btnEliminar) {
    let deleteId = id;
    let confirmDeleteModal = new bootstrap.Modal(document.getElementById('confirmDeleteModal'));
    let btnConfirmDelete = document.getElementById("btnConfirmDelete");
    confirmDeleteModal.show();

    btnConfirmDelete.removeEventListener("click", handleDelete);

    function handleDelete() {
        if (deleteId !== null) {
            fetchDeleteUser(deleteId)
                .then(data => {
                    confirmDeleteModal.hide();
                    fetchUsers()
                        .then(data => {
                            gridOptions.api.setRowData(data);
                            btnEliminar.disabled = true;
                        });
                });
        }
    }

    btnConfirmDelete.addEventListener("click", handleDelete);
}

document.addEventListener('DOMContentLoaded', function () {
    fetchUsers()
        .then(data => {
            gridOptions.api.setRowData(data);
        });
});
