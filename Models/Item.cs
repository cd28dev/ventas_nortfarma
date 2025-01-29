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
        public CarritoCompra carrito { get; set; }
        public Producto product { get; set; }

        // Constructor con validación
        public Item(string idItem, string nombreProduct, int cantidad, double subTotal, string estado, CarritoCompra car, Producto p)
        {
            IdItem = idItem;
            NombreProduct = nombreProduct;
            Cantidad = cantidad;
            SubTotal = subTotal;
            Estado = estado;
            carrito = car;
            product = p;
        }
    }
}
