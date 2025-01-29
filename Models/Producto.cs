using System;
using System.Collections.Generic;

namespace Models
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioLista { get; set; }
        public string Descripcion { get; set; }
        public CategoriaProducto cat { get; set; }

        public List<DetalleDeVenta> detVentas { get; set; }

        public List<Item> items { get; set; }

        // Constructor con validación
        public Producto(string idProducto, string nombreProducto, double precioLista, string descripcion, CategoriaProducto c)
        {

            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            PrecioLista = precioLista;
            Descripcion = descripcion;
            cat = c;
        }


        public Producto() { 
            detVentas = new List<DetalleDeVenta>();
            items = new List<Item>();
        }
    }
}
