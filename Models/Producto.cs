using System;
using System.Collections.Generic;

namespace Models
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioLista { get; set; }
        
        public bool Estado {  get; set; }

        public CategoriaProducto cat { get; set; }

        public Marca marca { get; set; }

        public List<DetalleDeVenta> detVentas { get; set; }

        public List<Item> items { get; set; }

        // Constructor con validación
        public Producto(bool estado, string idProducto, string nombreProducto, double precioLista, CategoriaProducto c, Marca marca)
        {

            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            PrecioLista = precioLista;
            cat = c;
            this.marca = marca;
            this.Estado = estado;
        }


        public Producto() { 
            detVentas = new List<DetalleDeVenta>();
            items = new List<Item>();
        }
    }
}
