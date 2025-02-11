using System.Collections.Generic;

namespace Models
{
    public class CategoriaProducto
    {
        // Propiedades automáticas
        public string IdCategoria { get; set; }
        public string nameCategory { get; set; }
        public bool Estado { get; set; }

        public List<Producto> Productos { get; set; }

        // Constructor vacío
        public CategoriaProducto() { 
            Productos = new List<Producto>();
            
        }

        // Constructor lleno
        public CategoriaProducto(string idCategoria, string name, bool estado)
        {
            IdCategoria = idCategoria;
            nameCategory = name;
            Estado = estado;
        }
    }
}
