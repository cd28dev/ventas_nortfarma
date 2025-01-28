using System;

namespace Models
{
    public class Item
    {
        public string IdItem { get; set; }
        public string NombreProduct { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public string Estado { get; set; }
        public string IdCarrito { get; set; }
        public string IdProducto { get; set; }

        // Constructor con validación
        public Item(string idItem, string nombreProduct, int cantidad, double subTotal, string estado, string idCarrito, string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idItem))
                throw new ArgumentException("El ID del artículo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreProduct))
                throw new ArgumentException("El nombre del producto no puede estar vacío.");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (subTotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idCarrito))
                throw new ArgumentException("El ID del carrito no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idProducto))
                throw new ArgumentException("El ID del producto no puede estar vacío.");

            IdItem = idItem;
            NombreProduct = nombreProduct;
            Cantidad = cantidad;
            SubTotal = subTotal;
            Estado = estado;
            IdCarrito = idCarrito;
            IdProducto = idProducto;
        }
    }
}
