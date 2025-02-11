// api.js

// Función para obtener la lista de usuarios
export function fetchUsers(tipo) {
    return fetch(`/User/ListarUsuarios?tipo=${encodeURIComponent(tipo)}`, { method: 'GET' })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error en la petición: ${response.status} ${response.statusText}`);
            }
            return response.json();
        })
        .catch(error => {
            console.error('Error en fetchUser:', error);
            throw error;
        });
}

// Función para obtener los detalles de un usuario
export function fetchUserDetails(idUsuario) {
    return fetch('/User/findByDoc', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nroDoc: idUsuario })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error en la petición: ${response.status} ${response.statusText}`);
            }
            return response.json();
        })
        .catch(error => {
            console.error('Error en fetchUserDetails:', error);
            throw error;
        });
}

// Función para eliminar un usuario
export function fetchDeleteUser(id) {
    return fetch(`/User/Delete/${id}`, { method: 'DELETE' })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error en la petición: ${response.status} ${response.statusText}`);
            }
            return response.json();
        })
        .catch(error => {
            console.error('Error en fetchDeleteUser:', error);
            throw error;
        });
}

// Función para guardar un usuario
export function fetchSaveUser(usuario) {
    return fetch('/User/SaveUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(usuario)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error en la petición: ${response.status} ${response.statusText}`);
            }
            return response.json();
        })
        .catch(error => {
            console.error('Error en fetchSaveUser:', error);
            throw error;
        });
}

// Función para actualizar un usuario
export function fetchUpdateUser(usuario) {
    return fetch('/User/UpdateUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(usuario)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error en la petición: ${response.status} ${response.statusText}`);
            }
            return response.json();
        })
        .catch(error => {
            console.error('Error en fetchUpdateUser:', error);
            throw error;
        });
}


export function fetchListRoles() {
    return fetch('/User/GetRoles')
        .then(response => {
            console.log("Estado de la respuesta:", response.status);
            if (!response.ok) {
                throw new Error("Error al obtener los roles");
            }
            return response.json();
        })
        .catch(error => {
            console.error("Error:", error);
        });
}

//Función para listar TD, llenar lista desplegable
export function fetchListTd() {
    return fetch('/User/GetTipDoc')
        .then(response => {
            console.log("Estado de la respuesta:", response.status);
            if (!response.ok) {
                throw new Error("Error al obtener los tipos de documentos");
            }
            return response.json();
        })
        .catch(error => {
            console.error("Error:", error);
        });
}

