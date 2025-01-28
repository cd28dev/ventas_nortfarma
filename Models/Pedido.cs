using System;

namespace Models
{
    public class Pedido
    {
        public string IdPedido { get; set; }
        public DateTime FechaRecojo { get; set; }
        public string DireccionEntrega { get; set; }
        public string Estado { get; set; }
        public string IdCarritoCompra { get; set; }

        // Constructor con validación
        public Pedido(string idPedido, DateTime fechaRecojo, string direccionEntrega, string estado, string idCarritoCompra)
        {
            if (string.IsNullOrWhiteSpace(idPedido))
                throw new ArgumentException("El ID del pedido no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(direccionEntrega))
                throw new ArgumentException("La dirección de entrega no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idCarritoCompra))
                throw new ArgumentException("El ID del carrito de compra no puede estar vacío.");

            IdPedido = idPedido;
            FechaRecojo = fechaRecojo;
            DireccionEntrega = direccionEntrega;
            Estado = estado;
            IdCarritoCompra = idCarritoCompra;
        }
    }
}
