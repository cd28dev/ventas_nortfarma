using System;
using System.Collections.Generic;

namespace Models
{
    public class Pedido
    {
        public string IdPedido { get; set; }
        public DateTime FechaRecojo { get; set; }
        public string DireccionEntrega { get; set; }
        public string Estado { get; set; }
        public CarritoCompra carrito { get; set; }

        public List<Venta> Ventas { get; set; }

        // Constructor con validación
        public Pedido(string idPedido, DateTime fechaRecojo, string direccionEntrega, string estado, CarritoCompra c)
        {

            IdPedido = idPedido;
            FechaRecojo = fechaRecojo;
            DireccionEntrega = direccionEntrega;
            Estado = estado;
            carrito = c;
        }

        public Pedido() { 
        
            this.Ventas = new List<Venta>();
        }
    }
}
