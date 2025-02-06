// api.js

// Función para obtener la lista de usuarios
export function fetchUsers() {
    return fetch('/User/ListarUsuarios', { method: 'GET' })
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
            console.error('Error en fetchSaveUser:', error);
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
            console.error('Error en fetchSaveUser:', error);
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
