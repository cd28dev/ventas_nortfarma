using System.Collections.Generic;

namespace Models
{
    public class CategoriaProducto
    {
        // Propiedades automáticas
        public string IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public List<Producto> Productos { get; set; }

        // Constructor vacío
        public CategoriaProducto() { 
            Productos = new List<Producto>();
            
        }

        // Constructor lleno
        public CategoriaProducto(string idCategoria, string descripcion, string estado)
        {
            IdCategoria = idCategoria;
            Descripcion = descripcion;
            Estado = estado;
        }
    }
}
