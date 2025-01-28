using System;

namespace Models
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioLista { get; set; }
        public string Descripcion { get; set; }
        public string IdCategoria { get; set; }

        // Constructor con validación
        public Producto(string idProducto, string nombreProducto, double precioLista, string descripcion, string idCategoria)
        {
            if (string.IsNullOrWhiteSpace(idProducto)) throw new ArgumentException("El ID del producto no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreProducto)) throw new ArgumentException("El nombre del producto no puede estar vacío.");
            if (precioLista < 0) throw new ArgumentException("El precio no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(descripcion)) throw new ArgumentException("La descripción no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(idCategoria)) throw new ArgumentException("La categoría no puede estar vacía.");

            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            PrecioLista = precioLista;
            Descripcion = descripcion;
            IdCategoria = idCategoria;
        }
    }
}
